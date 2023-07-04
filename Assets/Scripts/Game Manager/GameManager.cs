using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;

    [SerializeField]
    private TextMeshProUGUI endGameScoreText;

    public void GameOver()
    {
        endGameScoreText.text = "Your score: " + (int)Score.score;
        gameOver.SetActive(true);
    }
	public void Restart()
	{
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
	}
    public void MainMenu()
    {
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
		Application.Quit();
	}
}
