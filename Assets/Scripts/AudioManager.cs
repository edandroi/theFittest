using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource bgAudioSource;

    public AudioClip bgMusic;
    
    void Start()
    {
        bgAudioSource.PlayOneShot(bgMusic);
    }


    void Update()
    {
        
    }
}
