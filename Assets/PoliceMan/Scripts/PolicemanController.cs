using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform followPlayerPoisitonHpTwo;
	[SerializeField] private Transform followPlayerPoisitonHpOne;
	[SerializeField] private Transform followPlayerPoisitonHpZero;
	[SerializeField] private PlayerController playerController;
	private Transform policemanTargetPosition;

	private void Start()
	{
		GameManager.instance.playercrashed += ChangePolicemanTargettoEndGame;
		policemanTargetPosition = followPlayerPoisitonHpTwo;
	}
	private void Update()
	{
		PolicemanMovement();
	}

	private void PolicemanMovement()
	{
		if (GameManager.instance.startPoliceManMovement)
		{
			Vector3 newPosition = Vector3.Lerp(transform.position, policemanTargetPosition.position, 0.1f);
			newPosition.y = transform.position.y;
			transform.position = newPosition;
			transform.LookAt(playerController.transform);
		}
	}

	public void ChangePolicemanTargetPosition()
	{
		policemanTargetPosition = followPlayerPoisitonHpOne;
	}

	private void ChangePolicemanTargettoEndGame(object sender, EventArgs e)
	{
		policemanTargetPosition = followPlayerPoisitonHpZero;
	}
}
