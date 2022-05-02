using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.1f;
    [SerializeField] private float maxSwerveAmount = 1f;
    PlayerController playerController;
    [SerializeField] Material RedMat;
    [SerializeField] GameObject[] wallPrefabs;
    private float score = 0;
    public int minScore = 0;
    public int maxScore = 100;
    [SerializeField] Material[] wallMat;
    public bool controlScore;

    private void Awake()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
        playerController = FindObjectOfType<PlayerController>();
        
    }

    private void Update()
    {


        playerController.finishText.GetComponent<Text>().text=score.ToString("0");

        if (playerController.IsFinish == false)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.movefactorx;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }

        if (playerController.IsFinish == true)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.movefactorx;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

            StartCoroutine(timeDelay());
            //StartCoroutine(scoreDelay());
            
        }
        
    }

    IEnumerator timeDelay()
    {
        for (int i = 0; i < wallPrefabs.Length; i++)
        {
            
            if (Input.GetMouseButton(0))
            {                
                //wallPrefabs[i].GetComponent<MeshRenderer>().material = RedMat;
                wallPrefabs[i].GetComponent<MeshRenderer>().material = wallMat[1];
                controlScore = true;
                yield return new WaitForSeconds(0.2f);                
            }
            controlScore = false;
        }       
    }

    IEnumerator scoreDelay()
    {
       
        if (controlScore == true)
        {
            score += 10;
            yield return new WaitForSeconds(1f);
            score = Mathf.Clamp(score, minScore, maxScore);


        }
    }

   
}
