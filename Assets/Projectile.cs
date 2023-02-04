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

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("Pro Hit");
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
