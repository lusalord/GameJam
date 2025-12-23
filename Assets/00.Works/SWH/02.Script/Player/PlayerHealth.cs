using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HP { get; private set; }
    public event Action<int> OnDamage;
    public event Action OnDead;
    private void Awake()
    {
        HP = 10;
    }
    public void Damage(int dmg)
    {
        HP -= dmg;
        HP = Mathf.Clamp(HP, 0, 9999);
        OnDamage?.Invoke(HP);
        if (HP == 0)
        {
            OnDead?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealthSystem eh))
        {
            Damage(1);
            GetComponent<Rigidbody2D>().AddForce(collision.transform.position - transform.position, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        }
    }
}
