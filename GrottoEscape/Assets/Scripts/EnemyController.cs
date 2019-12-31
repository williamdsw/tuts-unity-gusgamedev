using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    // Config
    [SerializeField] private int health;
    [SerializeField] private int moveSpeed;

    // State
    protected bool isMoving = false;

    // Cached
    protected Rigidbody2D rigidBody2D;
    protected Animator animator;
    protected Transform player;

    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    private void Awake () 
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        player = GameObject.Find ("Player").GetComponent<Transform>();
    }
}