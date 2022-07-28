using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;


public class WithJson
{
    private static WithJson instance;

    public static WithJson GetInstance
    {
        get
        {
            if (instance == null)
                instance = new WithJson();
            return instance;
        }
    }
     
    //我们需要存储的数据有：玩家背包中的物品、玩家HP，场景位置等
    /// <summary>
    /// 将T类型的对象保存成为Json
    /// </summary>
    /// <param name="t">类型</param>
    /// <param name="filePath">保存路径</param>
    /// <typeparam name="T"></typeparam>
    public void SaveToJson<T>(T t, string UnityAssetFilePath)
    {
        string filePath = Application.dataPath + UnityAssetFilePath;
        string jsonStr = JsonUtility.ToJson(t,true);
        
        //File.WriteAllBytes存在两个库中，一个Unity提供一个C#提供（微软提供）
        //想要读取SO,应该使用Unity提供的。using UnityEngine.Windows;
        File.WriteAllBytes(filePath,Encoding.UTF8.GetBytes(jsonStr));
        Debug.Log("Saved in"+filePath);
        AssetDatabase.Refresh();
    }
    
    
    /// <summary>
    /// 读取
    /// </summary>
    /// <param name="t">覆盖此对象</param>
    /// <param name="UnityAssetFilePath">读取的文件路径和名字</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T LoadFromFile<T>(T t, string UnityAssetFilePath)
    {
        string filePath = Application.dataPath + UnityAssetFilePath;
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(filePath),t);
            if (t == null)
            {
                Debug.Log("读取对象为空");
                return default;
            }
            else
            {
                Debug.Log("读取成功");
            }

            return t;
        }

        return t;
    }
}
