using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] private Transform prevRoom;
   [SerializeField] private Transform nextRoom;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                prevRoom.GetComponent<Room>().ActivateRoom(false);  
            }
            else
            {
                
                prevRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
        }
    }
}
