using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameEnd : MonoBehaviour
{
    public Text highscore;
    public Text score;
    public float HighScore;
    public float Score;
    void Start()
    {
        Debug.Log(Score);
        GetComponent<SaveLoad>().Load2();
        highscore.text = HighScore.ToString("F2");// PlayerPrefs.GetFloat("HighScore").ToString("F2");
        score.text = Score.ToString("F2");//  PlayerPrefs.GetFloat("Score").ToString("F2");
    }

    void Update()
    {

    }

    public void GoToMainMenu(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
