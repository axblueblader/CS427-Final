
using System;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }

    }

    public bool isPaused()
    {
        return paused;
    }

    public void togglePause()
    {
        Debug.Log("Pause panel: " + pausePanel.activeSelf);
        Debug.Log("Toggling Pause - Before: " + paused);
        if (Time.timeScale == 0f)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
            Cursor.lockState = CursorLockMode.None;
        }
        Debug.Log("Pause panel: " + pausePanel.activeSelf);
        Debug.Log("Toggling Pause - After: " + paused);
    }
}