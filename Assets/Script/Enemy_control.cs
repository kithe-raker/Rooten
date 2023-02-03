using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_control : MonoBehaviour
{
    public float speed;
    public float checkRadius = 3f;
    public float attackRadius = 1f;

    public bool shouldRotate;

    public  LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector2 dir;

    public GameObject bulletpod;
   


   bool isInAttackRange;
   bool isInChaseRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        bulletpod.SetActive(false);
        anim.SetBool("IsRunning", false);





    }
    private void Update()
    {
       

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x);//* Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        anim.SetFloat("X", dir.x);
       /*if (shouldRotate)
        {
           anim.SetFloat("X",dir.x);
        }*/
    }
    /*private void OnCollisionEnter2D()
    {
        if(target != null)
        {
            rb.velocity = Vector2.zero;
        }
        
    }*/
    private void FixedUpdate()
    {
        if(isInAttackRange)
        {
           StartCoroutine(StopMoving());
            anim.SetBool("IsRunning",false);

        }
        else if(isInChaseRange){
            
            MoveCharacter(movement);
            anim.SetBool("IsRunning",true);
            bulletpod.SetActive(false);


        }
        else
        {
            anim.SetBool("IsRunning", false); 
        }
        //if(isInAttackRange == true)
        //{
            

        //}
    }
    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
       
       public IEnumerator StopMoving()
    {
         rb.velocity = Vector2.zero;
         yield return new WaitForSeconds(1f);
         bulletpod.SetActive(true);
    }
    

}