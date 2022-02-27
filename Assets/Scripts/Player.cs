using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float maxAcceleration = 2f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 acceleration = Vector3.zero;

    public Vector3 GetVelocity()
    {
        return this.velocity;
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        acceleration = moveDirection.normalized * maxAcceleration;

        velocity += acceleration * Time.fixedDeltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        if (moveDirection.magnitude == 0)
        {
            velocity = Vector3.zero;
        }

        this.transform.position += velocity * Time.fixedDeltaTime;
    }
}