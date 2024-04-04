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
            float newX = Mathf.MoveTowards(transform.position.x, targetX, walk_speed * Time.deltaTime);

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            yield return null;
        }
    }

    public void MoveRight()
    {
        StartCoroutine(StartWalkRight());
    }
}
