using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject respawnLoc = GameObject.Find(GlobalRespawnVal.respawnLocName);

        GameObject player = GameObject.Find("PlayerBody");

        Debug.Log("resLoc: " + respawnLoc.transform.position + "resName: " + GlobalRespawnVal.respawnLocName);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = respawnLoc.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(GlobalRespawnVal.levelName);
        }
    }
}
