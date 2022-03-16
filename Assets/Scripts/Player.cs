using UnityEngine;
using DataStructure;
using MovementAlgorithm;

public class Player : MonoBehaviour, IStats
{
    public float maxSpeed = 5f;
    public float maxAcceleration = 2f;


    private LookWhereYoureGoing lookWhereYoureGoing;

    public AlignData alignData;

    private Vector3 velocity = Vector3.zero;
    private Vector3 acceleration = Vector3.zero;
    private float rotationVelocity = 0;

    private void Awake()
    {
        lookWhereYoureGoing = new LookWhereYoureGoing(alignData, velocity);
    }

    public Vector3 GetVelocity()
    {
        return this.velocity;
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        acceleration = moveDirection.normalized * maxAcceleration;

        velocity += acceleration * Time.fixedDeltaTime;

        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        if(moveDirection.magnitude == 0)
        {
            velocity = Vector3.zero;
        }

        this.transform.position += velocity * Time.fixedDeltaTime;

        ExecuteWhereYouAreGoing();
    }

    private void ExecuteWhereYouAreGoing()
    {
        alignData.UpdateDate(this.rotationVelocity, this.transform.rotation.eulerAngles.z);
        lookWhereYoureGoing.velocity = velocity;

        SteeringOutput steeringOutput = lookWhereYoureGoing.GetSteering();

        if (rotationVelocity != 0 && steeringOutput.angular != 0)
        { this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 0, rotationVelocity); }

        rotationVelocity += steeringOutput.angular * Time.fixedDeltaTime;

        if (rotationVelocity > alignData.maxRotation)
        {
            rotationVelocity /= Mathf.Abs(rotationVelocity);
            rotationVelocity *= alignData.maxRotation;
        }

        if (steeringOutput.shouldCharacterStop)
        {
            rotationVelocity = 0;
        }
    }
}
