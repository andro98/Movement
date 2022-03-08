using UnityEngine;

namespace DataStructure
{
    [System.Serializable]
    public class PurseData: ArriveData
    {
        public float maxPredictionTime;
        [UnityEngine.HideInInspector]
        public UnityEngine.Vector3 targetVelocity;

        public void UpdateData(Vector3 c, Vector3 t, Vector3 cVelocity, Vector3 tVelocity)
        {
            base.UpdateData(c, t, cVelocity);
            this.targetVelocity = tVelocity;
        }
    }
}
