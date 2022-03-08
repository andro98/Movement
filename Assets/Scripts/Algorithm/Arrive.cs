using UnityEngine;
using DataStructure;

namespace MovementAlgorithm
{
    public class Arrive
    {
        public Arrive(ArriveData data)
        {
            this.ArriveData = data;
        }

        protected ArriveData ArriveData;

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();

            Vector3 direction = ArriveData.TargetPosition - ArriveData.CharacterPosition;
            float distance = direction.magnitude;

            float targetSpeed = 0;
            if (distance < ArriveData.arrivalRadius)
            {
                steering.acceleration = Vector3.zero;
                steering.shouldCharacterStop = true;
                return steering;
            }
            if (distance > ArriveData.slowRadius)
            {
                targetSpeed = ArriveData.maxSpeed;
            }
            else
            {
                targetSpeed = ArriveData.maxSpeed * distance / ArriveData.slowRadius;
            }

            Vector3 targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;

            steering.acceleration = (targetVelocity - ArriveData.characterVelocity) / ArriveData.timeTimeTarget;

            if (steering.acceleration.magnitude > ArriveData.MaxAcceleration)
            {
                steering.acceleration.Normalize();
                steering.acceleration *= ArriveData.MaxAcceleration;
            }

            steering.angular = 0;
            steering.shouldCharacterStop = false;
            steering.testPredictionPosition = ArriveData.TargetPosition;
            return steering;
        }
    }
}
