using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private GameObject mainMenuCanvas;
	[SerializeField] private GameObject gamePlayUI;
	[SerializeField] private TextMeshProUGUI highScoreText;
	[SerializeField] private TextMeshProUGUI scoreText;

	public static UIController instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		highScoreText.text = "High Score: " + GameManager.instance.HighScore.ToString();
	}
	public void StartGame()
	{
		mainMenuCanvas.SetActive(false);
		GameManager.instance.StartGame();
		gamePlayUI.SetActive(true);
	}



	public void ExitGame()
	{
		SaveHighScore();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
	}

	public void SaveHighScore()
	{
		PlayerPrefs.SetFloat("HighScore", GameManager.instance.HighScore);
	}

	public void UpdateScore(float score)
	{
		GameManager.instance.UpdateScore(score);
		scoreText.text = "Score: " + GameManager.instance.Score.ToString();
	}
}
