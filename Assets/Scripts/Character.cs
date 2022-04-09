using UnityEngine;
using MovementAlgorithm;
using DataStructure;

public class Character : MonoBehaviour
{
    //public AlignData alignData;

    //public ArriveData arriveData;

    //public VelocityMatchingData velocityMatchingData;

    //public PurseData purseData;

    //private Align align;

    //private Face face;
    //private Arrive arrive;

    //private VelocityMatching velocityMatching;

    //private Pursue pursue;

    //private float rotationVelocity = 0;

    public PathFollowingData pathFollowingData;
    public SeekData seekData;
    public SeparationData separationData;

    private Player player;

    private Vector3 velocity = Vector3.zero;

    private KinematicData kinematic;

    public PathFollowing pathFollowing;

    Separation separation;

    private void Awake()
    {
        player = FindObjectOfType<Player>();

        //kinematic = new KinematicData { characterPosition = this.transform.position, targetPosition = player.transform.position };

        //align = new Align(alignData);

        //arrive = new Arrive(arriveData);
        //velocityMatching = new VelocityMatching(velocityMatchingData);

        //pursue = new Pursue(purseData);

        //face = new Face(alignData, kinematic);

        pathFollowing = new PathFollowing(seekData, pathFollowingData);

        separation = new Separation(separationData);
    }

    private void OnDrawGizmos()
    {
        //Vector3 pos = path.GetMappedPositionOnPath(transform.position, 0);
        //Vector3 offsetValue = path.OffsetOnPath(0, 5f);
        //Vector3 offsetedPosition = pos + offsetValue;

        //Vector3 targetPosition = path.GetMappedPositionOnPath(offsetedPosition, 0);

        //Debug.DrawLine(transform.position, pos);
        //Debug.DrawLine(transform.position, targetPosition);
    }

    private void FixedUpdate()
    {
        //ExcutePursue();

        //ExcuteVelocityMatching();

        //ExecuteFace();

        seekData.UpdateData(transform.position);
        pathFollowingData.charachterVelocity = velocity;

        separationData.characterPosition = transform.position;

        //SteeringOutput steeringOutput = pathFollowing.GetSteering();
        SteeringOutput steeringOutput = separation.GetSteering();

        this.transform.position += velocity * Time.fixedDeltaTime;

        velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > seekData.maxSpeed)
        {
            velocity.Normalize();
            velocity *= seekData.maxSpeed;
        }

        if (steeringOutput.shouldCharacterStop)
        {
            velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Node")
        {
            pathFollowingData.currentIndexOnPath = collision.gameObject.GetComponent<Node>().index;
        }
    }


    //private void ExcuteVelocityMatching()
    //{
    //    velocityMatchingData.UpdateData(this.velocity, player.GetVelocity());
    //    SteeringOutput steeringOutput = velocityMatching.GetSteering();

    //    this.transform.position += velocity * Time.fixedDeltaTime;

    //    velocity += steeringOutput.acceleration * Time.fixedDeltaTime;

    //    if (velocity.magnitude > player.maxSpeed)
    //    {
    //        velocity.Normalize();
    //        velocity *= player.maxSpeed;
    //    }
    //}
    private void ExcutePursue()
    {
        //purseData.UpdateData(this.transform.position, player.transform.position, this.velocity, player.GetVelocity());
        //SteeringOutput seekSteeringOutput = pursue.GetSteering();

        //this.transform.position += velocity * Time.fixedDeltaTime;

        //velocity += seekSteeringOutput.acceleration * Time.fixedDeltaTime;

        //if (velocity.magnitude > purseData.maxSpeed)
        //{
        //    velocity.Normalize();
        //    velocity *= purseData.maxSpeed;
        //}

        //if (seekSteeringOutput.shouldCharacterStop)
        //{
        //    velocity = Vector3.zero;
        //}

        //Debug.DrawLine(this.transform.position, seekSteeringOutput.testPredictionPosition, Color.blue);
    } 

    //private void ExcuteArrive()
    //{
    //    purseData.UpdateData(this.transform.position, player.transform.position, this.velocity, player.GetVelocity());
    //    SteeringOutput seekSteeringOutput = pursue.GetSteering();

    //    this.transform.position += velocity * Time.fixedDeltaTime;

    //    velocity += seekSteeringOutput.acceleration * Time.fixedDeltaTime;

    //    if (velocity.magnitude > purseData.maxSpeed)
    //    {
    //        velocity.Normalize();
    //        velocity *= purseData.maxSpeed;
    //    }

    //    if (seekSteeringOutput.shouldCharacterStop)
    //    {
    //        velocity = Vector3.zero;
    //    }

    //    Debug.DrawLine(this.transform.position, seekSteeringOutput.testPredictionPosition, Color.blue);
    //}

    //private void ExecuteAlign()
    //{
    //    alignData.UpdateDate(this.rotationVelocity, this.transform.rotation.eulerAngles.z, this.player.transform.rotation.eulerAngles.z);

    //    SteeringOutput steeringOutput = align.GetSteering();

    //    if (rotationVelocity != 0 && steeringOutput.angular != 0)
    //    { this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 0, rotationVelocity); }

    //    rotationVelocity += steeringOutput.angular * Time.fixedDeltaTime;

    //    if (rotationVelocity > alignData.maxRotation)
    //    {
    //        rotationVelocity /= Mathf.Abs(rotationVelocity);
    //        rotationVelocity *= alignData.maxRotation;
    //    }

    //    if (steeringOutput.shouldCharacterStop)
    //    {
    //        rotationVelocity = 0;
    //    }
    ////}

    private void ExecuteFace()
    {
        //kinematic.UpdateDate(this.transform.position, player.transform.position);
        //alignData.UpdateDate(this.rotationVelocity, this.transform.rotation.eulerAngles.z);

        //SteeringOutput steeringOutput = face.GetSteering();

        //if (rotationVelocity != 0 && steeringOutput.angular != 0)
        //{ this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 0, rotationVelocity); }

        //rotationVelocity += steeringOutput.angular * Time.fixedDeltaTime;

        //if (rotationVelocity > alignData.maxRotation)
        //{
        //    rotationVelocity /= Mathf.Abs(rotationVelocity);
        //    rotationVelocity *= alignData.maxRotation;
        //}

        //if (steeringOutput.shouldCharacterStop)
        //{
        //    rotationVelocity = 0;
        //}
    }
}
