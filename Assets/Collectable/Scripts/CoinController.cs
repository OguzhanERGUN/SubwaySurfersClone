using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Alt�n ald�");
		if(other.TryGetComponent<PlayerController>(out PlayerController component))
		{
			UIController.instance.UpdateScore(100);
		}
	}

}
