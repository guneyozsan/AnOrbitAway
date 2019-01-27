using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Raycaster : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public static event Action<Transform> LookingAt;

    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            LookingAt?.Invoke(hit.transform);
        }
    }
}