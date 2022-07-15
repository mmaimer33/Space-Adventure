using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    private GameObject ship;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = ship.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ship.transform.position.x - offset, 0, transform.position.z);
    }
}
