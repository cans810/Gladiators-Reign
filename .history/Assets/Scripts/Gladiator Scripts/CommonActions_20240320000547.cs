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

    public void MoveRight()
    {
        StartCoroutine(StartWalkRight());
    }

    IEnumerator StartWalkRight()
    {
        float targetX = transform.position.x + attributes.walk_distance;

        while (transform.position.x < targetX)
        {
            float movementAmount = gameObject.GetComponent<EntityAttributes>().moveSpeed * Time.deltaTime;
                Vector3 movement = new Vector3(movementAmount, 0f, 0f);

            float newX = Mathf.MoveTowards(transform.position.x, targetX, attributes.walk_speed * Time.deltaTime);

            transform.position += new Vector3(newX, transform.position.y, transform.position.z);

            yield return null;
        }


    }
}
