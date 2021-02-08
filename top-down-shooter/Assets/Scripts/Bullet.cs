using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem effect;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (effect)
        {
            Instantiate(effect, transform.position, transform.rotation);
        }
        
        Destroy(gameObject);
    }
}
