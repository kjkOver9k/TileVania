using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    float deltaX;
    float deltaY;
    [SerializeField] float runspeed ;
    [SerializeField] float jumpspeed ;
    float yeetspeed = 8f;
    float gravityScaleAtStart;
    bool isAlive;
    Animator animator;
    
    Rigidbody2D playerrigidbody;
    Collider2D mycollider;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        playerrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mycollider = GetComponent<Collider2D>();
        gravityScaleAtStart = playerrigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            MovementHorizontally();
            Jump();
            Climb();
            Die();
        }
       

    }

    private void Climb()
    {
        if (mycollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            
            playerrigidbody.gravityScale = 0;
            deltaY = CrossPlatformInputManager.GetAxis("Vertical") ;
            Vector2 newpos = new Vector2(playerrigidbody.velocity.x, deltaY*Time.deltaTime*100);
            playerrigidbody.velocity = newpos;
            animator.SetBool("Climbing", true);
            if (deltaY==0)
            {
                animator.SetBool("Climbing", false);
            }
        }
        else
        {
            playerrigidbody.gravityScale = gravityScaleAtStart;
            animator.SetBool("Climbing", false);
        }
    }

    private void Jump()
    {
        if(playerrigidbody.velocity.y==0)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Vector2 jumpvel = new Vector2(playerrigidbody.velocity.x, jumpspeed);
                playerrigidbody.velocity = jumpvel;
            }
        }
       
    }

    private void MovementHorizontally()
    {

        deltaX = CrossPlatformInputManager.GetAxis("Horizontal")*runspeed ;
       if(deltaX>0)
        {
            Vector2 newscale = new Vector2(1, 1);
            transform.localScale = newscale;
            animator.SetBool("Running", true);

        }
       else if(deltaX<0)
        {
            Vector2 newscale = new Vector2(-1, 1);
            transform.localScale = newscale;
            animator.SetBool("Running", true);
        }
       else if(deltaX==0)
        {
            animator.SetBool("Running", false);
        }
        
        Vector2 newpos = new Vector2(deltaX, playerrigidbody.velocity.y);
        playerrigidbody.velocity = newpos;


    }
    private void Die()
    {
        if(mycollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard", "RisingWater")))
        {
            isAlive = false;
            
            playerrigidbody.velocity = new Vector2( 0f,yeetspeed);
            animator.SetTrigger("Dying");
            StartCoroutine(delayDeatheffect());
        }
       

        
    }
    IEnumerator delayDeatheffect()
    {
        yield return new WaitForSecondsRealtime(5f);
        FindObjectOfType<GameSession>().ifPlayerDies();
    }
        
}
