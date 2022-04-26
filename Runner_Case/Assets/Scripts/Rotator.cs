using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private int speed=100;
    [SerializeField] private int rotate;
    
    

    // Update is called once per frame

   


    void Update()
    {
        transform.Rotate(0, 0, rotate * speed * Time.deltaTime);

    } 

    
}
