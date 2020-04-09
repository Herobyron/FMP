using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        TheManager = FindObjectOfType<GameManagment>();
        NoRuneUsed.gameObject.SetActive(true);
        RuneBiengUsed = null;
    }

    // Update is called once per frame
    void Update()
    {
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

    // refreshes the UI of the rune to display everything.
    public void ChangeUI()
    {
        if(RuneBiengUsed == null)
        {
            NoRuneUsed.gameObject.SetActive(true);
        }
        else if(RuneBiengUsed != null)
        {
            RuneName.text = "Rune Name: " + RuneBiengUsed.ReturnRuneName();
            RuneLevelText.text = "Rune Level: " + RuneBiengUsed.ReturnRuneLevel();
            RuneStar.text = "Rune Star: " + RuneBiengUsed.ReturnAmountOfStars();
            RuneGrade.text = "Rune Rarity: " + RuneBiengUsed.ReturnRuneRarity();
            RuneSlot.text = "Rune Slot: " + RuneBiengUsed.ReturnRuneSlot();

            MainRuneStat.text = RuneBiengUsed.ReturnMainRuneStatType() + ": " + RuneBiengUsed.ReturnMainRuneStat();
            RuneOneStat.text = RuneBiengUsed.ReturnRuneStatOneType() + ": " + RuneBiengUsed.ReturnRuneStatOne();
            RuneTwoStat.text = RuneBiengUsed.ReturnRuneStatTwoType() + ": " + RuneBiengUsed.ReturnRuneStatTwo();
            RuneThreeStat.text = RuneBiengUsed.ReturnRuneStatThreeType() + ": " + RuneBiengUsed.ReturnRuneStatThree();
            RuneFourStat.text = RuneBiengUsed.ReturnRuneStatFourType() + ": " + RuneBiengUsed.ReturnRuneStatFour();

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
}
