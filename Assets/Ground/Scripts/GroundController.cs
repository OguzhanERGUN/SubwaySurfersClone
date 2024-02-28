using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundController : MonoBehaviour
{
	[SerializeField] private Vector3 startPoint;
	[SerializeField] private Vector3 endPoint;
	[SerializeField] private List<GameObject> obstacles;
	[SerializeField] private List<Transform> obstacleSpawnPoints;



	private void Start()
	{
		
	}

	void Update()
	{
		if (!GameManager.instance.IsGameStart) return;

		MovePlatform();
	}

	void MovePlatform()
	{
        //Platforms positions change per frame by z axis
        if (transform.position.z <= endPoint.z)
		{
			transform.position = startPoint;
			CreateNewObstaclew();
		}
		float levelspeed = GameManager.instance.levelSpeed;
		transform.position = Vector3.MoveTowards(transform.position, endPoint, levelspeed * Time.deltaTime);
	}

	private void CreateNewObstaclew()
	{
		throw new NotImplementedException();
	}
}
