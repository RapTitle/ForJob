using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceCon : MonoBehaviour
{
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void SetAudio(AudioClip clip,bool loop)
    {
        source.clip = clip;
        source.loop = loop;
        source.PlayOneShot(clip);
    }
}
