using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public HealthComponent _health;
    public GameObject heart1,heart2,heart3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num =_health.GetRemainingHealth();
        if (num == 2)
        {
            heart3.SetActive(false);
        }
        else if (num == 1)
        {
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (num == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            
        }

    }
}
