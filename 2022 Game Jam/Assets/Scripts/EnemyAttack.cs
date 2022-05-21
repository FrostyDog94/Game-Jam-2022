using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float attackCooldown = 3f;
    private float lastAttackTime;
    private float attackDamage = 5f;
    private boolean inRange = false; // is enemy within attacking range of player
    private Player player; // enemy always contains reference to player object

    void Start()
    {
        lastAttackTime = -attackCooldown; // ensures that enemy will attack immediately the first time
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    IEnumerator Attack()
    {
        while (inRange) {
            // attack once every attackCooldown
            if (lastAttackTime < Time.time - attackCooldown) {
                player.TakeDamage(attackDamage);
                lastAttackTime = Time.time;
            }
            yield return null;
        }
        yield break;
    }

    void OnTriggerEnter(Collider collision)
    {
        // collision with player
        if(collision.gameObject.tag == "Player" && inRange == false && player.health > 0){
            StartCoroutine(Attack());
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
