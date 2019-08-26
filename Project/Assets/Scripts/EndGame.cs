using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        endGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void endGame()
    {
        Debug.Log("Game ended");
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
}
