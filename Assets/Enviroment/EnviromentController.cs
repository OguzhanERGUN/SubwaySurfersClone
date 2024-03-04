using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
	[SerializeField] private Vector3 endPoint;
	[SerializeField] private Vector3 startPoint;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!GameManager.instance.IsGameStart) return;
		MoveEnviroment();
    }

	void MoveEnviroment()
	{
		//Platforms positions change per frame by z axis
		if (transform.position.z <= endPoint.z)
		{
			transform.position = startPoint;
		}
		float levelspeed = GameManager.instance.levelSpeed;
		transform.position = Vector3.MoveTowards(transform.position, endPoint, levelspeed * Time.deltaTime);
	}
}
