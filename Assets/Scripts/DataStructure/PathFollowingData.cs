using UnityEngine;

namespace DataStructure
{
    [System.Serializable]
    public class PathFollowingData
    {
        public Path path;
        public float pathOffset;
        public float predictTime;
        [HideInInspector]
        public int currentIndexOnPath;
        [HideInInspector]
        public Vector3 charachterVelocity;
    }
}
