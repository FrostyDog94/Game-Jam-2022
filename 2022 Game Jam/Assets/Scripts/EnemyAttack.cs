using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float attackCooldown = 2f;
    private float attackDamage = 5f;
    private bool canAttack = true;
    private bool inRange = false; // is enemy within attacking range of player
    private PlayerStats player;
    private Enemy enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemy = gameObject.GetComponent<Enemy>();
    }

    void Update()
    {
        if (inRange && canAttack) {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        player.currentHealth -= attackDamage;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        // collision with player
        if(collision.gameObject.tag == "Player" && inRange == false && player.currentHealth > 0) {
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
