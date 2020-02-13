using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SkillObject/HealSkill")]
public class HealingSkill : SkillObject
{
    [Tooltip("this is the amount that this skill will heal by before the healing multiplier of the skill is taken into affect")]
    [SerializeField]
    private int HealAmount = 0;

    [Tooltip("this is the multiplier that will affect the amount of healing that will be applied when it is used in the skill. this can be changed when a skill is upgraded")]
    [SerializeField]
    private float HealMultiplier = 0.0f;

    // this function is the skill that heals the target monster by the certain amount that is put in
    // this is a overide function that takes it base component from the parent class
    // parameters : 
    // the first parameter is the mosnster that will be using the skill 
    // the second parameter is the target monster that is going to be healed
    public override void SkillAction(MonsterScript ThisMonster, MonsterScript TargetMonster)
    {
        float TempHeal = HealAmount + (HealAmount * HealMultiplier);
        TargetMonster.ApplyHeal(TempHeal);
    }

    // this function is the skill that heals all of the target monsters by a certain amount that is put in
    // this is a overide function that takes it base component from the parent class 
    // parameters : 
    // the first parameter is the monster that will be using the skill
    // the second parameter is the all of the target monsters that are going to be healed
    public override void SkillActionAOE(MonsterScript ThisMonster, List<MonsterScript> TargetMonsters)
    {
        float TempHeal = HealAmount + (HealAmount * HealMultiplier);

        foreach(MonsterScript M in TargetMonsters)
        {
            M.ApplyHeal(TempHeal);
        }
    }
}
