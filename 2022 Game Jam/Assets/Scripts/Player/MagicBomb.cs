using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBomb : MonoBehaviour
{
    public GameObject magicBomb;
    public Transform spawnPosition;
    public float throwForce = 10.0f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("MagicBomb");
        }
    }

    public void bomb()
    {
        GameObject newBomb = Instantiate(magicBomb, spawnPosition.position, transform.rotation);
        newBomb.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * throwForce);
    }
}
