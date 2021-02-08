using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private float moveSpeed;

    // || State

    private Vector2 moveInput;

    // || Cached References

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
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
            StartCoroutine(OnDeath());
        }
    }

    private IEnumerator OnDeath()
    {
        Destroy(gameObject);
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}