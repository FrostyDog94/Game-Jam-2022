using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    public ScoreController scoreController;
    public PlayerStats playerStats;
    public EnemySpawner enemySpawner;
 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetComponent<Enemy>().currentState == ENEMY_STATE.UNDEAD)
        {
            Destroy(other.gameObject);
            scoreController.score += 1;
            if (playerStats.currentMana < playerStats.maxMana) {
                playerStats.currentMana += 30;
            }
            enemySpawner.RemoveEnemy();
        }
    }
}
