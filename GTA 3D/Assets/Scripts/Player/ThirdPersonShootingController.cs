using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonShootingController : MonoBehaviour
{
    [Title("Settings")]
    [SerializeField] private LayerMask _aimColliderMask;
    [SerializeField] private float _aimingSpeed = 2.5f;

    [Title("References")]
    [SerializeField] private Cinemachine.CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private StarterAssets.StarterAssetsInputs _starterAssetsInputs;
    [SerializeField] private StarterAssets.ThirdPersonController _thirdPersonController;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _debugTransform;
    [SerializeField] private GameObject _bulletNPCHitEffect;
    [SerializeField] private GameObject _bulletObjectHitEffect;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = _mainCamera.ScreenPointToRay(screenCenterPoint);

        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderMask))
        {
            _debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        HandleAiming(mouseWorldPosition);
        if (Input.GetMouseButtonDown(0) && hitTransform != null)
        {
            Shoot(hitTransform, raycastHit.point);
        }
    }

    private void HandleAiming(Vector3 mouseWorldPosition)
    {
        _aimVirtualCamera.gameObject.SetActive(_starterAssetsInputs.aim);
        _thirdPersonController.SetRotateOnMove(_starterAssetsInputs.aim);

        if (_starterAssetsInputs.aim)
        {
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;

            var currentWeight = _animator.GetLayerWeight(1);
            _animator.SetLayerWeight(1, Mathf.MoveTowards(currentWeight, 1f, Time.deltaTime * _aimingSpeed));

            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            var currentWeight = _animator.GetLayerWeight(1);
            _animator.SetLayerWeight(1, Mathf.MoveTowards(currentWeight, 0f, Time.deltaTime * _aimingSpeed));
        }
    }

    private void Shoot(Transform hitTransform, Vector3 hitPosition)
    {
        var bulletTarget = hitTransform.GetComponent<NPC>();
        if (bulletTarget != null)
        {
            var bullet = Instantiate(_bulletNPCHitEffect, hitPosition, Quaternion.identity);
            Destroy(bullet, 1);

            bulletTarget.TakeDamage(new HitInfo(1));
        }
        else
        {
            var bullet = Instantiate(_bulletObjectHitEffect, hitPosition, Quaternion.identity);
            Destroy(bullet, 1);
        }
    }
}