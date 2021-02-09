using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private float speed;

    // || Cached References

    private GameObject player;

    private Animator animator;

    private Collider2D myCollider;

    // || State

    private bool isAlive = true;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        myCollider = GetComponent<Collider2D>();
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
        if (isAlive)
        {
            if (other.CompareTag("Bullet"))
            {
                if (animator && AudioController.Instance && GameManager.Instance)
                {
                    myCollider.enabled = false;
                    AudioController.Instance.Play(AudioController.Instance.Death);
                    GameManager.Instance.UpdateNumberOfEnemiesKilled();

                    animator.SetTrigger("Death");
                    isAlive = false;
                    Destroy(gameObject, 0.5f);
                }
            }
        }

    }
}
