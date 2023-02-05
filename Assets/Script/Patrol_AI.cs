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

    private bool isEnd = false;
    bool isTrigger = false;


    int NextPosIndex = 0;

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
        Debug.Log("trigger " + Target.gameObject.name);
        if (Target.gameObject.tag == "Player")
        {
            isTrigger = true;
            Debug.Log("trigger");
        }
    }

    void MoveGameObjext()
    {
        Nextpos = Positions[NextPosIndex];
        
        if (transform.position == Nextpos.position )
        {
            
            if (NextPosIndex != Positions.Length-1 && !isEnd)
            {
                NextPosIndex++;
            }
            else if(NextPosIndex == Positions.Length-1 && !isEnd)
            {
                isEnd = true;
            }
            else if (NextPosIndex != 0 && isEnd)
            {
                NextPosIndex--;
            }
            else if (NextPosIndex == 0 && isEnd)
            {
                isEnd = false;
            }


        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Nextpos.position, ObjectSpeed * Time.deltaTime);
        }
    }
    
}