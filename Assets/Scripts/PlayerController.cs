using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;          // Speed of player movement
    public float jumpForce = 5f;          // Jump force
    public Transform groundCheck;         // Ground check reference
    public float groundCheckRadius = 0.2f; // Radius of the ground check circle
    public LayerMask groundLayer;         // Layer representing the ground

    private Rigidbody2D rb;               // Rigidbody2D component
    private bool isGrounded;              // Flag to check if player is on the ground
    private bool isJumping;               // Flag to track if the player is jumping

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when the player presses the jump button and is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;  // Set to true when player jumps
        }

        // Set isJumping to false if player is grounded
        if (isGrounded && rb.velocity.y <= 0)  // Only stop jumping when landing
        {
            isJumping = false;
        }

        // Call the method to flip the sprite based on movement direction
        FlipSprite(horizontalInput);
    }

    public bool GetJumpState()
    {
        return isJumping;  // This will return true when the player is jumping
    }

    // Method to get the horizontal movement for animation
    public float GetHorizontalMovement()
    {
        return Input.GetAxis("Horizontal") * moveSpeed;
    }

    // Method to flip the sprite based on movement direction
    private void FlipSprite(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            // Facing right
            transform.localScale = new Vector3(2, 2, 2); // Ensure the sprite faces right
        }
        else if (horizontalInput < 0)
        {
            // Facing left
            transform.localScale = new Vector3(-2, 2, 2); // Flip the sprite to face left
        }
    }

    // To visualize the ground check radius in the editor (optional)
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
