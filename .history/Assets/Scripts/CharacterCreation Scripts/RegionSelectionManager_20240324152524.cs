using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionSelectionManager : MonoBehaviour
{
    public int currentRegionNum;
    public List<Sprite> humanRegion_1Look;
    public SpriteRenderer eyes;
    public SpriteRenderer nose;
    public SpriteRenderer mouth;
    public SpriteRenderer accessory_1;
    public SpriteRenderer accessory_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextRegion(){
        if (currentRegionNum < 3-1){
            currentRegionNum++;
        }
    }

    public void prevRegion(){
        if (currentRegionNum > 0){
            currentRegionNum--;
        }
    }

    public void changeLooks(){
        if (eyes)
    }
}
