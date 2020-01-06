using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //-----------------------------------------------------------------//
    // FIELDS

    // Config
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float jumpForce = 650f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float timeToNextFire = 1f;
    [SerializeField] private GameObject prefabBullet;

    // State
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private int health = 10;
    [SerializeField] private bool isInvunerable = false;
    [SerializeField] private bool isAlive = true;

    // Cached
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    //-----------------------------------------------------------------//
    // GETTERS / SETTERS

    public int GetHealth ()
    {
        return this.health;
    }

    public bool GetIsInvunerable ()
    {
        return this.isInvunerable;
    }

    //-----------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS

    private void Awake () 
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update () 
    {
        // Checks
        if (!isAlive) { return; }

        isGrounded = Physics2D.Linecast (this.transform.position, groundCheck.position, layerGround);

        if (Input.GetButtonDown ("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if (Input.GetButton ("Fire1") && Time.time > timeToNextFire)
        {
            Fire ();
        }
    }

    private void FixedUpdate () 
    {
        // Checks
        if (!isAlive) { return; }

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

        animator.SetFloat ("Speed", Mathf.Abs (horizontal));
        animator.SetBool ("IsJumpFall", !isGrounded);
    }

    //-----------------------------------------------------------------//
    // HELPER FUNCTIONS

    private void Flip ()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        bulletSpawn.localPosition = new Vector3 (bulletSpawn.localPosition.x * -1, bulletSpawn.localPosition.y, bulletSpawn.localPosition.z);
    }

    private void Fire ()
    {
        timeToNextFire = Time.time + fireRate;
        GameObject bullet = Instantiate (prefabBullet, bulletSpawn.position, bulletSpawn.rotation);
        Vector3 bulletAngle = new Vector3 (0, 0, (spriteRenderer.flipX ? 180 : 0));
        bullet.transform.eulerAngles = bulletAngle;
        animator.SetTrigger ("Fire");
    }

    public void InflictDamage (int value)
    {
        // Checks
        if (!isAlive) { return; }

        isInvunerable = true;
        health -= value;
        StartCoroutine (FlickSprite ());

        if (health <= 0)
        {
            isAlive = false;
            animator.SetTrigger ("Death");
            Invoke ("ReloadLevel", 3f);
        }
    }

    private IEnumerator FlickSprite ()
    {
        float amountToIncrement = 0.1f;
        for (float i = 0f; i < 1f; i += amountToIncrement)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds (amountToIncrement);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds (amountToIncrement);
        }

        isInvunerable = false;
    }

    private void ReloadLevel ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}