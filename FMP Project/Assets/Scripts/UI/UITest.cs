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


    public GameObject TestDummy;
    public Text DummyHealth;

    public Text DummyBuffs;
    public Text DummyNerfs;


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
        DummyHealth.text = "Dummy Health : " + TestDummy.GetComponent<MonsterScript>().ReturnCurrentHealth();


        Debug.Log(Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneLevel());
        Debug.Log(Monster.GetComponent<MonsterScript>().ReturnRune(0).ReturnRuneStatOneType());

    }


    // for this functoin it needs to get the monster script. when this is done later on make sure to get all objects at the start
    // so that this getcomponent is not constantly called
    public void UpgradeRune()
    {
        Monster.GetComponent<MonsterScript>().ReturnRune(0).UpgradeRune();
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

   

}
