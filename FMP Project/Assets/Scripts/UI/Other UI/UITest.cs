﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITest : MonoBehaviour
{

    // this is the monster that is holding the rune that i want to test the upgrading on
    public GameObject Monster;

    // this is the text for the runes (this is for demonstration of UI may be used later on or may need to be serilised)
    public Text RuneOneStat;
    public Text RuneTwoStat;
    public Text RuneThreeStat;
    public Text RuneFourStat;
    public Text MainRuneStat;

    // other texts displaying other information on the rune
    public Text RuneLevelText;
    public Text RuneStar;
    public Text RuneGrade;
    public Text RuneSlot;
    public Text RuneName;

    // an image to display when no information is present
    public Image NoRuneUsed = null;

    // the current rune that is bieng used
    private RuneScript RuneBiengUsed = null;

    // this is the manager that holds all of the information 
    private GameManagment TheManager;

    [Tooltip("this is the text component for the rune selection button")]
    [SerializeField]
    private Text RuneSelectionText = null;

    [Tooltip("the list of buttons that will be used to display each rune")]
    [SerializeField]
    private List<GameObject> RuneButtons = new List<GameObject>();

    [Tooltip("this is the amount of monsters within the list")]
    [SerializeField]
    private int RuneButtonCount;

    [Tooltip("this is the button template that will be use dto create the button")]
    [SerializeField]
    private GameObject ButtonTemplate = null;

    [Tooltip("this is the panel object to display the rune UI")]
    [SerializeField]
    private GameObject RuneSelectionPanel = null;

    private bool Once = false;

    [Tooltip("this is a panel used to tell the player what to do on the rune UI")]
    [SerializeField]
    private GameObject FirstTimeRunePanel;


    // Start is called before the first frame update
    void Start()
    {
        TheManager = FindObjectOfType<GameManagment>();
        NoRuneUsed.gameObject.SetActive(true);
        RuneBiengUsed = null;
    }

    private void OnEnable()
    {
        Once = false;
        TheManager = FindObjectOfType<GameManagment>();
        TheManager.Load();
        ClearUI();

        if (TheManager.ReturnPlayerRunes().Count > 0)
        {
            Once = true;
        }

        if(Once)
        {
            TheManager.Load();
            TheManager.LoadRuneIn();
            TheManager.GetAllRunes();
            GenerateRuneButtons();
        }
        else
        {
            GenerateRuneButtons();
            FirstTimeRunePanel.SetActive(true);

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!Once)
            Once = true;

        ChangeUI();
    }

    //this functoin generates the buttons to display all of the runes that the player owns in thier inventory
    public void GenerateRuneButtons()
    {
        foreach(GameObject G in RuneButtons)
        {
            Destroy(G);
        }

        RuneButtons.Clear();
        RuneButtonCount = 0;

        foreach(RuneScript R in TheManager.ReturnPlayerRunes())
        {
            GameObject NewRune = Instantiate(ButtonTemplate) as GameObject;
            NewRune.SetActive(true);
            NewRune.name = "Rune " + RuneButtonCount;
            RuneButtonCount++;
            NewRune.transform.SetParent(ButtonTemplate.transform.parent, false);
            RuneButtons.Add(NewRune);
        }

    }


    public void ClearUI()
    {
        RuneBiengUsed = null;
        NoRuneUsed.gameObject.SetActive(true);

        RuneName.text = "Rune Name:";
        RuneLevelText.text = "Rune Level: ";
        RuneStar.text = "Rune Star: ";
        RuneGrade.text = "Rune Rarity: ";
        RuneSlot.text = "Rune Slot:";

        MainRuneStat.text = "0";
        RuneOneStat.text =  "0";
        RuneTwoStat.text =  "0";
        RuneThreeStat.text = "0";
        RuneFourStat.text = "0"; 
    }

    // refreshes the UI of the rune to display everything.
    public void ChangeUI()
    {
        if(RuneBiengUsed == null)
        {
            NoRuneUsed.gameObject.SetActive(true);
        }
        else if(RuneBiengUsed != null)
        {
            RuneName.text = "Rune Name: <color=darkblue>" + RuneBiengUsed.ReturnRuneName() + "</color>";
            RuneLevelText.text = "Rune Level: <color=darkblue>" + RuneBiengUsed.ReturnRuneLevel() + "</color>";
            RuneStar.text = "Rune Star: <color=darkblue>" + RuneBiengUsed.ReturnAmountOfStars() + "</color>";
            RuneGrade.text = "Rune Rarity: <color=darkblue>" + RuneBiengUsed.ReturnRuneRarity() + "</color>";
            RuneSlot.text = "Rune Slot: <color=darkblue>" + RuneBiengUsed.ReturnRuneSlot() + "</color>";

            if(RuneBiengUsed.ReturnMainRuneStatType() == "HealthPercentage" || RuneBiengUsed.ReturnMainRuneStatType() == "DefencePercentage" || RuneBiengUsed.ReturnMainRuneStatType() == "AttackPercentage")
            {
                switch (RuneBiengUsed.ReturnMainRuneStatType())
                {
                    case ("HealthPercentage"):
                        {
                            MainRuneStat.text = "Health Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnMainRuneStat() + "</color>";
                            break;
                        }
                    case ("DefencePercentage"):
                        {
                            MainRuneStat.text = "Defence Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnMainRuneStat() + "</color>";
                            break;
                        }
                    case ("AttackPercentage"):
                        {
                            MainRuneStat.text = "Attack Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnMainRuneStat() + "</color>";
                            break;
                        }
                }

            }
            else
            {
                MainRuneStat.text = RuneBiengUsed.ReturnMainRuneStatType() + ": <color=darkblue>" + RuneBiengUsed.ReturnMainRuneStat() + "</color>";
            }


            if (RuneBiengUsed.ReturnRuneStatOneType() == "HealthPercentage" || RuneBiengUsed.ReturnRuneStatOneType() == "DefencePercentage" || RuneBiengUsed.ReturnRuneStatOneType() == "AttackPercentage")
            {
                switch (RuneBiengUsed.ReturnRuneStatOneType())
                {
                    case ("HealthPercentage"):
                        {
                            RuneOneStat.text = "Health Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatOne() + "</color>";
                            break;
                        }
                    case ("DefencePercentage"):
                        {
                            RuneOneStat.text = "Defence Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatOne() + "</color>";
                            break;
                        }
                    case ("AttackPercentage"):
                        {
                            RuneOneStat.text = "Attack Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatOne() + "</color>";
                            break;
                        }
                }

            }
            else
            {
                RuneOneStat.text = RuneBiengUsed.ReturnRuneStatOneType() + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatOne() + "</color>";
            }

            if (RuneBiengUsed.ReturnRuneStatTwoType() == "HealthPercentage" || RuneBiengUsed.ReturnRuneStatTwoType() == "DefencePercentage" || RuneBiengUsed.ReturnRuneStatTwoType() == "AttackPercentage")
            {
                switch (RuneBiengUsed.ReturnRuneStatTwoType())
                {
                    case ("HealthPercentage"):
                        {
                            RuneTwoStat.text = "Health Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatTwo() + "</color>";
                            break;
                        }
                    case ("DefencePercentage"):
                        {
                            RuneTwoStat.text = "Defence Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatTwo() + "</color>";
                            break;
                        }
                    case ("AttackPercentage"):
                        {
                            RuneTwoStat.text = "Attack Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatTwo() + "</color>";
                            break;
                        }
                }

            }
            else
            {
                RuneTwoStat.text = RuneBiengUsed.ReturnRuneStatTwoType() + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatTwo() + "</color>";
            }


            if (RuneBiengUsed.ReturnRuneStatThreeType() == "HealthPercentage" || RuneBiengUsed.ReturnRuneStatThreeType() == "DefencePercentage" || RuneBiengUsed.ReturnRuneStatThreeType() == "AttackPercentage")
            {
                switch (RuneBiengUsed.ReturnRuneStatThreeType())
                {
                    case ("HealthPercentage"):
                        {
                            RuneThreeStat.text = "Health Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatThree() + "</color>";
                            break;
                        }
                    case ("DefencePercentage"):
                        {
                            RuneThreeStat.text = "Defence Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatThree() + "</color>";
                            break;
                        }
                    case ("AttackPercentage"):
                        {
                            RuneThreeStat.text = "Attack Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatThree() + "</color>";
                            break;
                        }
                }

            }
            else
            {
                RuneThreeStat.text = RuneBiengUsed.ReturnRuneStatThreeType() + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatThree() + "</color>";
            }

            if (RuneBiengUsed.ReturnRuneStatFourType() == "HealthPercentage" || RuneBiengUsed.ReturnRuneStatFourType() == "DefencePercentage" || RuneBiengUsed.ReturnRuneStatFourType() == "AttackPercentage")
            {
                switch (RuneBiengUsed.ReturnRuneStatFourType())
                {
                    case ("HealthPercentage"):
                        {
                            RuneFourStat.text = "Health Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatFour() + "</color>";
                            break;
                        }
                    case ("DefencePercentage"):
                        {
                            RuneFourStat.text = "Defence Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatFour() + "</color>";
                            break;
                        }
                    case ("AttackPercentage"):
                        {
                            RuneFourStat.text = "Attack Percentage" + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatFour() + "</color>";
                            break;
                        }
                }

            }
            else
            {
                RuneFourStat.text = RuneBiengUsed.ReturnRuneStatFourType() + ": <color=darkblue>" + RuneBiengUsed.ReturnRuneStatFour() + "</color>";
            }

            
            

            NoRuneUsed.gameObject.SetActive(false);
        }
    }

    // this sets the rune that is currently bieng used
    public void SetRuneBiengUsed(RuneScript TheRune)
    {
        RuneBiengUsed = TheRune;
    }

    // opens the rune penel to allow for the player to select the rune they want
    public void OpenCloseRuneSelection()
    {
        RuneSelectionPanel.SetActive(!RuneSelectionPanel.activeSelf);
    }

    //this sets the rune that is bieng used from the selection and then refreshes the UI. 
    public void SetRuneInUse()
    {
        RuneBiengUsed = TheManager.ReturnSelectedRune(EventSystem.current.currentSelectedGameObject.name);
        ChangeUI();
    }


    public void RuneSelectionTextChange()
    {
        if(RuneSelectionPanel.activeInHierarchy)
        {
            RuneSelectionText.text = "Close Rune\nSelection";
        }
        else
        {
            RuneSelectionText.text = "Open Rune\nSelection";
        }
    }

}
