using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
	[Header("Fields")]
	private Vector3 endPoint;
	// Start is called before the first frame update


	private void OnEnable()
	{
		endPoint = new Vector3(transform.position.x, transform.position.y, -100);

		if (ObjectPooling.instance.obstaclesPool.Contains(gameObject))
		{
			ObjectPooling.instance.obstaclesPool.Remove(gameObject);
		}
	}

	private void OnDisable()
	{
		ObjectPooling.instance.obstaclesPool.Add(gameObject);
	}
	void Update()
	{
		if (!GameManager.instance.IsGameStart) return;
		if (transform.position.z <= endPoint.z)
		{
			gameObject.SetActive(false);
		}
		float levelspeed = GameManager.instance.levelSpeed;
		transform.position = Vector3.MoveTowards(transform.position, endPoint, levelspeed * Time.deltaTime);
	}


}
