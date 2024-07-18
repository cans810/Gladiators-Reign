using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollisionManager : MonoBehaviour
{
    public EntitySortingLayerController entitySortingLayerController;
    
    // Start is called before the first frame update
    void Start()
    {
        entitySortingLayerController = GetComponent<EntitySortingLayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        entitySortingLayerController.SetSortingOrder(gameObject.transform, other.gameObject.transform);
    }

    private void OnTriggerStay2D(Collider2D other) {
        entitySortingLayerController.SetSortingOrder(gameObject.transform, other.gameObject.transform);
    }

    private void OnTriggerStay2D(Collider2D other) {
        entitySortingLayerController.SetSortingOrder(gameObject.transform, other.gameObject.transform);
    }
}
