using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBomb : MonoBehaviour
{
    public GameObject magicBomb;
    public Transform spawnPosition;
    public float throwForce = 10.0f;
    public float manaCost = 10;
    Animator anim;
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && playerStats.currentMana >= manaCost) 
        {
            anim.Play("MagicBomb");
            playerStats.currentMana -= manaCost;
        }
    }

    public void bomb()
    {
        GameObject newBomb = Instantiate(magicBomb, spawnPosition.position, transform.rotation);
        newBomb.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * throwForce);
    }
}
