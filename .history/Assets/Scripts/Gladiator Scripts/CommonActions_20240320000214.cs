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

    IEnumerator StartWalkRight()
    {
        float targetX = transform.position.x + attributes.walk_distance;
        
        while (transform.position.x < targetX)
        {
            // Calculate the new position to move to
            float newX = Mathf.MoveTowards(transform.position.x, targetX, walkSpeed * Time.deltaTime);
            // Move the object
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            // Wait for the next frame
            yield return null;
        }
    }

    public void MoveRight()
    {
        StartCoroutine(StartWalkRight());
    }
}
