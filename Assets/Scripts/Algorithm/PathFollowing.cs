using DataStructure;
using UnityEngine;

namespace MovementAlgorithm
{
    public class PathFollowing : Seek
    {
        public PathFollowing(SeekData seekData, PathFollowingData data) : base(seekData)
        {
            this.pathFollowingData = data;
        }

        protected PathFollowingData pathFollowingData;

        public override SteeringOutput GetSteering()
        {
            int nearestPosition = pathFollowingData.path.GetNearestLine(seekData.CharacterPosition);

            pathFollowingData.currentIndexOnPath = nearestPosition;

            Vector3 futurePos = seekData.CharacterPosition + (pathFollowingData.charachterVelocity * pathFollowingData.predictTime);

            Vector3 mappedPosition = pathFollowingData.path.GetMappedPositionOnPath(futurePos, pathFollowingData.currentIndexOnPath);

            Vector3 offsetValue = pathFollowingData.path.OffsetOnPath(pathFollowingData.currentIndexOnPath, pathFollowingData.pathOffset);

            Vector3 offsetPosition = mappedPosition + offsetValue;

            Vector3 targetPosition = pathFollowingData.path.GetMappedPositionOnPath(offsetPosition, pathFollowingData.currentIndexOnPath);

            base.seekData.TargetPosition = targetPosition;

            return base.GetSteering();
        }
    }
}
