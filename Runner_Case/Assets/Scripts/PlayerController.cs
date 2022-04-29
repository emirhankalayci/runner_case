using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float xRange = 0.75f;
    
    Animator animator;
    public bool IsStart = false;
    public bool IsFinish = false;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject finishFlag;
    [SerializeField] GameObject perText;
    public GameObject finishText;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsIdle", true);
        
    }


    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(0) && IsFinish == false )
        {
            startText.SetActive(false);
            IsStart = true;
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRun", true);

        }

        if (IsStart == true && IsFinish == false)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Finish")
        {
            StartCoroutine(delayStop());
            perText.SetActive(true);
            finishText.SetActive(true);       
        }

        if (other.gameObject.tag == "FinishFlag")
        {
            Destroy(other.gameObject);
            finishFlag.SetActive(true);  
        }      

    }
    IEnumerator delayStop()
    {
        yield return new WaitForSeconds(1f);
        IsFinish = true;
        
        animator.SetBool("IsRun", false);
        animator.SetBool("IsIdle", true);
        
    }
}
