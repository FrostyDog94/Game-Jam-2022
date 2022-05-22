using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurectCollision : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<Enemy>().currentState == ENEMY_STATE.DEAD) 
            {
            other.GetComponentInChildren<Outline>().enabled = true;

            if (Input.GetMouseButton(1))
            {
                StartCoroutine(other.GetComponent<Enemy>().State_Undead());
                Debug.Log(other.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponentInChildren<Outline>().enabled = false;
    }


}






