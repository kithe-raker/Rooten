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
            
                //Debug.Log(target.gameObject.name);
                Debug.Log("Hit!! Enemy");
                health.TakeDamage(damage);
                attackTime = 0f;
        }
    }
}
