using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public enum GameState
    {
        
        
    }
    public PlayAudio playAudio;

    private void Awake()
    {
        
        playAudio.InternalPlayAudio(true);
    }

    public void QuitAPP()
    {
        Application.Quit();
    }

    public void SaveGame()
    {
        
    }
 
}
