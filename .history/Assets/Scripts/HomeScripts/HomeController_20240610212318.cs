using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    public GameObject playerPos;

    // Start is called before the first frame update
    void Start()
    {
        // reset size
        transform.localScale = Player.Instance.GetComponent<GLAttributes>().battleSize;
        // set new size
        Player.Instance.transform.localScale *= 4;

        Player.Instance.transform.position = playerPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
