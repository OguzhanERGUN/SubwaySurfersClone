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
	private void Update()
	{
		PolicemanMovement();
	}

	private void PolicemanMovement()
	{
		if (GameManager.instance.startPoliceManMovement)
		{
			if (playerController.health == 2)
			{
				Vector3 newPosition = Vector3.Lerp(transform.position, followPlayerPoisitonHpTwo.position, 0.1f);
				newPosition.y = transform.position.y;
				transform.position = newPosition;
			}
			else if (playerController.health == 1)
			{
				Vector3 newPosition = Vector3.Lerp(transform.position, followPlayerPoisitonHpOne.position, 0.1f);
				newPosition.y = transform.position.y;
				transform.position = newPosition;
			}
			else if (playerController.health == 0)
			{
				Vector3 newPosition = Vector3.Lerp(transform.position, followPlayerPoisitonHpZero.position, 0.1f);
				transform.LookAt(playerController.transform.position);
				newPosition.y = transform.position.y;
				transform.position = newPosition;
			}

		}
	}
}
