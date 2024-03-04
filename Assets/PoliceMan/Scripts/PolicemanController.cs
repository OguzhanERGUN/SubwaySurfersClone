using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanController : MonoBehaviour
{
    [SerializeField] private Transform followPlayerPoisiton;
	private void Update()
	{
		if (GameManager.instance.startPoliceManMovement)
		{
			Vector3 newPosition = Vector3.Lerp(transform.position, followPlayerPoisiton.position, 0.1f);
			newPosition.y = transform.position.y;
			transform.position = newPosition;
		}


	}
}
