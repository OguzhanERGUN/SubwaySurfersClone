using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
	public float highScore;
	public float coinAmount;
	public static DataController instance;

	public event EventHandler endGame;

	private void Awake()
	{
		instance = this;
		endGame += DataController_endGame;
		highScore = PlayerPrefs.GetFloat("HighScore");
		GameManager.instance.totalCoinAmount = PlayerPrefs.GetFloat("TotalCoin");
	}
	private void DataController_endGame(object sender, EventArgs e)
	{
		SaveData();
		SceneManager.LoadScene(0);
	}

	public void EndGame()
	{
		endGame?.Invoke(this, EventArgs.Empty);
	}

	public void SaveData()
	{
		float currentScore = GameManager.instance.Score;
		if (currentScore > highScore)
		{
			PlayerPrefs.SetFloat("HighScore", currentScore);
		}
		PlayerPrefs.SetFloat("TotalCoin",GameManager.instance.totalCoinAmount);
	}
}
