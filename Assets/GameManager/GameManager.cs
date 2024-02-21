using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool IsGameStart;
	//Ceremony 
	public bool startPoliceManMovement;
	public bool startCameraMovement;
	public bool startPlayerMovement;
	[SerializeField] private Animator playerAnimator;


	// Start is called before the first frame update
	void Start()
	{
		IsGameStart = false;
		startPoliceManMovement = false;
		startCameraMovement = false;
		startPlayerMovement = false;
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

}
