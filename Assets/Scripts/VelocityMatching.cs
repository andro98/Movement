using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMatching : MonoBehaviour
{
    private Rigidbody2D character;

    //public Transform target;

    public float maxTargetSpeed = 60f;

    public float maxAcceleration = 0.1f;

    public float timeTimeTarget = 0.1f;
    
    private SteeringOutput steeringOutput = new SteeringOutput { acceleration = Vector3.zero, angular = 0f };

    private Vector3 velocity = Vector3.zero;

    private Vector3 targetVelocity = Vector3.right;

    private void Awake()
    {
        character = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        targetVelocity = maxTargetSpeed * Vector3.right;
        getSteeringOutput();

        character.transform.position += velocity * Time.fixedDeltaTime;

        velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > maxTargetSpeed)
        {
            velocity.Normalize();
            velocity *= maxTargetSpeed;
        }

        print(velocity);
    }
    private void getSteeringOutput()
    {
        steeringOutput.acceleration = (targetVelocity - velocity) / timeTimeTarget;

        if (steeringOutput.acceleration.magnitude > maxAcceleration)
        {
            steeringOutput.acceleration.Normalize();
            steeringOutput.acceleration *= maxAcceleration;
        }
    }
}
