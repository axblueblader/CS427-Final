using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public bool isDead = false;

    [SerializeField] public GameObject deathScreen;

    public void killPlayer()
    {
        isDead = true;
        // RectTransfrom deathScreen = GameObject.Find("DeathScreen").GetComponent<RectTransfrom>();
        deathScreen.SetActive(true);
    }
}