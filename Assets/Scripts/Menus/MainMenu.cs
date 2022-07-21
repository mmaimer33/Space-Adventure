using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for and handles. on-click events from Main Menu buttons.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Handles on-click event of play button: starts the game.
    /// </summary>
    public void HandlePlayButtonOnClick()
    {
        AudioManager.Play(AudioClipName.ButtonPlay);
        SceneManager.LoadScene("Gameplay");
    }

    /// <summary>
    /// Handles on-click event of quit button: quits the app.
    /// </summary>
    public void HandleQuitButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);
        Application.Quit();
    }
}
