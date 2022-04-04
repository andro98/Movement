using UnityEngine;

namespace DataStructure
{
    [System.Serializable]
    public class SeekData
    {
        public float MaxAcceleration;
        public float maxSpeed;
        [HideInInspector]
        public Vector3 CharacterPosition;
        [HideInInspector]
        public Vector3 TargetPosition;

        public void UpdateData(Vector3 c, Vector3 t)
        {
            this.CharacterPosition = c;
            this.TargetPosition = t;
        }

        public void UpdateData(Vector3 c)
        {
            this.CharacterPosition = c;
        }
    }
}