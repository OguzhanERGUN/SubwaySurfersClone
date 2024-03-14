using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanController : MonoBehaviour
{
    [SerializeField] private Transform followPlayerPoisitonHpTwo;
    [SerializeField] private Transform followPlayerPoisitonHpOne;
	private void Update()
	{
		PolicemanMovement();
	}

	private void PolicemanMovement()
	{
		if (GameManager.instance.startPoliceManMovement)
		{
			if (GameManager.instance.playerHp == 2)
			{
				Vector3 newPosition = Vector3.Lerp(transform.position, followPlayerPoisitonHpTwo.position, 0.1f);
				newPosition.y = transform.position.y;
				transform.position = newPosition;
			}
			else if (GameManager.instance.playerHp == 1)
			{
				Vector3 newPosition = Vector3.Lerp(transform.position, followPlayerPoisitonHpOne.position, 0.1f);
				newPosition.y = transform.position.y;
				transform.position = newPosition;
			}

		}
	}
}
