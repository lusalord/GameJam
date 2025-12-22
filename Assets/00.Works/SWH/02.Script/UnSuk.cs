using UnityEngine;

public class UnSuk : MonoBehaviour
{
    [SerializeField] Transform _target;
    public Vector2 pos;
    void Update()
    {
        transform.Translate((_target.position - transform.position).normalized * Time.deltaTime);
    }
}
