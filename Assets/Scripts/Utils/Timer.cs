using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fields

    // Timer duration
    private float totalSeconds = 0;

    // For timer execution
    private float elapsedSeconds = 0;
    private bool started = false;
    private bool running = false;

    #endregion

    #region Properties

    /// <summary>
    /// Sets the duration of the timer.
    /// Can only be set if timer is not running.
    /// </summary>
    /// <value>duration</value>
    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    /// <summary>
    /// Gets whether or not the timer has finished running.
    /// Returns false if timer has never started.
    /// </summary>
    public bool Finished
    {
        get { return started && !running; }
    }

    /// <summary>
    /// Gets whether the timer is currently running.
    /// </summary>
    public bool Running
    {
        get { return running; }
    }

    #endregion

    #region Methods

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }

    /// <summary>
    /// Runs the timer if duration is set to > 0.
    /// </summary>
    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    #endregion
}
