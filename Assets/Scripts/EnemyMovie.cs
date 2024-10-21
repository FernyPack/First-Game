using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovie : MonoBehaviour
{
    public Transform player;          // Reference to the player's transform
    public float speed = 2f;          // Speed at which the enemy moves
    public float detectionRange = 3f; // Distance at which the enemy detects the player
    public float attackRange = 1f;    // Range at which the enemy will attack

    private Animator animator;        // Reference to the Animator component

    void Start()
    {
        // Get the components attached to the enemy
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player exists and is within detection range
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceToPlayer <= attackRange)
            {
                // Attack player if within attack range
                AttackPlayer();
            }
            else if (distanceToPlayer <= detectionRange)
            {
                // Move toward the player if within detection range but not attack range
                FollowPlayer();
            }
        }
    }

    // Follow the player
    void FollowPlayer()
    {
        // Calculate direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the enemy toward the player
        transform.position += direction * speed * Time.deltaTime;

        // Adjust the facing direction of the enemy
        if (direction.x > 0)
            transform.localScale = new Vector3(4, 4, 4);  // Face right
        else if (direction.x < 0)
            transform.localScale = new Vector3(-4, 4, 4);  // Face left

        // Reset attack animation
        animator.SetBool("isAttacking", false);
    }

    // Attack the player
    void AttackPlayer()
    {
        // Set the attack animation
        animator.SetBool("isAttacking", true);

        // Destroy the player when the attack animation is triggered
        if (player != null)
        {
            Destroy(player.gameObject); // Destroy the player GameObject
            SceneManager.LoadScene("Lose"); // Call to load Lose scene immediately after
        }
    }
}
