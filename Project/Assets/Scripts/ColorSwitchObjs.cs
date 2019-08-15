using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class ColorTags
{
    public static string grey = "grey";

    public static string brown = "brown";

    public static string yellow = "yellow";
}

public static class ColoRules
{
    public static Dictionary<string, string[]> rules = new Dictionary<string, string[]>(){
        {"grey",new string[]{ColorTags.grey, ColorTags.yellow}},
        {"brown",new string[]{ ColorTags.brown, ColorTags.grey }},
        {"yellow",new string[]{ ColorTags.yellow, ColorTags.brown }}

    };
}

public class ColorSwitchObjs
{
    public static string curColor;

    public static string SwitchColor(string newColor)
    {
        string oldColor = curColor;
        if (newColor != curColor)
        {
            ChangeColorObjs(newColor);
        }
        return oldColor != null ? oldColor : "grey";
    }

    private static void ChangeColorObjs(string newColor)
    {
        ColoredObj[] coloredObjs = GameObject.FindObjectsOfType<ColoredObj>();

        Debug.Log("Color: " + newColor + ":" + ColoRules.rules[newColor]);

        string[] curRules = ColoRules.rules[newColor];
        foreach (string rule in curRules)
        {
            Debug.Log("Rules: " + rule);
        }
        foreach (ColoredObj obj in coloredObjs)
        {
            if (curRules.Contains(obj.color))
            {
                obj.Show();
            }
            else
            {
                obj.Hide();
            }
        }
    }
}


