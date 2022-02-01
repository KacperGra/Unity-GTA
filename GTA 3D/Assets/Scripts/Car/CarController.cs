using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : InteractionObject
{
    [Title("Refernces")]
    [SerializeField] private GameObject _carCamera;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CarData _data;

    [Title("Wheels")]
    [SerializeField] private WheelCollider _leftBackWheel;
    [SerializeField] private WheelCollider _rightBackWheel;
    [SerializeField] private WheelCollider _rightFrontWheel;
    [SerializeField] private WheelCollider _leftFrontWheel;

    private bool _selected;

    private void Start()
    {
        _selected = false;
    }

    private void Update()
    {
        if (!_selected)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        if (!_selected)
        {
            return;
        }

        float motorTorque = _data.MotorTorque;
        float steering = _data.Steering;
        float braking = _data.BrakeTorque;

        if (Input.GetKey(KeyCode.W))
        {
            _leftBackWheel.motorTorque = motorTorque;
            _rightBackWheel.motorTorque = motorTorque;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _leftBackWheel.motorTorque = -motorTorque;
            _rightBackWheel.motorTorque = -motorTorque;
        }
        else
        {
            _leftBackWheel.motorTorque = 0;
            _rightBackWheel.motorTorque = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rightFrontWheel.steerAngle = -steering;
            _leftFrontWheel.steerAngle = -steering;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rightFrontWheel.steerAngle = steering;
            _leftFrontWheel.steerAngle = steering;
        }
        else
        {
            _rightFrontWheel.steerAngle = 0;
            _leftFrontWheel.steerAngle = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _leftBackWheel.brakeTorque = braking;
            _rightBackWheel.brakeTorque = braking;
        }
        else
        {
            _leftBackWheel.brakeTorque = 0;
            _rightBackWheel.brakeTorque = 0;
        }
    }

    public override void Interaction()
    {
        base.Interaction();
        Debug.Log("Interaction with Car!");
        _selected = true;
        _carCamera.SetActive(true);
    }
}