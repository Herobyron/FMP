using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SkillObject/EffectSkill")]
public class EffectSkill : SkillObject
{
    [Tooltip("The List of beneficial Effects that can be applied to the target monster when this skill is used")]
    [SerializeField]
    private List<BeneficialEffects> BeneficialEffectsToBeApplied = null;

    [Tooltip("The List of harmful effects that can be applied to the target monster when this skill is used ")]
    [SerializeField]
    private List<HarmfulEffects> HarmfulEffectsToBeApplied = null;

    // this is the type of skill that this is. this determines wether the Harmful effects or Beneficial effects are used
    private enum EffectType {HarmfulEffect, BeneficialEffect };

    [Tooltip("this is the effect type that this skill is. this effects what types of effects this skill can use")]
    [SerializeField]
    private EffectType SkillEffect = EffectType.BeneficialEffect;


    // this function is an overide of the parent class function that will have all of the base components of the parent function
    // this function will apply the effects of the skills to the target.
    // parameters : 
    // the first parameter is the monster that will be using this skill
    // the second parameter is the monster that will be having the effects applied to them
    public override void SkillAction(MonsterScript ThisMonster, MonsterScript TargetMonster)
    {
        switch (SkillEffect)
        {
            case (EffectType.BeneficialEffect):
            {
                    foreach(BeneficialEffects B in BeneficialEffectsToBeApplied)
                    {
                        
                        TargetMonster.AddBeneficialEffect(B);
                    }
                    break;
            }
            case (EffectType.HarmfulEffect):
            {
                foreach(HarmfulEffects H in HarmfulEffectsToBeApplied)
                {
                    TargetMonster.AddHarmfulEffects(H);
                }
                break;
            }
        }
    }

    // this function is an overide of the parent class function that will have all of the base components of the parent function
    // this function will apply all of the specified effects of the skil to all of the target monsters
    // parameters : 
    // the first parameter is the monster that will be using this skill
    // the second parameter is the list of monsters that will be having the effects applied to all of them
    public override void SkillActionAOE(MonsterScript ThisMonster, List<MonsterScript> TargetMonsters)
    {
        foreach(MonsterScript M in TargetMonsters)
        {
            switch (SkillEffect)
            {
                case (EffectType.BeneficialEffect):
                    {
                        foreach (BeneficialEffects B in BeneficialEffectsToBeApplied)
                        {
                            M.AddBeneficialEffect(B);
                        }
                        break;
                    }
                case (EffectType.HarmfulEffect):
                    {
                        foreach (HarmfulEffects H in HarmfulEffectsToBeApplied)
                        {
                            M.AddHarmfulEffects(H);
                        }
                        break;
                    }
            }
        }
    }

}
