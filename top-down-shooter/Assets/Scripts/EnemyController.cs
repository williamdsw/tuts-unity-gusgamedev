using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private float speed;

    // || Cached References

    private GameObject player;

    private Animator animator;

    // || State

    private bool isAlive = true;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player && isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (animator)
        {
            if (other.CompareTag("Bullet") && isAlive)
            {
                animator.SetTrigger("Death");
                isAlive = false;
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
