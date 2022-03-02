# 项目文档
---
## 项目说明
本项目学习自[Unity开源项目](https://github.com/UnityTechnologies/open-project-1)

素材来源于Unity开源项目,同时在制作过程中学习了[咖喱饭游戏](https://space.bilibili.com/434224775?spm_id_from=333.788.b_765f7570696e666f.2)这位B站UP主的视频。

## 项目实现内容
- ## 输入系统
-  - 使用了新版的InputSystem，通过配置动作表，创建ScriptableObject文件监听人物行动的方法。
- 基础的人物行动
-  - 使用了Unity的CharacterController，这样可以简单的让人物在斜坡上行走
   - 创建了简单的有限状态机处理人物行动逻辑。再通过新版InputSystem监听运行
- ## 背包系统
 - - 使用了ScriptableObject,将物品的属性拆分，创建TabType保存物品在背包中的分页，ItemType划分物品类型且包含了TabTyep,最后创建Item。
   - 创建完成Item就可以创建Inventory了，同样使用ScriptableObject，将物品和数量合并成一个类ItemStack，在Inventory中存储。

|**TabType**     |**ItemType**|**Item**|**ItemSatck**|Inventory|
|---------------|--------|----|--------|-------------------|
|TabNme（分页名）|ActionName（物品使用命）|ItemName（物品命）|Item(物品)|ItemSatck(物品和数量)
|TabType（分页类型）|ItemType（物品类型）|ItemSprite（物品缩略图）|Amount（数量）|
|        |ActionType（物品事件触发类型）|ItemDescribe（物品描述）|
|       |TabType（分页）|ItemColor（物品背景颜色）|
|        |       |Value（物品数值）|
|         |       |ItemType（物品类型）|
- ## 任务系统
 - - 同样依照背包系统的操作，将任务细化，分别为QuestLine（任务线）Quest （任务），Actor（任务人物），Step（步骤）DialogueData（对话数据）DialogueLine（对话）Choice（选择）
   - 虽然看起来繁琐，但是在进行设计QuestManager时可以简单清晰。
