using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLState : MonoBehaviour
{
    public bool alive;
    public bool dying;
    public bool gotHit;

    public bool inTraining;

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
}
