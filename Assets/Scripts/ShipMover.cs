using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour
{
    #region Fields
    // For the ship
    private Rigidbody2D rb;

    // Fuel support
    private const int MaxFuel = 200;
    private const int MinFuel = 0;
    private int fuel;
    private Canvas canvas;

    // For forward motion
    [SerializeField]
    private float InitialSpeed = 5f;
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

    /// <summary>
    /// The amount of fuel the ship has, between 0 and 20;
    /// </summary>
    /// <value>The amount to set the fuel to.</value>
    public int Fuel
    {
        get { return fuel; }
        set { fuel = RestrictFuel(value); }
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
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        rb.AddForce(new Vector2(shipSpeed, 0), ForceMode2D.Impulse);
        direction = new Vector2();
        fuel = MaxFuel;

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

        if (Input.GetMouseButton(0))
        {
            if (fuel > MinFuel)
            {
                rb.AddForce(shipSpeed * direction, ForceMode2D.Force);
                rb.velocity = new Vector2(shipSpeed, direction.y);
                fuel--;
                fuel = RestrictFuel(fuel);
            }
        }
        else
        {
            fuel += 2;
            fuel = RestrictFuel(fuel);
        }

        // Update the fuel slider
        canvas.UpdateFuel(fuel);
    }

    private int RestrictFuel(int fuel)
    {
        if (fuel > MaxFuel)
        {
            return MaxFuel;
        }
        else if (fuel < MinFuel)
        {
            return MinFuel;
        }
        else
        {
            return fuel;
        }
    }

    #endregion
}
