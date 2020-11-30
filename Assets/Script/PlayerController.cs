using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMovementSpeed = 10;

    public float playerStrafeSpeed = 7;
    private float horizontalInput;

    private float xRange = 4.5f;

    private bool jump = false;
    private bool up = true;
    private float jumptime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerMovementSpeed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerStrafeSpeed);
        }

        if (jump == false) {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
        if(jump == true){

            if (up == true)
            {
                if (jumptime < 0.7)
                {
                    if (transform.position.y < 1)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + (1 * Time.deltaTime) * 3, transform.position.z);
                    }
                    jumptime += (1 * Time.deltaTime);
                }
                else
                {
                    up = false;
                }
            }
            if(up == false)
            {
                if (jumptime > 0)
                {
                    if (transform.position.y > 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - (1 * Time.deltaTime) * 3, transform.position.z);
                    }
                    jumptime -= (1 * Time.deltaTime);
                }
                else
                {
                    jump = false;
                    up = true;
                }



            }


        }

    }



    private void OnTriggerEnter(Collider other)
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);

    }
}
