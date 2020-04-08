using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using System.Xml;
using System;

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

    [Tooltip("this is the slot that this rune can be placed into")]
    [SerializeField]
    private Text RuneSlot = null;


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
    private Text MonsterLevel = null;

    [Tooltip("this is the Monsters Name")]
    [SerializeField]
    private Text MonstersName = null;

    [Tooltip("this is the monsters health stat")]
    [SerializeField]
    private Text MonsterHealth = null;

    [Tooltip("this is the monsters Damage Stat")]
    [SerializeField]
    private Text MonsterDamage = null;

    [Tooltip("this is the monsters Defence Stat")]
    [SerializeField]
    private Text MonsterDefence = null;

    [Tooltip("This is the monsters Speed stat")]
    [SerializeField]
    private Text MonsterSpeed = null;

    [Tooltip("this is the monsters Resistance Stat")]
    [SerializeField]
    private Text MonsterResistance = null;

    [Tooltip("This is the monsters Accuracy Stat")]
    [SerializeField]
    private Text MonsterAccuracy = null;

    [Tooltip("this is the monsters Crit Damage Stat")]
    [SerializeField]
    private Text MonsterCritDamage = null;

    [Tooltip("this is the monsters Crit Rate Stat")]
    [SerializeField]
    private Text MonsterCritRate = null;

    [Tooltip("this is the monsters stars")]
    [SerializeField]
    private Text MonsterStars = null;

    [Tooltip("this is the monsters Type")]
    [SerializeField]
    private Text MonsterType = null;

    [Tooltip("this is the monsters Awakening")]
    [SerializeField]
    private Text MonsterAwakening = null;

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

    //these are the images for the six runes bieng displayed
    [SerializeField]
    private Image RuneOneImage = null;
    
    [SerializeField]
    private Image RuneTwoImage = null;

    [SerializeField]
    private Image RuneThreeImage = null;

    [SerializeField]
    private Image RuneFourImage = null;

    [SerializeField]
    private Image RuneFiveImage = null;

    [SerializeField]
    private Image RuneSixImage = null;

    private bool Once = false;

    void Start()
    {
        RunePanel.SetActive(false);
        RuneUpgradePanel.SetActive(false);
        MonsterUpgradePanel.SetActive(false);

        //TheManager.Load();
    }

    private void OnEnable()
    {
        if (Once)
        {
            TheManager.Load();
            GenerateRuneButtons();
            TheManager.LoadMonsterInformation();
            StoreMonsters();
            RefreshMonsterStats();
        }
    }

    private void Update()
    {
        if (!Once)
            Once = true;
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

    // a function used to select a certain rune that has been equiped on the monster
    public void RuneMainButton(int RuneNumber)
    {
        switch (RuneNumber)
        {
            case (1):
                {
                    if(MonsterBiengUsed.ReturnRune(1) != null)
                    {
                        RuneBiengUsed = MonsterBiengUsed.ReturnRune(1);
                        RunePanel.SetActive(true);
                        RefreshRuneUI();
                    }
                    break;
                }
            case (2):
                {
                    if(MonsterBiengUsed.ReturnRune(2) != null)
                    {
                        RuneBiengUsed = MonsterBiengUsed.ReturnRune(2);
                        RunePanel.SetActive(true);
                        RefreshRuneUI();
                    }
                    break;
                }
            case (3):
                {
                    if (MonsterBiengUsed.ReturnRune(3) != null)
                    {
                        RuneBiengUsed = MonsterBiengUsed.ReturnRune(3);
                        RunePanel.SetActive(true);
                        RefreshRuneUI();
                    }
                    break;
                }
            case (4):
                {
                    if (MonsterBiengUsed.ReturnRune(4) != null)
                    {
                        RuneBiengUsed = MonsterBiengUsed.ReturnRune(4);
                        RunePanel.SetActive(true);
                        RefreshRuneUI();
                    }
                    break;
                }
            case (5):
                {
                    if (MonsterBiengUsed.ReturnRune(5) != null)
                    {
                        RuneBiengUsed = MonsterBiengUsed.ReturnRune(5);
                        RunePanel.SetActive(true);
                        RefreshRuneUI();
                    }
                    break;
                }
            case (6):
                {
                    if (MonsterBiengUsed.ReturnRune(6) != null)
                    {
                        RuneBiengUsed = MonsterBiengUsed.ReturnRune(6);
                        RunePanel.SetActive(true);
                        RefreshRuneUI();
                    }
                    break;
                }
        }

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
        RuneSlot.text = "Rune Slot: " + RuneBiengUsed.ReturnRuneSlot();
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

            MonsterBiengUsed.MonsterIncreasedStatRefresh(RuneBiengUsed, "Decreased");

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
            MonsterBiengUsed.MonsterIncreasedStatRefresh(RuneBiengUsed, "Increased");

            if(RuneBiengUsed.ReturnRuneEquiped())
            {
                RefreshRuneEquipedMonsterUI();
            }
        }
    }

    // this is a function to refresh the rune image UI when switching monsters
    public void RefreshRuneImageUI()
    {
        if (MonsterBiengUsed.ReturnRune(1) != null)
            RuneOneImage.color = new Color(1, 1, 1, 1);
        else
            RuneOneImage.color = new Color(1, 1, 1, 0);


        if (MonsterBiengUsed.ReturnRune(2) != null)
            RuneTwoImage.color = new Color(1, 1, 1, 1);
        else
            RuneTwoImage.color = new Color(1, 1, 1, 0);


        if (MonsterBiengUsed.ReturnRune(3) != null)
            RuneThreeImage.color = new Color(1, 1, 1, 1);
        else
            RuneThreeImage.color = new Color(1, 1, 1, 0);


        if (MonsterBiengUsed.ReturnRune(4) != null)
            RuneFourImage.color = new Color(1, 1, 1, 1);
        else
            RuneFourImage.color = new Color(1, 1, 1, 0);


        if (MonsterBiengUsed.ReturnRune(5) != null)
            RuneFiveImage.color = new Color(1, 1, 1, 1);
        else
            RuneFiveImage.color = new Color(1, 1, 1, 0);


        if (MonsterBiengUsed.ReturnRune(6) != null)
            RuneSixImage.color = new Color(1, 1, 1, 1);
        else
            RuneSixImage.color = new Color(1, 1, 1, 0);

    }


    // this function will increase the monstes stats by the increased stats by the rune bieng equiped
    public void EquipSelectedRune()
    {
        if (!RuneBiengUsed.ReturnRuneEquiped())
        {
            MonsterBiengUsed.EquipRune(RuneBiengUsed);
            RefreshRuneUI();
            RefreshRuneEquipedMonsterUI();

            switch (RuneBiengUsed.ReturnRuneSlot())
            {
                case (1):
                    {
                        StartCoroutine(FadeImageRune(RuneOneImage, "In"));
                        break;
                    }
                case (2):
                    {
                        StartCoroutine(FadeImageRune(RuneTwoImage, "In"));
                        break;
                    }
                case (3):
                    {
                        StartCoroutine(FadeImageRune(RuneThreeImage, "In"));
                        break;
                    }
                case (4):
                    {
                        StartCoroutine(FadeImageRune(RuneFourImage, "In"));
                        break;
                    }
                case (5):
                    {
                        StartCoroutine(FadeImageRune(RuneFiveImage, "In"));
                        break;
                    }
                case (6):
                    {
                        StartCoroutine(FadeImageRune(RuneSixImage, "In"));
                        break;
                    }
            }
        }
    }

    //this function will decrease the monsters stats by the increased stats of the rune bieng unequiped
    public void UnEquipSelectedRune()
    {
        if (RuneBiengUsed.ReturnRuneEquiped())
        {
            MonsterBiengUsed.UnequipRune(RuneBiengUsed);
            RefreshRuneUI();
            RefreshRuneEquipedMonsterUI();

            switch (RuneBiengUsed.ReturnRuneSlot())
            {
                case (1):
                    {
                        StartCoroutine(FadeImageRune(RuneOneImage, "Out"));
                        break;
                    }
                case (2):
                    {
                        StartCoroutine(FadeImageRune(RuneTwoImage, "Out"));
                        break;
                    }
                case (3):
                    {
                        StartCoroutine(FadeImageRune(RuneThreeImage, "Out"));
                        break;
                    }
                case (4):
                    {
                        StartCoroutine(FadeImageRune(RuneFourImage, "Out"));
                        break;
                    }
                case (5):
                    {
                        StartCoroutine(FadeImageRune(RuneFiveImage, "Out"));
                        break;
                    }
                case (6):
                    {
                        StartCoroutine(FadeImageRune(RuneSixImage, "Out"));
                        break;
                    }
            }
        }
    }


    //this function will change the monster stats ui to display the increased stats
    public void RefreshRuneEquipedMonsterUI()
    {
        if (MonsterBiengUsed.ReturnIncreasedHealth() > 0)
        {
            MonsterHealth.text = "Health: " + MonsterBiengUsed.ReturnBaseHealth() + " + " + MonsterBiengUsed.ReturnIncreasedHealth();
        }
        else
        {
            MonsterHealth.text = "Health: " + MonsterBiengUsed.ReturnBaseHealth();
        }

        if(MonsterBiengUsed.ReturnIncreasedAttack() > 0)
        {
            MonsterDamage.text = "Attack: " + MonsterBiengUsed.ReturnBaseDamage() + " + " + MonsterBiengUsed.ReturnIncreasedAttack();
        }
        else
        {
            MonsterDamage.text = "Attack: " + MonsterBiengUsed.ReturnBaseDamage();
        }

        if(MonsterBiengUsed.ReturnIncreasedDefence() > 0)
        {
            MonsterDefence.text = "Defence: " + MonsterBiengUsed.ReturnBaseDefence() + " + " + MonsterBiengUsed.ReturnIncreasedDefence();
        }
        else
        {
            MonsterDefence.text = "Defence: " + MonsterBiengUsed.ReturnBaseDefence();
        }
       
        if(MonsterBiengUsed.ReturnIncreasedSpeed() > 0)
        {
            MonsterSpeed.text = "Speed: " + MonsterBiengUsed.ReturnBaseSpeed() + " + " + MonsterBiengUsed.ReturnIncreasedSpeed();
        }
        else
        {
            MonsterSpeed.text = "Speed: " + MonsterBiengUsed.ReturnBaseSpeed();
        }

        if(MonsterBiengUsed.ReturnIncreasedCritRate() > 0)
        {
            MonsterCritRate.text = "Crit Rate: " + MonsterBiengUsed.ReturnBaseCritRate() + " + " + MonsterBiengUsed.ReturnIncreasedCritRate();
        }
        else
        {
            MonsterCritRate.text = "Crit Rate: " + MonsterBiengUsed.ReturnBaseCritRate();
        }

        if(MonsterBiengUsed.ReturnIncreasedCritDamage() > 0)
        {
            MonsterCritDamage.text = "Crit Damage: " + MonsterBiengUsed.ReturnBaseCritDamage() + " + " + MonsterBiengUsed.ReturnIncreasedCritDamage();
        }
        else
        {
            MonsterCritDamage.text = "Crit Damage: " + MonsterBiengUsed.ReturnBaseCritDamage();
        }
        
        if(MonsterBiengUsed.ReturnIncreasedAccuracy() > 0)
        {
            MonsterAccuracy.text = "Accuracy: " + MonsterBiengUsed.ReturnBaseAccuracy() + " + " + MonsterBiengUsed.ReturnIncreasedAccuracy();
        }
        else
        {
            MonsterAccuracy.text = "Accuracy: " + MonsterBiengUsed.ReturnBaseAccuracy();
        }

        if(MonsterBiengUsed.ReturnIncreasedResistance() > 0)
        {
            MonsterResistance.text = "Resistance: " + MonsterBiengUsed.ReturnBaseResistance() + " + " + MonsterBiengUsed.ReturnIncreasedResistance();
        }
        else
        {
            MonsterResistance.text = "Resistance: " + MonsterBiengUsed.ReturnBaseResistance();
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
        RefreshRuneEquipedMonsterUI();
        RefreshRuneImageUI();
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

            //decrease all increased stats for all runes equiped
            RefreshIncreasedStatDecrease();

            MonsterBiengUsed.IncreaseStars();

            //increase all increased stats for all runes equiped
            RefreshIncreasedStatIncrease();


            //refresh ui
            RefreshRuneEquipedMonsterUI();


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
            if (MonsterBiengUsed.ReturnMonsterLevel() != MonsterBiengUsed.ReturnMonsterMaxLevel())
            {
                PreviousMonsterDamage = MonsterBiengUsed.ReturnBaseDamage();
                PreviousMonsterDefence = MonsterBiengUsed.ReturnBaseDefence();
                PreviousMonsterHealth = MonsterBiengUsed.ReturnBaseHealth();
                PreviousMonsterLevel = MonsterBiengUsed.ReturnMonsterLevel();
                PreviousMonsterMaxLevel = MonsterBiengUsed.ReturnMonsterMaxLevel();

                RefreshIncreasedStatDecrease();

                MonsterBiengUsed.LevelUpMonster();

                RefreshIncreasedStatIncrease();


                //refresh ui
                RefreshRuneEquipedMonsterUI();

                StartCoroutine(LevelUpDisplayChange(2));
            }
        }

    }

    // a function to close the upgrade panel
    public void CloseUpgradPanel()
    {
        MonsterUpgradePanel.SetActive(false);
    }
    
    // function used to awaken the selected monster
    public void AwakenMonster()
    {
        if (MonsterBiengUsed.ReturnMonsterLevel() >= 25 && MonsterBiengUsed.ReturnMonsterStars() >= 4)
        {
            PreviousMonsterHealth = MonsterBiengUsed.ReturnBaseHealth();
            PreviousMonsterDefence = MonsterBiengUsed.ReturnBaseDefence();
            PreviousMonsterDamage = MonsterBiengUsed.ReturnBaseDamage();

            RefreshIncreasedStatDecrease();

            MonsterBiengUsed.Awaken();

            RefreshIncreasedStatIncrease();


            //refresh ui
            RefreshRuneEquipedMonsterUI();


            StartCoroutine(AwakendisplayChange(2.0f, true));
        }
        else
        {
            StartCoroutine(AwakendisplayChange(3.0f, false));
        }
    }

    // a function that refreshes the monsters increased stats by increasing them by the runes stats
    // this function is used to refresh the monsters increased stats when leveling up, awakening or increasing the stars on a monster 
    public void RefreshIncreasedStatIncrease()
    {
        if (MonsterBiengUsed.ReturnRune(1) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(1), "Increased");
        }
        if (MonsterBiengUsed.ReturnRune(2) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(2), "Increased");
        }
        if (MonsterBiengUsed.ReturnRune(3) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(3), "Increased");
        }
        if (MonsterBiengUsed.ReturnRune(4) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(4), "Increased");
        }
        if (MonsterBiengUsed.ReturnRune(5) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(5), "Increased");
        }
        if (MonsterBiengUsed.ReturnRune(6) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(6), "Increased");
        }
    }

    // a function that refreshes the monsters increased stats by decreaseing them by the runes stats
    // this function is used to refresh the monsters increased stats when leveliing up, awakening or increasing the stars on a monster
    public void RefreshIncreasedStatDecrease()
    {
        if (MonsterBiengUsed.ReturnRune(1) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(1), "Decreased");
        }
        if (MonsterBiengUsed.ReturnRune(2) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(2), "Decreased");
        }
        if (MonsterBiengUsed.ReturnRune(3) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(3), "Decreased");
        }
        if (MonsterBiengUsed.ReturnRune(4) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(4), "Decreased");
        }
        if (MonsterBiengUsed.ReturnRune(5) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(5), "Decreased");
        }
        if (MonsterBiengUsed.ReturnRune(6) != null)
        {
            MonsterBiengUsed.MonsterIncreasedStatRefresh(MonsterBiengUsed.ReturnRune(6), "Decreased");
        }

    }


    // enumerator to change the display to show monster awakening 
    IEnumerator AwakendisplayChange(float PauseTime, bool Awakened)
    {
        if (Awakened)
        {
            for (float i = 0; i < PauseTime; i += Time.deltaTime)
            {
                
                MonsterUpgradeText.text = "MONSTER SUCCESSULY AWAKENED!!!";

                HealthText.text = PreviousMonsterHealth + "  --->  " + MonsterBiengUsed.ReturnBaseHealth();
                DamageText.text = PreviousMonsterDamage + "  --->  " + MonsterBiengUsed.ReturnBaseDamage();
                DefenceText.text = PreviousMonsterDefence + "  --->  " + MonsterBiengUsed.ReturnBaseDefence();
                yield return null;
            }
            
        }
        else
        {
            for (float i = 0; i < PauseTime; i += Time.deltaTime)
            {
                MonsterUpgradeText.text = "Monster Needs to be level 25 and 4 stars or more to awaken!";
                yield return null;
            }
            
        }

        MonsterUpgradeText.text = "Upgrade your monster";
        HealthText.text = "Health: " + MonsterBiengUsed.ReturnBaseHealth();
        DamageText.text = "Damage: " + MonsterBiengUsed.ReturnBaseDamage();
        DefenceText.text = "Defence: " + MonsterBiengUsed.ReturnBaseDefence();
        MonsterLevelText.text = "Level: " + MonsterBiengUsed.ReturnMonsterLevel();

    }

    //enumerator to fade the image selected
    IEnumerator FadeImage(Image TheImage)
    {
        for (float i = 0.0f; i <= 1.0f; i += Time.deltaTime)
        {
            MonsterUpgradeText.text = "Monster Stars Increased!!";
            MonsterMaxLevelText.text = PreviousMonsterMaxLevel + "  --->  " + MonsterBiengUsed.ReturnMonsterMaxLevel();
            TheImage.color = new Color(1, 1, 1, i);
            yield return null;
        }

        MonsterMaxLevelText.text = "Max Level: " + MonsterBiengUsed.ReturnMonsterMaxLevel();
        MonsterUpgradeText.text = "Upgrade Your Monster";
    }

    //enumerator to fade any of the rune images
    IEnumerator FadeImageRune(Image TheImage, string InorOut)
    {
        if(InorOut == "In")
        {
            for (float i = 0.0f; i <= 1.0f; i += Time.deltaTime)
            {
                TheImage.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else if (InorOut == "Out")
        {
            for (float i = 1.0f; i >= 0.0f; i -= Time.deltaTime)
            {
                TheImage.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

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

        RefreshMonsterStats();
        RefreshRuneEquipedMonsterUI();
        

        LevelCorutineRun = false;
    }



}
