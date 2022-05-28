using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxNumEnemies = 10;
    public float spawnRate = 3f;
    public float minSpawnDist = 25f;
    public float maxSpawnDist = 50f;
    private Transform player;
    public int enemyCount = 0;
    [HideInInspector]
    public List<GameObject> aliveEnemies;
    [HideInInspector]
    public static EnemySpawner instance = null;
    [HideInInspector]
    public List<GameObject> undeadEnemies;

    float spawnTimer;

    void Start()
    {
        player = ThirdPersonMovement.instance.transform;
        instance = this;
       // StartCoroutine("SpawnEnemy");
        spawnTimer = 1;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnRate;
            if (enemyCount < maxNumEnemies)
            {
                enemyCount++;
                aliveEnemies.Add(Instantiate(enemyPrefab, RandomNavSphere(player.position, maxSpawnDist, minSpawnDist, 1), Quaternion.identity));
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(enemyCount < maxNumEnemies)
        {
            enemyCount++;
            aliveEnemies.Add(Instantiate(enemyPrefab, RandomNavSphere(player.position, maxSpawnDist, minSpawnDist, 1), Quaternion.identity));
            yield return new WaitForSeconds(spawnRate);
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, float minDist, int layermask) 
    {
        NavMeshHit navHit;
        NavMeshHit navEdge;
        
        do
        {
            Vector3 randDirection = Random.insideUnitSphere * dist;
            randDirection += origin;
            NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
            NavMesh.FindClosestEdge(navHit.position, out navEdge, 1);
        }while(navHit.position == navEdge.position && Vector3.Distance(navHit.position, origin) < minDist);
        
        //Debug.DrawRay(navHit.position, Vector3.up, Color.red, 15, true);
 
        return navHit.position;
    }

    public void RemoveEnemy()
    {
        enemyCount -= 1;
    }
}
