using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour,IDisabler
{
    public int Score,HighScore,BaseHP;
    public TextMeshProUGUI ScoreTmpro,HPTmpro;
    public static bool IsGameOver = false;
    public GameObject GOpanel;
    void Start()
    {
       BaseHP = 5;
       HighScore = PlayerPrefs.GetInt("HighScore");
    }
    void Update()
    {
        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
        ScoreTmpro.text = "Score :" + Score.ToString();
        HPTmpro.text = BaseHP.ToString();
        GameOver();
    }
    public void Disable(GameObject obj)
    {
        obj.SetActive(false);
    }
    void GameOver()
    {
        if (BaseHP <= 0)
        {
            GOpanel.SetActive(true);
            IsGameOver = true;
        }
        else
        {
            GOpanel.SetActive(false);
            IsGameOver = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            BaseHP -= 1;
            Disable(other.gameObject);
        }
    }
}
