using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Char;
    public float x, y;
    void Start()
    {
        Char = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        transform.position = new Vector3(Char.position.x+x, ((Char.position.y)/2)+y, -10);
    }
}
