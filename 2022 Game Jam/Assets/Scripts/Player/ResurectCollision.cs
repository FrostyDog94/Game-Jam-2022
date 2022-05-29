using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ResurectCollision : MonoBehaviour
{

    public PlayerStats playerStats;
    public Animator anim;
    public ThirdPersonMovement thirdPersonMovement;
    public float resurrectTime = 3.5f;
    Collider enemyCollider;
    bool canResurrect = true;
    private Image healthFill;


    private void Update()
    {
        
        if (enemyCollider != null)
        {
            if (enemyCollider.tag == "Enemy" && 
                enemyCollider.GetComponent<Enemy>().currentState == ENEMY_STATE.DEAD && 
                enemyCollider.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) // make sure death animation is finished
            {
                enemyCollider.GetComponent<Outline>().enabled = true;

                if (Input.GetKey(KeyCode.E) && canResurrect)
                {
                    canResurrect = false;
                    //playerStats.currentMana -= 10;
                    anim.SetTrigger("resurrect");
                    thirdPersonMovement.enabled = false;
                    EnemySpawner.instance.undeadEnemies.Add(enemyCollider.gameObject);
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
            if (enemyCollider.GetComponent<Outline>())
            {
                enemyCollider.GetComponent<Outline>().enabled = false;
            }
        }

        enemyCollider = null;
    }

    IEnumerator raiseDead()
    {
        yield return new WaitForSeconds(resurrectTime);
        if (enemyCollider != null)
        {
            StartCoroutine(enemyCollider.GetComponent<Enemy>().State_Undead());
            enemyCollider.GetComponent<Enemy>().health = 100;
            enemyCollider.GetComponentsInChildren<Image>().FirstOrDefault(c => c.gameObject.name == "Fill").color = Color.green;
        }
        thirdPersonMovement.enabled = true;
        canResurrect = true;
    }

}






