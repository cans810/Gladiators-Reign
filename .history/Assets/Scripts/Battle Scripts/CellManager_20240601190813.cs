using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public Camera cellCamera;

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
        mainCamera.enabled = false;
        Cell.GetComponent<CellManager>().cellCamera.enabled = true;

        Player.Instance.transform.localScale = Player.Instance.GetComponent<Attributes>().battleSize * 3.2f;
        Player.Instance.gameObject.transform.position = Cell.GetComponent<CellManager>().player_Cell_Pos.position;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        
        Player.Instance.GetComponent<AnimationsManager>().StopAnim("RestCampfire");


        Cell.GetComponent<CellManager>().SpeakingText.GetComponent<TextWritingEffect>().AnimateText("Are you ready gladiator?");
    }

}
