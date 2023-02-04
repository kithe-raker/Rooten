using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject target;
    public int damage = 1;
    HealthComponent health;
    [SerializeField] private float attackDelay= 1f;
    //private bool canAttack = false;
    private float attackTime = 0f;

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
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




