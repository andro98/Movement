namespace DataStructure
{
    [System.Serializable]
    public class AlignData
    {
        public float maxRotation;
        public float maxAngularAcceleration;
        public float arrivalRadius;
        public float slowRadius;
        public float timeTimeTarget;
        [UnityEngine.HideInInspector]
        public float rotationVelocity;
        [UnityEngine.HideInInspector]
        public float characterOrientation;
        [UnityEngine.HideInInspector]
        public float targetOrientation;

        public void UpdateDate(float r, float c, float t)
        {
            this.rotationVelocity = r;
            this.characterOrientation = c;
            this.targetOrientation = t;
        }
    }
}