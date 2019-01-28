using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed;
    [SerializeField]
    RandomActivator randomActivator;

    private MeshRenderer meshRenderer;
    private bool lookingAtEarth;

    private void Awake()
    {
        Raycaster.LookingAt += Raycaster_LookingAt;
        randomActivator.SetActiveAll(false);
        lookingAtEarth = false;
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
            randomActivator.SetActiveAll(false);
            lookingAtEarth = false;
            return;
        }

        if (!lookingAtEarth)
        {
            lookingAtEarth = true;
            randomActivator.SetActiveRandom();
            meshRenderer = randomActivator.GetCurrentActiveObject().GetComponent<MeshRenderer>();
            meshRenderer.material.color = new Color(1f, 1f, 1f, 0f);
            StopAllCoroutines();
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float alpha = 0f;

        while (meshRenderer.material.color.a < 1f)
        {
            alpha += fadeSpeed * 60 * Time.deltaTime / 256f;
            meshRenderer.material.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }
}