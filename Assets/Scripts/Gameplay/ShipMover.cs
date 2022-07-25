using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipMover : MonoBehaviour
{
    #region Fields
    // For the ship
    [SerializeField]
    private ShipSkinManager shipSkinManager;
    private Rigidbody2D rb;

    // Fuel support
    private float maxFuel;
    private const float MinFuel = 0f;
    private float fuel;
    private float fuelRefillRate;
    private Canvas canvas;

    // For forward motion
    private const float InitialSpeed = 5f;
    private float shipSpeed;

    // For rotation
    private Vector3 touchPosition;
    //private Vector3 mousePosition;
    private Vector2 direction;
    private float midY;

    // Score support
    private int score;

    // Pausing
    private bool paused;

    // Audio support
    private AudioSource rocketSound;

    // FRR slow down support
    Timer fuelTimer;

    // GameOver event support
    GameOverEvent gameOverEvent = new GameOverEvent();

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
    public float Fuel
    {
        get { return fuel; }
        set { fuel = RestrictFuel(value); }
    }

    /// <summary>
    /// True if ship is paused, false otherwise.
    /// </summary>
    public bool Paused
    {
        get { return paused; }
        set { paused = value; }
    }

    #endregion

    #region Methods
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shipSpeed = InitialSpeed;
        rocketSound = GetComponent<AudioSource>();
        maxFuel = GameManager.MaxFuel;
        fuelRefillRate = GameManager.FuelRefillRate;
    }

    /// <summary>
    /// Starts moving the ship.
    /// </summary>
    void Start()
    {
        // Set skin
        GetComponent<SpriteRenderer>().sprite = shipSkinManager.GetSelectedShipSkin().sprite;
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        midY = ScreenUtils.ScreenBottom + ((ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 2);

        rb.AddForce(new Vector2(shipSpeed, 0), ForceMode2D.Impulse);
        direction = new Vector2();
        fuel = maxFuel;
        score = 0;

        paused = false;

        fuelTimer = gameObject.AddComponent<Timer>();
        fuelTimer.Duration = 30;
        fuelTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // Slow down fuel refill rate.
        if (fuelTimer.Finished)
        {
            fuelRefillRate *= 0.95f;
        }

        if (Input.touchCount == 1)
        //if (Input.GetMouseButton(0))
        {
            // Gets the input position and makes the ship point that way.
            touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            direction.x = RestrictX(touchPosition.x - transform.position.x);
            direction.y = touchPosition.y - midY;

            //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //direction.x = RestrictX(mousePosition.x - transform.position.x);
            //direction.y = mousePosition.y - midY;

            transform.right = direction;

            // Play rocket sound
            if (!rocketSound.isPlaying)
            {
                rocketSound.volume = 1;
                rocketSound.Play();
            }
        }
        else if (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began)
        //else if (Input.GetMouseButtonDown(1))
        {
            // Open the pause menu if not already paused
            if (!paused)
            {
                rocketSound.volume = 0;
                rocketSound.Stop();
                paused = true;
                MenuManager.GoToMenu(MenuName.Pause);
            }
        }
        else
        {
            rocketSound.volume = 0;
            rocketSound.Stop();
            transform.right = direction;
        }
        direction.x = RestrictX(direction.x);
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
            fuel += fuelRefillRate;
            fuel = RestrictFuel(fuel);
        }

        // Update the fuel slider
        canvas.UpdateFuel(fuel);

        score = RestrictScore((int)transform.position.x);
        canvas.UpdateScore(score);
    }

    /// <summary>
    /// Called when ship collects a fuel can: Increases ship's fuel.
    /// </summary>
    public void CollectFuelCan()
    {
        fuel = RestrictFuel(fuel + 200);
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
    private float RestrictFuel(float fuel)
    {
        if (fuel > maxFuel)
        {
            return maxFuel;
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

    /// <summary>
    /// Adds a listener to the game over event.
    /// </summary>
    /// <param name="listener">Listener delegate to be added.</param>
    public void AddGameOverEventListener(UnityAction listener)
    {
        gameOverEvent.AddListener(listener);
    }

    /// <summary>
    /// Invokes the GameOver event.
    /// </summary>
    public void GameOver()
    {
        gameOverEvent.Invoke();
        rocketSound.volume = 0;
        rocketSound.Stop();
        MenuManager.GoToMenu(MenuName.GameOver);
        Destroy(this);
    }

    #endregion
}
