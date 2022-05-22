using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    private bool canTrigger = true;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Enemy" && canTrigger)
        {
            canTrigger = false;
        
            if(other.gameObject.GetComponent<Enemy>().currentState == ENEMY_STATE.ALIVE)
            {
                other.gameObject.GetComponent<Enemy>().health -= 100;
            }
            else if(other.gameObject.GetComponent<Enemy>().currentState == ENEMY_STATE.DEAD)
            {
                other.gameObject.GetComponent<Enemy>().resurrected = true;
            }
            else if(other.gameObject.GetComponent<Enemy>().currentState == ENEMY_STATE.UNDEAD)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Enemy") canTrigger = true;
    }
   
}
