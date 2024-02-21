using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
	[SerializeField] private Vector3 startPoint;
	[SerializeField] private Vector3 endPoint;
	[SerializeField] private float platformSpeed = 2f;

	void Start()
	{

	}

	void Update()
	{
		if (!gameManager.IsGameStart) return;

		MovePlatform();
	}

	void MovePlatform()
	{
        if (gameManager.Score % 100 == 0)
        {
			platformSpeed++;
        }
        //Platforms positions change per frame by z axis
        if (transform.position.z <= endPoint.z)
		{
			transform.position = startPoint;
		}
		transform.position = Vector3.MoveTowards(transform.position, endPoint, platformSpeed * Time.deltaTime);
	}
}
