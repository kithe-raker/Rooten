using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RangedPatrol_AI : MonoBehaviour
{

    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    [SerializeField] Transform Player;
    public Transform ProjectilePivot;
    public GameObject projectile;


    bool isTrigger = false;

    [SerializeField] private float attackDelay = 1f;
    private float attackTime = 0f;
    private HealthComponent target;


    private bool isEnd = false;
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
        if (!isTrigger)
        {
            MoveGameObjext();
        }
        else
        {
            Shooting();
        }
    }

    void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.tag == "Player")
        {
            isTrigger = true;
            target = Target.gameObject.GetComponent<HealthComponent>();
            Debug.Log("trigger");
        }
    }

    void MoveGameObjext()
    {
        Nextpos = Positions[NextPosIndex];

        if (transform.position == Nextpos.position)
        {

            if (NextPosIndex != Positions.Length - 1 && !isEnd)
            {
                NextPosIndex++;
            }
            else if (NextPosIndex == Positions.Length - 1 && !isEnd)
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

    void Shooting()
    {
        if (target != null && attackTime >= attackDelay)
        {
            Debug.Log("Hit!!");

            Vector2 dir = Player.position - ProjectilePivot.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Instantiate(projectile, ProjectilePivot.position, rotation);

            attackTime = 0f;
        }
        else
        {
            attackTime += Time.deltaTime;
        }
    }

}