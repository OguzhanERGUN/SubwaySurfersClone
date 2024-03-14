using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private GameObject mainMenuCanvas;
	[SerializeField] private GameObject gamePlayUI;
	[SerializeField] private GameObject crashedMenuUI;
	[SerializeField] private TextMeshProUGUI highScoreText;
	[SerializeField] private TextMeshProUGUI scoreTextPlayMenu;
	[SerializeField] private TextMeshProUGUI scoreTextCrashedMenu;

	public static UIController instance;

	private void Awake()
	{
		instance = this;
		GameManager.instance.playercrashed += OpenCrashedMenu;
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
		SaveDatas();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
	}

	public void SaveDatas()
	{
		if (GameManager.instance.Score >= GameManager.instance.HighScore)
		{
			PlayerPrefs.SetFloat("High Score", GameManager.instance.Score);

		}
		PlayerPrefs.SetFloat("Total Coin", GameManager.instance.totalCoinAmount);
	}

	public void UpdateScore(float score)
	{
		GameManager.instance.UpdateScore(score);
		scoreTextPlayMenu.text = "Score: " + GameManager.instance.Score.ToString();
	}


	public void RestartGame()
	{
		DataController.instance.EndGame();
	}


	private void OpenCrashedMenu(object sender, System.EventArgs e)
	{
		scoreTextCrashedMenu.text = "Your Score: " + GameManager.instance.Score;
		crashedMenuUI.SetActive(true);
	}
}
