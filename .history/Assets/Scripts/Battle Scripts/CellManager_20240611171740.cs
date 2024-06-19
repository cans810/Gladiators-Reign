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

    public Material litMaterial;

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
        foreach(GameObject playerGL in GameManager.Instance.playerGLs){
            playerGL.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
            Player.Instance.GetComponent<GLAttributes>().ChangeMaterial(litMaterial);  

            playerGL.transform.localScale = playerGL.GetComponent<GLAttributes>().battleSize * 3.2f;
            playerGL.gameObject.transform.position = player_Cell_Pos.position;
            playerGL.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            
            playerGL.GetComponent<AnimationsManager>().StopAnim("RestCampfire");
        }


        SpeakingText.GetComponent<TextWritingEffect>().AnimateText("Are you ready gladiator?");
    }

    public void YesButtonClicked()
    {
        ScreenFadeController.Instance.FadeToScene("BattleScene");
    }

    public void NoButtonClicked(){
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        OkButton.SetActive(true);

        SpeakingText.GetComponent<TextWritingEffect>().AnimateText("You have no other choice...");
    }

}
