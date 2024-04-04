using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionSelectionManager : MonoBehaviour
{
    public int currentRegionNum;
    private List<Sprite> currentLook;

    public List<Sprite> humanRegion_1Look;
    public List<Sprite> humanRegion_2Look;
    public List<Sprite> humanRegion_3Look;

    public SpriteRenderer eye_brows;
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

    public void detect

    public void changeLooks(){
        if (humanRegion_1Look[0] != null){
            eye_brows.sprite = humanRegion_1Look[0];
        }
        if (humanRegion_1Look[1] != null){
            eyes.sprite = humanRegion_1Look[1];
        }
        if (humanRegion_1Look[2] != null){
            nose.sprite = humanRegion_1Look[2];
        }
        if (humanRegion_1Look[3] != null){
            mouth.sprite = humanRegion_1Look[3];
        }
        // accessories
        if (humanRegion_1Look[4] != null){
            accessory_1.sprite = humanRegion_1Look[4];
        }
        if (humanRegion_1Look[5] != null){
            accessory_2.sprite = humanRegion_1Look[5];
        }
    }
}
