using UnityEngine;
namespace DataStructure
{
    public class Path: MonoBehaviour
    {
        public Node[] nodes;

        private void Awake()
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].index = i;
            }
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                Debug.DrawLine(nodes[i].transform.position, nodes[i + 1].transform.position, Color.black);
            }
        }

        public int GetNearestLine(Vector3 currentPosition)
        {
            int nearestPosition = 0;
            Vector3 min = GetMappedPositionOnPath(currentPosition, 0) - currentPosition;
            for (int i = 1; i < nodes.Length; i++)
            {
                Vector3 result = GetMappedPositionOnPath(currentPosition, i) - currentPosition;
                if(result.magnitude < min.magnitude)
                {
                    min = result;
                    nearestPosition = i;
                }
            }

            return nearestPosition;
        }

        public Vector3 GetMappedPositionOnPath(Vector3 pos, int nodePosition)
        {
            if(nodePosition == nodes.Length - 1)
            {
                return nodes[nodePosition].transform.position;
            }

            Vector3 firstNode = nodes[nodePosition].transform.position;
            Vector3 lastNode = nodes[nodePosition + 1].transform.position;

            Vector3 heading = lastNode - firstNode;
            float magnitudeMax = heading.magnitude;
            heading.Normalize();

            Vector3 lhs = pos - firstNode;
            float dotP = Vector3.Dot(lhs, heading);
            dotP = Mathf.Clamp(dotP, 0f, magnitudeMax);

            return firstNode + heading * dotP;
        }

        public Vector3 OffsetOnPath(int nodePosition, float offest)
        {
            if (nodePosition == nodes.Length - 1)
            {
                return nodes[nodePosition].transform.position;
            }

            Vector3 firstNode = nodes[nodePosition].transform.position;
            Vector3 lastNode = nodes[nodePosition + 1].transform.position;

            Vector3 direction = lastNode - firstNode;
            direction.Normalize();

            return direction * offest;
        }
    }
}
