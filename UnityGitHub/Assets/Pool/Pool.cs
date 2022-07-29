using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Tool.Pool
{
    [Serializable]
    public class Pool 
    {
        //对象池
        //选用什么结构来存取对象
       
       [SerializeField] private GameObject prefab; 
        public GameObject Prefab => prefab;
        
        private Queue<GameObject> queue;
        
        //此对象池中存储的对象数量
        [SerializeField] private int size;
    
        public int Size => size;
        //对象的初始化a
        
        //首先是Copy,对象池中的物体全部都是通过预制体Copy过来的
        private GameObject Copy()
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            return obj;
        }
    
        public void StartPool(Transform parent)
        {
            queue = new Queue<GameObject>();
            for (int i = 0; i < size; i++)
            {
                GameObject obj = Copy();
                obj.transform.SetParent(parent);
                queue.Enqueue(obj);
            }
        }
        
     
        private GameObject PreObj()
        {
            GameObject obj;
            //如果池子中的对象数量大于1，且池子中的第一个对象的状态为false
            if (queue.Count >= 1 && !queue.Peek().activeSelf)
            {
                //取出第一个对象
                obj = queue.Dequeue();
                obj.SetActive(true);
                queue.Enqueue(obj);//将此对象送到尾部
            }
            //池子中的对象全被占用了，需要新创建对象
            else
            {
                obj = Copy();
                obj.SetActive(true);
                queue.Enqueue(obj);
            }
    
            return obj;
        }
        //出池入池
        public GameObject GetObj()
        {
            GameObject obj = PreObj();
            return obj;
        }
    
        public GameObject GetObj(Vector3 V)
        {
            GameObject obj = PreObj();
            obj.transform.position = V;
            return obj;
        }
    
        public GameObject GetObj(Vector3 V, Quaternion Q)
        {
            GameObject obj = PreObj();
            obj.transform.position = V;
            obj.transform.rotation = Q;
            return obj;
        }
    
        public GameObject GetObj(Vector3 V, Quaternion Q, Vector3 LS)
        {
            GameObject obj = PreObj();
            obj.transform.position=V;
            obj.transform.rotation = Q;
            obj.transform.localScale = LS;
            return obj;
        }
        
    }

}

