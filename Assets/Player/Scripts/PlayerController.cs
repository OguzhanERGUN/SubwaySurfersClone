using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private GameInput inputActions;
	[SerializeField] private Transform movementPosRight;
	[SerializeField] private Transform movementPosLeft;
	[SerializeField] private Transform movementPosMiddle;
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private GameManager gameManager;
	

	[Header("Fields")]
	[SerializeField] private Transform currentPosPoint;

	private void Start()
	{
		currentPosPoint = movementPosMiddle;
	}

	// Update is called once per frame
	void Update()
	{
		if (!gameManager.IsGameStart) return;


		PlayerMovement();
	}


	private void OnCollisionEnter(Collision collision)
	{
		ObstacleCollideCheck(collision);
	}


	private void PlayerMovement()
	{
		//for left (-1,0)  (A/Left Arrow)
		//for right (1,0)	(D/Right Arrow)
		//for Jump (0,1)	(W/Up Arrow)
		//for Incline (0,-1)	(S/Down Arrow)
		Vector2 movementVector = inputActions.GetMovementVector();
		ChangePoint(currentPosPoint);

		if (movementVector == Vector2.zero || inputActions.GetPressedStatus()) return;


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
		if (movementVector == Vector2.up)
		{

		}
		if (movementVector == Vector2.down)
		{
			StartInclineAnimation();
		}
		inputActions.IsPressedAnyButton = true;
	}

	private void ChangePoint(Transform targetTransform)
	{
        if (gameManager.IsGameStart)
        {
			Vector3 newPosition = new Vector3();
			newPosition = Vector3.Lerp(transform.position, targetTransform.position, 0.5f);
			newPosition.y = transform.position.y; 

			transform.position = newPosition;
		}
        
	}
	
	private void StartInclineAnimation()
	{
		playerAnimator.SetBool("Incline", true);
	}

	private void ObstacleCollideCheck(Collision collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			Debug.Log("Crashed");
		}
	}

}
