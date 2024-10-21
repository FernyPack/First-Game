using UnityEngine;

public class KnightMovie : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private PlayerController playerController; // Reference to PlayerController

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Find the PlayerController script in the same GameObject
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Set the Speed parameter based on the player's movement
        float speed = Mathf.Abs(playerController.GetHorizontalMovement());
        animator.SetFloat("Speed", speed);

        // Update JumpState based on whether the player is jumping
        bool jumping = playerController.GetJumpState();

        if (jumping)
        {
            animator.SetInteger("JumpState", 1);  // Changed to use a bool parameter for better control
        }
        else
        {
            animator.SetInteger("JumpState", 0);
        }
    }
}