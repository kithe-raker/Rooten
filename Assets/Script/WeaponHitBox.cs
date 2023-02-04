using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    //public GameObject target;
    public int damage = 1;
    HealthComponent health;
    private float attackTime = 0f;
    private float attackDelay= 1f;
   void OnTriggerEnter2D(Collider2D target)
   {    
        if (target.gameObject.tag == "Enemy")
        {
            health = target.GetComponent<HealthComponent>();
            if (health != null && attackTime >= attackDelay)
            {
                Debug.Log("Hit!!");
                health.TakeDamage(damage);
                attackTime = 0f;
            }
            else
            {
                attackTime += Time.deltaTime;
                
            }
        
        }
    }
}
