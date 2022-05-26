using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AliveMovement : MonoBehaviour
{
    private Enemy enemy;
    private NavMeshAgent agent;
    private Transform player;
    public TextMeshPro text;

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
            text.SetText("Fighting");
            agent.isStopped = true;
        }
        else 
        {
            text.SetText("Chasing");
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }
}
