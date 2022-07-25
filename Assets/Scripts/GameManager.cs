using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private const float DefaultVolume = 0.5f;

    /// <summary>
    /// Provides difficulty support. For each difficulty (0 to 2),
    /// the key array values are as follows:
    ///     [0]: AsteroidSpawnFrequency
    ///     [1]: FuelRefillRate
    /// </summary>
    private static Dictionary<int, float[]> DifficultyValues =
        new Dictionary<int, float[]>
    {
        { 0, new float[2] {1.75f, 1.5f} },
        { 1, new float[2] {1.2f, 1f} },
        { 2, new float[2] {0.8f, 0.7f } }
    };

    /// <summary>
    /// Provides fuel support. For each fuel level (0 to 3),
    /// the key array values are as follows:
    ///     [0]: MaxFuelCapacity
    ///     [1]: FuelCanSpawnChance
    /// </summary>
    private static Dictionary<int, float[]> FuelValues =
        new Dictionary<int, float[]>
        {
            { 0, new float[2] {250f, 0.7f} },
            { 1, new float[2] {300f, 0.75f} },
            { 2, new float[2] {350f, 0.8f} },
            { 3, new float[2] {400f, 0.85f} }
        };

    /// <summary>
    /// Gets and sets the player's Highscore.
    /// </summary>
    public static int HighScore
    {
        get { return PlayerPrefs.GetInt("HighScore", 0); }
        set
        {
            PlayerPrefs.SetInt("HighScore", value);
        }
    }

    /// <summary>
    /// Gets and sets the number of coins the player has.
    /// </summary>
    public static int Coins
    {
        get { return PlayerPrefs.GetInt("Coins", 0); }
        set
        {
            PlayerPrefs.SetInt("Coins", value);
        }
    }

    /// <summary>
    /// Gets and sounds the background music sound in PlayerPrefs.
    /// Gets a default value of 0.5.
    /// </summary>
    public static float BackgroundVolume
    {
        get { return PlayerPrefs.GetFloat("BackgroundVolume", DefaultVolume); }
        set
        {
            PlayerPrefs.SetFloat("BackgroundVolume", value);

            // Change the background volume.
            BackgroundAudioManager.ChangeVolume(
                PlayerPrefs.GetFloat("BackgroundVolume"));
        }
    }

    /// <summary>
    /// Gets and sets the sound effect volume in PlayerPrefs.
    /// Get returns a default value of 0.5.
    /// </summary>
    public static float AudioVolume
    {
        get { return PlayerPrefs.GetFloat("AudioVolume", DefaultVolume); }
        set
        {
            PlayerPrefs.SetFloat("AudioVolume", value);

            // Change the audio volume.
            AudioManager.ChangeVolume(PlayerPrefs.GetFloat("AudioVolume"));
        }
    }

    public static int Difficulty
    {
        get { return PlayerPrefs.GetInt("Difficulty", 1); }
        set
        {
            PlayerPrefs.SetInt("Difficulty", value);
        }
    }

    /// <summary>
    /// Gets and sets the spawning frequency of asteroids.
    /// </summary>
    public static float AsteroidSpawnFrequency
    {
        get { return DifficultyValues[Difficulty][0]; }
    }

    /// <summary>
    /// Gets and sets the fuel refill rate of the ship.
    /// </summary>
    public static float FuelRefillRate
    {
        get { return DifficultyValues[Difficulty][1]; }
    }

    /// <summary>
    /// Gets and sets the index of the current skin.
    /// </summary>
    public static int ShipSkinIndex
    {
        get { return PlayerPrefs.GetInt("ShipSkinIndex", 0); }
        set
        {
            PlayerPrefs.SetInt("ShipSkinIndex", value);
        }
    }

    /// <summary>
    /// Gets and sets the FuelLevel.
    /// </summary>
    public static int FuelLevel
    {
        get { return PlayerPrefs.GetInt("FuelLevel", 0); }
        set
        {
            PlayerPrefs.SetInt("FuelLevel", value);
        }
    }

    public static float MaxFuel
    {
        get { return FuelValues[FuelLevel][0]; }
    }

    /// <summary>
    /// Gets and sets the fuel cans spawning chance.
    /// </summary>
    public static float FuelCanSpawnChance
    {
        get { return FuelValues[FuelLevel][1]; }
    }

    /// <summary>
    /// Saves PlayerPrefs.
    /// </summary>
    public static void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
