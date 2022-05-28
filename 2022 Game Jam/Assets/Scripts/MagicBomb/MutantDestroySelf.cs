using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantDestroySelf : MonoBehaviour
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
        if (other.tag == "Player")
        {
            
            other.GetComponent<PlayerStats>().currentHealth -= 20;

        }
    }


}
