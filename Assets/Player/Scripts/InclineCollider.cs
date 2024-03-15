using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclineCollider : MonoBehaviour
{
	[SerializeField] private Animator playerAnimator;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		if (other.gameObject.CompareTag("Obstacle") && playerAnimator.GetBool("Incline"))
		{
			GameManager.instance.Crashed();
		}

	}


}
