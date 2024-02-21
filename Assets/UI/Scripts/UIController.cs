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
}
