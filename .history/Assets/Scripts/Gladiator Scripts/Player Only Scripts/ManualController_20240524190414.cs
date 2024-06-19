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
            position.x -= speed * Time.deltaTime; // Move left
            isMovingLeft = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime; // Move right
            isMovingRight = true;
        }

        transform.position = position;

        // Adjust the rotation to face the direction of movement
        if (isMovingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Face left
        }
        else if (isMovingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face right
        }
    }
}
