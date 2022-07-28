using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

using Unity.Mathematics;
using UnityEditor.Timeline.Actions;
using UnityEngine;

using UnityEngine.Rendering.UI;

namespace Itch.Enemy
{
    public enum TravelMode
    {
        Once,
        Loop,
    }
    
    public class AttackDrone : BaseEnemy
    {
      
        public TravelMode travelMode=TravelMode.Once;
        

        //public Transform[] targetTransforms;
        public float moveSpeed;
       
        public float rotateSpeed;
        //private int currTarget=0;
        //追踪目标
        public Transform traceTarget;

        public float sightRange;

        public float attackRange;
        //与敌人高度差
        public float height;
        
        //与敌人半径
    
        //角速度
        public float angularSpeed;

        public int currTarget;
      

        protected override void Awake()
        {
          
        }

        private void OnEnable()
        {
          
        }


        #region 状态

        
        //巡逻状态
        public override void PatrolState()
        {
            if (Vector3.Distance(transform.position, targetTransforms[currTarget].position) <= 0.5f)
            { 
                   currTarget++;    
                    if (currTarget >= targetTransforms.Count) 
                        currTarget = 0;
            }
            
         
            //转向
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(targetTransforms[currTarget].position-transform.position),
                rotateSpeed*Time.deltaTime);

            transform.position += transform.forward * 3 * Time.deltaTime;
          
          
        }
    
        //追踪状态
        public override void TraceState()
        {

            if (traceTarget == null)
            {
                Debug.Log("traceTarget未设置");
                return;
            }
         
           
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(traceTarget.position-transform.position),
                rotateSpeed*Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        
        //攻击状态
        public override void AttackState()
        {
            //敌人旋转
            transform.RotateAround(traceTarget.position,Vector3.up, angularSpeed*Time.deltaTime);
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(traceTarget.position-transform.position),rotateSpeed*Time.deltaTime );
        }
        
        
        //待机状态
        public override void IdleState()
        {
            base.IdleState();
        }

        
        //死亡状态
        public override void DieState()
        {
            base.DieState();
        }

        #endregion
        
       


        #region 逻辑判断

        
        //巡逻判断
        public override bool ToPatrol()
        {
            Debug.Log("ToPatrol");
            if (traceTarget==null||Vector3.Distance(traceTarget.position, transform.position) > sightRange)
                return true;
             
            return false;
        }


        //追踪判断
        public override bool ToTrace()
        {
          
            if (traceTarget == null)
                return false;
            float tmp = Vector3.Distance(traceTarget.position, transform.position);
            if ( tmp < sightRange&&tmp>attackRange)//如果需要在攻击状态不进行移动，则需要加上>droneData.attackRange
                return true;
            else
                return false;
        }

        
        //攻击判断
        public override bool ToAttack()
        {
            
            Debug.Log("ToAttack");
            if (traceTarget == null)
                return false;
            else if (Vector3.Distance(traceTarget.position, transform.position) < attackRange)
                return true;
            return false;
        }
        
        #endregion
      
        
        
    
        
        
        //Trigger的大小必定是大于视野范围的
       //进入Trigger后获得tarceTarget，但不追踪，需要距离判断追踪和攻击
        public void OnTriggerChange(bool entered, GameObject who)
        {
            
            if (entered&&who.CompareTag("Player"))
            {
                traceTarget = who.transform;
            }

            if (!entered && who.CompareTag("Player"))
            {
              //  traceTarget = null;
            }

        }

        public void OnTriggerDeath(bool entered, GameObject who)
        {
            if (entered && who.CompareTag("Bullet"))
            {
                //受伤or死亡函数
            }
        }
        
       

      
        
      
    
    
     
    }

}
