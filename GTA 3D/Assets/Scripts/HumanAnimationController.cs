using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

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

    public void SetSpeed(float speed, float motionSpeed)
    {
        _animator.SetFloat(_speedID, speed);
        _animator.SetFloat(_motionSpeedID, motionSpeed);
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