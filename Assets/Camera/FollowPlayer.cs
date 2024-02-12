using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform mainPlayer;
    [SerializeField] private Vector3 camPosition;
    [SerializeField] float followSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (mainPlayer != null)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, mainPlayer.position.y + 5, mainPlayer.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
        }

    }
}
