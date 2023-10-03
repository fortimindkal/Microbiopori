using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the player's movement speed in the Inspector.
    private Rigidbody2D rb;
    private float horizontalInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input from the player (e.g., left and right arrow keys or A and D keys).
        horizontalInput = Input.GetAxis("Horizontal");
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
}
