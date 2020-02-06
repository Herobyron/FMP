using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// the basic skill class is a child of the skill class. this will be used for the monsters first skill
// this skill is a single target skill that damages the target enemy
public class BasicSkill : Skillsscript 
{


    private void Start()
    {
        
    }

    //this function will deal damage with the monster basic attack to the targeted enemy

    public override void SkillAction(MonsterScript ThisMonster, MonsterScript TargetMonster)
    {
        TargetMonster.ApplyDamage(ThisMonster.ReturnBaseDamage(), ThisMonster.ReturnBeneficialEffects(), ThisMonster.ReturnHarmfulEffects());
    }
}
