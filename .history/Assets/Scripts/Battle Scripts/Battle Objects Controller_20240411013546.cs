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
        InitCell();

    }

    public void InitCell(){
        mainCamera.enabled = false;
        secondaryCamera.enabled = true;

        Player.Instance.gameObject.transform.position = playerPos_CellView.position;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Player.Instance.transform.localScale = 
        new Vector3(Player.Instance.transform.localScale.x,Player.Instance.transform.localScale.y,Player.Instance.transform.localScale.z);
        Player.Instance.GetComponent<Animator>().SetBool("RestCampfire",false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
