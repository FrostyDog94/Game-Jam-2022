using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate = 5.0f;
    float fireTime;
    public Transform projectileSpawnPoint;
   
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        fireTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.playerInRange == false && enemy.currentState == ENEMY_STATE.ALIVE)
        {
            fireTime -= Time.deltaTime;
        }

        if (fireTime <= 0)
        {
            fireProjectile();
            fireTime = fireRate;
        }
    }

    void fireProjectile()
    {
        Instantiate(projectile, projectileSpawnPoint.position, transform.rotation);
    }
}
