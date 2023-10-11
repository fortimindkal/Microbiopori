using UnityEngine;

public class PlayerSpringy : MonoBehaviour
{
    public float bounceForce = 10f; // Adjust the force as needed.
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply an upward force when a key (e.g., spacebar) is pressed.
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
