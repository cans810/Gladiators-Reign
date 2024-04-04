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

    public void WalkRight()
    {
        attributes.inAction = true;
        StartCoroutine(StartWalkRight());
    }

    IEnumerator StartWalkRight()
    {
        
        float targetX = transform.position.x + attributes.walk_distance;

        while (transform.position.x <= targetX)
        {
            float movementAmount = attributes.walk_speed * Time.deltaTime;
            Vector3 movement = new Vector3(movementAmount, 0f, 0f);

            transform.position += movement;

            yield return null;
        }

        attributes.inAction = false;
    }

    public void WalkLeft()
    {
        attributes.inAction = true;
        StartCoroutine(StartWalkLeft());
    }

    IEnumerator StartWalkLeft()
    {
        float targetX = transform.position.x - attributes.walk_distance;

        while (transform.position.x >= targetX)
        {
            float movementAmount = attributes.walk_speed * Time.deltaTime;
            Vector3 movement = new Vector3(-movementAmount, 0f, 0f);

            transform.position += movement;

            yield return null;
        }

        attributes.inAction = false;
    }

}
