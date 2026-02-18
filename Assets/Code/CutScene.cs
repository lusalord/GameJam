using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image image01;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] textAll;
    [SerializeField] string _scene;
    private string _text;
    private float _textDelay = 0.0625f;
    float _delay = 1.5f;

    private void Start()
    {
        StartCoroutine(textPrint(_textDelay));
    }

    IEnumerator textPrint(float d)
    {
        
        for (int i = 0; i < textAll.Length; i++)
        {
            text.text = "";
            _text = textAll[i];
            for (int j = 0; j < _text.Length; j++)
            {
                text.text += _text[j].ToString();
                yield return new WaitForSeconds(_textDelay);
            }
            yield return new WaitForSeconds(_delay);
        }
        SceneManager.LoadScene(_scene);
    }
}
