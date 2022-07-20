using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides screen sizes, coordinates.
/// </summary>
public class ScreenUtils : MonoBehaviour
{
    #region Fields

    static int screenWidth;
    static int screenHeight;

    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the left edge of the screen in world coordinates.
    /// </summary>
    public static float ScreenLeft
    {
        get
        {
            CheckScreenSizeChanged();
            return screenLeft;
        }
    }

    /// <summary>
    /// Gets the right edge of the screen in world coordinates.
    /// </summary>
    public static float ScreenRight
    {
        get
        {
            CheckScreenSizeChanged();
            return screenRight;
        }
    }

    /// <summary>
    /// Gets the top edge of the screen in world coordinates.
    /// </summary>
    public static float ScreenTop
    {
        get
        {
            CheckScreenSizeChanged();
            return screenTop;
        }
    }

    /// <summary>
    /// Gets the bottom of the screen in world coordinates.
    /// </summary>
    public static float ScreenBottom
    {
        get
        {
            CheckScreenSizeChanged();
            return screenBottom;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes ScreenUtils fields.
    /// </summary>
    public static void Initialize()
    {
        // Support for resolution changes.
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Saves screen edges in world coordinates.
        float screenZ = -Camera.main.transform.position.z;
        Vector3 bottomLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 topRightCornerScreen =
            new Vector3(screenWidth, screenHeight, screenZ);

        Vector3 bottomLeftCornerWorld =
            Camera.main.ScreenToWorldPoint(bottomLeftCornerScreen);
        Vector3 topRightCornerWorld =
            Camera.main.ScreenToWorldPoint(topRightCornerScreen);

        screenLeft = bottomLeftCornerWorld.x;
        screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        screenBottom = bottomLeftCornerWorld.y;
    }

    static void CheckScreenSizeChanged()
    {
        if (screenWidth != Screen.width ||
            screenHeight != Screen.height)
        {
            Initialize();
        }
    }

    #endregion
}
