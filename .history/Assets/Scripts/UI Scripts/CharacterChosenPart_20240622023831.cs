using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChosenPart : MonoBehaviour
{
    public DungeonBlackSmithController generator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selectHelmets(){
        generator.selectHelmets();
    }
    public void selectChestplates(){
        generator.selectChestplates();
    }
    public void selectArm(){
        generator.selectShoulderguards();
    }
    public void selectForearm(){
        generator.selectWristguards();
    }
    public void selectLowerTorso(){
        generator.selectPants();
    }
    public void selectLegguards(){
        generator.selectLegguards();
    }
    public void selectShinguards(){
        generator.selectShinguards();
    }
    public void selectShoes(){
        generator.selectShoes();
    }
}
