using DataStructure;
using UnityEngine;

namespace MovementAlgorithm
{
    class Face : Align
    {
        public Face(AlignData data, KinematicData kinematic) : base(data)
        {
            this.KinematicData = kinematic;
        }

        protected KinematicData KinematicData;

        public override SteeringOutput GetSteering()
        {
            Vector3 direction = KinematicData.targetPosition - KinematicData.characterPosition;
            if(direction.magnitude == 0)
            {
                return new SteeringOutput { angular = 0, shouldCharacterStop = true };
            }

            float orientation = VectorHelper.CacluateOrientation(direction);
            base.alignData.targetOrientation = orientation;
            return base.GetSteering();
        }
    }
}
