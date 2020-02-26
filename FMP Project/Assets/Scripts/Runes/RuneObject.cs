using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rune", menuName = "ScriptableObjects/RuneObject", order = 1)]
public class RuneObject : ScriptableObject
{
    [Tooltip("The name that you want the rune to be callled")]
    [SerializeField]
    private string RuneName = null;

    [Tooltip("The bool to determine wether or not this rune is currently equiped")]
    [SerializeField]
    private bool RuneEquiped = false;

    [Tooltip("The current level of the Rune")]
    [SerializeField]
    private int RuneLevel = 0;

    // this int is to determine what slot this rune can be equiped to. this means it cant be equiped in other slots
    // if another rune is in the slot that this one is specified for then the player will have to replace it.
    [Tooltip("the rune slot that this rune will be equiped in (a rune can only be equiped to a specific slot")]
    [SerializeField]
    private int RuneSlot = 0;

    [Tooltip("this is the maximum amount of stats that can be on this rune. so when the rune is generated this is the max stats that are on the rune at the begining")]
    [SerializeField]
    private int MaxRuneStats = 0;

    [Tooltip("this is the number of current stats that are on the rune ")]
    [SerializeField]
    private int CurrentRuneStats = 0;

    [Tooltip("this is the max level that the rune can be. after this level the rune can no longer be upgraded ")]
    [SerializeField]
    private int RuneMaxLevel = 15;

    // this is the enum to hold the differnt types of stats that can be on the rune. depending on the type depends on what it affects on the monsters stats
    // the stats that can be there are all of the monsters base stats included in the monster class
    public enum RuneStats { Health, Defence, Attack, Speed, CritRate, CritDamage, Accuracy, Resistance };

    [Tooltip("this is the main stat of the rune that will be upgraded with every level")]
    [SerializeField]
    private float MainRuneStat = 0.0f;

    [Tooltip("the thye of stat that is applied for the main stat")]
    [SerializeField]
    private RuneStats MainStat = RuneStats.Attack;

    // this is a private string that holds the name of the type of stat for the main stat on the rune. used to help display to the user and outside the rune class
    private string MainStatType = "";

    [Tooltip("the first rune stat number")]
    [SerializeField]
    private float RuneStatOne = 0.0f;

    [Tooltip("the type of stat that is applied for the first stat of the rune")]
    [SerializeField]
    private RuneStats StatsOne = RuneStats.Health;

    //this is a private string that holds the name of the type of stat for the First stat, to be returned when the type is needed outside the class
    private string StatOneType = "";

    [Tooltip("the second rune stat number")]
    [SerializeField]
    private float RuneStatTwo = 0.0f;

    [Tooltip("the Type of stat that is applied for the second stat of the rune")]
    [SerializeField]
    private RuneStats StatsTwo = RuneStats.Health;

    //this is a private string that holds the name of the type of stat for the Second stat, to be returned when the type is needed outside the class
    private string StatTwoType = "";

    [Tooltip("the thrid rune stat number")]
    [SerializeField]
    private float RuneStatThree = 0.0f;

    [Tooltip("the Type of stat that is applied for the third stat of the rune")]
    [SerializeField]
    private RuneStats StatsThree = RuneStats.Health;

    //this is a private string that holds the name of the type of stat for the Thrid stat, to be returned when the type is needed outside the class
    private string StatThreeType = "";

    [Tooltip("the fouth rune stat number")]
    [SerializeField]
    private float RuneStatFour = 0.0f;

    [Tooltip("the Type of stat that is applied for the fourth stat of the rune")]
    [SerializeField]
    private RuneStats StatsFour = RuneStats.Health;

    // this is a private string that holds the name of the type of stat for the fourth stat, to be returned when the type is needed outside the class
    private string StatFourType = "";


    // this is the number that is given to each rune to derermine wether or not the rune will upgrade
    // this number is increased after every sucessful level up to change the probablity of an upgrade
    private int UpgradeNumber = 0;



    // Start is called before the first frame update
    void Start()
    {
        UpdateStatsType(RuneStatOne, StatsOne, StatOneType);
        UpdateStatsType(RuneStatTwo, StatsTwo, StatTwoType);
        UpdateStatsType(RuneStatThree, StatsThree, StatThreeType);
        UpdateStatsType(RuneStatFour, StatsFour, StatFourType);

        GenerateMainRuneStat();

    }

