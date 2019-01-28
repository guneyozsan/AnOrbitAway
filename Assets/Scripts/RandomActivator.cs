using System.Collections.Generic;
using UnityEngine;

public class RandomActivator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gameObjects;

    private int current = -1;

    public void SetActiveRandom()
    {
        int next = 0;

        if (gameObjects.Count > 1)
        {
            do
            {
                next = UnityEngine.Random.Range(0, gameObjects.Count);
            }
            while (next == current);
        }

        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (i == next)
            {
                gameObjects[i].SetActive(true);
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }

        current = next;
    }

    public void SetActiveAll(bool value)
    {
        foreach (GameObject g in gameObjects)
        {
            g.SetActive(value);
        }
    }

    public GameObject GetCurrentActiveObject()
    {
        return gameObjects[current];
    }
}
