using UnityEngine;

public class InstantStopMovementWithRigidbody : MonoBehaviour
{
    public float speed = 5f;  // Movement speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Apply movement
        Move(moveDirection);
    }

    void Move(Vector3 moveDirection)
    {
        // Set the Rigidbody's velocity directly
        rb.velocity = moveDirection * speed;
    }
}