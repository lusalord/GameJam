using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Attack _attackController;
    [SerializeField] private Transform _dirObj;
    [SerializeField] private float _spinPower;
    [SerializeField] private float _movePower;
    
    private void Start()
    {
        _attackController.OnAttack += () => StartCoroutine(Move());
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _dirObj.Rotate(0, 0, Time.deltaTime * _spinPower);
        }
        else if (Input.GetMouseButton(1))
        {
            _dirObj.Rotate(0, 0, -Time.deltaTime * _spinPower);
        }

    }
    private IEnumerator Move()
    {
        float x = _movePower * _dirObj.right.x;
        float y = _movePower * _dirObj.right.y;
        float t = 0;
        while (t < 1)
        {
            float x2 = x - Mathf.Lerp(0, x, t);
            float y2 = y - Mathf.Lerp(0, y, t);
            transform.position += new Vector3(x2, y2, 0) * Time.deltaTime;
            t += Time.deltaTime;
            t = Mathf.Clamp(t, 0, 1);
            yield return null;
        }
    }
}
