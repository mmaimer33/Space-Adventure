using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Listens for and handles on-click events from Main Menu buttons.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coinsCountText;

    void Start()
    {
        coinsCountText.text = GameManager.Coins.ToString();
    }

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

    /// <summary>
    /// Handles on-click event of settings button: goes to settings page.
    /// </summary>
    public void HandleSettingsButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);
        MenuManager.GoToMenu(MenuName.Settings);
    }

    /// <summary>
    /// Handles on-click event of tutorial button: goes to tutorial page.
    /// </summary>
    public void HandleTutorialButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button2);
        MenuManager.GoToMenu(MenuName.Tutorial);
    }

    /// <summary>
    /// Handles on-click event of credits button: goes to credits page.
    /// </summary>
    //public void HandleCreditsButtonOnClick()
    //{
    //    AudioManager.Play(AudioClipName.Button1);
    //    SceneManager.LoadScene("Credits");
    //}
}
