using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerID;

    private GladiatorManager glManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        glManager = GetComponent<GladiatorManager>();
    }

    public void Update()

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
        glManager.attributes.currentXP -= glManager.attributes.xpToNextLevel;
        glManager.attributes.level++;
        glManager.attributes.xpToNextLevel = CalculateXPToNextLevel(glManager.attributes.level);
        // Additional logic for leveling up (e.g., increasing attributes)
        //IncreaseAttributes();
    }

    private int CalculateXPToNextLevel(int level)
    {
        // formula for XP needed for next level
        return Mathf.FloorToInt(100 * Mathf.Pow(1.1f, level - 1));
    }

}
