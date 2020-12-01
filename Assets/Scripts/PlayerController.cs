using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float playerMovementSpeed = 10;

    public float playerStrafeSpeed = 7;
    private float horizontalInput;

    private bool touchingWall = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerMovementSpeed);


        if (touchingWall == true)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x+0.001f, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 0)
            {
                transform.position = new Vector3(transform.position.x-0.001f, transform.position.y, transform.position.z);
            }


        }


        if(touchingWall == false)
        {

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerStrafeSpeed);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            touchingWall = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            touchingWall = false;
        }
    }
}




    
