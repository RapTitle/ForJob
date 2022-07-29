using System.Collections;
using System.Collections.Generic;
using Itch.Tool.Pool;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
  [SerializeField]  private  GameObject audioSource;
    
    [SerializeField] private AudioCueSO audioCueSo;

    public void SetAudioCueSO(AudioCueSO audioCueSo)
    {
        this.audioCueSo = audioCueSo;
    }
    public void InternalPlayAudio(bool loop)
    {
        GameObject tmp = PoolManager.Realse(audioSource,transform.position);
        tmp.GetComponent<AudioSourceCon>().SetAudio(audioCueSo.GetClips(1),loop);
    }
    
}
