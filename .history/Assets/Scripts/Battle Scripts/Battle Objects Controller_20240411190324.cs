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

        Player.Instance.gameObject.transform.position = Cell.GetComponent<CellManager>().player_Cell_Pos.position;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Player.Instance.transform.localScale = 
        new Vector3(Player.Instance.transform.localScale.x*3.2f,Player.Instance.transform.localScale.y*3.2f,Player.Instance.transform.localScale.z);
        Player.Instance.GetComponent<AnimationsManager>().StopAnim("RestCampfire",false);


        Cell.GetComponent<CellManager>().SpeakingText.GetComponent<TextWritingEffect>().AnimateText("Are you ready gladiator?");
    }

    public void YesButton()
    {
        Cell.GetComponent<CellManager>().cellCamera.enabled = false;
        mainCamera.enabled = true;

        Player.Instance.gameObject.transform.position = playerPos_Arena.position;
        Player.Instance.transform.localScale = new Vector3(Player.Instance.transform.localScale.x / 3.2f, Player.Instance.transform.localScale.y / 3.2f, Player.Instance.transform.localScale.z);
        Player.Instance.GetComponent<CommonActions>().DoBeforeFightAnim();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.transform.position = enemyPos1_Arena.position;
            enemy.GetComponent<CommonActions>().DoBeforeFightAnim();
        }

        // wait for 1 second 
    }

    public void NoButton(){
        Cell.GetComponent<CellManager>().YesButton.SetActive(false);
        Cell.GetComponent<CellManager>().NoButton.SetActive(false);
        Cell.GetComponent<CellManager>().OkButton.SetActive(true);

        Cell.GetComponent<CellManager>().SpeakingText.GetComponent<TextWritingEffect>().AnimateText("You have no other choice...");
    }

    public void StartBattle(){
        StartCoroutine(StartBattleCoroutine());
    }

    IEnumerator StartBattleCoroutine()
    {

        // Wait until the animation ends
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
