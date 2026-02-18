using TMPro;
using UnityEngine;

public class GameOverPoint : MonoBehaviour
{
    [SerializeField] PointController point;
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "당신의 점수: " + point.Point;
    }
}
