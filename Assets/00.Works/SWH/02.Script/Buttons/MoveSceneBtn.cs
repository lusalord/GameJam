using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveSceneBtn : MonoBehaviour
{
    [SerializeField] string _key;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(_key));
    }
}
