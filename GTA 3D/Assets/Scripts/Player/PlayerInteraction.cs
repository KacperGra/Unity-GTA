using System;
using System.Collections;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionRange = 5f;
    [SerializeField] private LayerMask _interactionMask;

    private Camera _mainCamera;
    private IInteractable _selected;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = _mainCamera.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, _interactionRange, _interactionMask))
        {
            var interactable = raycastHit.collider.GetComponent<IInteractable>();
            if (interactable != null && interactable != _selected)
            {
                interactable.StartHover();
                _selected = interactable;
            }
            else
            {
                if (interactable != null)
                {
                    interactable.EndHover();
                }

                _selected = null;
            }
        }

        if (_selected != null && Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        _selected.Interaction();
    }
}