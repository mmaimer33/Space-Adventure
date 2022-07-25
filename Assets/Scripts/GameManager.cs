using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private const float DefaultVolume = 0.5f;
    private static Dictionary<int, float[]> DifficultyValues =
        new Dictionary<int, float[]>
    {
        { 0, new float[2] {1.5f, 1.5f} },
        { 1, new float[2] {1f, 1f} },
        { 2, new float[2] {0.6f, 0.5f } }
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
            AsteroidSpawnFrequency = DifficultyValues[value][0];
            FuelRefillRate = DifficultyValues[value][1];
        }
    }

    /// <summary>
    /// Gets and sets the spawning frequency of asteroids.
    /// </summary>
    public static float AsteroidSpawnFrequency
    {
        get { return PlayerPrefs.GetFloat("AsteroidSpawnFrequency",
            DifficultyValues[1][0]); }
        set
        {
            PlayerPrefs.SetFloat("AsteroidSpawnFrequency", value);
        }
    }

    /// <summary>
    /// Gets and sets the fuel refill rate of the ship.
    /// </summary>
    public static float FuelRefillRate
    {
        get { return PlayerPrefs.GetFloat("FuelRefillRate",
            DifficultyValues[1][1]); }
        set
        {
            PlayerPrefs.SetFloat("FuelRefillRate", value);
        }
    }

    public static int ShipSkinIndex
    {
        get { return PlayerPrefs.GetInt("ShipSkinIndex", 0); }
        set
        {
            PlayerPrefs.SetInt("ShipSkinIndex", value);
        }
    }

    public static float FuelCanFrequency
    {
        get { return PlayerPrefs.GetFloat("FuelCanFrequency", 50); }
        set
        {
            PlayerPrefs.SetFloat("FuelCanFrequency", value);
        }
    }

    /// <summary>
    /// Saves PlayerPrefs.
    /// </summary>
    public static void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
