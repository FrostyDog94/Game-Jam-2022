using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AliveMovement : MonoBehaviour
{
    private Enemy enemy;
    private NavMeshAgent agent;
    private Transform player;
    void Start() 
    {
        player = ThirdPersonMovement.instance.transform;
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
    }
    void Update()
    {
        if(enemy.playerInRange || enemy.enemyInRange)
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
