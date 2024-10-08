using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerID;

    public GladiatorManager glManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void giveXP(float amount){
        if (!glManager.state.waitingForLevelup){
            glManager.attributes.currentXP += amount;
        }
    }

    public void CheckLevelUp(){
        while (glManager.attributes.currentXP >= glManager.attributes.xpToNextLevel){
            LevelUp();
            glManager.state.waitingForLevelup = true;
        }
    }

    public void LevelUp()
    {
        glManager.attributes.currentXP -= attributes.xpToNextLevel;
        glManager.attributes.level++;
        glManager.attributes.xpToNextLevel = CalculateXPToNextLevel(attributes.level);
        // Additional logic for leveling up (e.g., increasing attributes)
        //IncreaseAttributes();
    }

}
