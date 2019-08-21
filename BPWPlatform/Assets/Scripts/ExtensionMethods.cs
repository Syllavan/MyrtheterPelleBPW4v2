using UnityEngine;
using System.Collections;


//For using a combination of Vector in my Enemy Script
public static class ExtensionMethods
{
    public static Vector2 toVector2(this Vector3 vec3)
    {
        return new Vector2(vec3.x, vec3.y);
    }
}

