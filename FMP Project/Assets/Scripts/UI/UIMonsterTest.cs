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

    // Monster Runes

    public Text RuneOne;
    public Text RuneTwo;
    public Text RuneThree;
    public Text RuneFour;
    public Text RuneFive;
    public Text RuneSix;


    // Monster Skills
    public Text SkillOne;
    public Text SkillTwo;
    public Text SkillThree;
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
    private MonsterData MonsterBiengUsed = null;

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



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MonsterDisplayFunc()
    {
        Monsters.Clear();
        for(int i = 0; i < TheManager.ReturnMonsterNames().Count; i++)
        {
            Monsters.Add(TheManager.ReturnMonsterNames()[1]);
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
            MonsterHealth.text = "Monster Health : " + MonsterBiengUsed.ReturnMonsterBaseHealth();
            MonsterDefence.text = "Monster Defence : " + MonsterBiengUsed.ReturnMonsterBaseDefence();
            MonsterAttack.text = "Monster Attack : " + MonsterBiengUsed.ReturnMonsterBaseDamage();
            MonsterSpeed.text = "Monster Speed : " + MonsterBiengUsed.ReturnMonsterBaseSpeed();
            MonsterCritRate.text = "Monster CritRate : " + MonsterBiengUsed.ReturnMonsterBaseCritRate();
            MonsterCritDamage.text = "Monster CritDamage : " + MonsterBiengUsed.ReturnMonsterBaseCritDamage();
            MonsterAccuracy.text = "Monster Accuracy : " + MonsterBiengUsed.ReturnMonsterBaseAccuracy();
            MonsterResistance.text = "Monster Resistance : " + MonsterBiengUsed.ReturnMonsterBaseResistance();
            MonsterStars.text = "Stars : " + MonsterBiengUsed.ReturnMonsterStars();
            MonsterType.text = "Type : " + MonsterBiengUsed.ReturnMonsterType();
            MonsterAwakened.text = "Awakened : " + MonsterBiengUsed.ReturnMonsterAwakened();
            MonsterLevel.text = "Level : " + MonsterBiengUsed.ReturnMonsterLevel();

            SkillOne.text = "Skill One : " + MonsterBiengUsed.ReturnSkillOneMainEffect();
            SkillTwo.text = "Skill Two : " + MonsterBiengUsed.ReturnSkillTwoMainEffect();
            SkillThree.text = "Skill Three : " + MonsterBiengUsed.ReturnSkillThreeMainEffect();

            SkillOneImportance.text = "Skill One Importance : " + MonsterBiengUsed.ReturnSkillOneImportance();
            SkillTwoImportance.text = "Skill Two Importance : " + MonsterBiengUsed.ReturnSkillTwoImportance();
            SkillThreeImportance.text = "SKill Three Importance : " + MonsterBiengUsed.ReturnSkillThreeImportance();
        }
    }


    public void SetMonsterBiengUsed(MonsterData TheMonster)
    {
        MonsterBiengUsed = TheMonster;
    }

}
