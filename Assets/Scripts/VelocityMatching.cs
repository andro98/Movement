using UnityEngine;

public class VelocityMatching : MonoBehaviour
{
    public Player player;

    private Rigidbody2D character;

    public float maxAcceleration = 2f;

    public float timeToTarget = 0.1f;

    private Vector3 velocity = Vector3.zero;

    private Vector3 targetVelocity = Vector3.zero;

    private SteeringOutput steeringOutput = new SteeringOutput { acceleration = Vector3.zero, angular = 0 };

    private void Awake()
    {
        character = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        targetVelocity = player.GetVelocity();

        getSteeringOutput();

        character.transform.position += velocity * Time.fixedDeltaTime;

        velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

        if(velocity.magnitude > player.maxSpeed)
        {
            velocity.Normalize();
            velocity *= player.maxSpeed;
        }
    }

    private void getSteeringOutput()
    {
        steeringOutput.acceleration = (targetVelocity - velocity) / timeToTarget;

        if(steeringOutput.acceleration.magnitude > maxAcceleration)
        {
            steeringOutput.acceleration.Normalize();
            steeringOutput.acceleration *= maxAcceleration;
        }
    }
}
