using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the player's movement speed in the Inspector.
    private Rigidbody2D rb;
    private float horizontalInput;

    // Variables for touch input.
    private Vector2 touchStartPos;
    private bool isSwiping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Handle touch input.
        HandleTouchInput();

        // Get horizontal input from the player (e.g., left and right arrow keys or A and D keys).
        // Only use this input if no swipe is detected.
        if (!isSwiping)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement to the player.
        Move(horizontalInput);
    }

    private void Move(float moveInput)
    {
        // Calculate the new velocity based on the input and speed.
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Apply the velocity to the player's Rigidbody.
        rb.velocity = movement;

        // You can also add jumping logic or other interactions here.
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    float swipeDeltaX = touch.position.x - touchStartPos.x;
                    horizontalInput = swipeDeltaX * 0.01f; // Adjust the sensitivity if needed.
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    horizontalInput = 0f;
                    break;
            }
        }
    }
}
