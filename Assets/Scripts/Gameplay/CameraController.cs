using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject ship;
    private float offset;
    private Vector3 cameraMover;

    // Start is called before the first frame update
    void Start()
    {
        offset = ship.transform.position.x - transform.position.x;
        cameraMover = new Vector3();
        cameraMover.y = 0;
        cameraMover.z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMover.x = ship.transform.position.x - offset;
        transform.position = cameraMover;
    }
}
