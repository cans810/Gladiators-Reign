using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{
    public Transform playerPos_CellView;
    public Camera secondaryCamera;
    public Camera secondaryCamera;


    // Start is called before the first frame update
    void Start()
    {
        Camera.main = secondaryCamera;
        Player.Instance.gameObject.transform.position = playerPos_CellView.position;
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        InitBattle();



        
    }

    public void InitBattle(){
        Player.Instance.GetComponent<Animator>().SetBool("RestCampfire",false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
