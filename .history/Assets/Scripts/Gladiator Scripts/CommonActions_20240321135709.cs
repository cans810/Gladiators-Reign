using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonActions : MonoBehaviour
{
    Attributes attributes;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
        animator = GetComponent<Animator>();
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
        animator.SetBool("Walk",true);

        float targetX = transform.position.x + attributes.walk_distance;

        while (transform.position.x <= targetX)
        {
            float movementAmount = attributes.walk_speed * Time.deltaTime;
            Vector3 movement = new Vector3(movementAmount, 0f, 0f);

            transform.position += movement;

            yield return null;
        }

        attributes.inAction = false;
        animator.SetBool("Walk",false);
    }

    public void WalkLeft()
    {
        attributes.inAction = true;
        StartCoroutine(StartWalkLeft());
    }

    IEnumerator StartWalkLeft()
    {
        animator.SetBool("Walk",true);
        float targetX = transform.position.x - attributes.walk_distance;

        while (transform.position.x >= targetX)
        {
            float movementAmount = attributes.walk_speed * Time.deltaTime;
            Vector3 movement = new Vector3(-movementAmount, 0f, 0f);

            transform.position += movement;

            yield return null;
        }

        attributes.inAction = false;
        animator.SetBool("Walk",false);
    }

}
