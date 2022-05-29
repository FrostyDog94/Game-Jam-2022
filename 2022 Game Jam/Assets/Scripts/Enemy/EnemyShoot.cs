using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate = 5.0f;
    float fireTime;
    public Transform projectileSpawnPoint;
    private Animator animator;
   
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
        fireTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.currentState == ENEMY_STATE.ALIVE) // && enemy.playerInRange == false
        {
            fireTime -= Time.deltaTime;
        }

        if (fireTime <= 0)
        {
            StartCoroutine(fireProjectile());
            fireTime = fireRate;
        }
    }

    IEnumerator fireProjectile()
    {
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(1);
        Instantiate(projectile, projectileSpawnPoint.position, transform.rotation);
    }
}
