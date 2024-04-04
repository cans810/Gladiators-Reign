using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObjectsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.GetComponent<Rigidbody2D>()
        transform.position = new Vector3(-2,-3.264662f,0);
        .constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
