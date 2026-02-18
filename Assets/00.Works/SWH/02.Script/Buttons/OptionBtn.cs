using UnityEngine;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    [SerializeField] GameObject _panal;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (_panal.activeSelf)
            {
                _panal.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                _panal.SetActive(true);
                Time.timeScale = 0;
            }
        });
        _panal.SetActive(false);
    }
}
