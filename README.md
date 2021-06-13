# Five

| 界面 | 功能                                | 脚本                  | 脚本功能                                                     | 子功能       |              |
| ---- | ----------------------------------- | --------------------- | ------------------------------------------------------------ | ------------ | ------------ |
| Main | 进入游戏界面                        | LoginInit             | 1.初始化场景内所有UI                                         |              |              |
|      |                                     | 进入游戏控制器        | 2.实例化切换场景工具 并设置跨场景不销毁                      | LevelLoader  |              |
|      |                                     |                       | 3.显示进入游戏UI                                             | Main         |              |
|      |                                     |                       | 4.播放背景音乐                                               |              |              |
|      |                                     | GameSaveManager       | 1.保存和载入仓库信息                                         |              |              |
|      |                                     | 游戏保存和载入控制器  | 2.保存和载入玩家信息                                         |              |              |
|      | 1.进入新游戏或者载入以前的存档/退出 | Main                  |                                                              |              |              |
|      | 2跨场景切换功能                     | LevelLoader           |                                                              |              |              |
|      |                                     |                       |                                                              |              |              |
|      |                                     |                       |                                                              |              |              |
| Home | 管理游戏进行一定的初始化和设置      | GameManager           | 1.管理GameMode、场景类别、敌人列表、NPC列表、是否释放技能中、是否装有装备、是否boss死亡、是否游戏结束 |              |              |
|      |                                     | 游戏管理员            | 2.当主角死亡同时没有死亡界面时ShowGameOverPanel              |              |              |
|      |                                     |                       | 3.载入游戏存档，没有存档则载入空存档                         |              |              |
|      |                                     |                       | 4.场景切换的过渡                                             |              |              |
|      |                                     |                       | 5.初始化对话窗口                                             |              |              |
|      |                                     |                       | 6.根据不同场景显示特定UI（ButtonInHome、Controller、Settings InfoPanel） |              |              |
|      |                                     |                       | 7.根据不同视角选择不同主角                                   |              |              |
|      |                                     | Inventorymanager      | 1.当InventoryManager启动时 刷新当前仓库                      |              |              |
|      |                                     | 仓库管理器            | 2.更新商品信息                                               |              |              |
|      |                                     |                       | 3.刷新当前仓库                                               |              |              |
|      |                                     | DialogManager         | 1.设置对话信息包括响应函数                                   | DialogSystem | 对话系统实现 |
|      |                                     | 对话管理器            |                                                              |              |              |
|      |                                     | AdsPrepare            | 1.返回广告准备好了                                           |              |              |
|      |                                     | 广告准备器            | 2.当广告结束时给予奖励                                       |              |              |
|      |                                     | PlayerInfoManager     | 1.玩家使用物品获得效果                                       |              |              |
|      |                                     | 玩家信息展示管理器    | 2.装备                                                       |              |              |
|      |                                     |                       | 3.挂载技能                                                   |              |              |
|      |                                     |                       | 4.清空技能挂载点                                             |              |              |
|      |                                     |                       | 5.存储角色信息                                               |              |              |
|      |                                     | GameSaveManager       | 1.保存和载入仓库信息                                         |              |              |
|      |                                     | 游戏保存和载入控制器  | 2.保存和载入玩家信息                                         |              |              |
|      |                                     | SkillTreeManager      | 1.显示技能信息                                               |              |              |
|      |                                     | 技能/天赋管理器       | 2.更新UI和按钮                                               |              |              |
|      |                                     |                       | 3.更新天赋点                                                 |              |              |
|      |                                     |                       | 4.升级天赋                                                   |              |              |
|      |                                     |                       | 5.更新技能信息                                               |              |              |
|      |                                     | BeatManager           | 1.管理攻击方向、力道、玩家朝向是否连击中等等                 |              |              |
|      |                                     | 攻击管理器            |                                                              |              |              |
|      |                                     | PlayerState           | 管理玩家名称 描述 等级 个人信息等                            |              |              |
|      |                                     | 升级管理器            |                                                              |              |              |
|      | 管理角色                            | Bodyhit               |                                                              |              |              |
|      |                                     | ArmourHit             |                                                              |              |              |
|      |                                     | PlayerController      |                                                              |              |              |
|      |                                     | PlayerAnimation       |                                                              |              |              |
|      |                                     | HealthBarSlider       |                                                              |              |              |
|      |                                     | HitPoint              |                                                              |              |              |
|      | 游戏设计                            |                       | 音效大小                                                     |              |              |
|      |                                     |                       | 音量大小                                                     |              |              |
|      | 角色信息展示                        | Settings(Clone)       |                                                              |              |              |
|      |                                     | Button In Home(Clone) |                                                              |              |              |
|      |                                     | Controller(Clone)     |                                                              |              |              |
|      |                                     | Dialog Panel(Clone)   |                                                              |              |              |
|      |                                     |                       |                                                              |              |              |
|      |                                     |                       |                                                              |              |              |
| Map  | 管理野外地区战斗                    | RoomGenerator         |                                                              |              |              |

## 角色功能

| 功能         |      |
| ------------ | ---- |
| 攻击系统     |      |
| 天赋系统     |      |
| 背包系统     |      |
| 本地存储系统 |      |
| 随机地图系统 |      |
| 小地图       |      |
| NPC          |      |
| 对话系统     |      |
| 云端资源分发 |      |



| 角色躯干                                     | 脚本             | 功能     |
| -------------------------------------------- | ---------------- | -------- |
|                                              | BodyHit          | 检测位置 |
| 躯干碰撞体/刚体/动画机/CinmachineSource/IK2D | ArmourHit        |          |
|                                              | PlayerCOntroller |          |
|                                              | PlayerrAnimation |          |
| healthBarCanVas上挂载                        | HealthBarSlider  |          |
| HitPoint挂载                                 | HitPoint         |          |
| landFX/JumpFX                                | JumpFX           |          |

| 角色攻击移动技能系统 | 左走/右走    | 其实这两个还OK的 |
| -------------------- | ------------ | ---------------- |
|                      | 左跑/右跑    |                  |
|                      | 跳跃         | 也还OK           |
|                      | 边跳跃边移动 |                  |
|                      | 普攻         |                  |
|                      | 跳击         |                  |
|                      | 空中攻击     |                  |
|                      | 空中滞空连击 |                  |





### 攻击系统

### 天赋系统

### 背包系统

### 本地存储系统

### 随机地图系统

### 小地图

### NPC

### 对话系统

### 云端资源分发

### 热更新

### 预下载

