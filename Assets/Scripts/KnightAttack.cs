using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KnightAttack : MonoBehaviour
{
    private Animator animator;           // Reference to the Animator component
    private bool canAttack = true;       // Flag to determine if the knight can attack
    private float attackTimer = 0.5f;    // Cooldown time between attacks

    public GameObject enemy; // Reference to the enemy GameObject

    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to the GameObject
    }

    void Update()
    {
        // Handle attack input
        HandleAttackInput();
    }

    private void HandleAttackInput()
    {
        if (canAttack && Input.GetMouseButton(0)) // Left mouse button (Mouse 1) triggers the attack
        {
            animator.SetBool("Attack", true);  // Start the attack animation
            canAttack = false;                 // Disable further attacks until cooldown ends
            StartCoroutine(AttackCooldown());  // Start cooldown for the next attack
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackTimer);
        animator.SetBool("Attack", false);     // End the attack animation after cooldown
        canAttack = true;                      // Allow attacking again
    }

    // This method will be called when the attack hitbox collides with an enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !canAttack) // Ensure the collided object is tagged as "Enemy"
        {
            Destroy(other.gameObject); // Destroy the enemy
            SceneManager.LoadScene("Win"); // Call to load Win scene
        }
    }
}
