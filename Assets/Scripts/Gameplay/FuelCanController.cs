using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls any spawned-in fuel cans. Increase ship's fuel if collide with it
/// and destory fuel can if it goes outside the screen.
/// </summary>
public class FuelCanController : MonoBehaviour
{
    // Fuel increase support
    private ShipMover shipMover;

    void Start()
    {
        shipMover = GameObject.FindGameObjectWithTag("Ship")
            .GetComponent<ShipMover>();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collided with ship
        if (collision.name == "Ship")
        {
            AudioManager.Play(AudioClipName.FuelCanPickup);

            // Increase fuel and destroy self.
            shipMover.CollectFuelCan();
            Destroy(gameObject);
        }
    }
}
