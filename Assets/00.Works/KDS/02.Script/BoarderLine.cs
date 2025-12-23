using System;
using UnityEngine;

public class BoarderLine : MonoBehaviour
{
    [SerializeField] private float _pushBackStrength = 5f; // 밀림 속도

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        Collider2D wallCollider = GetComponent<Collider2D>();
        if (other.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero;
            
            Vector2 closestPoint = wallCollider.ClosestPoint(rb.position);
            rb.transform.position = closestPoint;
            
            Vector2 pushDir = (closestPoint - rb.position).normalized;
            Vector2 pushVelocity = pushDir * _pushBackStrength;
            rb.MovePosition(rb.position + pushVelocity * Time.fixedDeltaTime);
        }
    }
}
