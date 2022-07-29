using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Itch.Tool.Pool
{
    [Serializable]
    public class PoolManager : MonoBehaviour
    {
        //所需要用到的池子
        //比如敌人池子
        [SerializeField] private List<Pool> audioPools;
    
        //使用字典存储
        private static Dictionary<GameObject, Pool> dic=new Dictionary<GameObject, Pool>();
    
        //父物体
        private GameObject parent;
    
    
        private void Awake()
        {
            parent = new GameObject("Pools");
          
            StartPool(audioPools);
        }
    
        private void StartPool(List<Pool> pools)
        {
            foreach (var pool in pools)
            {
                //为此池子中的物体创建子对象
                Transform t = new GameObject("Pool:" + pool.Prefab.name).transform;
                pool.StartPool(t);
                //可以使用id做Key吗，
                //如果要使用ID，那么id必须设计在对象的类中，这意味着要想通用，所有的类必须继承自同一个父类
                dic.Add(pool.Prefab,pool);
             
                t.SetParent(parent.transform);
            }
        }
        
        /// <summary>
        /// 根据prefab获得对象池中的物体
        /// </summary>
        /// <param name="prefab">需要获得的预制体</param>
        /// <returns></returns>
        public static GameObject Realse(GameObject prefab)
        { 
            
           
           Debug.Log(prefab.GetInstanceID());
    #if UNITY_EDITOR
            
            if (!dic.ContainsKey(prefab))
            {
                 Debug.Log(prefab.name+"未设置此缓存池");
            }
              
    #endif 
            Debug.Log("Success");
            return dic[prefab].GetObj();
    
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        public static GameObject Realse(GameObject prefab, Vector3 V)
        {
           
    #if UNITY_EDITOR
            if(!dic.ContainsKey(prefab))
                Debug.Log(prefab.name+"未设置此此缓存池");
    #endif
            return dic[prefab].GetObj(V);
        }
    
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="V"></param>
        /// <param name="Q"></param>
        /// <returns></returns>
        public static GameObject Realse(GameObject prefab, Vector3 V, Quaternion Q)
        {
    #if UNITY_EDITOR
            if(!dic.ContainsKey(prefab))
                Debug.Log(prefab.name+"未设置此此缓存池");
    #endif
            return dic[prefab].GetObj(V, Q);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="V"></param>
        /// <param name="Q"></param>
        /// <param name="LS"></param>
        /// <returns></returns>
        public static GameObject Realse(GameObject prefab, Vector3 V, Quaternion Q, Vector3 LS)
        {
    #if UNITY_EDITOR
            if(!dic.ContainsKey(prefab))
                Debug.Log(prefab.name+"未设置此此缓存池");
    #endif
            return dic[prefab].GetObj(V, Q, LS);
        }

        public static void ClearDic()
        {
            dic.Clear();
        }
    }
    
    

}
