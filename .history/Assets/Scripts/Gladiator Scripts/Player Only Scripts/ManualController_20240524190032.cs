using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    public float speed = 5f; // Speed at which the GameObject moves

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the GameObject
        Vector3 position = transform.position;

        // Check for input and move the GameObject
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime; // Move left
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime; // Move right
        }

        // Apply the new position to the GameObject
        transform.position = position;
    }
}
