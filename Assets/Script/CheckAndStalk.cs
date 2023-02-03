using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAndStalk : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] Transform player;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
    }
}
