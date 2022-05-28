using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class UndeadMovement : MonoBehaviour
{
    private Enemy enemy;
    private NavMeshAgent agent;
    private Transform player;
    public float playerRadius = 5f;
    public float seekingDist = 30f;
    public TextMeshPro text;
    Animator anim;
    bool isFollowing;

    void Start()
    {
        player = ThirdPersonMovement.instance.transform;
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isFollowing = !isFollowing;
        }

        if (isFollowing == false) { 
        if(enemy.enemyInRange)
        {
            text.SetText("Fighting");
            agent.isStopped = true;
        }
        else if(enemy.closestEnemy != null && Vector3.Distance(enemy.closestEnemy.position, player.position) < seekingDist)
        {
            text.SetText("Hunting");
            agent.isStopped = false;
            agent.SetDestination(enemy.closestEnemy.position);
            anim.SetBool("isWalking", true);
        }
        else if(Vector3.Distance(transform.position, player.position) <= playerRadius)
        {
            text.SetText("Waiting");
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
        }
        else 
        {
            text.SetText("Following");
            agent.isStopped = false;
            agent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) >= playerRadius + 5)
            {

                anim.SetBool("isWalking", true);
            }
        }
        }

        if (isFollowing)
        {
            if (Vector3.Distance(transform.position, player.position) <= playerRadius)
            {
                text.SetText("Waiting");
                agent.isStopped = true;
                anim.SetBool("isWalking", false);
            }
            else
            {
                text.SetText("Following");
                agent.isStopped = false;
                agent.SetDestination(player.position);
                if (Vector3.Distance(transform.position, player.position) >= playerRadius + 5)
                {

                    anim.SetBool("isWalking", true);
                }
            }
        }
    }


}
