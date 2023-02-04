using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.InputSystem;

public class MC_control : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public Rigidbody2D rb;
     Animator animator;
    public Vector2 movement;


    
    public bool collision;
    public Collider2D MC_collider;
    public float groundradius = 0.2f;

    private SpriteRenderer ren;

    
    void start()
    {
        MC_collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()//Input
    {
        if(movement != Vector2.zero)
        {
            bool success = Move(movement);
            if(!success)
            {
                success = Move(new Vector2(movement.x, 0));
                if(!success)
                {
                    success = Move(new Vector2(0,movement.y));
                }
            }
        }
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        // animator.SetFloat("Horizontal", movement.x);
        animator.SetBool("isMOving", success);
        

    }

    // Update is called once per frame
    void Update()//movement
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);  
        if(movement.y ==1)
        {
            //ren.renderingLayerMask = 1 ;
        }

        
    }
    void Move()
    {
        
    }

    
}
