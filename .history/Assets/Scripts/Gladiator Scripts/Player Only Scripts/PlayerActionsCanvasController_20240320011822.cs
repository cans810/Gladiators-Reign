using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionsCanvasController : MonoBehaviour
{

    public void Awake(){

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.Instance.gameObject.transform.position.x-1,Player.Instance.gameObject.transform.position.y+5,
        Player.Instance.gameObject.transform.position.z);
    }

    public void walkRight(){
        Player.Instance.gameObject.GetComponent<CommonActions>().WalkRight();
    }

    public void walkLeft(){
        Player.Instance.gameObject.GetComponent<CommonActions>().WalkLeft();
    }
}
