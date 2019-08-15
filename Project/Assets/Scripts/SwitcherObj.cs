using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherObj : MonoBehaviour
{
    public bool isOn = false;

    private bool isSwitched = false;

    private string oldColor;

    [SerializeField] private string switcherColor;
    private void Start()
    {
        isOn = false;
    }

    private void Update()
    {
        if (isOn)
        {
            if (!isSwitched)
            {
                isSwitched = true;
                oldColor = ColorSwitchObjs.SwitchColor(switcherColor);
            }
        }
        else
        {
            if (isSwitched)
            {

                isSwitched = false;
                if (oldColor != null)
                {
                    ColorSwitchObjs.SwitchColor(oldColor);
                }
            }
        }
    }
}