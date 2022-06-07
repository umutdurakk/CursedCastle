using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float KnifeSpeed = 10f;
    PlayerMovement player;
    float xSpeed;
    
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player =FindObjectOfType<PlayerMovement>(); 
        xSpeed = player.transform.localScale.x * KnifeSpeed;
        
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy2")
        {
            other.GetComponent<EnemyManager>().getDamage(1);
        }
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }

}

