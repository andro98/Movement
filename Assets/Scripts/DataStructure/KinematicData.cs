using UnityEngine;
namespace DataStructure
{
    public class KinematicData
    {
        public Vector3 targetPosition;
        public Vector3 characterPosition;

        public void UpdateDate(Vector3 pC, Vector3 pT)
        {
            this.targetPosition = pT;
            this.characterPosition = pC;
        }
    }
}
