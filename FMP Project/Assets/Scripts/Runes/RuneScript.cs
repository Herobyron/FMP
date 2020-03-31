using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RuneScript
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

    [Tooltip("this is the amount of stars that the rune has")]
    [SerializeField]
    private int RuneStars = 0;

    [Tooltip("this is the runes owner")]
    [SerializeField]
    private string RuneOwnerName;

    [Tooltip("this is the monster the rune is equiped to")]
    [SerializeField]
    private string MonsterEquipedToo;

    // this is the rarity that the runes can be 
    public enum RuneRarity { common, Uncommon, Rare, Epic, Legendary };

    [Tooltip("this is the grade of the rune which will have. this will change how much the runes stats are upgraded")]
    [SerializeField]
    private RuneRarity Rarity = RuneRarity.common;

    // this is the name of the rarity this rune is. the reason for this is so other scripts can tell what rarity the rune is
    private string RuneRarityName = "";


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
    public enum RuneStats { Health, Defence, Attack, Speed, CritRate, CritDamage, Accuracy, Resistance, HealthPer, DefencePer, AttackPer };

    [Tooltip("this is the main stat of the rune that will be upgraded with every level")]
    [SerializeField]
    private float MainRuneStat = 0.0f;

    [Tooltip("the type of stat that is applied for the main stat")]
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
    public string StatOneType = "";

    [Tooltip("the second rune stat number")]
    [SerializeField]
    private float RuneStatTwo = 0.0f;

    [Tooltip("the Type of stat that is applied for the second stat of the rune")]
    [SerializeField]
    private RuneStats StatsTwo = RuneStats.Health;

    //this is a private string that holds the name of the type of stat for the Second stat, to be returned when the type is needed outside the class
    public string StatTwoType = "";

    [Tooltip("the thrid rune stat number")]
    [SerializeField]
    private float RuneStatThree = 0.0f;

    [Tooltip("the Type of stat that is applied for the third stat of the rune")]
    [SerializeField]
    private RuneStats StatsThree = RuneStats.Health;

    //this is a private string that holds the name of the type of stat for the Thrid stat, to be returned when the type is needed outside the class
    public string StatThreeType = "";

    [Tooltip("the fouth rune stat number")]
    [SerializeField]
    private float RuneStatFour = 0.0f;

    [Tooltip("the Type of stat that is applied for the fourth stat of the rune")]
    [SerializeField]
    private RuneStats StatsFour = RuneStats.Health;

    // this is a private string that holds the name of the type of stat for the fourth stat, to be returned when the type is needed outside the class
    public string StatFourType = "";


    // this is the number that is given to each rune to derermine wether or not the rune will upgrade
    // this number is increased after every sucessful level up to change the probablity of an upgrade
    private int UpgradeNumber = 0;



    //// Start is called before the first frame update
    //void Start()
    //{
    //    UpdateStatsType(RuneStatOne, StatsOne, 1);
    //    UpdateStatsType(RuneStatTwo, StatsTwo, 2);
    //    UpdateStatsType(RuneStatThree, StatsThree, 3);
    //    UpdateStatsType(RuneStatFour, StatsFour, 4);
    //
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    
    //}


    // this function will be run when the player wants to upgrade a rune and will increase the level of the rune depending on a random percentage
    public bool UpgradeRune()
    {
        if (RuneLevel < RuneMaxLevel) // check to make sure that the rune level is not higher then the max level
        {
            UpgradeNumber = (RuneStars * RuneLevel); // checks the runes levels and stars to determine if the rune upgrade is successful

            if (Random.Range(0, 100) > UpgradeNumber) // does the check to see if upgrade was sucessful. if it is then it increases the level
            {
                RuneLevel++;
                UpgradeMainRuneStat();

                if (RuneLevel == 3 && CurrentRuneStats == 1)
                {
                    if ((int)StatsOne >= 4) // this is for the stats that are percentage
                    {
                        RuneStatOne += Random.Range(1, 5);
                    }
                    else if ((int)StatsOne <= 3) // this is for the stats that are non percentage
                    {
                        RuneStatOne += Random.Range(10, 30);
                    }

                }
                else if (RuneLevel == 3 && CurrentRuneStats > 1)
                {
                    switch (Random.Range(0, (CurrentRuneStats - 1)))
                    {
                        case (0):
                            {
                                if ((int)StatsOne >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatOne += Random.Range(1, 5);
                                }
                                else if ((int)StatsOne <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatOne += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (1):
                            {
                                if ((int)StatsTwo >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatTwo += Random.Range(1, 5);
                                }
                                else if ((int)StatsTwo <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatTwo += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (2):
                            {
                                if ((int)StatsThree >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatThree += Random.Range(1, 5);
                                }
                                else if ((int)StatsThree <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatThree += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (3):
                            {
                                if ((int)StatsFour >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatFour += Random.Range(1, 5);
                                }
                                else if ((int)StatsFour <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatFour += Random.Range(10, 30);
                                }
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
                    switch (Random.Range(0, (CurrentRuneStats - 1)))
                    {
                        case (0):
                            {
                                if ((int)StatsOne >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatOne += Random.Range(1, 5);
                                }
                                else if ((int)StatsOne <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatOne += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (1):
                            {
                                if ((int)StatsTwo >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatTwo += Random.Range(1, 5);
                                }
                                else if ((int)StatsTwo <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatTwo += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (2):
                            {
                                if ((int)StatsThree >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatThree += Random.Range(1, 5);
                                }
                                else if ((int)StatsThree <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatThree += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (3):
                            {
                                if ((int)StatsFour >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatFour += Random.Range(1, 5);
                                }
                                else if ((int)StatsFour <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatFour += Random.Range(10, 30);
                                }
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
                    switch (Random.Range(0, (CurrentRuneStats - 1)))
                    {
                        case (0):
                            {
                                if ((int)StatsOne >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatOne += Random.Range(1, 5);
                                }
                                else if ((int)StatsOne <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatOne += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (1):
                            {
                                if ((int)StatsTwo >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatTwo += Random.Range(1, 5);
                                }
                                else if ((int)StatsTwo <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatTwo += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (2):
                            {
                                if ((int)StatsThree >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatThree += Random.Range(1, 5);
                                }
                                else if ((int)StatsThree <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatThree += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (3):
                            {
                                if ((int)StatsFour >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatFour += Random.Range(1, 5);
                                }
                                else if ((int)StatsFour <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatFour += Random.Range(10, 30);
                                }
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
                    switch (Random.Range(0, (CurrentRuneStats - 1)))
                    {
                        case (0):
                            {
                                if ((int)StatsOne >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatOne += Random.Range(1, 5);
                                }
                                else if ((int)StatsOne <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatOne += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (1):
                            {
                                if ((int)StatsTwo >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatTwo += Random.Range(1, 5);
                                }
                                else if ((int)StatsTwo <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatTwo += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (2):
                            {
                                if ((int)StatsThree >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatThree += Random.Range(1, 5);
                                }
                                else if ((int)StatsThree <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatThree += Random.Range(10, 30);
                                }
                                break;
                            }
                        case (3):
                            {
                                if ((int)StatsFour >= 4) // this is for the stats that are percentage
                                {
                                    RuneStatFour += Random.Range(1, 5);
                                }
                                else if ((int)StatsFour <= 3) // this is for the stats that are non percentage
                                {
                                    RuneStatFour += Random.Range(10, 30);
                                }
                                break;
                            }
                    }
                }
                else if (RuneLevel == 12 && CurrentRuneStats <= 3)
                {
                    GenerateRuneStat(4);
                }

                // have it return a bool to show the upgrade was a success. 
                return true;

            }
        }

        return false;
    }

    public void UpgradeMainRuneStat()
    {
        switch (RuneStars)
        {
            case (1):
                {
                    if ((int)MainStat >= 4) // this is for the stats that are percentage
                    {
                        MainRuneStat += Random.Range(2, 5);
                    }
                    else if ((int)MainStat <= 3) // this is for the stats that are non percentage
                    {
                        MainRuneStat += Random.Range(10, 30);
                    }
                    break;
                }
            case (2):
                {
                    if ((int)MainStat >= 4) // this is for the stats that are percentage
                    {
                        MainRuneStat += Random.Range(3, 6);
                    }
                    else if ((int)MainStat <= 3) // this is for the stats that are non percentage
                    {
                        MainRuneStat += Random.Range(20, 60);
                    }
                    break;
                }
            case (3):
                {
                    if ((int)MainStat >= 4) // this is for the stats that are percentage
                    {
                        MainRuneStat += Random.Range(4, 7);
                    }
                    else if ((int)MainStat <= 3) // this is for the stats that are non percentage
                    {
                        MainRuneStat += Random.Range(30, 90);
                    }
                    break;
                }
            case (4):
                {
                    if ((int)MainStat >= 4) // this is for the stats that are percentage
                    {
                        MainRuneStat += Random.Range(5, 8);
                    }
                    else if ((int)MainStat <= 3) // this is for the stats that are non percentage
                    {
                        MainRuneStat += Random.Range(40, 120);
                    }
                    break;
                }
            case (5):
                {
                    if ((int)MainStat >= 4) // this is for the stats that are percentage
                    {
                        MainRuneStat += Random.Range(6, 9);
                    }
                    else if ((int)MainStat <= 3) // this is for the stats that are non percentage
                    {
                        MainRuneStat += Random.Range(50, 150);
                    }
                    break;
                }
            case (6):
                {
                    if ((int)MainStat >= 4) // this is for the stats that are percentage
                    {
                        MainRuneStat += Random.Range(7, 10);
                    }
                    else if ((int)MainRuneStat <= 3) // this is for the stats that are non percentage
                    {
                        MainRuneStat += Random.Range(60, 180);
                    }
                    break;
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
                    StatsOne = (RuneStats)Random.Range(0, 10);

                    if ((int)StatsOne >= 4) // this is for the stats that are percentage
                    {
                        RuneStatOne = Random.Range(1, 5);
                    }
                    else if ((int)StatsOne <= 3) // this is for the stats that are non percentage
                    {
                        RuneStatOne = Random.Range(10, 30);
                    }
                    UpdateStatsType(RuneStatOne, StatsOne, 1);
                    CurrentRuneStats++;
                    break;
                }
            case (2):
                {
                    StatsTwo = (RuneStats)Random.Range(0, 10);

                    if ((int)StatsTwo >= 4) // this is for the stats that are percentage
                    {
                        RuneStatTwo = Random.Range(1, 5);
                    }
                    else if ((int)StatsTwo <= 3) // this is for the stats that are non percentage
                    {
                        RuneStatTwo = Random.Range(10, 30);
                    }

                    UpdateStatsType(RuneStatTwo, StatsTwo, 2);
                    CurrentRuneStats++;
                    break;
                }
            case (3):
                {
                    StatsThree = (RuneStats)Random.Range(0, 10);

                    if ((int)StatsThree >= 4) // this is for the stats that are percentage
                    {
                        RuneStatThree = Random.Range(1, 5);
                    }
                    else if ((int)StatsThree <= 3) // this is for the stats that are non percentage
                    {
                        RuneStatThree = Random.Range(10, 30);
                    }

                    UpdateStatsType(RuneStatThree, StatsThree, 3);
                    CurrentRuneStats++;
                    break;
                }
            case (4):
                {
                    StatsFour = (RuneStats)Random.Range(0, 10);

                    if ((int)StatsFour >= 4) // this is for the stats that are percentage
                    {
                        RuneStatFour = Random.Range(1, 5);
                    }
                    else if ((int)StatsFour <= 3) // this is for the stats that are non percentage
                    {
                        RuneStatFour = Random.Range(10, 30);
                    }

                    UpdateStatsType(RuneStatFour, StatsFour, 4);
                    CurrentRuneStats++;
                    break;
                }
        }
    }

    // this function will create the main stat this rune will have. this stat is online created at the start
    public void GenerateMainRuneStat()
    {
        if (RuneSlot == 1)
        {
            MainStat = RuneStats.Attack;
            GenerateMainStatNumber();

        }
        else if (RuneSlot == 3)
        {
            MainStat = RuneStats.Health;
            GenerateMainStatNumber();
        }
        else if (RuneSlot == 5)
        {
            MainStat = RuneStats.Defence;
            GenerateMainStatNumber();
        }
        else
        {
            MainStat = (RuneStats)Random.Range(0, 10);
            if ((int)MainStat >= 4) // this is for the stats that are percentage
            {
                GenerateMainStatNumberPercentage();
            }
            else if ((int)MainStat <= 3) // this is for the stats that are non percentage
            {
                GenerateMainRuneStat();
            }
        }

        UpdateStatsType(MainRuneStat, MainStat, 0);

    }

    // this function generates main stat for the rune depending on the stars of the rune 
    // this function will only be used for stats that are not using percentages
    public void GenerateMainStatNumber()
    {
        switch (RuneStars)
        {
            case (1):
                {
                    MainRuneStat = Random.Range(1, 20);
                    break;
                }
            case (2):
                {
                    MainRuneStat = Random.Range(21, 40);
                    break;
                }
            case (3):
                {
                    MainRuneStat = Random.Range(41, 60);
                    break;
                }
            case (4):
                {
                    MainRuneStat = Random.Range(61, 80);
                    break;
                }
            case (5):
                {
                    MainRuneStat = Random.Range(81, 100);
                    break;
                }
            case (6):
                {
                    MainRuneStat = Random.Range(101, 120);
                    break;
                }
        }
    }


    // this function generates the main stat for the rune depending on the stars of the rune
    // this function will only be used for stats that are using percentages
    public void GenerateMainStatNumberPercentage()
    {
        switch (RuneStars)
        {
            case (1):
                {
                    MainRuneStat = Random.Range(1, 2);
                    break;
                }
            case (2):
                {
                    MainRuneStat = Random.Range(3, 4);
                    break;
                }
            case (3):
                {
                    MainRuneStat = Random.Range(5, 6);
                    break;
                }
            case (4):
                {
                    MainRuneStat = Random.Range(7, 8);
                    break;
                }
            case (5):
                {
                    MainRuneStat = Random.Range(9, 10);
                    break;
                }
            case (6):
                {
                    MainRuneStat = Random.Range(11, 12);
                    break;
                }
        }

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
    // - the int determines what stat is bieng updated (0 is main stat and the others are self explanitory
    // Returns : this returns a string which will update the private string used to determine what type of stats are on the rune
    public void UpdateStatsType(float runestats, RuneStats TheRuneStats, int StatsNumber)
    {
        //string TypeToSet = "";

        // if a rune stat has a higher value then 0 it means that the stat has been generated allready
        if (runestats > 0)
        {
            switch (TheRuneStats)
            {
                case (RuneStats.Accuracy):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "Accuracy";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "Accuracy";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "Accuracy";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "Accuracy";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "Accuracy";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.Attack):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "Attack";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "Attack";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "Attack";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "Attack";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "Attack";
                                    break;
                                }

                        }
                        break;
                    }
                case (RuneStats.CritDamage):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "CritDamage";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "CritDamage";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "CritDamage";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "CritDamage";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "CritDamage";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.CritRate):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "CritRate";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "CritRate";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "CritRate";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "CritRate";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "CritRate";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.Defence):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "Defence";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "Defence";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "Defence";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "Defence";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "Defence";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.Health):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "Health";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "Health";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "Health";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "Health";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "Health";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.Resistance):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "Resistance";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "Resistance";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "Resistance";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "Resistance";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "Resistance";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.Speed):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "Speed";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "Speed";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "Speed";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "Speed";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "Speed";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.AttackPer):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "AttackPercentage";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "AttackPercentage";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "AttackPercentage";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "AttackPercentage";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "AttackPercentage";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.HealthPer):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "HealthPercentage";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "HealthPercentage";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "HealthPercentage";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "HealthPercentage";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "HealthPercentage";
                                    break;
                                }

                        }

                        break;
                    }
                case (RuneStats.DefencePer):
                    {
                        switch (StatsNumber)
                        {
                            case (0):
                                {
                                    MainStatType = "DefencePercentage";
                                    break;
                                }
                            case (1):
                                {
                                    StatOneType = "DefencePercentage";
                                    break;
                                }
                            case (2):
                                {
                                    StatTwoType = "DefencePercentage";
                                    break;
                                }
                            case (3):
                                {
                                    StatThreeType = "DefencePercentage";
                                    break;
                                }
                            case (4):
                                {
                                    StatFourType = "DefencePercentage";
                                    break;
                                }

                        }

                        break;
                    }
            }

        }




    }

    public void UpdateRarityType()
    {
        switch (Rarity)
        {
            case (RuneRarity.common):
                {
                    RuneRarityName = "Common";
                    break;
                }
            case (RuneRarity.Uncommon):
                {
                    RuneRarityName = "Uncommon";
                    break;
                }
            case (RuneRarity.Rare):
                {
                    RuneRarityName = "Rare";
                    break;
                }
            case (RuneRarity.Epic):
                {
                    RuneRarityName = "Epic";
                    break;
                }
            case (RuneRarity.Legendary):
                {
                    RuneRarityName = "Legendary";
                    break;
                }
        }
    }

    // function that sets what monster this rune is equipped too 
    public void SetMonsterEquipedToo(string MonsterName)
    {
        MonsterEquipedToo = MonsterName;
    }

    // this function returns what rune slot this rune should be equiped to 
    public int ReturnRuneNumber()
    {
        return RuneSlot;
    }

    // this function sets the runes equiped bool
    public void SetRuneEquiped(bool Equiped)
    {
        RuneEquiped = Equiped;
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

    // function to set the amount of stars 
    public void SetRuneStars(int Stars)
    {
        RuneStars = Stars;
    }

    // a function to return the amount of stars this rune has
    public int ReturnAmountOfStars()
    {
        return RuneStars;
    }

    // a function to return the type of rarity that this rune is
    public string ReturnRuneRarity()
    {
        return RuneRarityName;
    }

    // a function used to set the rarity of the rune depending on the number that has been put in
    // - the int is the number that determines what rarity the rune will be 
    public void SetRuneRarty(int RuneRarityNumber)
    {
        switch (RuneRarityNumber)
        {
            case (1):
                {
                    Rarity = RuneRarity.common;
                    RuneRarityName = "Common";
                    break;
                }
            case (2):
                {
                    Rarity = RuneRarity.Uncommon;
                    RuneRarityName = "Uncommon";
                    break;
                }
            case (3):
                {
                    Rarity = RuneRarity.Rare;
                    RuneRarityName = "Rare";
                    break;
                }
            case (4):
                {
                    Rarity = RuneRarity.Epic;
                    RuneRarityName = "Epic";
                    break;
                }
            case (5):
                {
                    Rarity = RuneRarity.Legendary;
                    RuneRarityName = "Legendary";
                    break;
                }

        }

    }


    // a function that sets the number of the rune slot that this rune can be
    public void SetRuneSlot(int RuneSlotNumber)
    {
        RuneSlot = RuneSlotNumber;
    }

    public int ReturnRuneSlot()
    {
        return RuneSlot;
    }

    public void SetRuneName(string Name)
    {
        RuneName = Name;
    }

    public void SetRuneOwner(string Owner)
    {
        RuneOwnerName = Owner;
    }

    public float ReturnMainRuneStat()
    {
        return MainRuneStat;
    }

    public string ReturnMainRuneStatType()
    {
        return MainStatType;
    }

    public string ReturnRuneName()
    {
        return RuneName;
    }

    public string ReturnMonsterEquipedTo()
    {
        return MonsterEquipedToo;
    }

}
