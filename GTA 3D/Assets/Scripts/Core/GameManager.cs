using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MapPointManager _mapPointManager;

    public MapPointManager MapManager => _mapPointManager;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        _mapPointManager = FindObjectOfType<MapPointManager>();
    }
}