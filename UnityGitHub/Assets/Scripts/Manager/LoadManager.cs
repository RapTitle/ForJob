using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : Singleton<LoadManager>
{
   protected override void Awake()
   {
      base.Awake();
      DontDestroyOnLoad(gameObject);
   }

   public void LoadScene()
   {
      SceneManager.LoadScene(1);
   }

   public void QuitGameManager()
   {
      Application.Quit();
   }
}
