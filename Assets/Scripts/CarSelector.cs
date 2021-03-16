using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    private List<GameObject> cars;

    private int selectionIndex = 0;

    private void Start()
    {
        cars = new List<GameObject>();
        foreach (Transform t in transform)
        {
            cars.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        cars[selectionIndex].SetActive(true);
    }

    private void Update()
    {
            
    }

    public void Select(int index)
    {
        if (index == selectionIndex)
            return;
        if (index < 0 || index >= cars.Count)
            return;

        cars[selectionIndex].SetActive(false);
        selectionIndex = index;
        cars[selectionIndex].SetActive(true);
    }
}
