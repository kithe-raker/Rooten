using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class MC_control : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;


    
    public bool collision;
    public Transform Checker;
    public Collider2D MC_collider;
    public float groundradius = 0.2f;

    
    void start()
    {
        MC_collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()//Input
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("speed", movement.sqrMagnitude);

    }

    // Update is called once per frame
    void Update()//movement
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);  
        
    }

    
}
