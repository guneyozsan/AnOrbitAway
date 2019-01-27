using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 axis;

    void Update()
    {
        transform.Rotate(axis * (speed * Time.deltaTime));
    }
}
