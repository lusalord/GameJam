using UnityEngine;

public class FireBallPrefab :MonoBehaviour
{
    Vector2 _moveDir;
    Rigidbody2D _rb;

    public GameObject GameObject => gameObject;
    float waitTime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Vector2 playerPos = transform.parent.position;
        Vector2 dir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPos;
        float desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, desireAngle);
        _rb.linearVelocity = transform.right * 12;
    }
    private void Update()
    {
        if (waitTime >= 6) Destroy(gameObject);
        else waitTime += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealthSystem enemyHealth))
        {
            SoundManager.Play("sfx", GameManager.Instance._sfx);
            Destroy(collision.gameObject);
        }
    }
}
