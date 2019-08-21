using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSound()
    {
        clickAudio.PlayOneShot(clickAudio.clip, 0.7f);
    }
}
