using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private float moveSpeed;

    // || State

    private Vector2 moveInput;

    // || Cached References

    private Animator animator;
    private Collider2D myCollider;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.Translate(moveInput * Time.deltaTime * moveSpeed);
        animator.SetBool("IsMoving", moveInput != Vector2.zero);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.Instance)
            {
                myCollider.enabled = false;
                GameManager.Instance.IsPlayerAlive = false;
                GameManager.Instance.GameOver();
                Destroy(gameObject);
            }
        }
    }

}