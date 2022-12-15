using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LerpPosition
{
    public IEnumerator PositionLerp(Transform target, Vector3 destination, float speed)
    {
        float distance = Vector2.Distance(target.position, destination);
        float remainingDistance = distance;
        Vector3 start = target.position;
        while (remainingDistance > float.Epsilon)
        {
            remainingDistance -= Time.deltaTime * speed;
            target.position = Vector3.Lerp(start, destination, 1 - (remainingDistance / distance));
            yield return null;
        }
        target.position = destination;
    }
}
