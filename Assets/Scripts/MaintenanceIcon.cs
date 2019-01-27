using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintenanceIcon : MonoBehaviour
{
    [SerializeField]
    private GameObject idle;
    [SerializeField]
    private GameObject repairing;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        SetActive(false);
        Raycaster.LookingAt += Raycaster_LookingAt;
        Maintenance.RepairCompleted += Maintenance_RepairCompleted;
    }

    private void OnDestroy()
    {
        Raycaster.LookingAt -= Raycaster_LookingAt;
        Maintenance.RepairCompleted -= Maintenance_RepairCompleted;
    }

    public static event Action RepairStarted;
    public static event Action RepairQuit;

    private void Raycaster_LookingAt(Transform target)
    {
        if (target != transform)
        {
            if (repairing.activeInHierarchy)
            {
                RepairQuit?.Invoke();
            }

            SetActive(false);
            return;
        }

        if (!repairing.activeInHierarchy)
        {
            RepairStarted?.Invoke();
        }

        SetActive(true);
    }

    private void SetActive(bool value)
    {
        repairing.SetActive(value);
        idle.SetActive(!value);
    }

    private void Maintenance_RepairCompleted()
    {
        gameObject.SetActive(false);
    }
}