using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        verticalSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * verticalSpeed * Time.deltaTime * -1);
        Debug.Log(transform.position.x);

        if (transform.position.x < -50f)
        {
            transform.position = new Vector3(200,transform.position.y,transform.position.z);
            Debug.Log("sýnýr aþýldý");
        }
    }
}
