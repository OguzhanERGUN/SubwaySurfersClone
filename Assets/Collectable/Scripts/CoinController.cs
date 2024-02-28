using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<PlayerController>(out PlayerController component))
		{
			UIController.instance.UpdateScore(100);
			gameObject.SetActive(false);
		}
	}

}
