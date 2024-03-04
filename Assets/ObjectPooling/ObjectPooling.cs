using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
	[SerializeField] private List<GameObject> obstacles;
	public List<GameObject> obstaclesPool;
	public static ObjectPooling instance;

	//It will spawn obstacles 24 times for every different obtacles
	void Awake()
	{
		obstaclesPool = new List<GameObject>();
		foreach (GameObject obstacle in obstacles)
		{
			for (int i = 0; i < 10; i++)
			{
				GameObject newObstacle = Instantiate(obstacle);
				obstaclesPool.Add(newObstacle);
				newObstacle.SetActive(false);
			}
		}
		
	}
}
