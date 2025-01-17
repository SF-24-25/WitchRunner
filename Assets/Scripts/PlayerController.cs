using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private float speed = 5f; // Initial speed
    float horizontalInput;
    public float horizontalMultiplier;

    public float minX = -2.5f; // Minimum x position
    public float maxX = 2.5f;

    private void FixedUpdate()
    {
        Vector3 horizontalMove = horizontalInput * horizontalMultiplier * speed * Time.fixedDeltaTime * transform.right;
        Vector3 newPosition = rb.position + horizontalMove;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Apply the clamped position
        rb.MovePosition(newPosition);



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
