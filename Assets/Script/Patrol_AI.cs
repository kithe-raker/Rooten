using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_AI : MonoBehaviour
{

    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;

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
        MoveGameObjext();
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