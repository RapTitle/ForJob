using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   [SerializeField] private InputActionSO playerInput;
   [SerializeField] private CinemachineFreeLook freeLookVCam;
   private bool isRMBPressed;
   [SerializeField, Range(.5f, 3f)] private float speedMultiplier = 1f;

   private bool cameraMovementLock = false;

   private void OnEnable()
   {
        playerInput.onCamerMove+=OnCameraMove;
        playerInput.onEnableMouseCon+=OnEnableMouseCon;
        playerInput.onDisableMouseCon += OnDisableMouseCon;
   }

   private void OnDisable()
   {
      playerInput.onCamerMove -= OnCameraMove;
      playerInput.onEnableMouseCon -= OnEnableMouseCon;
      playerInput.onDisableMouseCon -= OnDisableMouseCon;

   }


   private void OnEnableMouseCon()
   {
      isRMBPressed = true;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      StartCoroutine(DisableMouseConForFrame());
   }

   IEnumerator DisableMouseConForFrame()
   {
      cameraMovementLock = true;
      yield return new WaitForEndOfFrame();
      cameraMovementLock = false;
   }

   private void OnDisableMouseCon()
   {
      isRMBPressed = false;
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;

      freeLookVCam.m_XAxis.m_InputAxisValue = 0;
      freeLookVCam.m_YAxis.m_InputAxisValue = 0;
   }

   void OnCameraMove(Vector2 cameraMovement, bool isDeviceMouse)
   {
      if (cameraMovementLock)
         return;
      if(isDeviceMouse&&!isRMBPressed)
         return;
      freeLookVCam.m_XAxis.m_InputAxisValue = cameraMovement.x * Time.deltaTime * -speedMultiplier;
      freeLookVCam.m_YAxis.m_InputAxisValue = cameraMovement.y * Time.deltaTime * -speedMultiplier;
   }
}
