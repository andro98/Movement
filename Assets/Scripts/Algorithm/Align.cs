using DataStructure;
using UnityEngine;
namespace MovementAlgorithm
{
    public class Align
    {
        public Align(AlignData data)
        {
            this.alignData = data;
        }

        protected AlignData alignData;

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput steeringOutput = new SteeringOutput();

            float rotationSize = Mathf.DeltaAngle(alignData.characterOrientation, alignData.targetOrientation);
            float rotationDirection = rotationSize / Mathf.Abs(rotationSize);

            float targetRotation = 0;
            if (Mathf.Abs(rotationSize) < alignData.arrivalRadius)
            {
                steeringOutput.angular = 0;
                steeringOutput.shouldCharacterStop = true;
                return steeringOutput;
            }
            if (Mathf.Abs(rotationSize) > alignData.slowRadius)
            {
                targetRotation = alignData.maxRotation;
            }
            else
            {
                targetRotation = alignData.maxRotation * Mathf.Abs(rotationSize) / alignData.slowRadius;
            }

            targetRotation *= rotationDirection;

            steeringOutput.angular = (targetRotation - alignData.rotationVelocity) / alignData.timeTimeTarget;

            if (Mathf.Abs(steeringOutput.angular) > alignData.maxAngularAcceleration)
            {
                steeringOutput.angular /= Mathf.Abs(steeringOutput.angular);
                steeringOutput.acceleration *= alignData.maxAngularAcceleration;
            }

            steeringOutput.shouldCharacterStop = false;
            return steeringOutput;
        }
    }
}