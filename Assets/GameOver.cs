using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] PlayerHealth h;
    [SerializeField] GameObject g;
    private void Start()
    {
        h.OnDead += () =>
        {
            g.SetActive(true);
            Time.timeScale = 0;
        };
    }
}
