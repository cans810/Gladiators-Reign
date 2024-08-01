using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonArenaController : MonoBehaviour
{

    public Transform playerPos;
    public int gladiatorSpacing;

    // Start is called before the first frame update
    void Start()
    {
        // float totalWidth = (GameManager.Instance.playerGLs.Count - 1) * gladiatorSpacing;
        // Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

        // for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        // {
        //     if (i >= GameManager.Instance.playerGLs.Count)
        //     {
        //         continue;
        //     }
        //     adjustGladiatorTransform(GameManager.Instance.playerGLs[i], startPosition + new Vector3(i * gladiatorSpacing, 0, 0));
        // }

        // if there is only 1 gladiator selected to fight
        // disable all other player gladiators

        if(DungeonHomeController.sceneMode.Equals("MultiFight")){
            for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
            {
                if (!GameManager.Instance.gladiatorsSelectedForFight.Contains(GameManager.Instance.playerGLs[i]))
                {
                    GameManager.Instance.playerGLs[i].SetActive(false);
                }
            }
        }

        else{
            for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
            {
                if (GameManager.Instance.gladiatorSelectedForFight != GameManager.Instance.playerGLs[i])
                {
                    GameManager.Instance.playerGLs[i].SetActive(false);
                }
            }

            float totalWidth = (1 - 1) * gladiatorSpacing;
            Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

            for (int i = 0; i < 1; i++)
            {
                if (i >= 1)
                {
                    continue;
                }
                adjustGladiatorTransform(GameManager.Instance.gladiatorSelectedForFight, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));
            }
        }
    }

    public void adjustGladiatorTransform(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    public void enterFightButtonClicked(){
        ScreenFadeController.Instance.FadeToScene("BattleScene");
    }
}
