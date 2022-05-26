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
    public float attackDistance = 3f;
    private Transform player;
    [HideInInspector]
    public bool playerInRange;
    // [HideInInspector]
    public bool enemyInRange;
    public bool allyInRange;
    public Transform closestEnemy;
    [HideInInspector]
    public bool resurrected;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponentInChildren<Renderer>();
        player = ThirdPersonMovement.instance.transform;
        StartCoroutine(State_Alive());
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= attackDistance) playerInRange = true;
        else playerInRange = false;

        closestEnemy = GetClosestEnemy();
        if(closestEnemy != null && Vector3.Distance(transform.position, closestEnemy.position) <= attackDistance) enemyInRange = true;
        else enemyInRange = false;
    }

    public IEnumerator State_Alive()
    {
        currentState = ENEMY_STATE.ALIVE;
        GetComponent<EnemyAttack>().enabled = true;
        GetComponent<AllyAttack>().enabled = false;
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
        animator.SetTrigger("die");
        animator.SetBool("isWalking", false);
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<AllyAttack>().enabled = false;
        GetComponent<AliveMovement>().enabled = false;
        GetComponent<UndeadMovement>().enabled = false;
        //rend.material.color = Color.green;
        EnemySpawner.instance.aliveEnemies.Remove(this.gameObject);
        while (currentState == ENEMY_STATE.DEAD)
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
        GetComponent<AliveMovement>().enabled = false;
        GetComponent<AllyAttack>().enabled = true;
        GetComponent<EnemyAttack>().enabled = false;
        rend.material.color = Color.blue;
        animator.SetBool("isWalking", true);
        while(currentState == ENEMY_STATE.UNDEAD)
        {
            yield return null;
        }
    }

    public Transform GetClosestEnemy()
    {
        Transform closestEnemy = null;
        float distToClosestEnemy = Mathf.Infinity;

        if(currentState == ENEMY_STATE.ALIVE)
        {
            if(EnemySpawner.instance.undeadEnemies == null) return null;

            foreach(GameObject enemy in EnemySpawner.instance.undeadEnemies)
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
        }
        else
        {
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
        }
        return closestEnemy;
    }

    public void TakeDamage(float amount) 
    {
        health -= amount;
    }

}
