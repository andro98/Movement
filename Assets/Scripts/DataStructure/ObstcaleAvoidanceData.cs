using UnityEngine;
namespace DataStructure
{
    [System.Serializable]
    public class ObstcaleAvoidanceData
    {
        public float avoidDistance = 2f;
        public float lookAhead = 5f;
        public float lookAheadSmall = 2f;
        [HideInInspector]
        public Vector2 characterVelocity;
    }
}
