using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    List<UnSuk> Unsuks = new();
    private void Start()
    {
        InputManager.OnWasd += TryAttack;
    }
    void TryAttack(Vector2 value)
    {
        GameObject obj = null;
        foreach (UnSuk i in Unsuks)
        {
            if (i.pos == value)
            {
                obj = i.gameObject;
                break;
            }
        }
        if (obj != null)
        {
            Destroy(obj);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unsuks.Add(collision.GetComponent<UnSuk>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Unsuks.Remove(collision.GetComponent<UnSuk>());
    }
}
