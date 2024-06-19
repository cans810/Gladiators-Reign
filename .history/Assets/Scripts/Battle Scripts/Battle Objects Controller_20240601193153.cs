using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{

    public Camera mainCamera;
    public Transform playerPos_Arena;
    public Transform enemyPos1_Arena;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<CameraFollowPlayer>().enabled = false;

        initBattle();
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
