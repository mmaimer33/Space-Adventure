using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour
{
    #region Fields
    // For the ship
    private Rigidbody2D rb;

    // For forward motion
    private const float InitialSpeed = 5f;
    private float shipSpeed;

    // For rotation
    //private Touch touch;
    //private Vector3 touchPosition;
    private Vector3 mousePosition;
    private Vector2 direction;

    #endregion

    #region Properties

    /// <summary>
    /// Represents the speed of the ship; gradually increases with progress.
    /// </summary>
    public float ShipSpeed
    {
        get { return shipSpeed; }
    }

    #endregion

    #region Methods
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shipSpeed = InitialSpeed;
    }

    /// <summary>
    /// Starts moving the ship.
    /// </summary>
    void Start()
    {
        rb.AddForce(new Vector2(shipSpeed, 0), ForceMode2D.Impulse);
        direction = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0)
        if (Input.GetMouseButton(0))
        {
            // Gets the input position and makes the ship point that way.
            //touch = Input.GetTouch(0);
            //touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            //direction.x = touchPosition.x - transform.position.x;
            //direction.y = touchPosition.y - transform.position.y;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
            direction.x = mousePosition.x - transform.position.x;
            direction.y = mousePosition.y - transform.position.y;

            transform.right = direction;
        }
    }

    // Frame-rate independent update
    void FixedUpdate()
    {
        // Moves the ship in the direction of the input, but with constant
        //  horizontal speed.

        rb.AddForce(shipSpeed * direction, ForceMode2D.Force);
        rb.velocity = new Vector2(shipSpeed, direction.y);
    }
    #endregion
}
