using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class PlayerStates
{
    public static bool isDead = false;

    public static void killPlayer()
    {
        isDead = true;
    }
}