using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GOpanel : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    private void Start()
    {
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
    }
    public  void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
