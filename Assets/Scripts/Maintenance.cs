using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maintenance : MonoBehaviour
{
    [SerializeField]
    private float maintenanceSpeed;
    [SerializeField]
    private float depreciationSpeed;
    [SerializeField]
    private ProgressBar progressBar;

    private bool repairing;
    private float maintenanceAmount;

    private void Awake()
    {
        maintenanceAmount = 100f;
        MaintenanceIcon.RepairStarted += MaintenanceIcon_RepairStarted;
        MaintenanceIcon.RepairQuit += MaintenanceIcon_RepairQuit;
    }

    private void Update()
    {
        if (repairing)
        {
            if (maintenanceAmount < 100f)
            {
                maintenanceAmount += maintenanceSpeed * 60 * Time.deltaTime;
            }
            else
            {
                RepairCompleted?.Invoke();
                repairing = false;
            }
        }
        else
        {
            if (maintenanceAmount > 0f)
            {
                maintenanceAmount -= depreciationSpeed * 60 * Time.deltaTime;
            }
        }

        progressBar.BarValue = maintenanceAmount;
    }

    private void OnDestroy()
    {
        MaintenanceIcon.RepairStarted -= MaintenanceIcon_RepairStarted;
        MaintenanceIcon.RepairQuit -= MaintenanceIcon_RepairQuit;
    }

    public static event Action RepairCompleted;

    private void MaintenanceIcon_RepairStarted()
    {
        repairing = true;
    }

    private void MaintenanceIcon_RepairQuit()
    {
        repairing = false;
    }
}
