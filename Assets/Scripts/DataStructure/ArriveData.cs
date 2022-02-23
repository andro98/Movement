using UnityEngine;

namespace DataStructure
{
    [System.Serializable]
    public class ArriveData : SeekData
    {
        public float arrivalRadius;
        public float slowRadius;
        public float timeTimeTarget;
        [HideInInspector]
        public Vector3 characterVelocity;

        public void UpdateData(Vector3 c, Vector3 t, Vector3 cVelocity)
        {
            base.UpdateData(c, t);
            this.characterVelocity = cVelocity;
        }
    }
}