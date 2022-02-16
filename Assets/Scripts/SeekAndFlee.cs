using UnityEngine;

public enum SteeringState { Seek, Flee }

[RequireComponent(typeof(Rigidbody2D))]
public class SeekAndFlee : MonoBehaviour
{
    private Rigidbody2D character;

    public Transform target;

    public float maxSpeed = 6f;

    public float maxAcceleration = 2f;

    public float arrivalRadius = 0.1f;
    public float slowRadius = 5f;
    public float timeTimeTarget= 0.1f;


    public SteeringState steeringState = SteeringState.Seek;
    private class SteeringOutput
    {
        public Vector3 acceleration { get; set; }
        public float rotation { get; set; }
    }

    private SteeringOutput steeringOutput = new SteeringOutput { acceleration = Vector3.zero, rotation = 0f };

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        character = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        getArrivingOutput();

        character.transform.position += velocity * Time.fixedDeltaTime;

        //character.transform.rotation = Quaternion.AngleAxis(steeringOutput.rotation, Vector3.forward);

        velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
    }
    
    private void getArrivingOutput()
    {
        Vector3 direction = target.position - character.transform.position;
        float distance = direction.magnitude;

        float targetSpeed = 0;
        if(distance < arrivalRadius)
        {
            steeringOutput.acceleration = Vector3.zero;
            velocity = Vector3.zero;
            return;
        }
        if(distance > slowRadius)
        {
            targetSpeed = maxSpeed;
        }
        else
        {
            targetSpeed = maxSpeed * distance / slowRadius;
        }

        Vector3 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        steeringOutput.acceleration = (targetVelocity - velocity) / timeTimeTarget;

        if(steeringOutput.acceleration.magnitude > maxAcceleration)
        {
            steeringOutput.acceleration.Normalize();
            steeringOutput.acceleration *= maxAcceleration;
        }
    }

    private void getSteeringOutput()
    {
        // Get Direction of movement
        steeringOutput.acceleration = steeringState == SteeringState.Seek ? target.position - character.transform.position : character.transform.position - target.position;
        // Normalize vector 
        steeringOutput.acceleration = steeringOutput.acceleration.normalized;
        // Max speed 
        steeringOutput.acceleration *= maxAcceleration;
        // Calculate angle of rotation
        steeringOutput.rotation = 0f;
    }

    private float CacluateOrientation(Vector3 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

}