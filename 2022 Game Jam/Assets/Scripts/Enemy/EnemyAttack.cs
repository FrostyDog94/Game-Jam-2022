using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCooldown = 2f;
    public float attackDamage = 5f;
    public bool isRanged;
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
        if (!isRanged && enemy.playerInRange && canAttack) {
            //StartCoroutine(Attack());
            animator.SetTrigger("attack");
            animator.SetBool("isWalking", false);
        }
    }

    IEnumerator Attack()
    {
        playerStats.currentHealth -= attackDamage;
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
