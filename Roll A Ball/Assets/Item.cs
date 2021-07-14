using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float Spinspeed;
    
    // Update is called once per frame

    void Awake()
    {
    }
    void Update()
    {
        transform.Rotate(Vector3.up*Spinspeed*Time.deltaTime,Space.World);
    }

    
}
