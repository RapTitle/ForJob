using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private InputActionSO playerInput;
     private FSMSystem stateMachine;

    private CharacterController playerController;
    [HideInInspector] public Animator anim;
    [SerializeField] private Transform gamePlayCamera;
    private Vector3 cameraForward;
    private Vector3 cameraRight;

    //用作状态机控制
    [HideInInspector] public Vector2 currInput;
    [HideInInspector] public Vector3 currVelocity;
    [HideInInspector] public Vector3 currDic;
    public float maxSpeed;
    public float moveSpeed;
    public float jumpSpeed;

    [HideInInspector] public Vector3 dic;
    [SerializeField] public bool isMove;
    [SerializeField] public bool isRun;
    [SerializeField] public bool isJump;


    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        stateMachine = new FSMSystem(this);
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
        playerInput.onRun += OnEventToRun;

    }

    private void OnDisable()
    {
        playerInput.OnDisableAllInput();
        playerInput.onMove -= OnEventToMove;
        playerInput.onStopMove -= OnEventToStopMove;
        playerInput.onRun -= OnEventToRun;
    }

    
    //当我点击方向键后，触发移动事件，状态机处在MoveState上，判断条件是
    //currInput！=Vector3。zero?进入状态：进入下一个状态
    private void OnEventToMove(Vector2 vector2)
    {
        currInput = vector2;
        isMove = true;
        anim.SetBool("IsMoveing", true);
    }
    
    private void OnEventToStopMove()
    {
        currInput.x = 0;
        currInput.y = 0;
        moveSpeed = 0;
        isMove = false;
        anim.SetBool("IsMoveing", false);
        if (isRun)
        {
            maxSpeed /= 2;
            isRun = false;
        }
    }

    private void OnEventToRun()
    {
        if (!isRun)
        {
            maxSpeed *= 2;
            isRun = true;
        }
    }

    private void OnEventToJump()
    {
        if (!isJump)
        {
            currInput.y = jumpSpeed;
        }
    }

    // IEnumerator PhysicalMotionMoroution()
    // {
    //     while (gameObject.activeSelf)
    //     {
    //         playerController.Move(currVelocity*Time.deltaTime);
    //         yield return null;
    //     }
    // }

    public void  SetCurrDic()
    {
         cameraForward = gamePlayCamera.forward;
         cameraForward.y = 0;
         cameraRight = gamePlayCamera.right;
         cameraRight.y = 0;
         currDic = cameraRight.normalized * currInput.x + cameraForward.normalized * currInput.y;
         currDic.y = -9.8f;
    }
    public void PlayerMove(Vector3 v)
    {
        playerController.Move(v * Time.deltaTime * moveSpeed);
        currVelocity = playerController.velocity;
    }

    private void Update()
    {
        // if (isMove)
        // {
        //     dic = currVelocity.normalized;
        //     dic.y = 0;
        //     if (dic != Vector3.zero)
        //         transform.forward = Vector3.Slerp(transform.forward, currVelocity.normalized, 0.1f);
        //
        //     moveSpeed = Mathf.Lerp(moveSpeed, maxSpeed, 0.01f);
        //     anim.SetFloat("MoveingSpeed", isRun ? moveSpeed / maxSpeed : 0);
        // }

        //应该加上相机旋转角度
       
        // currDic = Camera.current.transform.TransformDirection(currInput);
        // playerController.Move(currDic * Time.deltaTime * moveSpeed);
        // currVelocity = playerController.velocity;


    stateMachine.Update();

    }
}
