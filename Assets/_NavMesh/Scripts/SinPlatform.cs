using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinPlatform : MovingPlatform
{
    float currentZ = 0;
    protected override Vector3 NextMove(float t)
    {
        Vector3 newPosition = Vector3.Lerp(_startPosition, _endPosition, t);
        currentZ += Mathf.Sin(Time.time) * Time.deltaTime;
        newPosition.z += currentZ;
        return newPosition;
    }
}
