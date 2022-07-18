using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pauses and unpauses the game when pause button is clicked.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Pauses the game, since the method is called when the menu opens.
    /// </summary>
    void Start()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Handles event when resume button is clicked.
    /// </summary>
    public void HandleResumeButtonOnClick()
    {
        // Unpause game and destroy self.
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleHomeButtonOnClick()
    {
        // Unpause game and return to Home.
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
