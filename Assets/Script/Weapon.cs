using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Collider2D weaponCollider;
    public int attacksLeft = 10;
    public int attackTime = 10;
    public float coolDownDuration = 4f;
    private bool coolingDown = false;
    public float attackDelay = 0.5f;
    Animator animator;

    void Start()
    {
        weaponCollider.enabled = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && attacksLeft > 0 && !coolingDown)
        {
            StartCoroutine(Attack());
            animator.SetTrigger("Shoot");
        }
      
    }

    IEnumerator Attack()
    {
        weaponCollider.enabled = true;
        yield return new WaitForSeconds(1f);
        weaponCollider.enabled = false;
        attacksLeft--;
        if (attacksLeft == 0)
        {
            StartCoroutine(CoolDown());
        }
        yield return new WaitForSeconds(attackDelay);
        Debug.Log(attacksLeft);
    }

    IEnumerator CoolDown()
    {
        coolingDown = true;
        yield return new WaitForSeconds(coolDownDuration);
        attacksLeft = attackTime;
        Debug.Log(attacksLeft);
        coolingDown = false;
    }


    
    
}
