using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
	[SerializeField] private Vector3 startPoint;
	[SerializeField] private Vector3 endPoint;
	[SerializeField] private float obstacleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.z <= endPoint.z)
		{
			transform.position = startPoint;
			gameObject.SetActive(false);
		}
		transform.position = Vector3.MoveTowards(transform.position, endPoint, obstacleSpeed * Time.deltaTime);
	}
}
