using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{
    public GameObject Cell;

    public Camera mainCamera;
    public Transform playerPos_Arena;
    public Transform enemyPos1_Arena;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera.GetComponent<CameraFollowPlayer>().enabled = false;

        InitCellView();
    }

    public void InitCellView(){
        mainCamera.enabled = false;
        Cell.GetComponent<CellManager>().cellCamera.enabled = true;

        Player.Instance.transform.localScale = Player.Instance.GetComponent<Attributes>().battleSize * 3.2f;
        Player.Instance.gameObject.transform.position = Cell.GetComponent<CellManager>().player_Cell_Pos.position;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        
        Player.Instance.GetComponent<AnimationsManager>().StopAnim("RestCampfire");


        Cell.GetComponent<CellManager>().SpeakingText.GetComponent<TextWritingEffect>().AnimateText("Are you ready gladiator?");
    }

    public void YesButton()
    {
        mainCamera.GetComponent<CameraFollowPlayer>().enabled = true;
        Cell.GetComponent<CellManager>().cellCamera.enabled = false;
        mainCamera.enabled = true;

        Player.Instance.gameObject.transform.position = playerPos_Arena.position;
        Player.Instance.transform.localScale = Player.Instance.GetComponent<Attributes>().battleSize;

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

    public void NoButton(){
        Cell.GetComponent<CellManager>().YesButton.SetActive(false);
        Cell.GetComponent<CellManager>().NoButton.SetActive(false);
        Cell.GetComponent<CellManager>().OkButton.SetActive(true);

        Cell.GetComponent<CellManager>().SpeakingText.GetComponent<TextWritingEffect>().AnimateText("You have no other choice...");
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
