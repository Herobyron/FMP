using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

public class MonsterRuneUI : MonoBehaviour
{

    [Tooltip("The game manager that holds all of the player information")]
    [SerializeField]
    private GameManagment TheManager;

    [Tooltip("The layout for the runes that will be displayed to the player to use")]
    [SerializeField]
    private GridLayoutGroup GridGroup;

    [Tooltip("this is the button template that will be used to display a single rune")]
    [SerializeField]
    private GameObject ButtonTemplate;

    [Tooltip("This is the monster that has currently been selected ")]
    [SerializeField]
    private MonsterScript MonsterBiengUsed;

    [Tooltip("this is the rune that has been selected in the Rune Panel")]
    [SerializeField]
    private RuneScript RuneBiengUsed;

    [Tooltip("The Count for the buttons to determine how many runes have been loaded and what rune is bieng selected")]
    [SerializeField]
    private int RuneButtonCount = 0;

    [Tooltip("This is the monsters DropDown")]
    [SerializeField]
    private Dropdown MonsterDropDown;

    [Tooltip("a list of the gameobjects that act as buttons for the rune inventory")]
    [SerializeField]
    private List<GameObject> RuneButtons = new List<GameObject>();

    // text compoenets linking to the rune panel
    [Tooltip("this is the panal used to display the runes information")]
    [SerializeField]
    private GameObject RunePanel;

    [Tooltip("this is the runes name that is stored on the rune panel")]
    [SerializeField]
    private Text RuneName;

    [Tooltip("this is the runes level that is stored on the rune panel")]
    [SerializeField]
    private Text RuneLevel;

