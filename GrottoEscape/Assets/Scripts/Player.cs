using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    // Config
    [SerializeField] private float maxSpeed = 1.5f;
    [SerializeField] private float jumpForce = 150f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private LayerMask layerGround;

    // State
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isJumping = false;

    // Cached
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    private void Awake () 
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start () 
    {
        
    }

    private void Update () 
    {
        isGrounded = Physics2D.Linecast (this.transform.position, groundCheck.position, layerGround);

        if (Input.GetButtonDown ("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate () 
    {
        float horizontal = Input.GetAxis ("Horizontal");
        rigidBody2D.velocity = new Vector2 (horizontal * maxSpeed, rigidBody2D.velocity.y);

        if ((horizontal > 0f && spriteRenderer.flipX) || (horizontal < 0f && !spriteRenderer.flipX))
        {
            Flip ();
        }

        if (isJumping)
        {
            rigidBody2D.AddForce (new Vector2 (0f, jumpForce));
            isJumping = false;
        }
    }

    //-----------------------------------------------------------------//
    // HELPER FUNCTIONS

    private void Flip ()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}