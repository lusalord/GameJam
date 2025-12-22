using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action<Vector2> OnWasd;
    public static Action OnSpaceBar;
    public static Action<bool> OnLRClick;//좌클릭: false, 우클릭: true
    public static Action<Vector2> OnMousePosDelta;
    Vector2 _mousePosition;
    public static void Init()
    {
        GameObject obj = GameManager.Instance.gameObject;
        obj.AddComponent<InputManager>();
        //return obj.GetComponent<InputManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceBar?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnWasd?.Invoke(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            OnWasd?.Invoke(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            OnWasd?.Invoke(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnWasd?.Invoke(Vector2.right);
        }
        if (Input.GetMouseButtonDown(0))
        {
            OnLRClick?.Invoke(false);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            OnLRClick?.Invoke(true);
        }
        if (_mousePosition != (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition))
        {
            _mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            OnMousePosDelta?.Invoke(_mousePosition);
        }
    }
}
