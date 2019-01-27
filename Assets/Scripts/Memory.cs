using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Memory : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed;
    [SerializeField]
    private Transform earth;

    private MeshRenderer meshRenderer;
    private bool lookingAtEarth;

    private void Awake()
    {
        Raycaster.LookingAt += Raycaster_LookingAt;
        meshRenderer = GetComponent<MeshRenderer>();
        gameObject.SetActive(false);
        lookingAtEarth = false;
    }

    private void OnDestroy()
    {
        Raycaster.LookingAt -= Raycaster_LookingAt;
    }

    private void Raycaster_LookingAt(Transform obj)
    {
        if (obj != earth)
        {
            if (lookingAtEarth)
            {
                gameObject.SetActive(false);
                lookingAtEarth = false;
            }

            return;
        }

        lookingAtEarth = true;
        gameObject.SetActive(true);
        meshRenderer.material.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(FadeIn());
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