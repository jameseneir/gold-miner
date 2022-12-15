using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorMover : MonoBehaviour
{
    [SerializeField]
    float speed;

    public void Move(float horizontal)
    {
        transform.position += (Vector3)(speed * Time.deltaTime * horizontal * Vector2.right);
    }
}
