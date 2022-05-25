using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    private float attackCooldown = 2f;
    private float attackDamage = 5f;
    private bool canAttack = true;
    private bool inRange = false; // is ally within attacking range of enemy
    private Enemy enemy;

    void Update()
    {
        if (inRange && canAttack) {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        enemy.health -= attackDamage;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        // collision with player
        if(collision.gameObject.tag == "Enemy" && inRange == false) {
            enemy = collision.gameObject.GetComponent<Enemy>();
            inRange = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player") {
            inRange = false;
        }
    }
}
