using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingPlatformCollider : MonoBehaviour
{
	[SerializeField] private GameObject parentObject;


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			parentObject.SetActive(false);
		}
	}
}
