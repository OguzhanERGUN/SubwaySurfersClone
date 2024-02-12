using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
	[Header("References")]
	private PlayerInput inputActions;

	//[Header("Fields")]
	public event EventHandler PlayerMovementAction;
	public bool IsPressedAnyButton;


	private void Awake()
	{
		inputActions = new PlayerInput();
		inputActions.Enable();
	}

	private void OnEnable()
	{
		inputActions.Player.Movement.started += Movement_performed;
		inputActions.Player.Movement.canceled += Movement_canceled;
	}

	private void Movement_canceled(InputAction.CallbackContext obj)
	{
		IsPressedAnyButton = false;
	}

	private void OnDisable()
	{
		inputActions.Player.Movement.started -= Movement_performed;
		inputActions.Player.Movement.canceled -= Movement_canceled;
	}


	private void Movement_performed(InputAction.CallbackContext obj)
	{
		PlayerMovementAction?.Invoke(this, EventArgs.Empty);
	}

	public Vector2 GetMovementVector()
	{
		Vector2 movementVector = inputActions.Player.Movement.ReadValue<Vector2>();

		return movementVector;
	}

	//return true while press any move buttons
	public bool GetPressedStatus()
	{
		return IsPressedAnyButton;
	}
}
