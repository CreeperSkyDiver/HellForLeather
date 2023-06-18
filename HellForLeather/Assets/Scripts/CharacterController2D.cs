using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 5f;            // Movement speed of the character
    public float jumpForce = 5f;        // Force applied when jumping
    public float dashForce = 10f;       // Force applied when dashing
    public Transform groundCheck;       // Transform for checking ground contact
    public LayerMask groundLayer;       // Layer mask for the ground
    public float groundCheckRadius = 0.1f; // Radius for ground check
    public float boostMultiplier = 2f;  // Speed multiplier when boosting
    public int maxRings = 100;          // Maximum number of rings the character can hold

    private bool isGrounded;            // Flag to check if the character is grounded
    private bool isDashing;             // Flag to check if the character is dashing
    private bool isBoosting;            // Flag to check if the character is boosting
    private int rings;                  // Number of rings collected

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Handle dashing
        if (Input.GetButtonDown("Dash") && !isDashing)
        {
            isDashing = true;
            rb.velocity = new Vector2(moveInput * dashForce, rb.velocity.y);
            Invoke(nameof(ResetDash), 0.1f); // Reset isDashing after 0.1 second
        }

        // Handle boosting
        if (Input.GetButtonDown("Boost") && !isBoosting && rings > 0)
        {
            isBoosting = true;
            rb.velocity *= boostMultiplier;
            rings--;
            Invoke(nameof(ResetBoost), 1f); // Reset isBoosting after 1 second
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collect rings
        if (collision.CompareTag("Ring"))
        {
            rings++;
            Destroy(collision.gameObject);
        }
    }

    private void ResetDash()
    {
        isDashing = false;
    }

    private void ResetBoost()
    {
        isBoosting = false;
    }
}