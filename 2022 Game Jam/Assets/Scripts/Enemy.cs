using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMY_STATE
{
    ALIVE,
    DEAD,
    UNDEAD
};
public class Enemy : MonoBehaviour
{
    public ENEMY_STATE currentState = ENEMY_STATE.ALIVE;
    public float health = 100f;
    private Renderer rend;
    public float attackDistance = 1f;
    private Transform player;
    [HideInInspector]
    public bool playerInRange;
    // [HideInInspector]
    public bool enemyInRange;
    [HideInInspector]
    public bool resurrected;
    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        player = ThirdPersonMovement.instance.transform;
        StartCoroutine(State_Alive());
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= attackDistance) playerInRange = true;
        else playerInRange = false;
        if(GetClosestEnemy() != null && Vector3.Distance(transform.position, GetClosestEnemy().position) <= attackDistance) playerInRange = true;
        else playerInRange = false;
    }

    public IEnumerator State_Alive()
    {
        currentState = ENEMY_STATE.ALIVE;
        // GetComponent<AttackEnemy>().enabled = true;
        // GetComponent<AttackPlayer>().enabled = true;
        GetComponent<AliveMovement>().enabled = true;
        while(currentState == ENEMY_STATE.ALIVE) 
        {
            if(health <= 0)
            {
                StartCoroutine(State_Dead());
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator State_Dead()
    {
        currentState = ENEMY_STATE.DEAD;
        // GetComponent<AttackPlayer>().enabled = false;
        // GetComponent<AttackEnemy>().enabled = false;
        GetComponent<AliveMovement>().enabled = false;
        GetComponent<UndeadMovement>().enabled = false;
        rend.material.color = Color.green;
        while(currentState == ENEMY_STATE.DEAD)
        {
            if(resurrected)
            {
                StartCoroutine(State_Undead());
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator State_Undead()
    {
        currentState = ENEMY_STATE.UNDEAD;
        GetComponent<UndeadMovement>().enabled = true;
        // GetComponent<AttackEnemy>().enabled = true;
        rend.material.color = Color.blue;
        while(currentState == ENEMY_STATE.UNDEAD)
        {
            yield return null;
        }
    }

    public Transform GetClosestEnemy()
    {
        Transform closestEnemy = null;
        float distToClosestEnemy = Mathf.Infinity;

        if(EnemySpawner.instance.aliveEnemies == null) return null;

        foreach(GameObject enemy in EnemySpawner.instance.aliveEnemies)
        {
            if(enemy != this.gameObject)
            {
                float dist = Vector3.Distance(enemy.transform.position, player.position);
                if(dist < distToClosestEnemy)
                {
                    closestEnemy = enemy.transform;
                    distToClosestEnemy = dist;
                }
            }
        }
        return closestEnemy;
    }
}
