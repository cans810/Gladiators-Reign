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

    IEnumerator startWalkRight(){
        
    }

    public void moveRight(){
        transform.Translate(Vector3.right * attributes.walk_distance * Time.deltaTime);
    }
}
