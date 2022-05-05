using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float lerpValue;
    PlayerController playerController;
    Camera cam;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (playerController.IsFinish == true)
        {                   
            Vector3 rot = new Vector3(2.508f, 41.356f, -0.061f);
            Vector3 pos = new Vector3(-1.7477f, 0.73409f, 30.6984f);
            cam.transform.position = Vector3.Lerp(transform.position, pos,lerpValue);
            cam.transform.rotation = Quaternion.Euler(rot);
        }

        if (playerController.IsFinish == false)
        {
            Vector3 desPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
        }
      
    }
}
