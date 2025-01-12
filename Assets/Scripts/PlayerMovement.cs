using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5f; // Initial speed
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier;
    public float minX = -2.5f; // Minimum x position
    public float maxX = 2.5f;  // Maximum x position

    public float speedIncreaseRate = 1f; // Speed increase rate per second

    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }

        // Increase speed over time
        speed += speedIncreaseRate * Time.fixedDeltaTime;

        // Calculate movement
        Vector3 forwardMove = speed * Time.fixedDeltaTime * transform.forward;
        Vector3 horizontalMove = horizontalInput * horizontalMultiplier * speed * Time.fixedDeltaTime * transform.right;

        // Combine forward and horizontal movement
        Vector3 newPosition = rb.position + forwardMove + horizontalMove;

        // Clamp the x position
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Apply the clamped position
        rb.MovePosition(newPosition);

        // Visual rotation based on horizontal input
        if (horizontalInput != 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, -horizontalInput * 30);
        }
    }

    private void Update()
    {
        // Get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
