using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropSound : MonoBehaviour
{
    [SerializeField] private AudioSource grassLandAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            grassLandAudio.PlayOneShot(grassLandAudio.clip, 0.7f);
        }
    }
}
