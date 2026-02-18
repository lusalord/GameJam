using UnityEngine;

public class AttackAimmer : MonoBehaviour
{
    private void Start()
    {
        InputManager.OnMousePosDelta += Aimming;
    }

    private void Aimming(Vector2 pos)
    {
        Vector2 playerPos = transform.parent.position;

        Vector2 dir = pos - playerPos;
        float desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, desireAngle);
    }
    private void OnDestroy()
    {
        InputManager.OnMousePosDelta -= Aimming;
    }
}
