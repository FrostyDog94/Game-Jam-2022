using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurectCollision : MonoBehaviour
{

    public PlayerStats playerStats;
    public Animator anim;
    public ThirdPersonMovement thirdPersonMovement;
    public float resurrectTime = 3.5f;
    Collider enemyCollider;


    private void Update()
    {
        if (enemyCollider != null)
        {
            if (enemyCollider.tag == "Enemy" && enemyCollider.GetComponent<Enemy>().currentState == ENEMY_STATE.DEAD)
            {
                enemyCollider.GetComponentInChildren<Outline>().enabled = true;

                if (Input.GetMouseButtonDown(1))
                {
                    playerStats.currentMana -= 10;
                    anim.SetTrigger("resurrect");
                    thirdPersonMovement.enabled = false;
                    StartCoroutine(raiseDead());

                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<Enemy>().currentState == ENEMY_STATE.DEAD)
        {
            enemyCollider = other;
        }
  

    }

    private void OnTriggerExit(Collider other)
    {
        if (enemyCollider != null)
        {
            if (enemyCollider.GetComponentInChildren<Outline>())
            {
                enemyCollider.GetComponentInChildren<Outline>().enabled = false;
            }
        }

        enemyCollider = null;
    }

    IEnumerator raiseDead()
    {
        yield return new WaitForSeconds(resurrectTime);
        StartCoroutine(enemyCollider.GetComponent<Enemy>().State_Undead());
        thirdPersonMovement.enabled = true;
    }








}






