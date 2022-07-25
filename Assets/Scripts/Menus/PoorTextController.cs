using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the Not Enough Coins text, destroying itself in some time.
/// </summary>
public class PoorTextController : MonoBehaviour
{
    Timer textTimer;

    // Start is called before the first frame update
    void Start()
    {
        textTimer = gameObject.AddComponent<Timer>();
        textTimer.Duration = 2;
        textTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (textTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
