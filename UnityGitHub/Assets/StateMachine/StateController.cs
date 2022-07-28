using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itch.Enemy;

namespace Itch.Statemachine
{
    public class StateController : MonoBehaviour
    {
    
        
        //获取当前物体的移动、动画等，在此状态机中调用
        //对象的移动方式
        
        //如果将EnemyItem数据放在这里？
        /*
         * 将enemyitem放在这里，使用DataManager动态赋值
         * 所有的状态所执行的方法全都放在这里
         * 会造成一个问题，所有敌人所执行的各类State方法上一样，仅有数值的不同
         * 类似于，近战敌人与远程敌人没有了区别
         */
        
        public StateSO currState;
        //需要操作的对象
        public BaseEnemy enemy;
    
        private void Start()
        {
            
        }
    
        private void OnEnable()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            currState.UpdateState(this);
        }
    
        public void TransitionToState(StateSO targetState)
        {
            //如果为空，则代表继续此状态
            if (targetState == null)
                return;
            //还可以在运行Exit和Enter
            currState = targetState;
        }
    }

}
