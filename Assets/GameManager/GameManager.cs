using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header("Fields")]
	[SerializeField] public bool IsGameStart;
	[SerializeField] public float Score;
	[SerializeField] public float HighScore;

	//These parameters using for beginning 
	[SerializeField] public bool startPoliceManMovement;
	[SerializeField] public bool startCameraMovement;
	[SerializeField] public bool startPlayerMovement;

	[Header("References")]
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private TextMeshProUGUI highScore;

	private void Awake()
	{
		HighScore = PlayerPrefs.GetFloat("HighScore",HighScore);
	}
	// Start is called before the first frame update
	void Start()
	{
		highScore.text = "High Score: " + HighScore.ToString();
	}

	// Update is called once per frame
	void Update()
	{

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

	}

	public void UpdateHighScore()
	{

	}
}
