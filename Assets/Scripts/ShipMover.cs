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

    // Score support
    private int score;

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
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount == 1)
        if (Input.GetMouseButton(0))
        {
            // Gets the input position and makes the ship point that way.
            //touch = Input.GetTouch(0);
            //touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            //direction.x = touchPosition.x - transform.position.x;
            //direction.y = touchPosition.y - transform.position.y;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
            direction.x = RestrictX(mousePosition.x - transform.position.x);
            direction.y = mousePosition.y - transform.position.y;

            transform.right = direction;
        }
        //else if (Input.touchCount == 2 &&
        //    Input.GetTouch(2).phase == TouchPhase.Began)
        else if (Input.GetMouseButtonDown(1))
        {
            // Open the pause menu
            MenuManager.GoToMenu(MenuName.Pause);
        }
        else
        {
            direction.x = RestrictX(direction.x);
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

        score = RestrictScore((int)transform.position.x);
        canvas.UpdateScore(score);
    }

    /// <summary>
    /// Restricts the direction of the ship to a reasonable range.
    /// </summary>
    /// <param name="originalX">Calculated x direction.</param>
    /// <returns>Restricted x direction.</returns>
    private float RestrictX(float originalX)
    {
        if (originalX < 0.1f)
        {
            return 0.1f;
        }
        else
        {
            return originalX;
        }
    }

    /// <summary>
    /// Restricts the score so it is always above 0.
    /// </summary>
    /// <param name="score">Current score.</param>
    /// <returns>Restricted score.</returns>
    private int RestrictScore(int score)
    {
        if (score < 0)
        {
            return 0;
        }
        return score;
    }

    /// <summary>
    /// Ensures the fuel value does not exceed range.
    /// </summary>
    /// <param name="fuel">Original fuel value.</param>
    /// <returns>Restricted fuel value.</returns>
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
