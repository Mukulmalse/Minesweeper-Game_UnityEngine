using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public static int scoreValue;
    public Text PointsText;
    public void Setup()
    {
       gameObject.SetActive(true);
    //    PointsText.text = score.ToString[] + " POINTS";
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
