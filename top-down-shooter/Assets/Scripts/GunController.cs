using UnityEngine;

public class GunController : MonoBehaviour
{
    // || Inspector References

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnBullet;

    // || Cached References

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Aim();
        Shoot();
    }

    private void Aim()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        spriteRenderer.flipY = (mousePosition.x < screenPoint.x);
    }

    private void Shoot()
    {
        if (bulletPrefab && spawnBullet)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (AudioController.Instance)
                {
                    AudioController.Instance.Play(AudioController.Instance.Bullet);
                }

                Instantiate(bulletPrefab, spawnBullet.position, transform.rotation);
            }
        }
    }
}
