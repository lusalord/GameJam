using TMPro;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] PointController PointController;
    private void Start()
    {
        PointController.OnPointUpdated += PointUpdate;
        _text.text = "0";
    }
    void PointUpdate(int value)
    {
        _text.text = value.ToString();
    }
}
