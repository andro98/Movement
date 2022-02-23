using UnityEngine;

namespace DataStructure
{
    [System.Serializable]
    public class VelocityMatchingData
    {
        [HideInInspector]
        public Vector3 characterVelocity;
        [HideInInspector]
        public Vector3 targetVelocity;

        public float timeTimeTarget;
        public float maxAcceleration;

        public void UpdateData( Vector3 cVelocity, Vector3 tVelocity)
        {
            this.characterVelocity = cVelocity;
            this.targetVelocity = tVelocity;
        }
    }
}
