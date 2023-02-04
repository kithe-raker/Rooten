using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{

    HealthComponent health;
    void Start()
    {
        health = this.gameObject.GetComponent<HealthComponent>();
        health.OnOutOfHealth += DestroyObject;
    }

    void DestroyObject ()
    {
         Destroy(gameObject,0f);
    }
}
