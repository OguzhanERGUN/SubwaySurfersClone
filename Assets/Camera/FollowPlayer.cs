using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform camPosition;
    [SerializeField] private Transform camLookingPos;
    [SerializeField] private Transform endGamePosition;
    [SerializeField] private Transform endGameLookingPosition;


	private void Start()
	{
        GameManager.instance.playercrashed += TakeCameraToEndPosition;
	}

	// Update is called once per frame
	void Update()
    {
        if (!gameManager.startCameraMovement) return;
        transform.LookAt(camLookingPos);
        transform.position = Vector3.Lerp(transform.position, camPosition.position, 0.1f);
    }

    private void TakeCameraToEndPosition(object sender, EventArgs e)
    {
        camPosition = endGamePosition;
        camLookingPos = endGameLookingPosition;
	}
}
