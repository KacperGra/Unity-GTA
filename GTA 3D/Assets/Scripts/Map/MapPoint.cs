using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    [SerializeField] private Transform[] _avilablePointArray;

    public Transform GetNextPoint => _avilablePointArray[Random.Range(0, _avilablePointArray.Length)];
}