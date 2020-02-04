using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneScript : MonoBehaviour
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

    [Tooltip("this is the current level that the rune is at.")]
    [SerializeField]
    private int RuneCurrentLevel = 0;

    // this is the enum to hold the differnt types of stats that can be on the rune. depending on the type depends on what it affects on the monsters stats
    // the stats that can be there are all of the monsters base stats included in the monster class
    private enum RuneStats {Health, Defence, Attack, Speed, CritRate, CritDamage, Accuracy, Resistance };

    [Tooltip("the first rune stat number")]
    [SerializeField]
    private float RuneStatOne = 0.0f;

    [Tooltip("the type of stat that is applied for the first stat of the rune")]
    [SerializeField]
    private RuneStats StatsOne = RuneStats.Health;

    [Tooltip("the second rune stat number")]
    [SerializeField]
    private float RuneStatTwo = 0.0f;

    [Tooltip("the Type of stat that is applied for the second stat of the rune")]
    [SerializeField]
    private RuneStats StatsTwo = RuneStats.Health;

    [Tooltip("the thrid rune stat number")]
    [SerializeField]
    private float RuneStatThree = 0.0f;

    [Tooltip("the Type of stat that is applied for the third stat of the rune")]
    [SerializeField]
    private RuneStats StatsThree = RuneStats.Health;

    [Tooltip("the fouth rune stat number")]
    [SerializeField]
    private float RuneStatFour = 0.0f;

    [Tooltip("the Type of stat that is applied for the fourth stat of the rune")]
    [SerializeField]
    private RuneStats StatsFour = RuneStats.Health;

    // this is the number that is given to each rune to derermine wether or not the rune will upgrade
    // this number is increased after every sucessful level up to change the probablity of an upgrade
    private int UpgradeNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // this function will be run when the player wants to upgrade a rune and will increase the level of the rune depending on a random percentage
    public void UpgradeRune()
    {

    }

    //this function is called when a upgrade is sucessful. it will select one of the stats an generate a stat randomly 
    // this function is specific as its only called when it needs to get a new rune every 3 levels.
    // if there is already a stat in the position it would go in then it will upgrade a current stat
    // if there is no stat in the position that it would go then it will randomly pick a stat and put it there
    public void GenerateRuneStat()
    {

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

}
