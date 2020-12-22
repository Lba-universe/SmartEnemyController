# Smart Enemy Controller

### ![itch.io upload](https://lba-universe.itch.io/aicontroller)

**Created a Smart Controller for this modes:**
* Coward: The enemy chooses, from the targets on his list the most far target from the player.
* Brave: The enemy chooses, from the targets on his list the closest target to the player. 
* Chaser: The enemy chases players. 
* DestoryEngine: The enemy tries to reach the middle of the building to the engine (to destory him)
![](https://github.com/Lba-universe/SmartEnemyController/blob/main/pics/enemycontroller.png)
####
**Scene: EnemyController.unity** 

#### 
**Scripts**



EnemyMovement.cs - Moves the enemy towards the given target ![link](https://github.com/Lba-universe/SmartEnemyController/blob/main/Assets/Scripts/2-npc/EnemyMovement.cs)

EnemyController.cs - set to EnemyMovement target by selecting mode ``` enum ModeSwitching { None, Chaser, Brave, Coward, DestoryEngine }; ``` ![link](https://github.com/Lba-universe/SmartEnemyController/blob/main/Assets/Scripts/2-npc/EnemyController.cs)

DestoryOnTrigger.cs - When The enemy reach the engine the collider is triggered and engine is destoryed. ![link](https://github.com/Lba-universe/SmartEnemyController/blob/main/Assets/Scripts/2-npc/DestoryOnTrigger.cs)

####
### **Example Pics From the scene**
#### Brave - you can see the enemy stand in the closest point to player
![](https://github.com/Lba-universe/SmartEnemyController/blob/main/pics/brav1e.png)
#### Coward - you can see the enemy stand in the most far point from player
![](https://github.com/Lba-universe/SmartEnemyController/blob/main/pics/coward.png)
#### Chaser - the enemy is on the player 
![](https://github.com/Lba-universe/SmartEnemyController/blob/main/pics/chaser.png)
#### DestoryEngine - in this picture trigger is turned off so you can see the engine
![](https://github.com/Lba-universe/SmartEnemyController/blob/main/pics/engine.png)


## Credits

Base Code Programming:
* Michael Lemberger
* Erel Segal-Halevi

![link](https://github.com/gamedev-at-ariel/06-3d-terrain-ai)


Graphics:
* [Sci-Fi Gun Light](https://assetstore.unity.com/packages/3d/props/guns/sci-fi-gun-light-87916)
* [Sci-Fi Styled Modular Pack](https://assetstore.unity.com/packages/3d/environments/sci-fi/sci-fi-styled-modular-pack-82913)
* [Toon Soldiers Demo](https://assetstore.unity.com/packages/3d/characters/toon-soldiers-demo-69684)

Online course:
* [Unity RPG](https://www.gamedev.tv/p/unity-rpg/?product_id=1503859&coupon_code=JOINUS).
