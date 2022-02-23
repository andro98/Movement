using UnityEngine;

public static class VectorHelper 
{
    public static float CacluateOrientation(Vector3 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
