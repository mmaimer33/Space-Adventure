using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    private GameObject canvas;

    [SerializeField]
    private GameObject poorText;
    [SerializeField]
    private Image selectedShipSkin;
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private ShipSkinManager shipSkinManager;
    [SerializeField]
    private TextMeshProUGUI fuelLevelText;
    [SerializeField]
    private Button fuelLevelButton;
    [SerializeField]
    private TextMeshProUGUI fuelLevelCostText;
    private int currentFuelLevel;
    private const string FuelLevelPrefix = "Fuel Level: ";
    private int[] FuelUpgradeCosts = { 0, 50, 80, 100 };

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        currentFuelLevel = GameManager.FuelLevel;
    }

    void Update()
    {
        coinsText.text = GameManager.Coins.ToString();
        selectedShipSkin.sprite = shipSkinManager.GetSelectedShipSkin().sprite;
        fuelLevelText.text = FuelLevelPrefix + GameManager.FuelLevel.ToString();
        if (currentFuelLevel == 3)
        {
            fuelLevelCostText.text = "Max";
        }
        else
        {
            fuelLevelCostText.text = "Upgrade for " +
                FuelUpgradeCosts[currentFuelLevel + 1].ToString();
        }
    }

    /// <summary>
    /// Handles on-click event of main menu button:
    ///     Goes to main menu.
    /// </summary>
    public void HandleHomeButtonOnClick()
    {
        GameManager.SavePrefs();
        AudioManager.Play(AudioClipName.Button1);
        MenuManager.GoToMenu(MenuName.Main);
    }

    /// <summary>
    /// Handles on-click event of fuel level button:
    ///     Upgrades if possible, provides message otherwise.
    /// </summary>
    public void HandleFuelLevelButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);
        if (GameManager.FuelLevel != 3)
        {
            if (GameManager.Coins >= FuelUpgradeCosts[currentFuelLevel + 1])
            {
                GameManager.Coins -= FuelUpgradeCosts[currentFuelLevel + 1];
                GameManager.FuelLevel++;
                GameManager.SavePrefs();
                currentFuelLevel++;
            }
            else
            {
                Instantiate<GameObject>(poorText, canvas.transform);
            }
        }
    }
}
