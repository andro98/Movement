using UnityEngine;

public enum SteeringState { Seek, Flee }

[RequireComponent(typeof(Rigidbody2D))]
public class SeekAndFlee : MonoBehaviour
{
    private Rigidbody2D character;

    public Transform target;

    public float maxSpeed = 6f;

    public float maxAcceleration = 2f;

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
        setKinematicOutput();

        character.transform.position += velocity  * Time.fixedDeltaTime;

        //character.transform.rotation = Quaternion.AngleAxis(steeringOutput.rotation, Vector3.forward);

        velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
    }
    
    private void setKinematicOutput()
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