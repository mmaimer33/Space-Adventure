using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Listens for and handles events from shop menu.
/// </summary>
public class ShopSkinItem : MonoBehaviour
{
    [SerializeField]
    private GameObject poorText;
    [SerializeField]
    private ShipSkinManager shipSkinManager;
    [SerializeField]
    private int shipSkinIndex;
    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private TextMeshProUGUI costText;

    private GameObject canvas;
    private ShipSkin shipSkin;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        shipSkin = shipSkinManager.shipSkins[shipSkinIndex];

        GetComponent<Image>().sprite = shipSkin.sprite;

        if (shipSkinManager.IsUnlocked(shipSkinIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            costText.text = shipSkin.cost.ToString();
        }
    }

    /// <summary>
    /// Handles on-click event of ship skin button:
    ///     Sets current skin if unlocked.
    /// </summary>
    public void HandleShipSkinOnClick()
    {
        if (shipSkinManager.IsUnlocked(shipSkinIndex))
        {
            shipSkinManager.SelectShipSkin(shipSkinIndex);
        }
    }

    /// <summary>
    /// Handles on-click event of buy button:
    ///     Checks if player has enough coins and unlocks skin if they do.
    /// </summary>
    public void HandleBuyButtonOnClick()
    {
        int coins = GameManager.Coins;
        if (coins >= shipSkin.cost && !shipSkinManager.IsUnlocked(shipSkinIndex)) {
            GameManager.Coins = coins - shipSkin.cost;
            shipSkinManager.Unlock(shipSkinIndex);
            buyButton.gameObject.SetActive(false);
            shipSkinManager.SelectShipSkin(shipSkinIndex);
            GameManager.SavePrefs();
        } else
        {
            Instantiate<GameObject>(poorText, canvas.transform);
        }
    }
}
