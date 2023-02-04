using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Collider2D weaponCollider;
    public float delay = 1.0f;
    public int hitLimit = 10;
    private int hitCount = 0;
    private float cooldownTimer;
    float lastAttack;
    bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {      if(hitCount < hitLimit & canAttack)
                {
                Attack();   
                }            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            weaponCollider.enabled = false;
        }

        if(hitCount >= hitLimit)
        {
            canAttack = false;
            StartCoroutine(cooldown());
        }
            Debug.Log(hitCount);
            
    }

    private void Attack()
    {
        if (Time.time - lastAttack < delay)
        {
             return;    
        }
        lastAttack = Time.time;
        hitCount += 1;
        weaponCollider.enabled = true;
        
        //weaponAnimator.SetTrigger("Shoot");
    }

    private IEnumerator cooldown()
    {
        //yield return new WaitForSeconds(2.0f);
        while(hitCount > 0)
        {
            hitCount -= 1;
            yield return new WaitForSeconds(1.0f);
        }
        canAttack = true;
    }


    
    
}
