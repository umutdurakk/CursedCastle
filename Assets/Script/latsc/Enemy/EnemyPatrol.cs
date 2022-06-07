using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftedge;
    [SerializeField] private Transform rightedge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initscale;
    private bool movingleft;


    [SerializeField]private Animator anim;

    private void Awake()
    {
        initscale = enemy.localScale;
       
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    private void Update()
    {
        if (movingleft)
        {
            if (enemy.position.x >= leftedge.position.x)    
        MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightedge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }
    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        movingleft = !movingleft;
    }
    private void MoveInDirection(int _direction)
    {
        anim.SetBool("moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x)*_direction,initscale.y,initscale.z);


        //bir doðrultu da düþmanýn ilerlemesi
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

}
