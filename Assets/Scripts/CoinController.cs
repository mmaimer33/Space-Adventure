using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float rotationSpeed;
    private Canvas canvas;

    // Start is called before the first frame update
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        rotationSpeed = 150;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    /// <summary>
    /// Destroys the object if it moves out of the screen without being collected.
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the coin is hit by the ship.
        if (collision.name == "Ship")
        {
            // Increment score
            canvas.IncrementCoins();

            // Destroy coin
            Destroy(gameObject);
        }
    }
}
