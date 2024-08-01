using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLState : MonoBehaviour
{
    public bool alive;
    public bool dying;
    public bool gotHit;

    public bool isTraining;

    // level up states
    public bool waitingForLevelup;
    public bool levelUpHandled; //dungeon home controller variable

    // skill states
    public bool effectedBy_GrimChallenge;
    public bool is_Stunned;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsPlayerMoving() {
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    float threshold = 0.1f; // Small value to account for minor velocity fluctuations

    return rb.velocity.magnitude > threshold;
}

}
