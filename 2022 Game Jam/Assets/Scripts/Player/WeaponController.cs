using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Staff;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public Collider attackCollider;
    public float colliderCooldown = 0.1f;

    private void Start()
    {
        attackCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                staffAttack();
            }
        }
    }

    public void staffAttack()
    {
        canAttack = false;
        Animator anim = Staff.GetComponent<Animator>();
        anim.SetTrigger("Attack");
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




}
