using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{

    HealthComponent health;
    public GameObject target;
    void Start()
    {
        target = transform.gameObject;
        health = target.GetComponent<HealthComponent>();
        health.OnOutOfHealth += DestroyObject;
    }

    void DestroyObject ()
    {
         Destroy(target,0f);
    }
}
