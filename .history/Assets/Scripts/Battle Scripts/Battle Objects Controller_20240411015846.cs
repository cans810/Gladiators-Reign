using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{
    public Transform playerPos_CellView;
    public Camera mainCamera;
    public Camera secondaryCamera;

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
        secondaryCamera.enabled = true;

        Player.Instance.gameObject.transform.position = playerPos_CellView.position;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Player.Instance.transform.localScale = 
        new Vector3(Player.Instance.transform.localScale.x*3.2f,Player.Instance.transform.localScale.y*3.2f,Player.Instance.transform.localScale.z);

        Player.Instance.GetComponent<Animator>().SetBool("RestCampfire",false);
    }

    public void YesButton(){
        secondaryCamera.enabled = false;
        mainCamera.enabled = true;

        Player.Instance.gameObject.transform.position = playerPos_Arena.position;
        Player.Instance.transform.localScale = 
        new Vector3(Player.Instance.transform.localScale.x/3.2f,Player.Instance.transform.localScale.y/3.2f,Player.Instance.transform.localScale.z);
        
    }

    public void NoButton(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
