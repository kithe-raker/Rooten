using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Collider2D weaponCollider;
    public int attacksLeft = 10;
    public float coolDownDuration = 5f;
    private bool coolingDown = false;
    public float attackDelay = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && attacksLeft > 0 && !coolingDown)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        weaponCollider.enabled = true;
        attacksLeft--;
        if (attacksLeft == 0)
        {
            StartCoroutine(CoolDown());
        }
        yield return new WaitForSeconds(attackDelay);
        weaponCollider.enabled = false;
        Debug.Log(attacksLeft);
    }

    IEnumerator CoolDown()
    {
        coolingDown = true;
        yield return new WaitForSeconds(coolDownDuration);
        attacksLeft = 10;
        coolingDown = false;
    }
}
