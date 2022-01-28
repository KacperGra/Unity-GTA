using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HumanAnimationController : MonoBehaviour
{
    private const float AnimationChangeSpeed = 5f;

    [SerializeField] private Animator _animator;

    private float _targetSpeed;
    private float _targetMotionSpeed;

    private int _speedID;
    private int _motionSpeedID;
    private int _jumpID;
    private int _groundedID;

    private void Awake()
    {
        _speedID = Animator.StringToHash("Speed");
        _motionSpeedID = Animator.StringToHash("MotionSpeed");
        _jumpID = Animator.StringToHash("Jump");
        _groundedID = Animator.StringToHash("Grounded");
    }

    private void Update()
    {
        if (_targetSpeed != _animator.GetFloat(_speedID))
        {
            _animator.SetFloat(_speedID, Mathf.Lerp(_animator.GetFloat(_speedID), _targetSpeed, Time.deltaTime * AnimationChangeSpeed));
        }
        if (_targetMotionSpeed != _animator.GetFloat(_motionSpeedID))
        {
            _animator.SetFloat(_motionSpeedID, Mathf.Lerp(_animator.GetFloat(_motionSpeedID), _targetMotionSpeed, Time.deltaTime * AnimationChangeSpeed));
        }
    }

    public void SetSpeed(float speed, float motionSpeed)
    {
        //_animator.SetFloat(_speedID, speed);
        //_animator.SetFloat(_motionSpeedID, motionSpeed);

        _targetSpeed = speed;
        _targetMotionSpeed = motionSpeed;
    }

    public void SetJump(bool jump)
    {
        _animator.SetBool(_jumpID, jump);
    }

    public void SetGrounded(bool grounded)
    {
        _animator.SetBool(_groundedID, grounded);
    }
}