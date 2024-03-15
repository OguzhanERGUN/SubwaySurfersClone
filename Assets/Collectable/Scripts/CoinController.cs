using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<PlayerController>(out PlayerController component))
		{
			GameManager.instance.totalCoinAmount += 10;
			gameObject.SetActive(false);
		}
	}

}
