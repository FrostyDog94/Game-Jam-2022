using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetection : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<Enemy>().currentState == ENEMY_STATE.ALIVE)
        {

           //StartCoroutine(other.GetComponent<Enemy>().State_Dead());
           //EnemySpawner.instance.aliveEnemies.Remove(other.gameObject);
            
            //StartCoroutine(other.GetComponent<Enemy>().State_Dead());
           other.GetComponent<Enemy>().TakeDamage(20);
            
        }
    }
}
