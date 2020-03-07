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

    // this is the drop down that is used to display the rune information
    public Dropdown RuneDisplay = null;

    public Image NoRuneUsed = null;

    // other infromation bits
    public GameObject loadedrune;
    public bool LoadTheRuneOnce = false;
    public RuneScript RuneBiengUsed = null;
    public MonsterData MonsterBiengUsed = null;

    
    // this is the manager that holds all of the information 
    private GameManagment TheManager;

    // list of the runes names to be used for sorting through differnt runes
    private List<string> Runes = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        TheManager = FindObjectOfType<GameManagment>();
        Runes.Add("NoRune");
        RuneDisplay.ClearOptions();
        RuneDisplay.AddOptions(Runes);
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<Image>().gameObject.SetActive(true);
        ChangeUI();
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


   public void LoadRuneTest()
   {
        
        loadedrune = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Assets/Prefabs/RunesPrefabs/Rune.prefab") ;
        RuneBiengUsed = loadedrune.GetComponent<RuneScript>();
        
   }


   public void RuneDisplayFunc()
   {
        Debug.Log(TheManager.ReturnRuneNames()[0]);
        
        for(int i = 0; i < TheManager.ReturnRuneNames().Count; i++)
        {
            Runes.Add(TheManager.ReturnRuneNames()[i]);
        }
        RuneDisplay.ClearOptions();
        RuneDisplay.AddOptions(Runes);
        RuneDisplay.value = 0;
        RuneDisplay.Select();
        RuneDisplay.RefreshShownValue();


   }

    public void ChangedValue()
    {
        if(RuneDisplay.value == 0)
        {
            RuneBiengUsed = null;
        }
        else if(RuneDisplay.value >= TheManager.ReturnRuneNames().Count)
        {
            RuneBiengUsed = TheManager.SelectedDropDownRuneLoad(RuneDisplay.value - 1);
        }
        else
        {
            RuneBiengUsed = TheManager.SelectedDropDownRuneLoad(RuneDisplay.value - 1);
        }
       
    }


    public void ChangeUI()
    {
        if(RuneBiengUsed == null)
        {
            NoRuneUsed.gameObject.SetActive(true);
        }
        else 
        {
            RuneLevelText.text = "Rune Level : " + RuneBiengUsed.ReturnRuneLevel();
            RuneStar.text = "Rune star : " + RuneBiengUsed.ReturnAmountOfStars();
            RuneGrade.text = "Rune Grade : " + RuneBiengUsed.ReturnRuneRarity();
            RuneSlot.text = "Rune Slot : " + RuneBiengUsed.ReturnRuneSlot();

            MainRuneStat.text = "Main Rune Stat : " + RuneBiengUsed.ReturnMainRuneStat();
            RuneOneStat.text = RuneBiengUsed.ReturnRuneStatOneType() + ": " + RuneBiengUsed.ReturnRuneStatOne();
            RuneTwoStat.text = RuneBiengUsed.ReturnRuneStatTwoType() + ": " + RuneBiengUsed.ReturnRuneStatTwo();
            RuneThreeStat.text = RuneBiengUsed.ReturnRuneStatThreeType() + ": " + RuneBiengUsed.ReturnRuneStatThree();
            RuneFourStat.text = RuneBiengUsed.ReturnRuneStatFourType() + ": " + RuneBiengUsed.ReturnRuneStatFour();

            NoRuneUsed.gameObject.SetActive(false);
        }
    }

}
