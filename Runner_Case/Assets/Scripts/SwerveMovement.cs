using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    [SerializeField] private float swerveSpeed =0.1f;
    [SerializeField] private float maxSwerveAmount = 1f;
    PlayerController playerController;

    private void Awake()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerController.IsFinish == false)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.movefactorx;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }
        
    }
}
