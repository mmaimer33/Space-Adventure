using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawner script for FuelCans.
/// </summary>
public class FuelCanSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private GameObject fuelCan;
    [SerializeField]
    private GameObject ship;

    private Timer spawnTimer;
    private float fuelCanSpawnChance;

    private float minY;
    private float maxY;
    private Vector3 fuelCanPosition;

    private const float DistanceFromShip = 20f;

    #endregion

    #region Methods

    void Start()
    {
        fuelCanSpawnChance = GameManager.FuelCanSpawnChance;
        minY = ScreenUtils.ScreenBottom + 1;
        maxY = ScreenUtils.ScreenTop - 1;
        fuelCanPosition = new Vector3();
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 15;
        spawnTimer.Run();
    }

    void Update()
    {
        if (spawnTimer.Finished)
        {
            if (Random.value <= fuelCanSpawnChance)
            {
                SpawnFuelCan();
            }
            spawnTimer.Run();
        }
    }

    /// <summary>
    /// Spawns in a fuel can in between the min and max Y values.
    /// </summary>
    private void SpawnFuelCan()
    {
        fuelCanPosition.x = ship.transform.position.x + DistanceFromShip;
        fuelCanPosition.y = Random.Range(minY, maxY);

        Instantiate<GameObject>(fuelCan, fuelCanPosition, transform.rotation);
    }

    #endregion
}
