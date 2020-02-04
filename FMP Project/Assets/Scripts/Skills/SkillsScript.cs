using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillsscript : MonoBehaviour
{
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

    [Tooltip("this bool is to determine wether this skill is a skill that will deal damage")]
    [SerializeField]
    private bool DamageSkill = false;

    [Tooltip("this bool is to determine wether this skill is a skill that will heal")]
    [SerializeField]
    private bool HealSkill = false;

    [Tooltip("this bool is to determine wether this skill is a skill that will apply effects")]
    [SerializeField]
    private bool EffectSkill = false;

    [Tooltip("this bool is to determine wether this skill is a leader skill that will affect everyone in battle")]
    [SerializeField]
    private bool LeaderSkill = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function is what applys the skill. each skill will be differnt this is the base class for the skills what will allow for each script to hold a differnt skill
    public void SkillAction(MonsterScript ThisMonster, MonsterScript TargetMonster)
    {

    }

    // this function will allow the skill to apply effects on the monster and the allies in battle if this skill is a specific type
    public void ApplyLeaderSkill(MonsterScript ThisMonster)
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
}
