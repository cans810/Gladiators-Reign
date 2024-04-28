using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{
    public Transform playerPos_CellView;
    public Camera mainCamera;
    public Camera secondaryCamera;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = false;
        secondaryCamera.enabled = true;

        Player.Instance.gameObject.transform.position = playerPos_CellView.position;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Player.Instance.transform.local = 
        InitCell();

    }

    public void InitCell(){
        Player.Instance.GetComponent<Animator>().SetBool("RestCampfire",false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
