using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{

    HealthComponent health;
    void Start()
    {
        health = GetComponentInChildren(typeof(HealthComponent)) as HealthComponent;
        if (health != null)
            health.OnOutOfHealth += DestroyObject;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
