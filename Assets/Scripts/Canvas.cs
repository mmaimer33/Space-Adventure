using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    #region Fields

    [SerializeField]
    TextMeshProUGUI coinsText;

    private int coinsCollected;
    private const string coinsCollectedPrefix = "Coins Collected: ";

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
    #endregion
}
