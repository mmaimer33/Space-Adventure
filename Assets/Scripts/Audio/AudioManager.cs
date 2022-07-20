using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    #region Fields

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets whether or not the audio manager has been initialized.
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the audio manager.
    /// </summary>
    /// <param name="source"></param>
    public static void Initialize(AudioSource source)
    {
        audioSource = source;

        audioClips.Add(AudioClipName.Background1, Resources.Load<AudioClip>("Background1"));
        audioClips.Add(AudioClipName.Background2, Resources.Load<AudioClip>("Background2"));
        audioClips.Add(AudioClipName.Background3, Resources.Load<AudioClip>("Background3"));
        audioClips.Add(AudioClipName.Button1, Resources.Load<AudioClip>("Button1"));
        audioClips.Add(AudioClipName.Button2, Resources.Load<AudioClip>("Button2"));
        audioClips.Add(AudioClipName.ButtonPlay, Resources.Load<AudioClip>("ButtonPlay"));
        audioClips.Add(AudioClipName.CoinPickup1, Resources.Load<AudioClip>("CoinPickup1"));
        audioClips.Add(AudioClipName.CoinPickup2, Resources.Load<AudioClip>("CoinPickup2"));
        audioClips.Add(AudioClipName.GameOver, Resources.Load<AudioClip>("GameOver"));
        audioClips.Add(AudioClipName.NewHighscore, Resources.Load<AudioClip>("NewHighscore"));
        audioClips.Add(AudioClipName.Rocket, Resources.Load<AudioClip>("Rocket"));
        audioClips.Add(AudioClipName.RocketNoFuel, Resources.Load<AudioClip>("RocketNoFuel"));
        audioClips.Add(AudioClipName.ScoreMarker, Resources.Load<AudioClip>("ScoreMarker"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    #endregion
}
