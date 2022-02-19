using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour
{
    private Rigidbody2D character;

    public Transform target;

    public float maxRotation = 6f;

    public float maxAngularAcceleration = 2f;

    public float arrivalRadius = 1.5f;
    public float slowRadius = 5f;
    public float timeTimeTarget = 0.1f;


    private SteeringOutput steeringOutput = new SteeringOutput { acceleration = Vector3.zero, angular = 0f };

    private float rotationVelocity = 0;


    private void Awake()
    {
        character = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        getSteeringOutput();

        if(rotationVelocity != 0 && steeringOutput.angular != 0)
        { character.transform.rotation = character.transform.rotation * Quaternion.Euler(0, 0, rotationVelocity); }

        rotationVelocity += steeringOutput.angular * Time.fixedDeltaTime;

        if (rotationVelocity> maxRotation)
        {
            rotationVelocity /= Mathf.Abs(rotationVelocity);
            rotationVelocity *= maxRotation;
        }
    }

    private void getSteeringOutput()
    {
        float rotationSize = Mathf.DeltaAngle(character.transform.rotation.eulerAngles.z, target.rotation.eulerAngles.z);
        float rotationDirection = rotationSize / Mathf.Abs(rotationSize);

        float targetRotation = 0;
        if (Mathf.Abs(rotationSize) < arrivalRadius)
        {
            steeringOutput.angular = 0;
            rotationVelocity = 0;
            return;
        }
        if (Mathf.Abs(rotationSize) > slowRadius)
        {
            targetRotation = maxRotation;
        }
        else
        {
            targetRotation = maxRotation * Mathf.Abs(rotationSize) / slowRadius;
        }

        targetRotation *= rotationDirection;

        steeringOutput.angular = (targetRotation - rotationVelocity) / timeTimeTarget;

        if (Mathf.Abs(steeringOutput.angular) > maxAngularAcceleration)
        {
            steeringOutput.angular /= Mathf.Abs(steeringOutput.angular);
            steeringOutput.acceleration *= maxAngularAcceleration;
        }
    }

    private float CacluateOrientation(Vector3 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

}
