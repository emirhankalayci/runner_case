using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private int speed=100;
    [SerializeField] private int rotate;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forceX, forceY, forceZ;


    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Rotate(0, 0, rotate * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            rb.AddForce(forceX, forceY, forceZ);

        }
    }

}
