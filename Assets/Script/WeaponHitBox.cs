using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    public GameObject target;
    public int damage = 1;
    HealthComponent health;
   void OnTriggerEnter2D(Collider2D target)
   {    
        if(target.gameObject.tag == "Enemy")
        {
            health = target.GetComponent<HealthComponent>();  
            if (health != null)
            {
                //Debug.Log("Hit!!");
                health.TakeDamage(damage);
            }
        }
        
   }
}
