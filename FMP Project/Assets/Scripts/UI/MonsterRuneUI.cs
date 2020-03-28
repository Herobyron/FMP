using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using System.Xml;

public class MonsterRuneUI : MonoBehaviour
{

    [Tooltip("The game manager that holds all of the player information")]
    [SerializeField]
    private GameManagment TheManager = null;

    [Tooltip("The layout for the runes that will be displayed to the player to use")]
    [SerializeField]
    private GridLayoutGroup GridGroup;

    [Tooltip("this is the button template that will be used to display a single rune")]
    [SerializeField]
    private GameObject ButtonTemplate = null;

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
    private Dropdown MonsterDropDown = null;

    [Tooltip("a list of the gameobjects that act as buttons for the rune inventory")]
    [SerializeField]
    private List<GameObject> RuneButtons = new List<GameObject>();

    // text compoenets linking to the rune panel
    [Tooltip("this is the panal used to display the runes information")]
    [SerializeField]
    private GameObject RunePanel = null;

    [Tooltip("this is the runes name that is stored on the rune panel")]
    [SerializeField]
    private Text RuneName = null;

    [Tooltip("this is the runes level that is stored on the rune panel")]
    [SerializeField]
    private Text RuneLevel = null;

    [Tooltip("this is the runes main stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneMainStat = null;

    [Tooltip("this is the runes first sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatOne = null;

    [Tooltip("this is the runes second sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatTwo = null;

    [Tooltip("this is the runes third sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatThree = null;

    [Tooltip("this is the runes forth sub stat that is stored on the rune panel")]
    [SerializeField]
    private Text RuneSubStatFour = null;

    [Tooltip("this is wether the rune has been equiped to a monster that is stored on the rune panel")]
    [SerializeField]
    private Text RuneEquiped = null;

    [Tooltip("this is what monster the rune is equiped too that is stored on the rune panel")]
    [SerializeField]
    private Text MonsterRuneEquipedTo = null;


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
    private GameObject RuneUpgradePanel = null;

    [Tooltip("text to duisplay if the rune was upgraded")]
    [SerializeField]
    private Text RuneUpgradedText = null;

    [Tooltip("The Text that displays the runes level increase")]
    [SerializeField]
    private Text RuneLevelUpgradeText = null;

    [Tooltip("this is the upgraded rune stat display for the main stat")]
    [SerializeField]
    private Text RuneMainStatUpgradeText = null;

    [Tooltip("this is the upgraded rune stat display for first stat")]
    [SerializeField]
    private Text RuneStatOneUpgradeText = null;

    [Tooltip("this is the upgraded rune stat display for second stat")]
    [SerializeField]
    private Text RuneStatTwoUpgradeText = null;

    [Tooltip("this is the upgraded rune stat display for the third stat")]
    [SerializeField]
    private Text RuneStatThreeUpgradeText = null;

    [Tooltip("this is the Upgraded Rune Stat display for the Fourth stat")]
    [SerializeField]
    private Text RuneStatFourUpgradeText = null;

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

    [Tooltip("This is the monsters Speed stat")]
    [SerializeField]
    private Text MonsterSpeed;

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

    // UI components that link to monster upgrade panel
    [Tooltip("this is the upgrade panels health text")]
    [SerializeField]
    private Text HealthText = null;

    [Tooltip("this is the upgrade panels health text")]
    [SerializeField]
    private Text DefenceText = null;

    [Tooltip("this is the upgrade panels health text")]
    [SerializeField]
    private Text DamageText = null;

    [Tooltip("this is the upgrade panels health text")]
    [SerializeField]
    private Text MonsterLevelText = null;

    [Tooltip("this is the upgrade panels health text")]
    [SerializeField]
    private Text MonsterMaxLevelText = null;

    [Tooltip("List of images for the stars of the monster")]
    [SerializeField]
    private List<Image> MonsterStarImages = new List<Image>();

    [Tooltip("this is the text at the top of the monster upgrade panel")]
    [SerializeField]
    private Text MonsterUpgradeText = null;

    [Tooltip("Panel To Upgrade the monster")]
    [SerializeField]
    private GameObject MonsterUpgradePanel = null;

    //variables for the previous monsters stats
    private float PreviousMonsterHealth;
    private float PreviousMonsterDamage;
    private float PreviousMonsterDefence;
    private int PreviousMonsterLevel;
    private int PreviousMonsterMaxLevel;

    // a bool to determine when the level up corutine is running
    private bool LevelCorutineRun = false;


    void Start()
    {
        RunePanel.SetActive(false);
        RuneUpgradePanel.SetActive(false);
        MonsterUpgradePanel.SetActive(false);

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

    //function to update and display the selected monsters stats
    public void RefreshMonsterStats()
    {
        MonsterLevel.text = "Level: " + MonsterBiengUsed.ReturnMonsterLevel();
        MonstersName.text = "Name: " + MonsterBiengUsed.ReturnMonsterName();
        MonsterHealth.text = "Health: " + MonsterBiengUsed.ReturnBaseHealth();
        MonsterDamage.text = "Attack: " + MonsterBiengUsed.ReturnBaseDamage();
        MonsterDefence.text = "Defence: " + MonsterBiengUsed.ReturnBaseDefence();
        MonsterSpeed.text = "Speed: " + MonsterBiengUsed.ReturnBaseSpeed();
        MonsterAccuracy.text = "Accuracy: " + MonsterBiengUsed.ReturnBaseAccuracy();
        MonsterResistance.text = "Resistance: " + MonsterBiengUsed.ReturnBaseResistance();
        MonsterCritRate.text = "Crit Rate: " + MonsterBiengUsed.ReturnBaseCritRate();
        MonsterCritDamage.text = "Crit Damage: " + MonsterBiengUsed.ReturnBaseCritDamage();

        MonsterType.text = "Type: " + MonsterBiengUsed.ReturnMonsterType();
        MonsterAwakening.text = (MonsterBiengUsed.ReturnMonsterAwkaned() ? "Awakened : Yes" : "Awakened : No");
        MonsterStars.text = "Stars: " + MonsterBiengUsed.ReturnMonsterStars();


    }

    // a function that will change the loaded monster when the player swicthes monsters
    public void ChangeMonster()
    {
        if (!MonsterUpgradePanel.activeInHierarchy || RuneUpgradePanel.activeInHierarchy || !RunePanel.activeInHierarchy)
        {
            MonsterUpgradePanel.SetActive(false);
            RuneUpgradePanel.SetActive(false);
            RunePanel.SetActive(false);
        }

        MonsterBiengUsed = TheManager.SelectedDropDownMonsterLoad(MonsterDropDown.value);
        RefreshMonsterStats();
    }

    // a function to load the upgrade rune panel
    public void LoadUpgradeMonsterPanel()
    {
        HealthText.text = "Health: " + MonsterBiengUsed.ReturnBaseHealth();
        DamageText.text = "Damage: " + MonsterBiengUsed.ReturnBaseDamage();
        DefenceText.text = "Defence: " + MonsterBiengUsed.ReturnBaseDefence();

        MonsterLevelText.text = "Level: " + MonsterBiengUsed.ReturnMonsterLevel();
        MonsterMaxLevelText.text = "Max Level: " + MonsterBiengUsed.ReturnMonsterMaxLevel();

        MonsterUpgradePanel.SetActive(true);

        foreach(Image I in MonsterStarImages)
        {
            I.color = new Color(1,1,1,0);
        }

        for (int i = 0; i < MonsterBiengUsed.ReturnMonsterStars(); i++)
        {
            MonsterStarImages[i].color = new Color(1,1,1,1);
        }

    }

    // a function to increase the stars of the selected monster
    public void IncreaseStarsOnMonster()
    {
        if (MonsterBiengUsed.ReturnMonsterLevel() == MonsterBiengUsed.ReturnMonsterMaxLevel())
        {

            PreviousMonsterMaxLevel = MonsterBiengUsed.ReturnMonsterMaxLevel();

            MonsterBiengUsed.IncreaseStars();



            switch (MonsterBiengUsed.ReturnMonsterStars())
            {
                case (2):
                    {
                        StartCoroutine(FadeImage(MonsterStarImages[1]));
                        break;
                    }
                case (3):
                    {
                        StartCoroutine(FadeImage(MonsterStarImages[2]));
                        break;
                    }
                case (4):
                    {
                        StartCoroutine(FadeImage(MonsterStarImages[3]));
                        break;
                    }
                case (5):
                    {
                        StartCoroutine(FadeImage(MonsterStarImages[4]));
                        break;
                    }
                case (6):
                    {
                        StartCoroutine(FadeImage(MonsterStarImages[5]));
                        break;
                    }
            }
        }
    }

    // a function to increase the monsters level
    public void IncreaseLevel()
    {
        if (!LevelCorutineRun)
        {
            PreviousMonsterDamage = MonsterBiengUsed.ReturnBaseDamage();
            PreviousMonsterDefence = MonsterBiengUsed.ReturnBaseDefence();
            PreviousMonsterHealth = MonsterBiengUsed.ReturnBaseHealth();
            PreviousMonsterLevel = MonsterBiengUsed.ReturnMonsterLevel();
            PreviousMonsterMaxLevel = MonsterBiengUsed.ReturnMonsterMaxLevel();


        
            MonsterBiengUsed.LevelUpMonster();

            StartCoroutine(LevelUpDisplayChange(2));
        }

    }

    // a function to close the upgrade panel
    public void CloseUpgradPanel()
    {
        MonsterUpgradePanel.SetActive(false);
    }
    

    //enumerator to fade the image selected
    IEnumerator FadeImage(Image TheImage)
    {
        for(float i = 0.0f; i <= 1.0f; i += Time.deltaTime)
        {
            MonsterUpgradeText.text = "Monster Stars Increased!!";
            MonsterMaxLevelText.text = PreviousMonsterMaxLevel + "  --->  " + MonsterBiengUsed.ReturnMonsterMaxLevel();
            TheImage.color = new Color(1,1,1,i);
            yield return null;
        }

        MonsterMaxLevelText.text = "Max Level: " + MonsterBiengUsed.ReturnMonsterMaxLevel();
        MonsterUpgradeText.text = "Upgrade Your Monster";
    }

    // an enumerator to pause the display just for a couple of seconds
    IEnumerator LevelUpDisplayChange(float PauseTime)
    {
        LevelCorutineRun = true;

        for(float i = 0; i < PauseTime; i += Time.deltaTime)
        {
            MonsterUpgradeText.text = "Monster Level up SUCCESS!!";
            HealthText.text = "Health: " + PreviousMonsterHealth + "  --->  " + MonsterBiengUsed.ReturnBaseHealth();
            DamageText.text = "Damage: " +  PreviousMonsterDamage + "  --->  " + MonsterBiengUsed.ReturnBaseDamage();
            DefenceText.text = "Defence: " + PreviousMonsterDefence + "  --->  " + MonsterBiengUsed.ReturnBaseDefence();
            MonsterLevelText.text = "Level: " + PreviousMonsterLevel + " --->  " + MonsterBiengUsed.ReturnMonsterLevel();
            yield return null;
        }

        MonsterUpgradeText.text = "Upgrade your monster";
        HealthText.text = "Health: " + MonsterBiengUsed.ReturnBaseHealth();
        DamageText.text = "Damage: " + MonsterBiengUsed.ReturnBaseDamage();
        DefenceText.text = "Defence: " + MonsterBiengUsed.ReturnBaseDefence();
        MonsterLevelText.text = "Level: " + MonsterBiengUsed.ReturnMonsterLevel();

        LevelCorutineRun = false;
    }

}
