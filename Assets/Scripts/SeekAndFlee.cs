using UnityEngine;

public enum KinematicState { Seek, Flee }

public class SeekAndFlee : MonoBehaviour
{
    private Rigidbody2D character;
    public Transform target;
    public float maxSpeed = 2f;

    public KinematicState kinematicState = KinematicState.Seek;
    private class KinematicOutput
    {
        public Vector3 velocity { get; set; }
        public float rotation { get; set; }
    }

    private KinematicOutput kinematicOutput = new KinematicOutput { velocity = Vector3.zero, rotation = 0f };

    private void Awake()
    {
        character = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        setKinematicOutput();

        character.transform.position += kinematicOutput.velocity * Time.fixedDeltaTime;

        character.transform.rotation = Quaternion.AngleAxis(kinematicOutput.rotation, Vector3.forward);
    }

    private void setKinematicOutput()
    {
        // Get Direction of movement
        kinematicOutput.velocity = kinematicState == KinematicState.Seek ? target.position - character.transform.position : character.transform.position - target.position;
        // Normalize vector 
        kinematicOutput.velocity = kinematicOutput.velocity.normalized;
        // Max speed 
        kinematicOutput.velocity *= maxSpeed;
        // Calculate angle of rotation
        kinematicOutput.rotation = CacluateOrientation(kinematicOutput.velocity);
    }

    private float CacluateOrientation(Vector3 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

}