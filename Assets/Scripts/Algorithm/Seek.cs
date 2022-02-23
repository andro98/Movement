using DataStructure;
namespace MovementAlgorithm
{
    public class Seek
    {
        public Seek(SeekData seekData)
        {
            this.seekData = seekData;
        }

        protected SeekData seekData { get; private set; }

        public virtual SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();

            steering.acceleration = seekData.TargetPosition - seekData.CharacterPosition;
            steering.acceleration.Normalize();
            steering.acceleration *= seekData.MaxAcceleration;

            steering.angular = 0;
            steering.shouldCharacterStop = false;
            return steering;
        }
    }
}