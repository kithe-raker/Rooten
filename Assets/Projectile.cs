using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthComponent healthComp = collision.gameObject.GetComponent<HealthComponent>();
            if (healthComp != null)
            {
                healthComp.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
