using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private PointController _point;
    [SerializeField] private int _cost;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_point.Point >= _cost)
            {
                _point.Point -= _cost;
                Satelite s = Instantiate(_prefab, transform).GetComponent<Satelite>();
                s._target = transform;
            }
        }
    }
}
