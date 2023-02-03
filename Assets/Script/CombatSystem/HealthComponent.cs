using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    // Trigger when out of health
    public delegate void OutOfHealth();
    public event OutOfHealth OnOutOfHealth;

    // Received health from field value
    public int health;

    // remaining health
    int _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0 && OnOutOfHealth != null)
        {
            OnOutOfHealth();

        }
    }

    // return remaining health
    public int GetRemainingHealth()
    {
        return _health;
    }


}
