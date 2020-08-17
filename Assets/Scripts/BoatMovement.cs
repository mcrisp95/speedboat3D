using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    private float velocity = 0.0f;
    private float maxVelocity = 10.0f;
    private float accelRate = 0.5f;
    private float decelRate = 0.25f;
    private float turnSpeed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        ResolveMovement();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Accelerate(accelRate);
        }

        if (Input.GetKey(KeyCode.S))
        {
            AccelerateBackwards(accelRate);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Turn(turnSpeed * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Turn(turnSpeed);
        }


        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            Decelerate(decelRate);
        }
    }

    void Accelerate(float strength)
    {
        velocity += accelRate;
        if(velocity > maxVelocity)
        {
            velocity = maxVelocity;
        }
    }

    void AccelerateBackwards(float strength)
    {
        velocity -= accelRate;
        if (velocity < maxVelocity * -1)
        {
            velocity = maxVelocity * -1;
        }
    }

    void Decelerate(float strength)
    {
        if (velocity <= decelRate && velocity >= (decelRate * -1))
        {
            velocity = 0.0f;
        }
        else
        {
            if (velocity > 0.0f)
            {
                velocity -= decelRate;
            }
            else if (velocity < 0.0f)
            {
                velocity += decelRate;
            }
        }
    }

    void Turn(float strength)
    {
        if (velocity == 0)
        {
            // Turn
        }
    }

    void ResolveMovement()
    {
        if (velocity != 0)
        {
            Debug.Log("Velocity: " + velocity);
            Vector3 forward = transform.forward;

            //float z = transform.position.z + (forward.z * velocity);

            //Debug.Log("Old z: " + transform.position.z + "--- New x: " + z);


            transform.Translate(forward * velocity);
        }
    }
}
