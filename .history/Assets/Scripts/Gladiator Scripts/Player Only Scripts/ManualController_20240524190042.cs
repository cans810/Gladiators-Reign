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

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime; // Move left
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime; // Move right
        }

        transform.position = position;
    }
}
