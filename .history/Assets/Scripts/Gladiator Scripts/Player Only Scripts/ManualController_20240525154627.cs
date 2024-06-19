using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        bool isMovingLeft = false;
        bool isMovingRight = false;

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime;
            isMovingLeft = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
            isMovingRight = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            foreach(G)
        }

        transform.position = position;

        if (isMovingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (isMovingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
