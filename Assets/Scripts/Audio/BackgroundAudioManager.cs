using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager for background audio only.
/// </summary>
public static class BackgroundAudioManager
{
    #region Fields

    private static bool initialized = false;
    private static AudioSource audioSource;
    private static Dictionary<BackgroundAudioClipName, AudioClip> audioClips =
        new Dictionary<BackgroundAudioClipName, AudioClip>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets whether or not the audio manager has been initialized.
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Gets the manager's audio source.
    /// </summary>
    public static AudioSource AudioSource
    {
        get { return audioSource; }
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

        audioClips.Add(BackgroundAudioClipName.Background1, Resources.Load<AudioClip>("Background1"));
        audioClips.Add(BackgroundAudioClipName.Background2, Resources.Load<AudioClip>("Background2"));
        audioClips.Add(BackgroundAudioClipName.Background3, Resources.Load<AudioClip>("Background3"));
        audioClips.Add(BackgroundAudioClipName.Background4, Resources.Load<AudioClip>("Background4"));

        initialized = true;
    }

    /// <summary>
    /// Plays the given background audio clip.
    /// </summary>
    /// <param name="name">BackgroundAudioClip (enum) to play.</param>
    public static void Play(BackgroundAudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    /// <summary>
    /// Changes the volume of the background audio.
    /// </summary>
    /// <param name="volume">New volume.</param>
    public static void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    #endregion
}
