using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
	public float HighScore;
	public float CoinAmount;
	public static DataController instance;

	public event EventHandler endGame;

	private void Awake()
	{
		instance = this;
		endGame += DataController_endGame;
	}

	private void DataController_endGame(object sender, EventArgs e)
	{
		SceneManager.LoadScene(0);
	}

	public void EndGame()
	{
		endGame?.Invoke(this, EventArgs.Empty);
	}
}
