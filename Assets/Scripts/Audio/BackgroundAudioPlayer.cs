using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioPlayer : MonoBehaviour
{
    private int currentClipNumber;
    private const int numClips = 3;
    private int[] remaining = new int[numClips - 1];

    void Start()
    {
        currentClipNumber = Random.Range(0, numClips);
        BackgroundAudioManager.Play((BackgroundAudioClipName)currentClipNumber);
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (!BackgroundAudioManager.AudioSource.isPlaying)
        {
            switch (currentClipNumber)
            {
                case (0):
                    currentClipNumber = Random.Range(1, numClips);
                    break;

                case (1):
                    remaining[0] = 0;
                    remaining[1] = 2;
                    remaining[2] = 3;
                    currentClipNumber = remaining[Random.Range(0, numClips - 1)];
                    break;

                case (2):
                    remaining[0] = 0;
                    remaining[1] = 1;
                    remaining[2] = 3;
                    currentClipNumber = remaining[Random.Range(0, numClips - 1)];
                    break;

                case (3):
                    currentClipNumber = Random.Range(1, numClips);
                    break;
            }
            BackgroundAudioManager.Play((BackgroundAudioClipName)currentClipNumber);
        }
    }
}
