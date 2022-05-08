using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] Transform[] waypoints1;
    [SerializeField] GameObject finishFlag;
    [SerializeField] GameObject failPanel;
    [SerializeField] float speed = 1;
    [SerializeField] float distanceThreshold;   
    PlayerController playerController;
    Animator anim;

    public bool aiFinish;
    Vector3 targetPoint;
    int j = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsIdle", true);
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {      
        int randomIndex = Random.Range(0, waypoints1.Length);
        targetPoint = waypoints1[randomIndex].position;       
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPoint) < distanceThreshold && aiFinish != true && playerController.IsFinish != true)
        {
            changeTarget();         
        }

        if (playerController.IsStart == true && aiFinish != true && playerController.IsFinish != true)
        {
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsRun", true);
            MoveMe();
        }
    }

    void MoveMe()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);       
    }

    void changeTarget()
    {

        if (waypoints[j].transform.childCount == 1)
        {
            if (j != 15)
            {
                targetPoint = waypoints[j].transform.GetChild(0).transform.position;
                j++;
            }
        }
        else if (waypoints[j].transform.childCount == 2)
        {
            if (j != 15)
            {
                targetPoint = waypoints[j].transform.GetChild(Random.Range(0, 1)).transform.position;
                j++;
            }

            
        }
        else if (waypoints[j].transform.childCount == 3)
        {
            if (j != 26)
            {
                targetPoint = waypoints[j].transform.GetChild(Random.Range(0, 2)).transform.position;
                j++;
            }           
        }
        else if (waypoints[j].transform.childCount == 4)
        {
            if (j != 26)
            {
                targetPoint = waypoints[j].transform.GetChild(Random.Range(0, 3)).transform.position;
                j++;
            }
        }
        else if (waypoints[j].transform.childCount == 5)
        {
            if (j != 26)
            {
                targetPoint = waypoints[j].transform.GetChild(Random.Range(0, 4)).transform.position;
                j++;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Obstacle")
        {
            transform.position = playerController.RespawnPoint.transform.position;
            transform.rotation = playerController.RespawnPoint.rotation;
            int randomIndex = Random.Range(0, waypoints1.Length);
            targetPoint = waypoints1[randomIndex].position;
            j= 1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishFlag")
        {
            Destroy(other.gameObject);
            finishFlag.SetActive(true);           
        }

        if (other.gameObject.tag == "Finish" && playerController.IsFinish != true)
        {
            failPanel.SetActive(true);
            StartCoroutine(delayStop());
            aiFinish = true;
            Time.timeScale = 0;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public IEnumerator delayStop()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsRun", false);
        anim.SetBool("IsIdle", true);
    }
}
