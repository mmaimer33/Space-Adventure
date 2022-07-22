using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipSkinManager", menuName = "Ship Skin Manager")]
public class ShipSkinManager : ScriptableObject
{
    [SerializeField]
    public ShipSkin[] shipSkins;
    private const string Prefix = "ShipSkin_";

    /// <summary>
    /// Sets the skin index as given in the GameManager
    /// </summary>
    /// <param name="shipSkinIndex">ShipSkin index to select</param>
    public void SelectShipSkin(int shipSkinIndex)
    {
        GameManager.ShipSkinIndex = shipSkinIndex;
    }

    /// <summary>
    /// Returns the ShipSkin selected if it exists.
    /// </summary>
    /// <returns>Current ShipSkin</returns>
    public ShipSkin GetSelectedShipSkin()
    {
        int shipSkinIndex = GameManager.ShipSkinIndex;
        if (shipSkinIndex >= 0 && shipSkinIndex < shipSkins.Length)
        {
            return shipSkins[shipSkinIndex];
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Unlocks the skin at a given index.
    /// </summary>
    /// <param name="shipSkinIndex">Index of skin to be unlocked.</param>
    public void Unlock(int shipSkinIndex)
    {
        PlayerPrefs.SetInt(Prefix + shipSkinIndex, 1);
    }

    /// <summary>
    /// Returns true if a skin has been unlocked, false otherwise.
    /// </summary>
    /// <param name="shipSkinIndex">Index to check</param>
    /// <returns>true or false as above</returns>
    public bool IsUnlocked(int shipSkinIndex)
    {
        return PlayerPrefs.GetInt(Prefix + shipSkinIndex, 0) == 1;
    }
}
