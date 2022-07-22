using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    /// <summary>
    /// Handles on-click event of back button:
    ///     Goes to main menu.
    /// </summary>
    public void HandleBackButtonOnClick()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
