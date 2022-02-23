using DataStructure;

namespace MovementAlgorithm
{
    public class VelocityMatching
    {
        public VelocityMatching(VelocityMatchingData data)
        {
            this.velocityMatchingData = data;
        }

        protected VelocityMatchingData velocityMatchingData { get; private set; }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput steeringOutput = new SteeringOutput();
            steeringOutput.acceleration = (velocityMatchingData.targetVelocity - velocityMatchingData.characterVelocity) / velocityMatchingData.timeTimeTarget;

            if (steeringOutput.acceleration.magnitude > velocityMatchingData.maxAcceleration)
            {
                steeringOutput.acceleration.Normalize();
                steeringOutput.acceleration *= velocityMatchingData.maxAcceleration;
            }

            return steeringOutput;
        }
    }
}