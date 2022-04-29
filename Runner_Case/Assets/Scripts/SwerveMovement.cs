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
    private int score = 0;

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

        if (playerController.IsFinish == true)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.movefactorx;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

            StartCoroutine(timeDelay());
            
        }

    }

    IEnumerator timeDelay()
    {
        for (int i = 0; i < wallPrefabs.Length; i++)
        {
            
            if (Input.GetMouseButton(0))
            {                
                wallPrefabs[i].GetComponent<MeshRenderer>().material = RedMat;
                playerController.finishText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
                score = score + 10;
                yield return new WaitForSeconds(1);
                
            }           
        }       
    }
}
