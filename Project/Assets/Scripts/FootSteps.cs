using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    [SerializeField] public AudioSource audio;

    [SerializeField] private float stopDelay;

    [SerializeField] private float stopTimer = 0;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            if (characterController.isGrounded && !audio.isPlaying)
            {
                audio.Play();
            }
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            audio.Pause();
            stopTimer -= Time.deltaTime;
        }

        if (stopTimer <= 0)
        {
            stopTimer += stopDelay;
            audio.Stop();
        }
    }
}
