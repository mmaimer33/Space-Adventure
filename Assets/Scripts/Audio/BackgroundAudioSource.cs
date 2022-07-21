using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioSource : MonoBehaviour
{
    void Awake()
    {
        if (!BackgroundAudioManager.Initialized)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            BackgroundAudioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
