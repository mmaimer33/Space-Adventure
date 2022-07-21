using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game.
/// </summary>
public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        // Initialize ScreenUtils
        ScreenUtils.Initialize();
    }
}
