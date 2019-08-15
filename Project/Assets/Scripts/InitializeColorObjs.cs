using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeColorObjs : MonoBehaviour
{
    [SerializeField] public string initColor = "grey";

    private void Awake()
    {
        string oldColor = ColorSwitchObjs.SwitchColor(initColor);
        Debug.Log("initOldColor: " + oldColor);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
