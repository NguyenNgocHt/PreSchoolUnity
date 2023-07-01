using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMono : MonoBehaviour
{
    AudioSource audioMono;
    public float time;
    private void Awake()
    {
        audioMono = GetComponent<AudioSource>();
    }
    private void Update()
    {
        time = audioMono.time / audioMono.clip.length;
        if (time==1 || !audioMono.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
