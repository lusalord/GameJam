using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string nextScene;
    public GameObject settingUI;

    private void Awake()
    {
        settingUI.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    public void SettingButton()
    {
        Time.timeScale = 0;
        settingUI.SetActive(true);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        settingUI.SetActive(false);
    }
}
