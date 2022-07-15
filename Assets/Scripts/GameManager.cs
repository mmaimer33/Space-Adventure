using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    static TextMeshProUGUI coinsText;

    private static int coinsCollected;
    private static int score;
    #endregion

    #region Properties
    /// <summary>
    /// Keeps track of how many coins the ship collects.
    /// </summary>
    public static int CoinsCollected
    {
        get { return coinsCollected; }
    }

    /// <summary>
    /// Keeps track of the game score.
    /// </summary>
    public static int Score
    {
        get { return score; }
        set { score = value; }
    }
    #endregion

    #region Methods

    // Awake is called before start
    void Awake()
    {
        // Initialize Screen Utils
        ScreenUtils.Initialize();
        InitializeGame();
    }

    /// <summary>
    /// Initializes the game, setting coins and score to 0.
    /// </summary>
    static void InitializeGame()
    {
        coinsCollected = 0;
        score = 0;
        coinsText.text = "Coins Collected: " + coinsCollected.ToString();
    }

    /// <summary>
    /// Increments the coins collected.
    /// </summary>
    public static void IncrementCoins()
    {
        coinsCollected++;
        coinsText.text = "Coins Collected: " + coinsCollected.ToString();
    }

    #endregion
}
