using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    private Image selectedShipSkin;
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private ShipSkinManager shipSkinManager;

    void Update()
    {
        coinsText.text = GameManager.Coins.ToString();
        selectedShipSkin.sprite = shipSkinManager.GetSelectedShipSkin().sprite;
    }

    /// <summary>
    /// Handles on-click event of main menu button:
    ///     Goes to main menu.
    /// </summary>
    public void HandleHomeButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
