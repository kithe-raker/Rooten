using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Collider2D weaponCollider;
    public ParticleSystem smoke;
    public int attacksLeft = 10;
    public int attackTime = 10;
    public float coolDownDuration = 4f;
    private bool coolingDown = false;
    public float attackDelay = 0.5f;
    Animator animator;
    public AudioSource audioSourceAttack;
    public AudioSource audioSourceIdle;

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
            audioSourceIdle.Pause();
            audioSourceAttack.Play();
            
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.4f);
        weaponCollider.enabled = true;
        yield return new WaitForSeconds(0.3f);
        weaponCollider.enabled = false;
        audioSourceIdle.UnPause();
        attacksLeft--;
        if (attacksLeft == 0)
        {
            StartCoroutine(CoolDown());
        }
        yield return new WaitForSeconds(attackDelay);
        //Debug.Log(attacksLeft);
    }

    IEnumerator CoolDown()
    {
        coolingDown = true;
        if (smoke != null)
        {
            smoke.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(coolDownDuration);
        if (smoke != null)
        {
            smoke.gameObject.SetActive(false);
        }
        attacksLeft = attackTime;
        //Debug.Log(attacksLeft);
        coolingDown = false;
    }




}
