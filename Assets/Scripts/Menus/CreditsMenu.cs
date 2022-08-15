using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    /// <summary>
    /// Handles on-click event of back button:
    ///     Goes to main menu.
    /// </summary>
    public void HandleBackButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
