using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private InputActionSO playerInput;

    private CharacterController playerController;
    private Animator anim;
    [SerializeField] private Transform gamePlayCamera;
    private Vector3 cameraForward;
    private Vector3 cameraRight;

    private Vector2 currInput;
    private Vector3 currVelocity;
    private Vector3 currDic;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private Vector3 dic;
    [SerializeField] private bool isMove;
    [SerializeField] private bool isRun;
    [SerializeField] private bool isJump;


    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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

    private void Update()
    {
        if (isMove)
        {
            dic = currVelocity.normalized;
            dic.y = 0;
            if (dic != Vector3.zero)
                transform.forward = Vector3.Slerp(transform.forward, currVelocity.normalized, 0.1f);

            moveSpeed = Mathf.Lerp(moveSpeed, maxSpeed, 0.01f);
            anim.SetFloat("MoveingSpeed", isRun ? moveSpeed / maxSpeed : 0);
        }

        //应该加上相机旋转角度
        cameraForward = gamePlayCamera.forward;
        cameraForward.y = 0;
        cameraRight = gamePlayCamera.right;
        cameraRight.y = 0;
        currDic = cameraRight.normalized * currInput.x + cameraForward.normalized * currInput.y;
        currDic.y = -9.8f;
        // currDic = Camera.current.transform.TransformDirection(currInput);
        playerController.Move(currDic * Time.deltaTime * moveSpeed);
        currVelocity = playerController.velocity;




    }
}
