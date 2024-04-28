using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public BattleAI battleAI;

    public List<GameObject> objectsInHitbox;


    // Start is called before the first frame update
    void Start()
    {
        objectsInHitbox = new List<GameObject>()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        
    }
}
