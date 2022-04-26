using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float lerpValue;

    private void LateUpdate()
    {
        Vector3 desPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
    }
}
