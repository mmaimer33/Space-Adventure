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
        AudioManager.Play(AudioClipName.GameOver);
    }

    /// <summary>
    /// Handles home button on-click.
    /// </summary>
    public void HandleHomeButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
