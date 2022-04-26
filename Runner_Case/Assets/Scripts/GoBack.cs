using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPoint;  
    
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag =="Player")
        {
            Player.transform.position = RespawnPoint.transform.position;
            Player.transform.rotation = RespawnPoint.rotation;
        }

        if (other.gameObject.tag == "Opponents")
        {

        }
    }

    


}
