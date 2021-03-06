using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    public float attackCooldown = 2f;
    public float attackDamage = 5f;
    private bool canAttack = true;
    private Enemy enemy;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (enemy.enemyInRange && canAttack) {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("attack");
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        if (enemy.closestEnemy!= null)
        {
            enemy.closestEnemy.gameObject.GetComponent<Enemy>().health -= attackDamage;
        }
        canAttack = true;
    }
}
