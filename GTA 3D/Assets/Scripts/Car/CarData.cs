using System.Collections;
using UnityEngine;

[System.Serializable]
public class CarData
{
    [SerializeField] private float _motorTorque = 600f;
    [SerializeField] private float _steering = 20f;
    [SerializeField] private float _brakeTorque = 600f;

    public float MotorTorque => _motorTorque;
    public float Steering => _steering;
    public float BrakeTorque => _brakeTorque;
}