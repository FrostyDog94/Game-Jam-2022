using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    public ScoreController scoreController;
 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetComponent<Enemy>().currentState == ENEMY_STATE.UNDEAD)
        {
            Destroy(other.gameObject);
            scoreController.score -= 1;
        }
    }
}
