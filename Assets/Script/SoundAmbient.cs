using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    private AudioSource ambientAudio;

    void Start()
    {
        ambientAudio = GetComponent<AudioSource>();
        ambientAudio.Play();
    }
}
