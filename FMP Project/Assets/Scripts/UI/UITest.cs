using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{

    // this is the monster that is holding the rune that i want to test the upgrading on
    public GameObject Monster;

    public Text RuneLevelText;
    public Text RuneStatOne;
    public Text RuneStatOneNumber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RuneLevelText.text = "Rune Level: " + Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneLevel();
        RuneStatOne.text = "Rune Stat One: " + Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneStatOneType();
        RuneStatOneNumber.text = "Rune Stat One Number: " + Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneStatOne();

    }


    // for this functoin it needs to get the monster script. when this is done later on make sure to get all objects at the start
    // so that this getcomponent is not constantly called
    public void UpgradeRune()
    {
        Monster.GetComponent<MonsterScript>().ReturnRune(0).UpgradeRune();
    }



}
