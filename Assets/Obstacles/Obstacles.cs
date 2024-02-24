using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
	[Header("Fields")]
	[SerializeField] private Vector3 startPoint;
	[SerializeField] private Vector3 endPoint;
    // Start is called before the first frame update

    void Update()
    {
		if (!GameManager.instance.IsGameStart) return;
		if (transform.position.z <= endPoint.z)
		{
			transform.position = startPoint;
			gameObject.SetActive(false);
		}
		float levelspeed = GameManager.instance.levelSpeed;
		transform.position = Vector3.MoveTowards(transform.position, endPoint, levelspeed * Time.deltaTime);
	}


}
