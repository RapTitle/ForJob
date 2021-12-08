using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForllow : MonoBehaviour
{
    private Transform player;
    private Vector3 target;
    private Vector3 distance;
    private float speed=5f;

    private void Awake()
    {
        player = GameObject.Find("PigChef_Idle").transform;
        transform.LookAt(player.position);
        distance = player.position - transform.position;
    }

    private void LateUpdate()
    {
        target = player.position - distance;
        transform.position=Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
    }
}
