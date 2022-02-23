using UnityEngine;
using DataStructure;

public class Player : MonoBehaviour, IStats
{
    public float maxSpeed = 5f;
    public float maxAcceleration = 2f;


    private Vector3 velocity = Vector3.zero;
    private Vector3 acceleration = Vector3.zero;

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
    }
}
