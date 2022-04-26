using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float xRange = 0.75f;
    [SerializeField] private Rigidbody rb;
    Animator animator;
    public bool IsStart = false;
    [SerializeField] GameObject startText;
    [SerializeField] private float itmeGucu = 0.5f;


    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsIdle", true);
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startText.SetActive(false);
            IsStart = true;
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRun", true);
        }

        if (IsStart == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }



        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        
           
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RotateStick")
        {
            
            rb.AddForce(Vector3.right * itmeGucu);

        }
    }
}
