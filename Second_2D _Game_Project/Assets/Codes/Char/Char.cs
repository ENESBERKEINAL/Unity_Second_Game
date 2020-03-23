using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public float Speed,JumpPower=350,MaxSpeed = 5;
    public bool Yerdemi,SecondJump;
    Rigidbody2D agirlik;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        agirlik = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Yerdemi)
            {
                agirlik.AddForce(Vector2.up * JumpPower);
                SecondJump = true;
            }
            else
            {
                if (SecondJump)
                {
                    SecondJump = false;
                    agirlik.AddForce(Vector2.up * JumpPower/2);
                }
            }
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        agirlik.AddForce(Vector2.right * h * Speed);
        anim.SetFloat("Speed", Mathf.Abs(h));
        anim.SetBool ("Yerde",Yerdemi);


        if(h> 0.1f)             //Char is going riht
        {
            transform.localScale = new Vector2(-1,1);
        }
        if (h < -0.1f)           //Char is going left
         {
            transform.localScale = new Vector2(1, 1);        //Change only x then multiple -1
        }


        if (agirlik.velocity.x > MaxSpeed)                      //Trying to nonslide char
        {
            agirlik.velocity = new Vector2(MaxSpeed, agirlik.velocity.y); 
        }
        if (agirlik.velocity.x < -MaxSpeed)
        {
            agirlik.velocity = new Vector2(-MaxSpeed, agirlik.velocity.y);
        }
    }
}
