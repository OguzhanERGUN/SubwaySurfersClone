using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Fields")]
	[SerializeField] public bool IsGameStart;
	[SerializeField] public float Score;
	[SerializeField] public float HighScore;
	[SerializeField] public float levelSpeed;
	[SerializeField] public float levelSpeedCondition;
	[SerializeField] public float maxLevelSpeed;

	//These parameters using for beginning 
	[SerializeField] public bool startPoliceManMovement;
	[SerializeField] public bool startCameraMovement;
	[SerializeField] public bool startPlayerMovement;

	[Header("References")]
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private GameObject beginningAssets;
	[SerializeField] private TextMeshProUGUI scoreText;
	public static GameManager instance;



	private void Start()
	{
		levelSpeedCondition = 500f;
		maxLevelSpeed = 11;
	}

	private void Update()
	{
		if (!IsGameStart) return;
		AddScoreDependsTime();
		UpdateLevelSpeed();

	}

	private void Awake()
	{
		instance = this;
		HighScore = PlayerPrefs.GetFloat("HighScore", HighScore);
	}

	public void StartGame()
	{
		StartCoroutine(GameStartCeremony());
	}


	IEnumerator GameStartCeremony()
	{
		startPoliceManMovement = true;
		yield return new WaitForSeconds(1f);
		startCameraMovement = true;
		IsGameStart = true;
		playerAnimator.SetBool("IsStartGame", true);
		beginningAssets.SetActive(false);
	}

	//public void UpdateHighScore()
	//{

	//}

	public void UpdateScore(float score)
	{
		Score += score;
	}

	private void AddScoreDependsTime()
	{
		Score += Time.deltaTime * 50;
		scoreText.text = "Score: " + ((int)Score);

	}

	private void UpdateLevelSpeed()
	{
		if (Score >= levelSpeedCondition)
		{
			if (levelSpeed < maxLevelSpeed)
			{
				levelSpeedCondition += 500f;
				levelSpeed += 1;
			}
		}

	}
}
