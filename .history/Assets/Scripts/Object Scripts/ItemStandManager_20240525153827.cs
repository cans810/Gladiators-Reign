using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStandManager : MonoBehaviour
{
    public GameObject itemContained;

    // Start is called before the first frame update
    void Start()
    {
        itemContained.transform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
