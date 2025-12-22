using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private AttackAimmer _attackController;
    [SerializeField] private Transform _dirObj;
    private Vector2 _dir = Vector2.right;
    private void Start()
    {
        _attackController.OnAttack += Move;
        InputManager.OnLRClick += ChangeDir;
    }

    private void ChangeDir(bool value)
    {
        if (value)
        {
            _dirObj.Rotate(0, 0, -90);
            if (_dir == Vector2.up) _dir = Vector2.right;
            else if (_dir == Vector2.right) _dir = Vector2.down;
            else if (_dir == Vector2.down) _dir = Vector2.left;
            else if (_dir == Vector2.left) _dir = Vector2.up;
        }
        else
        {
            _dirObj.Rotate(0, 0, 90);
            if (_dir == Vector2.up) _dir = Vector2.left;
            else if (_dir == Vector2.left) _dir = Vector2.down;
            else if (_dir == Vector2.down) _dir = Vector2.right;
            else if (_dir == Vector2.right) _dir = Vector2.up;
        }
    }

    private void Move()
    {
        transform.Translate(-_dir);
    }
}
