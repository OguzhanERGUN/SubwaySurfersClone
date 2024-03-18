using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
	[SerializeField] private TextMeshProUGUI coinCountText;
	[SerializeField] private GameObject secondHealthImage;
	[SerializeField] private GameObject firstHealthImage;

	public static UIController instance;

	private void Awake()
	{
		instance = this;
		GameManager.instance.playercrashed += OpenCrashedMenu;
	}


	private void Start()
	{
		DisplayHighScore();
		DisplayCoinCount();
	}
	public void StartGame()
	{
		mainMenuCanvas.SetActive(false);
		GameManager.instance.StartGame();
		gamePlayUI.SetActive(true);
	}

	public void DisplayHighScore()
	{
		highScoreText.text = "High Score: " + DataController.instance.highScore.ConvertTo<int>().ToString();

	}
	public void ExitGame()
	{
		DataController.instance.SaveData();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
	}
	public void UpdateScore(float score)
	{
		GameManager.instance.UpdateScore(score);
		scoreTextPlayMenu.text = "Score: " + GameManager.instance.Score.ToString();
	}
	public void DisplayCoinCount()
	{
		coinCountText.text = "Coin: " + GameManager.instance.totalCoinAmount.ToString();
	}
	public void RestartGame()
	{
		DataController.instance.EndGame();
	}
	private void OpenCrashedMenu(object sender, System.EventArgs e)
	{
		scoreTextCrashedMenu.text = "Your Score: " + (int)GameManager.instance.Score;
		crashedMenuUI.SetActive(true);
	}
	public void UpdateHealthBar(int health)
	{
		if (health == 2)
		{
			return;
		}
		else if (health == 1)
		{
			firstHealthImage.SetActive(false);
		}
		else if (health == 0)
		{
			secondHealthImage.SetActive(false);

		}
	}
}