    [Tooltip("this is the runes main stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneMainStat;

    [Tooltip("this is the runes first sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatOne;

    [Tooltip("this is the runes second sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatTwo;

    [Tooltip("this is the runes third sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatThree;

    [Tooltip("this is the runes forth sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatFour;

    [Tooltip("this is wether the rune has been equiped to a monster that is stored on the rune panel")]
    [SerializeField]
    private Text RuneEquiped;

    [Tooltip("this is what monster the rune is equiped too that is stored on the rune panel")]
    [SerializeField]
    private Text MonsterRuneEquipedTo;


    ////////////////////////////////////////////////
    // these are variables for the previous stats of the rune before upgrades 
    // used to show changes.
    // only this script can have access to them so are completly private
    private int PreviousRuneLevel;
    private float PreviousRuneMainStat;
    private float PreviousRuneSubStatOne;
    private float PreviousRuneSubStatTwo;
    private float PreviousRuneSubStatThree;
    private float PreviousRuneSubStatFour;
    /// ////////////////////////////////////////////


    // text components linking to the rune upgrade panel
    [Tooltip("this is the pannel that appears when a rune is upgraded")]
    [SerializeField]
    private GameObject RuneUpgradePanel;

    [Tooltip("text to duisplay if the rune was upgraded")]
    [SerializeField]
    private Text RuneUpgradedText;

    [Tooltip("The Text that displays the runes level increase")]
    [SerializeField]
    private Text RuneLevelUpgradeText;

    [Tooltip("this is the upgraded rune stat display for the main stat")]
    [SerializeField]
    private Text RuneMainStatUpgradeText;

    [Tooltip("this is the upgraded rune stat display for first stat")]
    [SerializeField]
    private Text RuneStatOneUpgradeText;

    [Tooltip("this is the upgraded rune stat display for second stat")]
    [SerializeField]
    private Text RuneStatTwoUpgradeText;

    [Tooltip("this is the upgraded rune stat display for the third stat")]
    [SerializeField]
    private Text RuneStatThreeUpgradeText;

    [Tooltip("this is the Upgraded Rune Stat display for the Fourth stat")]
    [SerializeField]
    private Text RuneStatFourUpgradeText;

    //text components linking to the monster panel
    [Tooltip("this is the Monsters Level Text")]
    [SerializeField]
    private Text MonsterLevel;

    [Tooltip("this is the Monsters Name")]
    [SerializeField]
    private Text MonstersName;

    [Tooltip("this is the monsters health stat")]
    [SerializeField]
    private Text MonsterHealth;

    [Tooltip("this is the monsters Damage Stat")]
    [SerializeField]
    private Text MonsterDamage;

    [Tooltip("this is the monsters Defence Stat")]
    [SerializeField]
    private Text MonsterDefence;

    [Tooltip("this is the monsters Resistance Stat")]
    [SerializeField]
    private Text MonsterResistance;

    [Tooltip("This is the monsters Accuracy Stat")]
    [SerializeField]
    private Text MonsterAccuracy;

    [Tooltip("this is the monsters Crit Damage Stat")]
    [SerializeField]
    private Text MonsterCritDamage;

    [Tooltip("this is the monsters Crit Rate Stat")]
    [SerializeField]
    private Text MonsterCritRate;

    [Tooltip("this is the monsters stars")]
    [SerializeField]
    private Text MonsterStars;

    [Tooltip("this is the monsters Type")]
    [SerializeField]
    private Text MonsterType;

    [Tooltip("this is the monsters Awakening")]
    [SerializeField]
    private Text MonsterAwakening;


    void Start()
    {
        RunePanel.SetActive(false);
        RuneUpgradePanel.SetActive(false);
    }

    // generates the runes buttons to be used on the scrolling ui
    public void GenerateRuneButtons()
    {
        foreach(GameObject G in RuneButtons)
        {
            Destroy(G);
        }

        RuneButtons.Clear();
        RuneButtonCount = 0;

        foreach (RuneScript R in TheManager.ReturnPlayerRunes())
        {
            GameObject NewButton = Instantiate(ButtonTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = "Rune " + RuneButtonCount;
            RuneButtonCount++;
            NewButton.transform.SetParent(ButtonTemplate.transform.parent, false);
            RuneButtons.Add(NewButton);
        }

    }


    // a function to set the monster bieng used
    public void SetMonsterInUse(MonsterScript Monster)
    {
        MonsterBiengUsed = Monster;
    }

    // a function that will set the monster drop down to have all of the players monsters
    public void StoreMonsters()
    {
        MonsterDropDown.ClearOptions();
        MonsterDropDown.AddOptions(TheManager.ReturnMonsterNames());
        MonsterDropDown.value = 0;
        MonsterDropDown.Select();
        MonsterDropDown.RefreshShownValue();

    }


    // a function attached to the button
    // this function will make a pop up appear
    // allows the player to upgrade the rune, equip the rune or destroy the rune
    public void RuneButtonFunc()
    {
        RuneBiengUsed = TheManager.ReturnSelectedRune(EventSystem.current.currentSelectedGameObject.name);
        RunePanel.SetActive(true);
        RefreshRuneUI();
        
    }

    // a function that updates the rune UI section of this 
    public void RefreshRuneUI()
    {
        RuneName.text = "Rune Name: " + RuneBiengUsed.ReturnRuneName();
        RuneLevel.text = "Rune Level: " + RuneBiengUsed.ReturnRuneLevel();
        RuneMainStat.text = RuneBiengUsed.ReturnMainRuneStatType() + ": " + RuneBiengUsed.ReturnMainRuneStat();
        RuneSubStatOne.text = RuneBiengUsed.ReturnRuneStatOneType() + ": " + RuneBiengUsed.ReturnRuneStatOne();
        RuneSubStatTwo.text = RuneBiengUsed.ReturnRuneStatTwoType() + ": " + RuneBiengUsed.ReturnRuneStatTwo();
        RuneSubStatThree.text = RuneBiengUsed.ReturnRuneStatThreeType() + ": " + RuneBiengUsed.ReturnRuneStatThree();
        RuneSubStatFour.text = RuneBiengUsed.ReturnRuneStatFourType() + ": " + RuneBiengUsed.ReturnRuneStatFour();
        RuneEquiped.text = (RuneBiengUsed.ReturnRuneEquiped() ? "Rune Equiped" : "Rune Not Equiped");
        MonsterRuneEquipedTo.text = (RuneBiengUsed.ReturnRuneEquiped() ? "Monster Rune equiped to : " + RuneBiengUsed.ReturnMonsterEquipedTo() : "Not Equiped to any Monster");
    
    }

    // a function to close the rune panel to enable selection of other runes
    public void CloseRuneUI()
    {
        RunePanel.SetActive(false);
    }

    // a function that allows the rune to be upgraded
    public void UpgradeSelectedRune()
    {
        if (RuneBiengUsed.ReturnRuneLevel() < 15)
        {
            RuneUpgradePanel.SetActive(true);

            PreviousRuneLevel = RuneBiengUsed.ReturnRuneLevel();
            PreviousRuneMainStat = RuneBiengUsed.ReturnMainRuneStat();
            PreviousRuneSubStatOne = RuneBiengUsed.ReturnRuneStatOne();
            PreviousRuneSubStatTwo = RuneBiengUsed.ReturnRuneStatTwo();
            PreviousRuneSubStatThree = RuneBiengUsed.ReturnRuneStatThree();
            PreviousRuneSubStatFour = RuneBiengUsed.ReturnRuneStatFour();

            if (RuneBiengUsed.UpgradeRune())
            {
                RuneUpgradedText.text = "Rune Upgraded Successfully!!!";
            }
            else
            {
                RuneUpgradedText.text = "Rune Upgrade Failed";
            }

            RuneLevelUpgradeText.text = "Rune Level: " + PreviousRuneLevel + "  --->  " + RuneBiengUsed.ReturnRuneLevel();
            RuneMainStatUpgradeText.text = RuneBiengUsed.ReturnMainRuneStatType() + ": " + PreviousRuneMainStat + "  --->  " + RuneBiengUsed.ReturnMainRuneStat();
            RuneStatOneUpgradeText.text = RuneBiengUsed.ReturnRuneStatOneType() + ": " + PreviousRuneSubStatOne + "  --->  " + RuneBiengUsed.ReturnRuneStatOne();
            RuneStatTwoUpgradeText.text = RuneBiengUsed.ReturnRuneStatTwoType() + ": " + PreviousRuneSubStatTwo + "  --->  " + RuneBiengUsed.ReturnRuneStatTwo();
            RuneStatThreeUpgradeText.text = RuneBiengUsed.ReturnRuneStatThreeType() + ": " + PreviousRuneSubStatThree + "  --->  " + RuneBiengUsed.ReturnRuneStatThree();
            RuneStatFourUpgradeText.text = RuneBiengUsed.ReturnRuneStatFourType() + ": " + PreviousRuneSubStatFour + "  --->  " + RuneBiengUsed.ReturnRuneStatFour();

            RefreshRuneUI();
        }
    }

    // this function will close the rune upgraded panel
    public void CloseRuneUpgradedPanel()
    {
        RuneUpgradePanel.SetActive(false);
    }

    public void RefreshMonsterStats()
    {

    }
}
