using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;


    private Vector3 positionLeft;
    private Vector3 positionMiddle;
    private Vector3 positionRight;

    private int playerPositionIndex;
    // Start is called before the first frame update
    void Start()
    {
        playerPositionIndex = 0;
        positionMiddle = transform.position;
        positionLeft = transform.position + new Vector3(0, 0, 3.5f);
        positionRight = transform.position + new Vector3(0, 0, -3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }



    private void Movement()
    {
        if (playerPositionIndex == 0)
        {
            transform.position = Vector3.Lerp(transform.position, positionMiddle, moveSpeed * Time.deltaTime);
        }
        else if (playerPositionIndex == 1)
        {
            transform.position = Vector3.Lerp(transform.position, positionRight, moveSpeed * Time.deltaTime);

        }
        else if (playerPositionIndex == -1)
        {
            transform.position = Vector3.Lerp(transform.position, positionLeft, moveSpeed * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerPositionIndex == 0)
            {
                playerPositionIndex = 1;
            }

            if (playerPositionIndex == -1)
            {
                playerPositionIndex = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerPositionIndex == 0)
            {
                playerPositionIndex = -1;
            }

            if (playerPositionIndex == 1)
            {
                playerPositionIndex = 0;
            }
        }
    }
}
