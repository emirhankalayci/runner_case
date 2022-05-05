using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.1f;
    [SerializeField] private float maxSwerveAmount = 1f;    
    [SerializeField] GameObject[] wallPrefabs;  
    [SerializeField] GameObject completePanel;
    [SerializeField] GameObject confetti;
    [SerializeField] Material[] wallMat;
    [SerializeField] Material RedMat;
    PlayerController playerController;

    private float score = 0;
    public int minScore = 0;
    public int maxScore = 100;
    public bool controlScore;
    public bool isPanel;
    AI ai;
        
    private void Awake()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
        playerController = FindObjectOfType<PlayerController>();
        ai = FindObjectOfType<AI>();
        
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

        if (playerController.IsFinish == true && ai.aiFinish == false)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.movefactorx;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

            StartCoroutine(timeDelay());                  
        }

        if (wallPrefabs[9].gameObject.tag == "Paint")
        {
            isPanel = true;
            completePanel.SetActive(true);
            confetti.SetActive(true);

        }
   
    }

    IEnumerator timeDelay()
    {
        int i = 0;

        for (i = 0; i < wallPrefabs.Length; i++)
        {          
            if (Input.GetMouseButton(0))
            {                                
                wallPrefabs[i].GetComponent<MeshRenderer>().material = wallMat[1];
                wallPrefabs[i].gameObject.tag = "Paint";
                controlScore = true;
                yield return new WaitForSeconds(0.2f);
                Debug.Log(i);
            }
            controlScore = false;
        }      
    }

    IEnumerator scoreDelay() //gerçek zamanlý olarak boyama skorunu yazmayý denedim ancak update fonksiyonunda yazdýðým için bug'larla karþýlaþtým bu yüzden kaldýrmayý tercih ettim.
    {       
        if (controlScore == true)
        {
            score += 10;
            yield return new WaitForSeconds(1f);
            score = Mathf.Clamp(score, minScore, maxScore);
        }
    }

   
}
