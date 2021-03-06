using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Listens for and handles on-click events from settings menu buttons.
/// </summary>
public class SettingsMenu : MonoBehaviour
{

    // Background volume support
    [SerializeField]
    private Slider backgroundVolumeSlider;

    // Audio volume support
    [SerializeField]
    private Slider audioVolumeSlider;

    // Difficulty button support
    [SerializeField]
    private Button difficultyButton;
    [SerializeField]
    private Sprite[] difficultySprites;
    private Image difficultyImage;
    private int currentDifficulty;

    // High score support
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    private const string highScoreTextPrefix = "Your highscore: ";

    void Start()
    {
        // Init background volume
        backgroundVolumeSlider.value = GameManager.BackgroundVolume;
        backgroundVolumeSlider.onValueChanged.
            AddListener(HandleBackgroundVolumeOnValueChanged);

        // Init audio volume
        audioVolumeSlider.value = GameManager.AudioVolume;
        audioVolumeSlider.onValueChanged.
            AddListener(HandleAudioVolumeOnValueChanged);

        // Init difficulty button
        currentDifficulty = GameManager.Difficulty;
        difficultyImage = difficultyButton.GetComponent<Image>();
        difficultyImage.sprite = difficultySprites[currentDifficulty];

        // Init high score text
        highScoreText.text = highScoreTextPrefix + GameManager.HighScore.ToString();
    }

    /// <summary>
    /// Handles the on-value-changed event of background volume slider:
    ///     Changes the background music volume.
    /// </summary>
    /// <param name="newValue"></param>
    public void HandleBackgroundVolumeOnValueChanged(float newValue)
    {
        GameManager.BackgroundVolume = newValue;
    }

    /// <summary>
    /// Handles the on-value-changed event of audio volume slider:
    ///     Changes the sound effects volume.
    /// </summary>
    /// <param name="newValue"></param>
    public void HandleAudioVolumeOnValueChanged(float newValue)
    {
        GameManager.AudioVolume = newValue;
    }

    /// <summary>
    /// Handles the on-click event of the difficulty button:
    ///     Cycles through the sprites and changes difficulty.
    /// </summary>
    public void HandleDifficultyButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);

        currentDifficulty++;
        RestrictDifficulty();
        difficultyImage.sprite = difficultySprites[currentDifficulty];
        GameManager.Difficulty = currentDifficulty;
    }

    private void RestrictDifficulty()
    {
        if (currentDifficulty > 2)
        {
            currentDifficulty = 0;
        }
    }

    /// <summary>
    /// Handles on-click event for save button:
    ///     Saves the GameManager's PlayerPrefs.
    /// </summary>
    public void HandleSaveButtonOnClick()
    {
        AudioManager.Play(AudioClipName.Button1);
        GameManager.SavePrefs();
        MenuManager.GoToMenu(MenuName.Main);
    }
}