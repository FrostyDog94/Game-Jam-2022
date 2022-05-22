using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetection : MonoBehaviour
{
    public WeaponController wc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(other.GetComponent<Enemy>().State_Dead());
            
        }
    }
}
