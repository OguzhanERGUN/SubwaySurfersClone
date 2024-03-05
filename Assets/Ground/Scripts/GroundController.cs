using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundController : MonoBehaviour
{
	[SerializeField] private bool isBeginningGround;
	[SerializeField] private Vector3 startPoint;
	[SerializeField] private Vector3 endPoint;
	[SerializeField] private List<Transform> obstacleSpawnPoints;



	private void Start()
	{
		if (!isBeginningGround)
		{
			CreateNewObstacle();
		}
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
			CreateNewObstacle();
		}
		float levelspeed = GameManager.instance.levelSpeed;
		transform.position = Vector3.MoveTowards(transform.position, endPoint, levelspeed * Time.deltaTime);
	}

	private void CreateNewObstacle()
	{
		Debug.Log("Ground Reset");
		foreach (Transform item in obstacleSpawnPoints)
		{
			int objectPoolCount = ObjectPooling.instance.obstaclesPool.Count;
			int randomObstacleNumber = UnityEngine.Random.Range(0, objectPoolCount);

			//set obstacle position and set active true
			ObjectPooling.instance.obstaclesPool[randomObstacleNumber].transform.position = item.position;
			ObjectPooling.instance.obstaclesPool[randomObstacleNumber].SetActive(true);
		}
	}
}
