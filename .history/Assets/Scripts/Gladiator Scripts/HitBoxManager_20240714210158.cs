using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public List<GameObject> objectsInHitbox;

    public EntitySortingLayerController entitySortingLayerController;


    // Start is called before the first frame update
    void Start()
    {
        objectsInHitbox = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" || other.tag == "Enemy"){
            objectsInHitbox.Add(other.gameObject);

            entitySortingLayerController.SetSortingOrder(gameObject.transform.parent, other.gameObject.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        entitySortingLayerController.SetSortingOrder(gameObject.transform, other.gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D other) {
        objectsInHitbox.Remove(other.gameObject);
    }
}
