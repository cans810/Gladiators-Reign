using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonActions : MonoBehaviour
{
    Attributes attributes;
    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveRight(){

        gameObject.GetComponent<Player>().animator.SetBool("Idle",false);
        gameObject.GetComponent<Player>().animator.SetBool("Walking",true);
        changeEyes("eyesRight");
        gameObject.GetComponent<EntityAttributes>().destinationX = gameObject.GetComponent<Player>().rb.position.x + gameObject.GetComponent<EntityAttributes>().stepSize;
        inAction = true;
        movingRight = true;

        adjustMoveSpeed();
    }
}
