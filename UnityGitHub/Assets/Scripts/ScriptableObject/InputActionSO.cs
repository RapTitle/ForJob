using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "PlayerInput")]
public class InputActionSO : ScriptableObject,InputActions.IGamePlayActions
{
   public event UnityAction<Vector2> onMove=delegate(Vector2 arg0) {  };
   public event UnityAction onStopMove=delegate {  }; 
   
   public event UnityAction onRun=delegate {  }; 
   public event UnityAction onJump=delegate {  }; 

   private InputActions _inputActions;
   private InputActions.IGamePlayActions _gamePlayActionsImplementation;


   private void OnEnable()
   {
       _inputActions = new InputActions();
       _inputActions.GamePlay.SetCallbacks(this);
   }


   public void OnEnableGamePlay()
   {
       _inputActions.GamePlay.Enable();
   }

   public void OnDisableAllInput()
   {
       _inputActions.Dispose();
   }
   
   

   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase==InputActionPhase.Performed)
            onMove.Invoke(context.ReadValue<Vector2>());
        if(context.phase==InputActionPhase.Canceled)
            onStopMove.Invoke();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.phase==InputActionPhase.Performed)
            onRun.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase==InputActionPhase.Performed)
            onJump.Invoke();
    }
}
