using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredObj : MonoBehaviour
{
    [SerializeField] public string color;
    public void Hide()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public void Show()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
