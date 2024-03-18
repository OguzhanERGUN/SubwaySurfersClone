using System;
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
	[SerializeField] public float levelSpeed;
	[SerializeField] public float levelSpeedCondition;
	[SerializeField] public float maxLevelSpeed;
	[SerializeField] public float totalCoinAmount;

	//These parameters using for beginning 
	[SerializeField] public bool startPoliceManMovement;
	[SerializeField] public bool startCameraMovement;
	[SerializeField] public bool startPlayerMovement;

	[Header("References")]
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private GameObject beginningAssets;
	[SerializeField] private TextMeshProUGUI scoreText;
	public static GameManager instance;
	public event EventHandler playercrashed;

	private void OnEnable()
	{
		if (playercrashed != null) return;
		playercrashed += GameManager_playercrashed;
	}

	private void Awake()
	{
		instance = this;
	}

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

	public void Crashed()
	{
		playercrashed?.Invoke(this, EventArgs.Empty);
	}

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

	private void GameManager_playercrashed(object sender, EventArgs e)
	{
		IsGameStart = false;
	}
}
