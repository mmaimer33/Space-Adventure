using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    #region Fields

    // Coins Text
    [SerializeField]
    TextMeshProUGUI coinsText;
    private int coinsCollected;
    private const string coinsCollectedPrefix = "Coins Collected: ";

    // Fuel Bar
    [SerializeField]
    Slider fuelSlider;
    private const int MaxFuel = 200;

    // Score Text
    [SerializeField]
    TextMeshProUGUI scoreText;
    private int score;
    private const string scorePrefix = "Score: ";

    #endregion

    #region Properties

    public int CoinsCollected
    {
        get { return coinsCollected; }
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        // Initialize coins
        coinsCollected = 0;
        coinsText.text = coinsCollectedPrefix + coinsCollected.ToString();

        // Initialize score
        score = 0;
        scoreText.text = scorePrefix + score.ToString();
    }

    /// <summary>
    /// Increments the coins collected.
    /// </summary>
    public void IncrementCoins()
    {
        coinsCollected++;
        coinsText.text = coinsCollectedPrefix + coinsCollected.ToString();
    }

    /// <summary>
    /// Updates the score.
    /// </summary>
    /// <param name="scoreValue">New score.</param>
    public void UpdateScore(int scoreValue)
    {
        scoreText.text = scorePrefix + scoreValue.ToString();
    }

    /// <summary>
    /// Updates the fuel slider value.
    /// </summary>
    /// <param name="fuelValue">New fuel value,</param>
    public void UpdateFuel(int fuelValue)
    {
        fuelSlider.value = (float)fuelValue / (float)MaxFuel;
    }

    #endregion
}