    // Update is called once per frame
    void Update()
    {

    }


    // this function will be run when the player wants to upgrade a rune and will increase the level of the rune depending on a random percentage
    public void UpgradeRune()
    {
        if (RuneLevel < RuneMaxLevel) // check to make sure that the rune level is not higher then the max level
        {
            if (Random.Range(0, 100) > UpgradeNumber) // does the check to see if upgrade was sucessful. if it is then it increases the level
            {
                RuneLevel++;


                if (RuneLevel == 3 && CurrentRuneStats == 1)
                {
                    RuneStatOne += Random.Range(0.0f, 5.0f);
                }
                else if (RuneLevel == 3 && CurrentRuneStats > 1)
                {
                    switch (Random.Range(0, CurrentRuneStats))
                    {
                        case (0):
                            {
                                RuneStatOne += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (1):
                            {
                                RuneStatTwo += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (2):
                            {
                                RuneStatThree += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (3):
                            {
                                RuneStatFour += Random.Range(0.0f, 5.0f);
                                break;
                            }
                    }

                }
                else if (RuneLevel == 3 && CurrentRuneStats <= 0) // this generates a random stat from the enum and then adds this to the first stat of the rune.
                {
                    GenerateRuneStat(1);
                }


                if (RuneLevel == 6 && CurrentRuneStats >= 2)
                {
                    switch (Random.Range(0, CurrentRuneStats))
                    {
                        case (0):
                            {
                                RuneStatOne += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (1):
                            {
                                RuneStatTwo += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (2):
                            {
                                RuneStatThree += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (3):
                            {
                                RuneStatFour += Random.Range(0.0f, 5.0f);
                                break;
                            }
                    }
                }
                else if (RuneLevel == 6 && CurrentRuneStats <= 1)
                {
                    GenerateRuneStat(2);
                }


                if (RuneLevel == 9 && CurrentRuneStats >= 3)
                {
                    switch (Random.Range(0, CurrentRuneStats))
                    {
                        case (0):
                            {
                                RuneStatOne += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (1):
                            {
                                RuneStatTwo += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (2):
                            {
                                RuneStatThree += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (3):
                            {
                                RuneStatFour += Random.Range(0.0f, 5.0f);
                                break;
                            }
                    }
                }
                else if (RuneLevel == 9 && CurrentRuneStats <= 2)
                {
                    GenerateRuneStat(3);
                }


                if (RuneLevel == 12 && CurrentRuneStats == 4)
                {
                    switch (Random.Range(0, CurrentRuneStats))
                    {
                        case (0):
                            {
                                RuneStatOne += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (1):
                            {
                                RuneStatTwo += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (2):
                            {
                                RuneStatThree += Random.Range(0.0f, 5.0f);
                                break;
                            }
                        case (3):
                            {
                                RuneStatFour += Random.Range(0.0f, 5.0f);
                                break;
                            }
                    }
                }
                else if(RuneLevel == 12 && CurrentRuneStats <= 3)
                {
                    GenerateRuneStat(4);
                }

            }
        }
    }

    //this function is called when a upgrade is sucessful. it will select one of the stats an generate a stat randomly 
    // this function is specific as its only called when it needs to get a new rune every 3 levels.
    // if there is already a stat in the position it would go in then it will upgrade a current stat
    // if there is no stat in the position that it would go then it will randomly pick a stat and put it there
    // the variable is to determine what stat is bieng generated on the rune
    public void GenerateRuneStat(int StatNumber)
    {
        switch (StatNumber)
        {
            case (1):
                {
                    StatsOne = (RuneStats)Random.Range(0, 7);
                    RuneStatOne = Random.Range(0.0f, 5.0f);
                    //RuneStatOne = Mathf.Round
                    UpdateStatsType(RuneStatOne, StatsOne, StatOneType);
                    CurrentRuneStats++;
                    break;
                }
            case (2):
                {
                    StatsTwo = (RuneStats)Random.Range(0, 7);
                    RuneStatTwo = Random.Range(0.0f, 5.0f);
                    UpdateStatsType(RuneStatTwo, StatsTwo, StatTwoType);
                    CurrentRuneStats++;
                    break;
                }
            case (3):
                {
                    StatsThree = (RuneStats)Random.Range(0, 7);
                    RuneStatThree = Random.Range(0.0f, 5.0f);
                    UpdateStatsType(RuneStatThree, StatsThree, StatThreeType);
                    CurrentRuneStats++;
                    break;
                }
            case (4):
                {
                    StatsFour = (RuneStats)Random.Range(0, 7);
                    RuneStatFour = Random.Range(0.0f, 5.0f);
                    UpdateStatsType(RuneStatFour, StatsFour, StatFourType);
                    CurrentRuneStats++;
                    break;
                }
        }
    }

    // this function will create the main stat that this rune will have. this stat is only created at the start
    public void GenerateMainRuneStat()
    {
        MainStat = (RuneStats)Random.Range(0, 7);
        MainRuneStat = Random.Range(1, 60);
        UpdateStatsType(MainRuneStat, MainStat, MainStatType);

    }

    // a function that returns the stat for the main stat on the rune
    public float ReturnMainStat()
    {
        return MainRuneStat;
    }

    // this function will return the type of stat that the main stat is on the rune
    public string ReturnMainStatType()
    {
        return MainStatType;
    }

    // a function that returns the stat for the first slot on the rune
    public float ReturnRuneStatOne()
    {
        return RuneStatOne;
    }

    // a function that returns the stat for the second slot on the rune
    public float ReturnRuneStatTwo()
    {
        return RuneStatTwo;
    }

    // a function that returns the stat for the third slot on the rune
    public float ReturnRuneStatThree()
    {
        return RuneStatThree;
    }

    // a function that returns the stat for the fourth slot on the rune
    public float ReturnRuneStatFour()
    {
        return RuneStatFour;
    }

    // this function will return the type of stat the first stat is 
    public string ReturnRuneStatOneType()
    {
        return StatOneType;
    }

    // this function will return the type of stat the second stat is
    public string ReturnRuneStatTwoType()
    {
        return StatTwoType;
    }

    // this function will return the type of stat the third stat is
    public string ReturnRuneStatThreeType()
    {
        return StatThreeType;
    }

    // this function will return the type of stat the fourth stat is
    public string ReturnRuneStatFourType()
    {
        return StatFourType;
    }

    //this function will be used to update the stats information like the private string used to return the differnt stat types
    // this function will be run at the start of when the rune is created and also when this rune is powered up and the amount of stats on the rune increases
    // params :
    // - the float runestats is the stats that you are checking. each rune has four stats and this float is one of those four stats depending on which stat you are updating
    // - the RuneStats is the stat that you are updating. example. if you are updating the first stat then you would put in stat one
    // - the string parameter is the string that needs to know what type that stat is. so when the type is updated this string is updated to know the type
    // Returns : this returns a string which will update the private string used to determine what type of stats are on the rune
    public string UpdateStatsType(float runestats, RuneStats TheRuneStats, string RuneTypeToUpdate)
    {
        // if a rune stat has a higher value then 0 it means that the stat has been generated allready
        if (runestats > 0)
        {
            switch (TheRuneStats)
            {
                case (RuneStats.Accuracy):
                    {
                        RuneTypeToUpdate = "Accuracy";

                        break;
                    }
                case (RuneStats.Attack):
                    {
                        RuneTypeToUpdate = "Attack";
                        break;
                    }
                case (RuneStats.CritDamage):
                    {
                        RuneTypeToUpdate = "CritDamage";
                        break;
                    }
                case (RuneStats.CritRate):
                    {
                        RuneTypeToUpdate = "CritRate";
                        break;
                    }
                case (RuneStats.Defence):
                    {
                        RuneTypeToUpdate = "Defence";
                        break;
                    }
                case (RuneStats.Health):
                    {
                        RuneTypeToUpdate = "Health";
                        break;
                    }
                case (RuneStats.Resistance):
                    {
                        RuneTypeToUpdate = "Resistance";
                        break;
                    }
                case (RuneStats.Speed):
                    {
                        RuneTypeToUpdate = "Speed";
                        break;
                    }
            }

        }


        return RuneTypeToUpdate;

    }

    // this function returns what rune slot this rune should be equiped to 
    public int ReturnRuneNumber()
    {
        return RuneSlot;
    }

    // returns the bool that determines wether this rune is equiped to the monster or not
    public bool ReturnRuneEquiped()
    {
        return RuneEquiped;
    }

    // this function is used to return the runes current level
    public int ReturnRuneLevel()
    {
        return RuneLevel;
    }
}
