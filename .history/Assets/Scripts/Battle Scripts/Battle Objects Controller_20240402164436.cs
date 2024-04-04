using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.gameObject.transform.position = new Vector3(-2,-3.264662f,0);
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        InitBattle();
    }

    public void InitBattle(){
        Player.Instance.GetComponent<Animator>().SetBool("RestCampfire",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
