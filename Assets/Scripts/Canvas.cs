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
        coinsCollected = 0;
        coinsText.text = coinsCollectedPrefix + coinsCollected.ToString();
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
    /// Updates the fuel slider value.
    /// </summary>
    /// <param name="fuelValue">New fuel value,</param>
    public void UpdateFuel(int fuelValue)
    {
        fuelSlider.value = (float)fuelValue / (float)MaxFuel;
    }

    #endregion
}
