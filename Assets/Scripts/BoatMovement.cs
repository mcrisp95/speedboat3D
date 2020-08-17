using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    private float velocity = 0.0f;
    private float maxVelocity = 25.0f;
    private float accelRate = 0.5f;
    private float decelRate = 0.25f;
    private float turnSpeed = 1.0f;

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
            Accelerate();
        }

        if (Input.GetKey(KeyCode.S))
        {
            AccelerateBackwards();
        }

        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }


        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            Decelerate();
        }
    }

    void Accelerate()
    {
        velocity += accelRate;
        if (velocity > maxVelocity)
        {
            velocity = maxVelocity;
        }
    }

    void AccelerateBackwards()
    {
        velocity -= accelRate;
        if (velocity < maxVelocity * -1)
        {
            velocity = maxVelocity * -1;
        }
    }

    void Decelerate()
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

    void TurnLeft()
    {
        if (velocity == 0)
        {
            transform.Rotate(0, turnSpeed * -1, 0);
        }
    }

    void TurnRight()
    {
        if (velocity == 0)
        {
            transform.Rotate(0, turnSpeed, 0);
        }
    }

    void ResolveMovement()
    {
        if (velocity != 0)
        {
            transform.Translate(transform.forward * velocity * Time.deltaTime, Space.World);
        }
    }
}
