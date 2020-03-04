using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    // this is all temporary as this ui will not be used in final vertical slice

    // this is the monster that is holding the rune that i want to test the upgrading on
    public GameObject Monster;

    public Text RuneLevelText;
    public Text RuneStatOneType;
    public Text RuneStatOne;

    public Text RuneStar;
    public Text RuneGrade;
    public Text RuneSlot;

    public Text MainRuneStat;
    public Text MainRuneStatType;

    public Text RuneStatTwoType;
    public Text RuneStatTwo;

    public Text RuneStatThreeType;
    public Text RuneStatThree;

    public Text RuneStatFourType;
    public Text RuneStatFour;

    public GameObject TestDummy;
    public Text DummyHealth;

    public Text DummyBuffs;
    public Text DummyNerfs;

    public Text MonsterName;

    public GameObject loadedrune;
    public bool LoadTheRuneOnce = false;
    public RuneScript RuneBiengUsed = null;
    public MonsterData MonsterBiengUsed = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        FindObjectOfType<Image>().gameObject.SetActive(true);

        //RuneLevelText.text = "Rune Level: " + Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneLevel();
        //RuneStatOne.text = "Rune Stat One: " + Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneStatOneType();
        //RuneStatOneNumber.text = "Rune Stat One Number: " + Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneStatOne();
        DummyHealth.text = "Dummy Health : " + TestDummy.GetComponent<MonsterScript>().ReturnCurrentHealth();
        

        if(RuneBiengUsed != null)
        {
            RuneLevelText.text = "Rune Level : " + RuneBiengUsed.ReturnRuneLevel();
            RuneStar.text = "Rune star : " + RuneBiengUsed.ReturnAmountOfStars();
            RuneGrade.text = "Rune Grade : " + RuneBiengUsed.ReturnRuneRarity();
            RuneSlot.text = "Rune Slot : " + RuneBiengUsed.ReturnRuneSlot();

            MainRuneStat.text = "Main Rune Stat : " + RuneBiengUsed.ReturnMainRuneStat();
            MainRuneStatType.text = "Main Rune Stat Type : " + RuneBiengUsed.ReturnMainRuneStatType();

            RuneStatOne.text = "Rune Stat one : " + RuneBiengUsed.ReturnRuneStatOne();
            RuneStatOneType.text = "Rune Stat one Type" + RuneBiengUsed.ReturnRuneStatOneType();

            RuneStatTwo.text = "Rune Stat Two : " + RuneBiengUsed.ReturnRuneStatTwo();
            RuneStatTwoType.text = "Rune Stat Two Type : " + RuneBiengUsed.ReturnRuneStatTwoType();

            RuneStatThree.text = "Rune Stat Three : " + RuneBiengUsed.ReturnRuneStatThree();
            RuneStatThreeType.text = "Rune Stat Three Type : " + RuneBiengUsed.ReturnRuneStatThreeType();

            RuneStatFour.text = "Rune Stat Four : " + RuneBiengUsed.ReturnRuneStatFour();
            RuneStatFourType.text = "Rune stat Four Type : " + RuneBiengUsed.ReturnRuneStatFourType();

            
        }
      

        if(MonsterBiengUsed != null)
        {
            Debug.Log("yes");
            MonsterName.text = MonsterBiengUsed.ReturnMonsterName();
        }

    }


    // for this functoin it needs to get the monster script. when this is done later on make sure to get all objects at the start
    // so that this getcomponent is not constantly called
    public void UpgradeRune()
    {
        if(RuneBiengUsed != null)
        {
            RuneBiengUsed.UpgradeRune();
        }
    }

    public void UseMonstersSkillTwo()
    {
        Monster.GetComponent<MonsterScript>().UseSkill(2).SkillAction(Monster.GetComponent<MonsterScript>(), TestDummy.GetComponent<MonsterScript>()); 
    }

    public void UseMonsterSkillOne()
    {
        Monster.GetComponent<MonsterScript>().UseSkill(1).SkillAction(Monster.GetComponent<MonsterScript>(), TestDummy.GetComponent<MonsterScript>());
        UpdatingBuffsText();
    }

    public void UseMonsterSkillThree()
    {
        Monster.GetComponent<MonsterScript>().UseSkill(3).SkillAction(Monster.GetComponent<MonsterScript>(), TestDummy.GetComponent<MonsterScript>());
    }


    public void UpdatingBuffsText()
    {
        DummyBuffs.text = "Buffs on Dummy : ";
        DummyNerfs.text = "Debuffs on Dummy : ";

        foreach (BeneficialEffects B in TestDummy.GetComponent<MonsterScript>().ReturnBeneficialEffects())
        {
            DummyBuffs.text += B.name + ", ";
        }

        foreach(HarmfulEffects H in TestDummy.GetComponent<MonsterScript>().ReturnHarmfulEffects())
        {
            DummyNerfs.text += H.name + ", ";
        }
    }

   public void LoadRuneTest()
   {
        
        loadedrune = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Assets/Prefabs/RunesPrefabs/Rune.prefab") ;

        RuneBiengUsed = loadedrune.GetComponent<RuneScript>();
        Debug.Log(RuneBiengUsed.ReturnMainRuneStatType());
   }


}
