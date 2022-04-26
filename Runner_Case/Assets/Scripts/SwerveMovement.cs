using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    [SerializeField] private float swerveSpeed =0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    private void Awake()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.movefactorx;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
    }
}
