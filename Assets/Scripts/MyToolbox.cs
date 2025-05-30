using UnityEditor.Rendering.Universal;
using UnityEngine;

public static class MyToolbox
{
    public static Vector2 GetRandomVector2()
    {
        // x -150 180
        // y -150 150
        return new Vector2(Random.Range(-150, 180), Random.Range(-150, 150));
    }
}
