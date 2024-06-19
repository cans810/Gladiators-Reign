using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public GameObject SpeakingText;
    public Transform player_Cell_Pos;

    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject OkButton;

    // Start is called before the first frame update
    void Start()
    {
        OkButton.SetActive(false);

        InitCellView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitCellView(){
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
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        OkButton.SetActive(true);

        SpeakingText.GetComponent<TextWritingEffect>().AnimateText("You have no other choice...");
    }

}
