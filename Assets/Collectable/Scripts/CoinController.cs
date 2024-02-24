using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	[SerializeField] private Transform startPos;
	[SerializeField] private Transform endPos;
	private void OnTriggerEnter(Collider other)
	{
		
		if(other.TryGetComponent<PlayerController>(out PlayerController component))
		{
			gameManager.Score += 100;
		}
	}

	private void OnEnable()
	{
		
	}

	private void OnDisable()
	{
		
	}

	private void Update()
	{
		
	}

}
