using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurectCollision : MonoBehaviour
{

    public PlayerStats playerStats;
    public Animator anim;
    



    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<Enemy>().currentState == ENEMY_STATE.DEAD) 
            {
            other.GetComponentInChildren<Outline>().enabled = true;

            if (Input.GetMouseButton(1))
            {
                StartCoroutine(other.GetComponent<Enemy>().State_Undead());
                EnemySpawner.instance.undeadEnemies.Add(other.gameObject);
                playerStats.currentMana -= 10;
                anim.SetTrigger("resurrect");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInChildren<Outline>())
        {
            other.GetComponentInChildren<Outline>().enabled = false;
        }
    }




}






