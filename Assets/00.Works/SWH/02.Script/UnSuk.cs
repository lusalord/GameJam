using UnityEngine;

public class UnSuk : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] int dmg;
    public Vector2 pos;
    void Update()
    {
        transform.Translate((_target.position - transform.position).normalized * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth hp))
        {
            hp.Damage(dmg);
            Destroy(gameObject);
        }
    }
}
