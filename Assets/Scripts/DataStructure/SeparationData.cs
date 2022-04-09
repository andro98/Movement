using UnityEngine;
namespace DataStructure
{
    [System.Serializable]
    public class SeparationData
    {
        [HideInInspector]
        public Vector3 characterPosition;
        public Target[] target;

        public float maxAcceleration;
        public float threshold;
        public float decayCofficient;
    }
}
