using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{

    public Transform playerPos_Arena;
    public Transform enemyPos1_Arena;


    // Start is called before the first frame update
    void Start()
    {
        initBattle();
    }

    public void initBattle(){
        foreach(GameObject playerGL in GameManager.Instance.playerGLs){
            playerGL.gameObject.transform.position = playerPos_Arena.position;
            playerGL.transform.localScale = playerGL.GetComponent<GLAttributes>().battleSize;

            //playerGL.GetComponent<GLCommonActions>().DoBeforeFightAnim();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            
            enemy.transform.position = enemyPos1_Arena.position;
            //enemy.GetComponent<GLCommonActions>().DoBeforeFightAnim();
        }

        // wait for 1 second
        List<GameObject> everyGladiatorInArena = new List<GameObject>();
        foreach(GameObject playerGL in GameManager.Instance.playerGLs){
            everyGladiatorInArena.Add(playerGL);
        }
        
        everyGladiatorInArena.AddRange(enemies);

        StartBattle(everyGladiatorInArena);
    }

    public void StartBattle(List<GameObject> everyGladiator){
        StartCoroutine(StartBattleCoroutine(everyGladiator));
    }

    IEnumerator StartBattleCoroutine(List<GameObject> everyGladiator)
    {
        yield return new WaitForSeconds(1f);

        foreach(GameObject gladiator in everyGladiator){
            gladiator.GetComponent<GLBattleAI>().StartAI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
