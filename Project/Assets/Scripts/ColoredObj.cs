using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredObj : MonoBehaviour
{
    [SerializeField] public string color;
    public void Hide()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void Show()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
