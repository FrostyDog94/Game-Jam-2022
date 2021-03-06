using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waitThenDie());
    }



    IEnumerator waitThenDie()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<Enemy>().currentState == ENEMY_STATE.ALIVE)
        {

            other.GetComponent<Enemy>().TakeDamage(75);

        }

        if (other.tag == "Player" && other.GetComponent<PlayerStats>().currentHealth <= other.GetComponent<PlayerStats>().maxHealth)
        {

            other.GetComponent<PlayerStats>().currentHealth += 30;

        }
    }


}
