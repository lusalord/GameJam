using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AttackAimmer : MonoBehaviour
{
    [SerializeField] PointController PointController;
    List<UnSuk> Unsuks = new();
    public event Action OnAttack;
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
        //Vector2 dir = MouseInput.Instance.MousePosition - (Vector2)pos.position;
        //float desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //pos.transform.localScale = desireAngle > 90 || desireAngle < -90 ? new Vector3(pos.localScale.x, -pos.localScale.y, 1) : new Vector3(pos.localScale.x, pos.localScale.y, 1);
        //pos.rotation = Quaternion.Euler(0, 0, desireAngle);
        //return (MouseInput.Instance.MousePosition - (Vector2)pos.transform.position).normalized;
    }
}
