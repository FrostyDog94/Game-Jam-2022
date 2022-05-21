using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ENEMY_STATE
{
    ALIVE,
    DEAD,
    UNDEAD
};
public class Enemy : MonoBehaviour
{
    public ENEMY_STATE currentState = ENEMY_STATE.ALIVE;
    public float health = 100f;
    public bool resurrected;
    public Renderer rend;
    public NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(State_Alive());
    }

    void Update()
    {
        
    }

    public IEnumerator State_Alive()
    {
        currentState = ENEMY_STATE.ALIVE;

        while(currentState == ENEMY_STATE.ALIVE) 
        {
            if(health <= 0)
            {
                StartCoroutine(State_Dead());
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator State_Dead()
    {
        currentState = ENEMY_STATE.DEAD;
        rend.material.color = Color.green;
        while(currentState == ENEMY_STATE.DEAD)
        {
            if(resurrected)
            {
                StartCoroutine(State_Undead());
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator State_Undead()
    {
        currentState = ENEMY_STATE.UNDEAD;
        rend.material.color = Color.blue;
        while(currentState == ENEMY_STATE.UNDEAD)
        {
            // Follow and attack enemies

            yield return null;
        }
    }
}
