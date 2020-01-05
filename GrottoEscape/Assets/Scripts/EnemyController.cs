using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    // Config
    [SerializeField] protected int health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float distanceToAttack;

    // State
    protected bool isMoving = false;

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

    public float GetMoveSpeed ()
    {
        return this.moveSpeed;
    }

    public void SetMoveSpeed (float moveSpeed)
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

    protected virtual void Update ()
    {
        float currentDistance = this.CalculatePlayerDistance ();
        this.SetIsMoving ((currentDistance <= this.GetDistanceToAttack ()));

        if (this.GetIsMoving ())
        {
            if ((player.position.x > this.transform.position.x && spriteRenderer.flipX) || 
                (player.position.x < this.transform.position.x && !spriteRenderer.flipX))
            {
                this.FlipSprite ();
            }
        }
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