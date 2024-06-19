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
        Player.Instance.gameObject.transform.position = playerPos_Arena.position;
        Player.Instance.transform.localScale = Player.Instance.GetComponent<GLAttributes>().battleSize;

        Player.Instance.GetComponent<CommonActions>().DoBeforeFightAnim();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.transform.position = enemyPos1_Arena.position;
            enemy.GetComponent<CommonActions>().DoBeforeFightAnim();
        }

        // wait for 1 second
        List<GameObject> everyGladiatorInArena = new List<GameObject>();
        everyGladiatorInArena.Add(Player.Instance.gameObject);
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
            gladiator.GetComponent<BattleAI>().StartAI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
