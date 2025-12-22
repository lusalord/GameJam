using System.Collections.Generic;
using UnityEngine;

public class DefenceItem : MonoBehaviour
{
    [SerializeField] private float spinRadius = 2f;
    [SerializeField] private float spinSpeed = 2f;
    [SerializeField] private bool isRotate = true;
    [SerializeField] private GameObject center;
    

    private float _angle;

    protected virtual void Awake()
    {
        _angle = 0f;
    }

    private void Update()
    {
        if (center.gameObject == null)
            return;

        _angle += spinSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(
            spinRadius * Mathf.Cos(_angle),
            spinRadius * Mathf.Sin(_angle),
            0f
        );

        transform.position = center.gameObject.transform.position + offset;

        if (isRotate)
        {
            Vector3 dir = center.gameObject.transform.position - transform.position;
            float angleToPlayer = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angleToPlayer + 90f, Vector3.forward);
        }
    }
}
