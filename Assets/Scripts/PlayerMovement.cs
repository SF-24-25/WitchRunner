using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier;

    private void FixedUpdate()
    {
        if (!alive)
        {

        }
        Vector3 forwardMove = speed * Time.fixedDeltaTime * transform.forward;
        Vector3 horizontalMove = horizontalInput * horizontalMultiplier * speed * Time.fixedDeltaTime * transform.right;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        if (horizontalInput > 0)
            rb.rotation = Quaternion.Euler(0, 0, -30);
        if (horizontalInput < 0)
            rb.rotation = Quaternion.Euler(0, 0, 30);
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
