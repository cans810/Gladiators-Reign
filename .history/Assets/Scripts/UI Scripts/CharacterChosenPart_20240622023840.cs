using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChosenPart : MonoBehaviour
{
    public DungeonBlackSmithController generator;

    public void selectHelmets(){
        generator.selectHelmets();
    }
    public void selectChestplates(){
        generator.selectChestplates();
    }
    public void selectShoulderguards(){
        generator.selectShoulderguards();
    }
    public void selectWristguards(){
        generator.selectWristguards();
    }
    public void selectPants(){
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
