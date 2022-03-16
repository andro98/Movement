using DataStructure;
using UnityEngine;

namespace MovementAlgorithm
{
    class LookWhereYoureGoing : Align
    {
        public LookWhereYoureGoing(AlignData data, Vector3 velocity) : base(data)
        {
            this.velocity = velocity;
        }

        public Vector3 velocity;

        public override SteeringOutput GetSteering()
        {

            if(velocity.magnitude == 0)
            {
                return new SteeringOutput { angular = 0 };
            }

            float orientation = VectorHelper.CacluateOrientation(velocity);
            base.alignData.targetOrientation = orientation;
            return base.GetSteering();
        }
    }
}
