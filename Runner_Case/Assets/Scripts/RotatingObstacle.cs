using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float rotate;
    [SerializeField] private float speed;
    void Update()
    {
        transform.Rotate(0, 0, rotate * speed * Time.deltaTime);
    }
}
