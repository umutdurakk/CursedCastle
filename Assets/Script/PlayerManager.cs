using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float health;
   
    void Start()
    {

    }

 
    void Update()
    {

    }
    public void getDamage(float damage)
    {
        if (health - damage >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
    }
    void amIdead()
    {
        if (health == 0)
        {
            FindObjectOfType<GameSession>().TakeLife();
        }
    }
}
