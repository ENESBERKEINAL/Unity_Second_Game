﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char : MonoBehaviour
{
    public float Speed,JumpPower=350,MaxSpeed = 5;
    public bool Yerdemi,SecondJump;
    Rigidbody2D agirlik;
    Animator anim;
    public int Heal, MaxHeal,Paper;
    public Text PaperCounter;
    public AudioClip[] Sesler;
    
    public GameObject[] Heals;
    void Start()
    {
        anim = GetComponent<Animator>();
        agirlik = GetComponent<Rigidbody2D>();
        Heal = 3;
        CanSistemi();
    }

    void Update()
    {
        PaperCounter.text = "" + Paper;
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
        if(Heal <= 0)
        {
            dead();
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        /*
        if (h < 0)
        {
            transform.Translate(-h * Speed * Time.deltaTime);
        }
        if (h > 0)                                                              //COde Blocks of non slide Ground
        {
            transform.Translate(h * Speed * Time.deltaTime);
        }
        */
        float h = Input.GetAxis("Horizontal");
        agirlik.AddForce(Vector2.right * h * Speed);
        anim.SetFloat("Speed", Mathf.Abs(h));
        anim.SetBool ("Yerde",Yerdemi);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
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

    [System.Obsolete]
    void dead()
    { 
        Application.LoadLevel(Application.loadedLevel);
    }

    private void OnCollisionEnter2D(Collision2D nesne)
    {
        if (nesne.gameObject.tag == "Trap") 
        {
            Heal -= 1;
            agirlik.AddForce(Vector2.up * JumpPower);
            CanSistemi();
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Duzelt",0.5f); 
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Paper")
        {
            Paper++;
            GetComponent<AudioSource>().PlayOneShot(Sesler[0]);
            Destroy(collision.gameObject);
        }
    }
    void CanSistemi()
    {
        for(int i = 0; i < MaxHeal; i++)
        {
            Heals[i].SetActive(false);
        }
        for(int i = 0; i < Heal; i++)
        {
            Heals[i].SetActive(true); 
        }
    }
    void Duzelt()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
