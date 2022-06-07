using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
   void OnAttack(InputValue value)
    {
        Attack();
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag =="Enemy2")
            {
                enemy.GetComponent<EnemyManager>().getDamage(1);
            }
            else if (enemy.tag == "Enemy")
            {
                Destroy(enemy.gameObject);
            }
            
        }
    
    
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint ==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
