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
        transform.localScale = GetComponent<GLAttributes>().battleSize;
        // set new size
        transform.localScale *= 4;

        transform.position = playerPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
