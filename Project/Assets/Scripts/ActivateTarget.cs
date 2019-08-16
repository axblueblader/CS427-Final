using UnityEngine;
using System.Collections;

public class ActivateTarget : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        target.SetActive(true);
    }
}