using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private InputActionSO playerInput;

    private CharacterController playerController;

    private Vector3 currInput;
    private Vector3 currVelocity;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float moveSpeed;

    private Vector3 dic;
    [SerializeField] private bool isMove;
    [SerializeField] private bool isRun;
    [SerializeField] private bool isJump;
    

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Start()
    {
        // StartCoroutine(PhysicalMotionMoroution());
         currInput.y = -9.8f;
    }

    private void OnEnable()
    {
        playerInput.OnEnableGamePlay();
        playerInput.onMove += OnEventToMove;
        playerInput.onStopMove += OnEventToStopMove;
    }

    private void OnDisable()
    {
        playerInput.onMove -= OnEventToMove;
        playerInput.onStopMove -= OnEventToStopMove;
    }

    private void OnEventToMove(Vector2 vector2)
    {
        currInput.x = vector2.x;
        currInput.z = vector2.y;
        isMove = true;

    }

    private void OnEventToStopMove()
    {
        currInput.x = 0;
        currInput.z = 0;
        moveSpeed = 0;
        isMove = false;
    }

    // IEnumerator PhysicalMotionMoroution()
    // {
    //     while (gameObject.activeSelf)
    //     {
    //         playerController.Move(currVelocity*Time.deltaTime);
    //         yield return null;
    //     }
    // }

    private void Update()
    {
        if (isMove||isRun)
        { 
            dic = currVelocity.normalized;
            dic.y = 0;
            if(dic!=Vector3.zero) 
                transform.forward = Vector3.Slerp(transform.forward,currVelocity.normalized,0.05f);
            
            moveSpeed = Mathf.Lerp(moveSpeed, maxSpeed, 0.01f);
            
            
        }
        
        playerController.Move(currInput*Time.deltaTime*moveSpeed);
        currVelocity = playerController.velocity; 
       
        
        
        
        
    }
}
