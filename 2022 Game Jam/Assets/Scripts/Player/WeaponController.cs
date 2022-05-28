using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject playerModel;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public Collider attackCollider;
    public float colliderCooldown = 0.1f;
    public ParticleSystem particle;
    Animator anim;
    public ParticleSystem attackParticles;

    private void Start()
    {
        attackCollider.enabled = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                anim.SetTrigger("attack");
                canAttack = false;
            }
        }
    }

    public void staffAttack()
    {     
        attackCollider.enabled = true;
        StartCoroutine(resetColliderCooldown());
        StartCoroutine(resetAttackCooldown());
    }

    IEnumerator resetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        
    }

    IEnumerator resetColliderCooldown()
    {
        yield return new WaitForSeconds(colliderCooldown);
        attackCollider.enabled = false;
    }

    public void playParticle()
    {
        particle.Play();
    }

    public void playAttackParticle()
    {
        attackParticles.Play();
    }




}
