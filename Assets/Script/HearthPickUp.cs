using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthPickUp : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSfx;
    [SerializeField] int pointsForHearthPickup = 1;

    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToLife(pointsForHearthPickup);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
