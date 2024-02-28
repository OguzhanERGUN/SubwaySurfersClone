using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclineCollider : MonoBehaviour
{
	[SerializeField] private Animator playerAnimator;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Obstacle") && playerAnimator.GetBool("Incline"))
		{
			Debug.Log("Crashed while incline");
		}

	}


}
