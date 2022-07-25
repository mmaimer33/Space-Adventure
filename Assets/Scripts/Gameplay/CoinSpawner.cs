using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawner script for coins.
/// </summary>
public class CoinSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private GameObject ship;

    private float frequency;
    private float minY;
    private float maxY;
    private Vector3 coinPosition;

    private const float DistanceFromShip = 20f;
    private const float HalfSpawnRange = 4f;

    #endregion

    #region Properties

    /// <summary>
    /// Controls how often a coin will spawn. Dependent on ship speed.
    /// </summary>
    public float Frequency
    {
        get { return frequency; }
        set { frequency = value; }
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        frequency = 1.25f;
        minY = ScreenUtils.ScreenBottom + 1;
        maxY = ScreenUtils.ScreenTop - 1;
        coinPosition = new Vector3();
        InvokeRepeating("SpawnCoin", 1, frequency);
    }

    /// <summary>
    /// Spawns in a coin between the min and max values, a range of roughly
    /// a fifth of the screen around the last spawned coin.
    /// </summary>
    private void SpawnCoin()
    {
        coinPosition.x = ship.transform.position.x + DistanceFromShip;
        coinPosition.y = RestrictY(Random.Range(minY, maxY));
        Instantiate<GameObject>(coin, coinPosition, transform.rotation);
        minY = RestrictY(coinPosition.y - HalfSpawnRange);
        maxY = RestrictY(coinPosition.y + HalfSpawnRange);
    }

    /// <summary>
    /// Ensures the coins don't spawn outside the screen by restricting
    ///     the y-position so it is in range of ScreenTop and ScreenBottom.
    /// </summary>
    /// <param name="originalY">The randomly calculated Y position.</param>
    /// <returns>The restricted Y position,
    ///     roughly between screen top and bottom</returns>
    private float RestrictY(float originalY)
    {
        if (originalY > ScreenUtils.ScreenTop - 1)
        {
            return ScreenUtils.ScreenTop - 1;
        }
        else if (originalY < ScreenUtils.ScreenBottom + 1)
        {
            return ScreenUtils.ScreenBottom + 1;
        }
        else
        {
            return originalY;
        }
    }

    #endregion
}
