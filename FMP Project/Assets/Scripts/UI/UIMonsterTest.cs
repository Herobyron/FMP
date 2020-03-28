using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMonsterTest : MonoBehaviour
{
    // these are the text elements linked to the UI
    // Monster Stat
    public Text MonsterName;
    public Text MonsterHealth;
    public Text MonsterDefence;
    public Text MonsterAttack;
    public Text MonsterSpeed;
    public Text MonsterCritRate;
    public Text MonsterCritDamage;
    public Text MonsterAccuracy;
    public Text MonsterResistance;
    public Text MonsterStars;
    public Text MonsterLevel;
    public Text MonsterAwakened;
    public Text MonsterType;

    // Monster Skills
    public Text SkillOne;
    public Text SkillTwo;
    public Text SkillThree;
    public Text SkillOneSecondaryEffect;
    public Text SkillTwoSecondaryEffect;
    public Text SkillThreeSecondaryEffect;
    public Text SkillOneImportance;
    public Text SkillTwoImportance;
    public Text SkillThreeImportance;

    // DropDown Commponents
    public Dropdown MonsterDisplay;
    public Dropdown SkillImportanceSelectionOne;
    public Dropdown SkillImportanceSelectionTwo;
    public Dropdown SkillImportanceSelectionThree;

    // bool to determine the wether the rune has been loaded
    public bool LoadTheRuneOnce = false;

    // the monster data that has currently been loaded
    private MonsterScript MonsterBiengUsed = null;

    // the game management
    private GameManagment TheManager;


    //list of the monsters names to be used for sorting through differnt monsters
    private List<string> Monsters = new List<string>();

    //the list of options for the Importance selection (these are predefined)
    private List<string> ImportanceSelectionOptions = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        TheManager = FindObjectOfType<GameManagment>();
        Monsters.Add("No Monster");
        MonsterDisplay.ClearOptions();
        MonsterDisplay.AddOptions(Monsters);

        ImportanceSelectionOptions.Add("Importance 1");
        ImportanceSelectionOptions.Add("Importance 2");
        ImportanceSelectionOptions.Add("Importance 3");

        SkillImportanceSelectionOne.ClearOptions();
        SkillImportanceSelectionOne.AddOptions(ImportanceSelectionOptions);

        SkillImportanceSelectionTwo.ClearOptions();
        SkillImportanceSelectionTwo.AddOptions(ImportanceSelectionOptions);

        SkillImportanceSelectionThree.ClearOptions();
        SkillImportanceSelectionThree.AddOptions(ImportanceSelectionOptions);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUI();
    }


    public void MonsterDisplayFunc()
    {
        Monsters.Clear();
        for(int i = 0; i < TheManager.ReturnMonsterNames().Count; i++)
        {
            Monsters.Add(TheManager.ReturnMonsterNames()[i]);
        }

        MonsterDisplay.ClearOptions();
        MonsterDisplay.AddOptions(Monsters);
        MonsterDisplay.value = 0;
        MonsterDisplay.Select();
        MonsterDisplay.RefreshShownValue();
    }


    public void ChangedValue()
    {
        if(TheManager.ReturnMonsterCount() == 0)
        {
            //do something with no monste used (for now does nothing)
        }
        else
        {
            MonsterBiengUsed = TheManager.SelectedDropDownMonsterLoad(MonsterDisplay.value);
        }

    }

    public void ChangeUI()
    {
        if(MonsterBiengUsed == null)
        {
            //this will change the display to display nothing (only once tests have been completed it will be implemented)
        }
        else if(MonsterBiengUsed != null)
        {
            MonsterName.text = "Monster Name : " + MonsterBiengUsed.ReturnMonsterName();
            MonsterHealth.text = "Monster Health : " + MonsterBiengUsed.ReturnBaseHealth();
            MonsterDefence.text = "Monster Defence : " + MonsterBiengUsed.ReturnBaseDefence();
            MonsterAttack.text = "Monster Attack : " + MonsterBiengUsed.ReturnBaseDamage();
            MonsterSpeed.text = "Monster Speed : " + MonsterBiengUsed.ReturnBaseSpeed();
            MonsterCritRate.text = "Monster CritRate : " + MonsterBiengUsed.ReturnBaseCritRate();
            MonsterCritDamage.text = "Monster CritDamage : " + MonsterBiengUsed.ReturnBaseCritDamage();
            MonsterAccuracy.text = "Monster Accuracy : " + MonsterBiengUsed.ReturnBaseAccuracy();
            MonsterResistance.text = "Monster Resistance : " + MonsterBiengUsed.ReturnBaseResistance();
            MonsterStars.text = "Stars : " + MonsterBiengUsed.ReturnMonsterStars();
            MonsterType.text = "Type : " + MonsterBiengUsed.ReturnMonsterType();
            MonsterAwakened.text = "Awakened : " + MonsterBiengUsed.ReturnMonsterAwkaned();
            MonsterLevel.text = "Level : " + MonsterBiengUsed.ReturnMonsterLevel();

            SkillOne.text = "Skill One : " + MonsterBiengUsed.ReturnrSkillOneMainEffect();
            SkillTwo.text = "Skill Two : " + MonsterBiengUsed.ReturnSkillTwoMainEffect();
            SkillThree.text = "Skill Three : " + MonsterBiengUsed.ReturnSkillThreeMainEffect();

            SkillOneSecondaryEffect.text = "Skill One Secondary Effect: " + MonsterBiengUsed.ReturnSkillOneSecondaryEffect();
            SkillTwoSecondaryEffect.text = "Skill Two Secondary Effect: " + MonsterBiengUsed.ReturnSkillTwoSecondaryEffect();
            SkillThreeSecondaryEffect.text = "Skill Three Secondary Effect: " + MonsterBiengUsed.ReturnSkillThreeSecondaryEffect();

            SkillOneImportance.text = "Skill One Importance : " + MonsterBiengUsed.ReturnSkillOneImportance();
            SkillTwoImportance.text = "Skill Two Importance : " + MonsterBiengUsed.ReturnSkillTwoImportance();
            SkillThreeImportance.text = "SKill Three Importance : " + MonsterBiengUsed.ReturnSkillThreeImportance();
        }
    }


    public void SetMonsterBiengUsed(MonsterScript TheMonster)
    {
        MonsterBiengUsed = TheMonster;
    }

    public void LevelUpMonster()
    {
        MonsterBiengUsed.LevelUpMonster();
    }

    public void AwakenMonster()
    {
        MonsterBiengUsed.Awaken();
    }

    public void IncreaseStars()
    {
        MonsterBiengUsed.IncreaseStars();
    }

    public void ChangeSkillOneImportance()
    {
        MonsterBiengUsed.SetSkillOneImportance(SkillImportanceSelectionOne.value);
    }

    public void ChangeSkillTwoImportance()
    {
        MonsterBiengUsed.SetSkillTwoImportance(SkillImportanceSelectionTwo.value);
    }

    public void ChangeSkillThreeImportance()
    {
        MonsterBiengUsed.SetSkillthreeImportance(SkillImportanceSelectionThree.value);
    }

}
