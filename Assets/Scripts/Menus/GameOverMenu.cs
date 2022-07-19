using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles game over menu on-click events.
/// </summary>
public class GameOverMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Handles home button on-click.
    /// </summary>
    public void HandleHomeButtonOnClick()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
