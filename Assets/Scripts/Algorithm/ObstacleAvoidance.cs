using DataStructure;
using UnityEngine;
namespace MovementAlgorithm
{
    public class ObstacleAvoidance : Seek
    {
        public ObstacleAvoidance(SeekData seekData, ObstcaleAvoidanceData data) : base(seekData)
        {
            this.obstcaleAvoidanceData = data;
        }

        protected ObstcaleAvoidanceData obstcaleAvoidanceData;

        public override SteeringOutput GetSteering()
        {
            Vector2 direction = obstcaleAvoidanceData.characterVelocity.normalized;
            Vector2 directionLeft = Rotate(obstcaleAvoidanceData.characterVelocity.normalized, 30);
            Vector2 directionRight= Rotate(obstcaleAvoidanceData.characterVelocity.normalized, -30);

            Debug.DrawRay(seekData.CharacterPosition, direction * obstcaleAvoidanceData.lookAhead);
            Debug.DrawRay(seekData.CharacterPosition, directionLeft * obstcaleAvoidanceData.lookAheadSmall);
            Debug.DrawRay(seekData.CharacterPosition, directionRight * obstcaleAvoidanceData.lookAheadSmall);


            RaycastHit2D hit = Physics2D.Raycast(seekData.CharacterPosition, directionLeft, obstcaleAvoidanceData.lookAhead);
            if (hit.collider != null)
            {
                Vector3 newTargetPosition = hit.point + hit.normal * obstcaleAvoidanceData.avoidDistance;
                base.seekData.TargetPosition = newTargetPosition;
                return base.GetSteering();
            }
            RaycastHit2D hitLeft = Physics2D.Raycast(seekData.CharacterPosition, directionRight, obstcaleAvoidanceData.lookAhead);
            if (hitLeft.collider != null)
            {
                Vector3 newTargetPosition = hitLeft.point + hitLeft.normal * obstcaleAvoidanceData.avoidDistance;
                base.seekData.TargetPosition = newTargetPosition;
                return base.GetSteering();
            }
            RaycastHit2D hitRight = Physics2D.Raycast(seekData.CharacterPosition, direction, obstcaleAvoidanceData.lookAhead);
            if (hitRight.collider != null)
            {
                Vector3 newTargetPosition = hitRight.point + hitRight.normal * obstcaleAvoidanceData.avoidDistance;
                base.seekData.TargetPosition = newTargetPosition;
                return base.GetSteering();
            }
            else
            {
                base.seekData.TargetPosition = seekData.TargetPosition; return base.GetSteering();
            }
        }

        public Vector2 Rotate(Vector2 v, float degrees)
        {
            return Quaternion.Euler(0, 0, degrees) * v;
        }
    }
}
