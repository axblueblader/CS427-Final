using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGlobals : MonoBehaviour
{
    [SerializeField] public string initColor = "grey";
    [SerializeField] public string levelName = "Level1";

    private void Awake()
    {
        string oldColor = ColorSwitchObjs.SwitchColor(initColor);
        Debug.Log("initOldColor: " + oldColor);
        GlobalRespawnVal.levelName = levelName;
    }
}
