using UnityEditor.Rendering.Universal;
using UnityEngine;

public static class MyToolbox
{
    public static Vector2 GetRandomVector2(float xMin, float xMax, float yMin, float yMax)
    {
        // x -150 180
        // y -150 150
        return new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    }
}
