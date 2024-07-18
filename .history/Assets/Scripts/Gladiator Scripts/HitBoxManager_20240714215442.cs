using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public List<GameObject> objectsInHitbox;
    public EntitySortingLayerController entitySortingLayerController;

    GLGearController 

    // Start is called before the first frame update
    void Start()
    {
        objectsInHitbox = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (!objectsInHitbox.Contains(other.gameObject))
            {
                objectsInHitbox.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        objectsInHitbox.Remove(other.gameObject);
    }
}
