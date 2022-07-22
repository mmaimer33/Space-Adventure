using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    #region Fields

    // GameObjects
    [SerializeField]
    private GameObject[] asteroids;
    [SerializeField]
    private GameObject ship;

    // Spawning support
    private float frequency;
    private const float distanceFromShip = 20;

    // Location support
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;
    private Vector3 location;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        minY = ScreenUtils.ScreenBottom;
        maxY = ScreenUtils.ScreenTop;
        location = new Vector3();
        location.z = 0;

        frequency = GameManager.AsteroidSpawnFrequency;
        InvokeRepeating("SpawnAsteroid", 0.5f, frequency);
    }


    /// <summary>
    /// Spawns a new asteroid at a random but restricted location.
    /// </summary>
    private void SpawnAsteroid()
    {
        // Calculate min and max values for x-coordinate
        minX = ship.transform.position.x + distanceFromShip;
        maxX = minX + 10f;

        // Generate random location
        location.x = Random.Range(minX, maxX);
        location.y = Random.Range(minY, maxY);

        Instantiate<GameObject>(asteroids[Random.Range(0, asteroids.Length)],
            location, transform.rotation);
    }

    #endregion
}
