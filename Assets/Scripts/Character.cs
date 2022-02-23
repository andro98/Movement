using UnityEngine;
using MovementAlgorithm;
using DataStructure;

public class Character : MonoBehaviour
{
    public AlignData alignData;

    public ArriveData arriveData;

    public VelocityMatchingData velocityMatchingData;

    private Align align;

    private Arrive arrive;

    private VelocityMatching velocityMatching;

    private float rotationVelocity = 0;

    private Player player;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        align = new Align(alignData);
        arrive = new Arrive(arriveData);
        velocityMatching = new VelocityMatching(velocityMatchingData);
    }

    private void FixedUpdate()
    {
        ExcuteArrive();

        //ExcuteVelocityMatching();

        ExecuteAlign();
    }

    private void ExcuteVelocityMatching()
    {
        velocityMatchingData.UpdateData(this.velocity, player.GetVelocity());
        SteeringOutput steeringOutput = velocityMatching.GetSteering();

        this.transform.position += velocity * Time.fixedDeltaTime;

        velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > player.maxSpeed)
        {
            velocity.Normalize();
            velocity *= player.maxSpeed;
        }
    }

    private void ExcuteArrive()
    {
        arriveData.UpdateData(this.transform.position, player.transform.position, this.velocity);
        SteeringOutput seekSteeringOutput = arrive.GetSteering();

        this.transform.position += velocity * Time.fixedDeltaTime;

        velocity += seekSteeringOutput.acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > arriveData.maxSpeed)
        {
            velocity.Normalize();
            velocity *= arriveData.maxSpeed;
        }

        if (seekSteeringOutput.shouldCharacterStop)
        {
            velocity = Vector3.zero;
        }
    }

    private void ExecuteAlign()
    {
        alignData.UpdateDate(this.rotationVelocity, this.transform.rotation.eulerAngles.z, this.player.transform.rotation.eulerAngles.z);

        SteeringOutput steeringOutput = align.GetSteering();

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
