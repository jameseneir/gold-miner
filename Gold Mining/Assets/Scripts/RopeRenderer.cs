using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField]
    LineRenderer lineRenderer;

    [SerializeField]
    Transform RopeStartingPoint;
    [SerializeField]
    Transform RopeEndingPoint;

    private void LateUpdate()
    {
        lineRenderer.SetPosition(0, RopeStartingPoint.position);
        lineRenderer.SetPosition(1, RopeEndingPoint.position);
    }
}
