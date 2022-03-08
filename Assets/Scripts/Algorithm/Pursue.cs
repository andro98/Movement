using DataStructure;
using UnityEngine;
namespace MovementAlgorithm 
{ 
    class Pursue: Arrive
    {
        public Pursue(PurseData data): base(data)
        {
            this.purseData = data;
        }

        public PurseData purseData;

        public override SteeringOutput GetSteering()
        {
            Vector3 direction = this.purseData.CharacterPosition - this.purseData.TargetPosition;
            float distance = direction.magnitude;

            float speed = this.purseData.targetVelocity.magnitude;

            float prediction = 0;

            if(speed <= distance / this.purseData.maxPredictionTime)
            {
                prediction = this.purseData.maxPredictionTime;
            }
            else
            {
                prediction = distance / speed;
            }

            Vector3 predictedPosition = purseData.TargetPosition + (purseData.targetVelocity * prediction);

            base.ArriveData.TargetPosition = predictedPosition;
            return base.GetSteering();
        }
    }
}
