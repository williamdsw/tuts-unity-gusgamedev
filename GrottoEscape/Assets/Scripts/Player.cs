using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;

    // State
    private bool isGrounded;
    private bool isJumping;

    // Cached
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
}