using DataStructure;
using UnityEngine;
namespace MovementAlgorithm
{
    public class Separation
    {
        public Separation(SeparationData data)
        {
            this.separationData = data;
        }

        protected SeparationData separationData;

        public SteeringOutput GetSteering()
        {
            SteeringOutput steeringOutput = new SteeringOutput();

            foreach (Target target in separationData.target)
            {
                Vector3 direction = separationData.characterPosition - target.transform.position;
                float distance = direction.magnitude;

                if(distance < separationData.threshold)
                {
                    float strength = Mathf.Min(separationData.decayCofficient / (distance * distance) ,separationData.maxAcceleration);

                    direction.Normalize();

                    steeringOutput.acceleration += strength * direction;

                    steeringOutput.shouldCharacterStop = false;
                }
                else
                {
                    steeringOutput.shouldCharacterStop = true;
                }
            }

            return steeringOutput;
        }
    }
}
