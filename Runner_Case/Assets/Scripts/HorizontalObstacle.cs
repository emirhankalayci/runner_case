using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float newPosZ;
    [SerializeField] private float newPosX;
    [SerializeField] private float startPos;


    private Vector3 pos1 = new Vector3(0f, 0.26f, 0f);
    private Vector3 pos2 = new Vector3(0f, 0.26f, 0f);


    private void Start()
    {
        pos1.z = newPosZ;
        pos2.z = newPosZ;
        pos1.x = startPos + newPosX;
        pos2.x = startPos -newPosX;        
        
    }


    void Update()
    {

        gameObject.transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

    }
}
