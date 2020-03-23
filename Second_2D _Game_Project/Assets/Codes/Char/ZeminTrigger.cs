using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminTrigger : MonoBehaviour
{
    Char ch;
    // Start is called before the first frame update
    void Start()
    {
        ch = transform.root.gameObject.GetComponent<Char>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {
        ch.Yerdemi = true;
    }

   void OnTriggerStay2D()
    {
        ch.Yerdemi = true;
    }
    void OnTriggerExit2D()
    {
        ch.Yerdemi = false;
    }
}
