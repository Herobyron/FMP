using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SkillObject/DamageSkill")]
public class DamageSkill : SkillObject
{
    [Tooltip("This is the amount of damage that this skill will do (before damage multiplier )")]
    [SerializeField]
    private int SkillDamage = 0;

    [Tooltip("This is the multiplier of the damage which can change depending on the skills upgrades")]
    [SerializeField]
    private float SkillMultiplier = 0.0f;

    // this is an overide of the base function in the parent script
    // this function is what applys the skill. since this is a damage skill it will apply damage to the target monster
    // the parameters : 
    // the first parameter is the monster that will be using the skill
    // the second parameter is the monster that will have the damage applied to them
    public override void SkillAction(MonsterScript ThisMonster, MonsterScript TargetMonster)
    {
    
        float TempDamage = SkillDamage + (SkillDamage * SkillMultiplier);
        TempDamage += ThisMonster.ReturnBaseDamage();

        TargetMonster.ApplyDamage(TempDamage, ThisMonster.ReturnBeneficialEffects(), ThisMonster.ReturnHarmfulEffects());

    }

    // this is an overide of the base function in the parent script
    // this function is what applys damage to all of the monsters that are bieng targeted. since this is a damage skill it will damage all of the monsters affected by the AOE
    // the parameters : 
    // the first parameter is the monster that will be using the skill
    // the second paramerer is all of the monsters that are bieng targeted by the AOE
    public override void SkillActionAOE(MonsterScript ThisMonster, List<MonsterScript> TargetMonsters)
    {
        float TempDamage = SkillDamage + (SkillDamage * SkillMultiplier);
        TempDamage += ThisMonster.ReturnBaseDamage();

        foreach(MonsterScript M in TargetMonsters)
        {
            M.ApplyDamage(TempDamage, ThisMonster.ReturnBeneficialEffects(), ThisMonster.ReturnHarmfulEffects());
        }
    }
}
