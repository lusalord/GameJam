using System;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public event Action<int> OnPointUpdated;
    int _point;
    public int Point
    {
        get
        {
            return _point;
        }
        set
        {
            _point = value;
            OnPointUpdated?.Invoke(_point);
        }
    }
}
