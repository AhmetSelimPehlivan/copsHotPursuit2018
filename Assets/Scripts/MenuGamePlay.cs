using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGamePlay : MonoBehaviour
{
    public GameObject cnvPauseMenu;

    void Start()
    {
        cnvPauseMenu.SetActive(false);
    }

    public void Pause()
    {
        cnvPauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        cnvPauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu(int sceneindex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneindex);
    }

    public void Restart(int sceneindex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneindex);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
