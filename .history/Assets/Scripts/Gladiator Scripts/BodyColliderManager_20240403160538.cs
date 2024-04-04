using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void faceTowardsEnemy(Vector2 enemyPos){
        Vector2 direction = (enemyPos - (Vector2)transform.position).normalized;

        if (direction.x < 0) // Enemy is on the left
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Face left
        }
        else // Enemy is on the right
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Face right
        }
    }
}
