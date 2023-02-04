using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Patrol_AI : MonoBehaviour
{

    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    [SerializeField] Transform Player;
    public GameObject Target;
   
    
    bool isTrigger = false;


    int NextPosIndex;

    Transform Nextpos;
    // Start is called before the first frame update
    void Start()
    {
        Nextpos = Positions[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, ObjectSpeed * Time.deltaTime);
        }
        else
        {
            MoveGameObjext();
        }
    }

    void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.tag == "Player")
        {
            isTrigger = true;
            Debug.Log("trigger");
        }
    }

    void MoveGameObjext()
    {
        if (transform.position == Nextpos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            Nextpos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Nextpos.position, ObjectSpeed * Time.deltaTime);
        }
    }
    
}