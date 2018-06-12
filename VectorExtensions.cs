using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 ToVector2(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static Vector3 ToVector3(this Vector2 v)
    {
        return new Vector3(v.x, v.y, 0.0f);
    }

    public static Vector3 Mult(this Vector3 v, Vector3 m)
    {
        return new Vector3(v.x * m.x, v.y * m.y, v.z * m.z);
    }
}