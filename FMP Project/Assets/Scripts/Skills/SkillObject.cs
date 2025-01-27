﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/SkillObject", order = 2)]
public class SkillObject : ScriptableObject
{
    [Tooltip("This is to determine wether this skill is an AOE - Area of Effect Skill or not")]
    [SerializeField]
    private bool ISAOE = false;

    [Tooltip("this is the number that represents how many turns this skill has left on cooldown")]
    [SerializeField]
    private int CoolDownTurns = 0;

    [Tooltip("this bool is to represent wether the skill is on cooldown or not")]
    [SerializeField]
    private bool OnCoolDown = false;

    [Tooltip("this is the max amount of turns that this skill can be on cooldown")]
    [SerializeField]
    private int MaxCoolDown = 5;

    [Tooltip("this is the name of the skill")]
    [SerializeField]
    private string SkillName = "Blank";



    // this function is what applys the skill. each skill will be differnt this is the base class for the skills what will allow for each script to hold a differnt skill
    // the parameters :
    // the first monster is the monster that is using the skill
    // the second monster is the one that will be taking the damage or bieng healed depending on the Type of attack
    public virtual void SkillAction(MonsterScript ThisMonster, MonsterScript TargetMonster)
    {

    }

    // this function is what will happen when this skill is an AOE. this will effect all of the monsters that is put into the list and will use the skill on each of them
    //Parameters : 
    // the first monster is for the monster that is using the skill
    // the second is a list of monsters that will have the effect of the skill used against them
    public virtual void SkillActionAOE(MonsterScript ThisMonster, List<MonsterScript> TargetMonsters)
    {

    }


    // this function will allow the skill to apply effects on the monster and the allies in battle if this skill is a specific type
    public virtual void ApplyLeaderSkill(MonsterScript ThisMonster)
    {

    }

    // this returns a bool that shows wether the skills is on cooldown or not
    public bool SkillOnCoolDown()
    {
        return OnCoolDown;
    }


    // this function returns the amount of turns left on this skills cooldown
    public int AmountOfTurnsLeft()
    {
        return CoolDownTurns;
    }

    public void SetCoolDownTurns(int turns)
    {
        CoolDownTurns = turns;
    }

    public bool ReturnAOEBool()
    {
        return ISAOE;
    }
}
