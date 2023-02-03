using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_attack : MonoBehaviour
{
    public GameObject target;
    HealthComponent health;


    void Start()
    {
         health = target.GetComponent<HealthComponent>();
        if(health != null)
        {
        health.OnOutOfHealth += printDie;
        StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
            yield return new WaitForSeconds(1);
        health.TakeDamage(1);
        print(health.GetRemainingHealth());

        StartCoroutine(attack());
    }

    void printDie()
    {
        print("Die");
    }
}
