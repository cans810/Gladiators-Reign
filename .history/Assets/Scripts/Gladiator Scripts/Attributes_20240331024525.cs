using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public string race;
    public string raceRegion;

    public string gladiator_name;
    public int level;

    public float walk_distance;
    public float walk_speed;

    public float max_HP;
    public float HP;


    //
    public bool inAction;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AppereanceManager>().setRace();
        GetComponent<AppereanceManager>().setR();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
