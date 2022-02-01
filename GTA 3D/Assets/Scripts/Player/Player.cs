using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Player : Human
{
    [SerializeField] private HumanAnimationController _animationController;
    [SerializeField] private ThirdPersonController _controller;
    [SerializeField] private StarterAssetsInputs _input;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }
}