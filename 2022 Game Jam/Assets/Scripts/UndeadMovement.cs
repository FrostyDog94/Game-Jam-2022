using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UndeadMovement : MonoBehaviour
{
    private Enemy enemy;
    private NavMeshAgent agent;
    private Transform player;
    public float playerRadius = 5f;
    public float seekingDist = 30f;

    void Start()
    {
        player = ThirdPersonMovement.instance.transform;
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetClosestEnemy() != null && Vector3.Distance(enemy.GetClosestEnemy().position, player.position) < seekingDist)
        {
            agent.isStopped = false;
            agent.SetDestination(enemy.GetClosestEnemy().position);
        }
        else if(Vector3.Distance(transform.position, player.position) <= playerRadius || enemy.enemyInRange)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }
}
