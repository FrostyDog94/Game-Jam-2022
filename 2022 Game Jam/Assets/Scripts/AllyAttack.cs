using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    private float attackCooldown = 2f;
    private float attackDamage = 5f;
    private bool canAttack = true;
    private Enemy enemy;

    void Start()
    {
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
        canAttack = false;
        enemy.closestEnemy.gameObject.GetComponent<Enemy>().health -= attackDamage;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
