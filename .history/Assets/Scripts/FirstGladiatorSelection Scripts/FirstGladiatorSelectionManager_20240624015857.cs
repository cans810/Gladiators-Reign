using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGladiatorSelectionManager : MonoBehaviour
{
    public GameObject selectedGladiator;

    public GameObject NPC_MysteriousSeller;

    // Start is called before the first frame update
    void Start()
    {
        NPC_MysteriousSeller.GetComponent<MysteriousSellerController>().StartTalking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 

    
}
