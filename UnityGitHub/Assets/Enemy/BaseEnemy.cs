using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace Itch.Enemy
{

   
    
    public abstract class BaseEnemy : MonoBehaviour
    {


        public int hP;
        
        //地面敌人路线
        public List<Transform> targetTransforms;

 
        //所有敌人的基类
        //初始化时就将data获取
        protected virtual void Awake()
        {
          
        }
    
        protected virtual void Start()
        {
            
        }
    
        //巡逻状态
        public virtual void PatrolState()
        {
        }
        
        
        //跟踪状态
        public virtual void TraceState()
        {
        }
    
        //攻击状态
        public virtual void AttackState()
        {
         
        }
        //待机状态
        public virtual void IdleState()
        {
            
        }
        
        
        //死亡状态
        public virtual void DieState()
        {
            
            
        }
        
        
        
        
        
        
        
        //状态切换条件
        public virtual bool ToTrace()
        {
            return false;
        }
    
        public virtual bool ToPatrol()
        {
            return false;
        }

        public virtual bool ToAttack()
        {
            return false;
        }

        public virtual bool ToIdle()
        {
            return false;
        }

        public virtual bool ToDie()
        {
            return false;
        }
        
        
        //。。。
    
    }

}
