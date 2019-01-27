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

    private float homesickAmount;
    private bool looking;

    private void Awake()
    {
        homesickAmount = 100f;
        Raycaster.LookingAt += Raycaster_LookingAt;
    }

    private void Update()
    {
        if (looking)
        {
            if (homesickAmount < 100f)
            {
                homesickAmount += longingSpeed;
            }
        }
        else
        {
            if (homesickAmount > 0f)
            {
                homesickAmount -= relaxingSpeed;
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
        if (target == null ||
            target != transform)
        {
            looking = false;
            return;
        }

        looking = true;
    }
}
