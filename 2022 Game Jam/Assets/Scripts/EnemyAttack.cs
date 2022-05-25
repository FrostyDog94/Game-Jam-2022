using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float attackCooldown = 2f;
    private float attackDamage = 5f;
    private bool canAttack = true;
    private PlayerStats playerStats;
    private Enemy enemy;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (enemy.playerInRange && canAttack) {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        playerStats.currentHealth -= attackDamage;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
