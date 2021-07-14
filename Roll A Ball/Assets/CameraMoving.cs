using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    Transform playertransform;
    Vector3 Offset;
    void Awake()
    {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playertransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playertransform.position + Offset;
    }
}
