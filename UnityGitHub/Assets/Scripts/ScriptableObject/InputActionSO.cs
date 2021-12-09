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
   
   public event UnityAction<Vector2,bool> onCamerMove=delegate(Vector2 arg0, bool b) {  };
   public event UnityAction onEnableMouseCon=delegate {  };
   public event UnityAction onDisableMouseCon=delegate {  };

   private InputActions _inputActions;
   private InputActions.IGamePlayActions _gamePlayActionsImplementation;
   private InputActions.IGamePlayActions _gamePlayActionsImplementation1;


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
    
    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        onCamerMove.Invoke(context.ReadValue<Vector2>(),IsDeviceMouse(context));
    }

    private bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";
    public void OnCameraController(InputAction.CallbackContext context)
    {
        if(context.phase==InputActionPhase.Performed)
            onEnableMouseCon.Invoke();
        if (context.phase == InputActionPhase.Canceled)
            onDisableMouseCon.Invoke();
        
    }

   
}
