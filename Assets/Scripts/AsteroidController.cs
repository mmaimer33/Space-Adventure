using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region Fields

    // Cache Rigidbody2D, Vectors for movement.
    [SerializeField]
    private float maxRotationSpeed;

    private float rotationSpeed;

    private const float MinForce = 0.25f;
    private const float MaxForce = 0.6f;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // Get random direction
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        // Get random speed
        float magnitude = Random.Range(MinForce, MaxForce);

        // Move asteroid
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);

        // Get random rotation
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
    }

    // Rotate asteroid continuously.
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Destroy the asteroid if it leaves the screen.
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Trigger Game Over if collides with ship.
    /// </summary>
    /// <param name="collision">Provided by engine</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ship")
        {
            MenuManager.GoToMenu(MenuName.GameOver);
        }
    }

    #endregion
}
