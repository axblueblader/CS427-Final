using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGlobals : MonoBehaviour
{
    [SerializeField] public string initColor = "grey";

    private void Awake()
    {
        string oldColor = ColorSwitchObjs.SwitchColor(initColor);
        Debug.Log("initOldColor: " + oldColor);
        PlayerStates.isDead = false;
    }
}
