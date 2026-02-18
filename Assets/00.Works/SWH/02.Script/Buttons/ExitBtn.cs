using UnityEngine;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => Application.Quit());
    }
}
