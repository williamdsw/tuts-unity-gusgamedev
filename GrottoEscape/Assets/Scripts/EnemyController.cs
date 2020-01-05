using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    // Config
    protected int health;
    [SerializeField] private int moveSpeed;
    protected float distanceToAttack;

    // State
    [SerializeField] protected bool isMoving = false;

    // Cached
    protected Rigidbody2D rigidBody2D;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Transform player;

    //-----------------------------------------------------------------//
    // GETTERS / SETTERS

    public int GetHealth ()
    {
        return this.health;
    }

    public void SetHealth (int health)
    {
        this.health = health;
    }

    public int GetMoveSpeed ()
    {
        return this.moveSpeed;
    }

    public void SetMoveSpeed (int moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public float GetDistanceToAttack ()
    {
        return this.distanceToAttack;
    }

    public void SetDistanceToAttack (float distanceToAttack)
    {
        this.distanceToAttack = distanceToAttack;
    }

    public bool GetIsMoving ()
    {
        return this.isMoving;
    }

    public void SetIsMoving (bool isMoving)
    {
        this.isMoving = isMoving;
    }

    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    private void Awake () 
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        player = GameObject.Find ("Player").GetComponent<Transform>();
    }

    //-----------------------------------------------------------------//
    // HELPER FUNCTIONS

    protected float CalculatePlayerDistance ()
    {
        return Vector2.Distance (player.position, this.transform.position);
    }

    protected void FlipSprite ()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        moveSpeed *= -1;
    }
}