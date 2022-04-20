using MovementAlgorithm;
using DataStructure;
using UnityEngine;

public class CharacterAvoidance : MonoBehaviour
{
    public ObstcaleAvoidanceData obstcaleAvoidanceData;
    public SeekData seekData;

    ObstacleAvoidance obstcaleAvoidance;

    public float maxSpeed = 10f;
    private Vector3 velocity = Vector3.zero;

    public Target target;

    void Start()
    {
        seekData.TargetPosition = target.transform.position;
        obstcaleAvoidance = new ObstacleAvoidance(seekData, obstcaleAvoidanceData);
    }

    void FixedUpdate()
    {
        seekData.CharacterPosition = transform.position;
        seekData.TargetPosition = target.transform.position;
        obstcaleAvoidanceData.characterVelocity = velocity;
        SteeringOutput steeringOutput = obstcaleAvoidance.GetSteering();

        this.transform.position += velocity * Time.fixedDeltaTime;

        this.velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        if (steeringOutput.shouldCharacterStop)
        {
            velocity = Vector3.zero;
        }
    }
}
