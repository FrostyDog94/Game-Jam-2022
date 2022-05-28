using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 3.0f;
    public GameObject enemyExplosion;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroySelf(lifetime));
        player = GameObject.FindGameObjectWithTag("followPos");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
    }

    IEnumerator destroySelf(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
        Instantiate(enemyExplosion, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(enemyExplosion, transform.position, transform.rotation);
        }
    }
}
