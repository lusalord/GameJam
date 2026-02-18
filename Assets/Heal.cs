using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth hp))
        {
            hp.Damage(-2);
            Destroy(gameObject);
        }
    }
}
