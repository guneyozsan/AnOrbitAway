using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malfunction : MonoBehaviour
{
    [SerializeField]
    List<GameObject> malfunctions;

    private int currentMalfunction;

    private void Awake()
    {
        Maintenance.RepairCompleted += Maintenance_RepairCompleted;
    }

    private void Start()
    {
        RandomMalfunction();
    }

    private void OnDestroy()
    {
        Maintenance.RepairCompleted -= Maintenance_RepairCompleted;
    }

    private void Maintenance_RepairCompleted()
    {
        RandomMalfunction();
    }

    private void RandomMalfunction()
    {
        int nextMalfunction = 0;

        if (malfunctions.Count > 1)
        {
            do
            {
                nextMalfunction = UnityEngine.Random.Range(0, malfunctions.Count - 1);
            }
            while (nextMalfunction == currentMalfunction);
        }

        for (int i = 0; i < malfunctions.Count; i++)
        {
            if (i == nextMalfunction)
            {
                malfunctions[i].SetActive(true);
            }
            else
            {
                malfunctions[i].SetActive(false);
            }
        }
    }
}
