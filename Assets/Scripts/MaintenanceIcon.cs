using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintenanceIcon : MonoBehaviour
{
    [SerializeField]
    private GameObject idle;
    [SerializeField]
    private GameObject active;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        SetActive(false);
        Raycaster.LookingAt += Raycaster_LookingAt;
    }

    private void OnDestroy()
    {
        Raycaster.LookingAt -= Raycaster_LookingAt;
    }

    private void Raycaster_LookingAt(Transform target)
    {
        if (target != transform)
        {
            SetActive(false);
            return;
        }

        SetActive(true);
    }

    private void SetActive(bool value)
    {
        active.SetActive(value);
        idle.SetActive(!value);
    }
}