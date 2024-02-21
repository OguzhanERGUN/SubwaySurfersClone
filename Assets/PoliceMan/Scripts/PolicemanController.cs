using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanController : MonoBehaviour
{
    [SerializeField] private Transform followPlayerPoisiton;
	[SerializeField] private GameManager gameManager;
	private void Update()
	{
		if (gameManager.startPoliceManMovement)
		{
			transform.position = Vector3.Lerp(transform.position, followPlayerPoisiton.position, 0.1f);
		}

	}
}
