using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField]
    private float longingSpeed;
    [SerializeField]
    private float relaxingSpeed;
    [SerializeField]
    private ProgressBar homesickBar;

    private float homesickAmount = 0f;
    private bool looking;

    private void Awake()
    {
        homesickAmount = 0f;
        Raycaster.LookingAt += Raycaster_LookingAt;
    }

    private void Update()
    {
        if (looking)
        {
            if (homesickAmount > 0f)
            {
                homesickAmount -= relaxingSpeed;
            }
        }
        else
        {
            if (homesickAmount < 100f)
            {
                homesickAmount += longingSpeed;
            }
        }

        homesickBar.BarValue = homesickAmount;
    }

    private void OnDestroy()
    {
        Raycaster.LookingAt -= Raycaster_LookingAt;
    }

    private void Raycaster_LookingAt(Transform target)
    {
        if (target != transform)
        {
            looking = false;
            return;
        }

        looking = true;
    }
}
