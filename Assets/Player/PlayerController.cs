using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private GameInput inputActions;
	[SerializeField] private Transform movementPosRight;
	[SerializeField] private Transform movementPosLeft;
	[SerializeField] private Transform movementPosMiddle;

	[Header("Fields")]
	[SerializeField] private Transform currentPosPoint;

	private void Start()
	{
		currentPosPoint = movementPosMiddle;
	}

	// Update is called once per frame
	void Update()
	{
		if (!GameManager.IsGameStart) return;


		PlayerMovement();
	}


	private void PlayerMovement()
	{
		//for left (-1,0)
		//for right (1,0)
		//for Jump (0,1)
		//for Incline (0,-1)
		Vector2 movementVector = inputActions.GetMovementVector();
		ChangePoint(currentPosPoint);
		Debug.Log(inputActions.GetPressedStatus());

		if (movementVector == Vector2.zero || inputActions.GetPressedStatus()) return;
		Debug.Log("bip");
		if (movementVector == Vector2.left)
		{
			if (currentPosPoint == movementPosLeft)
			{
				return;
			}
			else if (currentPosPoint == movementPosMiddle)
			{
				currentPosPoint = movementPosLeft;
			}
			else if (currentPosPoint == movementPosRight)
			{
				currentPosPoint = movementPosMiddle;
			}
		}
		if (movementVector == Vector2.right)
		{
			if (currentPosPoint == movementPosRight)
			{
				return;
			}
			else if (currentPosPoint == movementPosMiddle)
			{
				currentPosPoint = movementPosRight;
			}
			else if (currentPosPoint == movementPosLeft)
			{
				currentPosPoint = movementPosMiddle;
			}
		}
		if (movementVector == Vector2.up) return;
		if (movementVector == Vector2.down) return;

	}

	private void ChangePoint(Transform targetTransform)
	{
		transform.position = Vector2.Lerp(transform.position, targetTransform.position, 0.5f);
	}
}
