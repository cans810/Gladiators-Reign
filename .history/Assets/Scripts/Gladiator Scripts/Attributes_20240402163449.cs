using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    // managers
    public CommonActions

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
    public bool alive;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AppereanceManager>().setRace();
        GetComponent<AppereanceManager>().setRegion();

        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
