using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SaveSystem : Singleton<SaveSystem>
{
    public string saveFileName = "save.chop";
    public string backupSaveFileName = "save.chop.bak";

    [SerializeField] private InventorySO playerInventory;
    public Save saveData = new Save();

    public  void SaveDataToDisk()
    {
        //保存背包数据
        saveData.itemStacks.Clear();
        saveData.saveQueseLine = QuestManager.GetInstance().currQuestLineNum;
        saveData.saveQuest = QuestManager.GetInstance().currQuestNum;
        saveData.saveStep = QuestManager.GetInstance().currStepNum;
        foreach (var itemSatck in  playerInventory.currItemStacks)
        {
              saveData.itemStacks.Add(new SerializedItemStack(itemSatck.item.Guid,itemSatck.amount));
        }
        Debug.Log("Save");
        if(FileManager.MoveFile(saveFileName,backupSaveFileName))
            if (FileManager.WritemToFile(saveFileName, saveData.ToJsonm()))
            {
                Debug.Log("Save Successful");
            }
    }

    public bool LoadSaveDataFromDisk()
    {
        if (FileManager.LoadFromFile(saveFileName, out var json))
        {
            //然后就可以使用saveData将数据传递给背包以及任务系统了。
            saveData.LoadFromJson(json);
            return true;
        }
        return false;
    }


    public IEnumerator LoadSaveInventory()
    {
        // playerInventory.currItemStacks.Clear();
        foreach (var serializedItemStack in saveData.itemStacks)
        {
            var loadItemOperationhandle = Addressables.LoadAssetAsync<ItemSO>(serializedItemStack.itemGuid);
            yield return loadItemOperationhandle;
            if (loadItemOperationhandle.Status == AsyncOperationStatus.Succeeded)
            {
                var item = loadItemOperationhandle.Result;
                playerInventory.AddItem(item,serializedItemStack.amount);
            }
        }
    }
    
}
