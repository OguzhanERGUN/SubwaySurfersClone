using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclineCollider : MonoBehaviour
{
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private PlayerController playerHealth;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Obstacle") && playerAnimator.GetBool("Incline"))
		{
			if (playerHealth.health == 0)
			{
				GameManager.instance.Crashed();
			}
			else
			{

				playerHealth.health--;
				UIController.instance.UpdateHealthBar(playerHealth.health);
			}
			other.gameObject.SetActive(false);
			playerHealth.PlayCrashedParticleEffect();
		}

	}


}
