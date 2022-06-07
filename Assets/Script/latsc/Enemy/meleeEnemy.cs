using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField]private float attackCooldown;
    [SerializeField]private float range;
    [SerializeField]private int damage;

    [Header("Collider Parameters")]
    [SerializeField]private float colliderDistances;
    [SerializeField] private BoxCollider2D boxcollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;


    private Health playerHealth; 
    private Animator anim;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>(); ;
    }
   
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
            cooldownTimer = 0;
            anim.SetTrigger("meleeAttack");
             }

        }
        if (enemyPatrol !=null)
        {
            enemyPatrol.enabled = !PlayerSight();
        }

    }
    private bool PlayerSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * range*transform.localScale.x * colliderDistances,
            new Vector3(boxcollider.bounds.size.x * range,boxcollider.bounds.size.y, boxcollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if (hit.collider !=null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null ;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right*range*transform.localScale.x * colliderDistances, new Vector3(boxcollider.bounds.size.x * range,
            boxcollider.bounds.size.y, boxcollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (PlayerSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
