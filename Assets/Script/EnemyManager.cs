using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float damage;

    bool playerCollider = false;
     void Start()
    {
        
    }
     void Update()
    {
        
    }
   /*  void OnTriggerEnter2D(Collider other)
    {
        if (other.tag =="Player" && !playerCollider)
        {
            playerCollider = true;
            other.GetComponent<PlayerManager>().getDamage(damage);
        }
       
       
    }*/
    public void getDamage(float damage)
    {
        if (health - damage >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            Destroy(gameObject);
        }
    }
   /* private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            playerCollider  =false;
        }
    }*/
}
