using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private int speed=100;
    [SerializeField] private int rotate;
    [SerializeField] private float forceX, forceY, forceZ;

    #region RigidBodies
    [SerializeField] private Rigidbody rb0;
    [SerializeField] private Rigidbody rb1;
    [SerializeField] private Rigidbody rb2;
    [SerializeField] private Rigidbody rb3;
    [SerializeField] private Rigidbody rb4;
    [SerializeField] private Rigidbody rb5;
    [SerializeField] private Rigidbody rb6;
    [SerializeField] private Rigidbody rb7;
    [SerializeField] private Rigidbody rb8;
    [SerializeField] private Rigidbody rb9;
    [SerializeField] private Rigidbody rb10;
    #endregion

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotate * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        #region AddForce
        if (collision.gameObject.tag == "Player")
        {

            rb0.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI1")
        {

            rb1.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI2")
        {

            rb2.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI3")
        {

            rb3.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI4")
        {

            rb4.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI5")
        {

            rb5.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI6")
        {

            rb6.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI7")
        {

            rb7.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI8")
        {

            rb8.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI9")
        {

            rb9.AddForce(forceX, forceY, forceZ);

        }

        if (collision.gameObject.tag == "AI10")
        {

            rb10.AddForce(forceX, forceY, forceZ);

        }
        #endregion

    }

}
