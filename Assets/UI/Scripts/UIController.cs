using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private GameObject MainMenuCanvas;
	[SerializeField] private GameManager gameManager;

	public void StartGame()
	{
		MainMenuCanvas.SetActive(false);
		gameManager.StartGame();
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
		PlayerPrefs.SetFloat("HighScore",gameManager.HighScore);
	}

}
