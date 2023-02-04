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
    Vector2 MOnementInput;
    public Collider2D MC_collider;
    public float groundradius = 0.2f;
    private float movementThreshold = 0.1f;
    private SpriteRenderer ren;
    bool isLeft = false;

    bool isMoving = false;

    
    void Start()
    {
        MC_collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Flip()
    {
        Vector3 scale = transform.localScale ;
        scale.x*=-1;
        transform.localScale = scale;
        isLeft = !isLeft;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            if((movement.x < 0 && !isLeft) || (movement.x > 0 && isLeft))
            {
                Flip();
            }
            //Debug.Log("X MOve: " + movement.x);
            animator.SetInteger("Walking", 1);
        }
        else
        {
            animator.SetInteger("Walking", 0);
        }

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
        
       

        //animator.SetBool("isMoving",IsMoving); 

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); 
    }
    // bool IsMoving()
    //     {
    //         return Mathf.Abs(rb.velocity.x) > movementThreshold || Mathf.Abs(rb.velocity.y) > movementThreshold;
    //     }
    
}
