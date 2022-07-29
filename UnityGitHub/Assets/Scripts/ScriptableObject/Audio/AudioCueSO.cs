using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/AduioCueSO")]
public class AudioCueSO : ScriptableObject
{
    public List<AudioClip> audioClips;

    public AudioClip GetClips(int i)
    {
        return audioClips[i];
    }
}
