using System;
using System.Collections;
using UnityEngine;

public class Malfunction : MonoBehaviour
{
    [SerializeField]
    RandomActivator randomActivator;

    private void Awake()
    {
        Maintenance.RepairCompleted += Maintenance_RepairCompleted;
    }

    private void Start()
    {
        randomActivator.SetActiveRandom();
    }

    private void OnDestroy()
    {
        Maintenance.RepairCompleted -= Maintenance_RepairCompleted;
    }

    private void Maintenance_RepairCompleted()
    {
        randomActivator.SetActiveRandom();
    }
}
