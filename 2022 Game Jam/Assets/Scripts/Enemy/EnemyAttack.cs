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
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (enemy.playerInRange && canAttack) {
            StartCoroutine(Attack());
            animator.SetBool("isWalking", false);
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("attack");
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        playerStats.currentHealth -= attackDamage;
        canAttack = true;
    }
}
