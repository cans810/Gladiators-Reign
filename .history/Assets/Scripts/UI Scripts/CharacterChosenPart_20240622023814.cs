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

    public void selectHead(){
        generator.selectHelmets();
    }
    public void selectTorso(){
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
    public void selectHead(){
        generator.selectHelmets();
    }
    public void selectHead(){
        generator.selectHelmets();
    }
}
