using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemybody;
    
    [SerializeField]float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        enemybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
      
    }

    private void Movement()
    {
        bool facingRight = Mathf.Sign(transform.localScale.x)==1;//Better to use transform.localScale.x >0 
        if(facingRight)                                          // in case scale changes
        {
            enemybody.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            enemybody.velocity = new Vector2(-movespeed, 0f);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(transform.localScale.x), 1f);
    }
}
