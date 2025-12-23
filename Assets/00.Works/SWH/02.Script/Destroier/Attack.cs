using System;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public event Action OnAttack;
    private List<EnemyHealthSystem> Enemys = new();
    [SerializeField] private PointController _point;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent(out EnemyHealthSystem eh))
    //    {
    //        eh.Hp--;
    //        OnAttack?.Invoke();
    //        Destroy(collision.gameObject);
    //    }
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyHealthSystem eh = null;
            foreach (EnemyHealthSystem i in Enemys)
            {
                if (i == null) break;
                bool aaa = false;
                if (Vector2.Distance(transform.position, i.transform.position) < 0.25f)
                {
                    print("정확");
                    aaa = i.TakeDamage(3);
                }
                else
                {
                    print("적중");
                    aaa = i.TakeDamage(1);
                }
                OnAttack?.Invoke();

                if (aaa)
                {
                    eh = i;
                    break;
                }
                //else
                //{
                //    Rigidbody2D rb = i.GetComponent<Rigidbody2D>();
                //    rb.linearVelocity = rb.linearVelocity * -2;
                //}
            }
            if (eh != null)
            {
                Enemys.Remove(eh);
                Destroy(eh.gameObject);
                _point.Point++;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealthSystem eh))
        {
            Enemys.Add(eh);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHealthSystem eh))
        {
            if (Enemys.Contains(eh))
            {
                Enemys.Remove(eh);
            }
        }
    }
}
