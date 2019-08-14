using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatOnStep : MonoBehaviour
{

    [SerializeField] private Material stepOnMat;
    [SerializeField] private Material normalMat;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = normalMat;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision: " + other);
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = stepOnMat;
        }
    }
}
