using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{

    [SerializeField] private Material stepOnMat;
    [SerializeField] private Material normalMat;
    // Start is called before the first frame update

    private HashSet<int> objsOn = new HashSet<int>();
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = normalMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (objsOn.Count > 0)
        {

            gameObject.GetComponent<MeshRenderer>().material = stepOnMat;
        }
        else
        {

            gameObject.GetComponent<MeshRenderer>().material = normalMat;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision: " + other);
        objsOn.Add(other.gameObject.GetInstanceID());
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("collision: " + other);
        objsOn.Remove(other.gameObject.GetInstanceID());
    }
}
