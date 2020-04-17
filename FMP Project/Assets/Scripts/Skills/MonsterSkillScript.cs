using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterSkillScript
{

    // this is the Skill Number. this is to do with what number skill it is (1, 2, 3)
    private int SKillNumber = 1;

    // this is the multiplier for the main effect of the skill
    private float MainEffectMultiplier = 0.0f;

    // this is the multiplier for the secondary effect of the skill
    private float SecondaryEffectMultipleir = 0.0f;

    // this is the list of effects the skill can apply if this skill is a benefical or harmful effect skill
    private List<string> SkillEffects = new List<string>();

    // this is the bool to determine wether this skill is an AOE skill or not
    private bool AOESKill = false;

    // this is the main effect of the skill (healing, damage, harmful/benefical effect)
    private string MainEffect = "";

    // this is the secondary effect of the skill (healing, damage, harmful/benefical effect)
    private string SecondaryEffect = "";

    // this is the max cooldown of the skill when it has just been used within battle
    private int MaxCoolDown = 0;

    // this is the current cooldown of the skill in battle
    private int CurrentCoolDown = 0;

    

   // this function allows for the execution of the skill. using all of the information of the skill it will determine what to execute and how long to put the skill on cooldown
   // Params:
   // Targets - is a list of monsters that this skill can target. if this skill is not an AOE the list will only have one monster included within it
   // UsingMonster - this is the monster that is using the skill. this will allow for information like damage and defence to be used
   public int UseSkill(List<MonsterScript> Targets, MonsterScript UsingMonster)
   {
        //this is a return number for the amount of damage/healing done
        int TempDamageReturn = 0;

        if(CurrentCoolDown == 0)
        {
            switch (MainEffect)
            {
                case ("Healing"):
                    {
                        float TempHealAmount = Mathf.Round((UsingMonster.ReturnBaseHealth() * MainEffectMultiplier) + UsingMonster.ReturnBaseHealth());

                        foreach(MonsterScript M in Targets)
                        {
                            TempDamageReturn = (int)M.ApplyHeal(TempHealAmount);

                        }

                        break;
                    }
                case ("Damage"):
                    {
                        float TempDamageAmount = Mathf.Round((UsingMonster.ReturnBaseDamage() * MainEffectMultiplier) + UsingMonster.ReturnBaseDamage());

                        foreach(MonsterScript M in Targets)
                        {
                           TempDamageReturn =  (int)M.ApplyDamage(TempDamageAmount, UsingMonster.ReturnBeneficialEffects(), UsingMonster.ReturnHarmfulEffects());
                        }

                        break;
                    }
                case ("BeneficialEffect"):
                    {
                        foreach(MonsterScript M in Targets)
                        {

                            foreach(string S in SkillEffects)
                            { 

                                switch (S)
                                {
                                    case ("Accuracy"):
                                        {
                                            BeneficialEffects AccuracyEffect = new BeneficialEffects();
                                            AccuracyEffect.SetBeneficialEffects("Accuracy");
                                            AccuracyEffect.SetTurns(2);

                                            M.AddBeneficialEffect(AccuracyEffect);

                                            break;
                                        }
                                    case ("Attack"):
                                        {
                                            BeneficialEffects AttackEffect = new BeneficialEffects();
                                            AttackEffect.SetBeneficialEffects("Attack");
                                            AttackEffect.SetTurns(2);

                                            M.AddBeneficialEffect(AttackEffect);

                                            break;
                                        }
                                    case ("CritRate"):
                                        {
                                            BeneficialEffects CritRateEffect = new BeneficialEffects();
                                            CritRateEffect.SetBeneficialEffects("CritRate");
                                            CritRateEffect.SetTurns(2);

                                            M.AddBeneficialEffect(CritRateEffect);

                                            break;
                                        }
                                    case ("Defence"):
                                        {
                                            BeneficialEffects DefenceEffect = new BeneficialEffects();
                                            DefenceEffect.SetBeneficialEffects("Defence");
                                            DefenceEffect.SetTurns(2);

                                            M.AddBeneficialEffect(DefenceEffect);

                                            break;
                                        }
                                    case ("Immunity"):
                                        {
                                            BeneficialEffects ImmunityEffect = new BeneficialEffects();
                                            ImmunityEffect.SetBeneficialEffects("Immunity");
                                            ImmunityEffect.SetTurns(2);

                                            M.AddBeneficialEffect(ImmunityEffect);

                                            break;
                                        }
                                    case ("Shield"):
                                        {
                                            BeneficialEffects ShieldEffect = new BeneficialEffects();
                                            ShieldEffect.SetBeneficialEffects("Shield");
                                            ShieldEffect.SetTurns(2);

                                            M.AddBeneficialEffect(ShieldEffect);

                                            break;
                                        }
                                }

                            }

                            
                        }

                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        foreach (MonsterScript M in Targets)
                        {
                            
                            foreach(string S in SkillEffects)
                            { 
                                switch (S)
                                {
                                    case ("AttackDeBuff"):
                                        {
                                            HarmfulEffects AttackDeBuffEffect = new HarmfulEffects();
                                            AttackDeBuffEffect.SetHarmfulEffect("Attack");
                                            AttackDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(AttackDeBuffEffect);

                                            break;
                                        }
                                    case ("CritDeBuff"):
                                        {
                                            HarmfulEffects CritDeBuffEffect = new HarmfulEffects();
                                            CritDeBuffEffect.SetHarmfulEffect("CritRate");
                                            CritDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(CritDeBuffEffect);

                                            break;
                                        }
                                    case ("DefenceDeBuff"):
                                        {
                                            HarmfulEffects DefenceDeBuffEffect = new HarmfulEffects();
                                            DefenceDeBuffEffect.SetHarmfulEffect("Defence");
                                            DefenceDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(DefenceDeBuffEffect);

                                            break;
                                        }
                                    case ("ImmunityDeBuff"):
                                        {
                                            HarmfulEffects ImmunityDeBuffEffect = new HarmfulEffects();
                                            ImmunityDeBuffEffect.SetHarmfulEffect("Immunity");
                                            ImmunityDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(ImmunityDeBuffEffect);

                                            break;
                                        }
                                    case ("MissDeBuff"):
                                        {
                                            HarmfulEffects MissDeBuffEffect = new HarmfulEffects();
                                            MissDeBuffEffect.SetHarmfulEffect("Miss");
                                            MissDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(MissDeBuffEffect);

                                            break;
                                        }
                                    case ("ShieldDeBuff"):
                                        {
                                            HarmfulEffects ShieldDeBuffEffect = new HarmfulEffects();
                                            ShieldDeBuffEffect.SetHarmfulEffect("Shield");
                                            ShieldDeBuffEffect.SetTurns(2);


                                            M.AddHarmfulEffects(ShieldDeBuffEffect);

                                            break;
                                        }
                                }

                            }
                        }
                        break;
                    }
            }


            switch (SecondaryEffect)
            {
                case ("Damage"):
                    {
                        float TempDamageAmount = Mathf.Round((UsingMonster.ReturnBaseDamage() * SecondaryEffectMultipleir) + UsingMonster.ReturnBaseDamage());

                        foreach (MonsterScript M in Targets)
                        {
                           TempDamageReturn += (int)M.ApplyDamage(TempDamageAmount, UsingMonster.ReturnBeneficialEffects(), UsingMonster.ReturnHarmfulEffects());
                        }

                        break;
                    }
                case ("Healing"):
                    {
                        if(MainEffect == "HarmfulEffect" || MainEffect == "Damage")
                        {
                            float TempHealAmount = Mathf.Round((UsingMonster.ReturnBaseHealth() * SecondaryEffectMultipleir) + UsingMonster.ReturnBaseHealth());

                            UsingMonster.ApplyHeal(TempHealAmount);
                        }
                        else
                        {
                            float TempHealAmount = Mathf.Round((UsingMonster.ReturnBaseHealth() * SecondaryEffectMultipleir) + UsingMonster.ReturnBaseHealth());

                            foreach (MonsterScript M in Targets)
                            {
                               TempDamageReturn += (int)M.ApplyHeal(TempHealAmount);

                            }
                        }

                        break;
                    }
                case ("HarmfulEffect"):
                    {

                        foreach (MonsterScript M in Targets)
                        {
                            foreach (string S in SkillEffects)
                            {
                                switch (S)
                                {
                                    case ("AttackDeBuff"):
                                        {
                                            HarmfulEffects AttackDeBuffEffect = new HarmfulEffects();
                                            AttackDeBuffEffect.SetHarmfulEffect("Attack");
                                            AttackDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(AttackDeBuffEffect);

                                            break;
                                        }
                                    case ("CritDeBuff"):
                                        {
                                            HarmfulEffects CritDeBuffEffect = new HarmfulEffects();
                                            CritDeBuffEffect.SetHarmfulEffect("CritRate");
                                            CritDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(CritDeBuffEffect);

                                            break;
                                        }
                                    case ("DefenceDeBuff"):
                                        {
                                            HarmfulEffects DefenceDeBuffEffect = new HarmfulEffects();
                                            DefenceDeBuffEffect.SetHarmfulEffect("Defence");
                                            DefenceDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(DefenceDeBuffEffect);

                                            break;
                                        }
                                    case ("ImmunityDeBuff"):
                                        {
                                            HarmfulEffects ImmunityDeBuffEffect = new HarmfulEffects();
                                            ImmunityDeBuffEffect.SetHarmfulEffect("Immunity");
                                            ImmunityDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(ImmunityDeBuffEffect);

                                            break;
                                        }
                                    case ("MissDeBuff"):
                                        {
                                            HarmfulEffects MissDeBuffEffect = new HarmfulEffects();
                                            MissDeBuffEffect.SetHarmfulEffect("Miss");
                                            MissDeBuffEffect.SetTurns(2);

                                            M.AddHarmfulEffects(MissDeBuffEffect);

                                            break;
                                        }
                                    case ("ShieldDeBuff"):
                                        {
                                            HarmfulEffects ShieldDeBuffEffect = new HarmfulEffects();
                                            ShieldDeBuffEffect.SetHarmfulEffect("Shield");
                                            ShieldDeBuffEffect.SetTurns(2);


                                            M.AddHarmfulEffects(ShieldDeBuffEffect);

                                            break;
                                        }
                                }

                            }
                        }

                        break;
                    }
                case ("BeneficialEffect"):
                    {
                        if(MainEffect == "Damage")
                        {
                            foreach (string S in SkillEffects)
                            {
                                switch (S)
                                {
                                    case ("Accuracy"):
                                        {
                                            BeneficialEffects AccuracyEffect = new BeneficialEffects();
                                            AccuracyEffect.SetBeneficialEffects("Accuracy");
                                            AccuracyEffect.SetTurns(2);

                                            UsingMonster.AddBeneficialEffect(AccuracyEffect);

                                            break;
                                        }
                                    case ("Attack"):
                                        {
                                            BeneficialEffects AttackEffect = new BeneficialEffects();
                                            AttackEffect.SetBeneficialEffects("Attack");
                                            AttackEffect.SetTurns(2);

                                            UsingMonster.AddBeneficialEffect(AttackEffect);

                                            break;
                                        }
                                    case ("CritRate"):
                                        {
                                            BeneficialEffects CritRateEffect = new BeneficialEffects();
                                            CritRateEffect.SetBeneficialEffects("CritRate");
                                            CritRateEffect.SetTurns(2);

                                            UsingMonster.AddBeneficialEffect(CritRateEffect);

                                            break;
                                        }
                                    case ("Defence"):
                                        {
                                            BeneficialEffects DefenceEffect = new BeneficialEffects();
                                            DefenceEffect.SetBeneficialEffects("Defence");
                                            DefenceEffect.SetTurns(2);

                                            UsingMonster.AddBeneficialEffect(DefenceEffect);

                                            break;
                                        }
                                    case ("Immunity"):
                                        {
                                            BeneficialEffects ImmunityEffect = new BeneficialEffects();
                                            ImmunityEffect.SetBeneficialEffects("Immunity");
                                            ImmunityEffect.SetTurns(2);

                                            UsingMonster.AddBeneficialEffect(ImmunityEffect);

                                            break;
                                        }
                                    case ("Shield"):
                                        {
                                            BeneficialEffects ShieldEffect = new BeneficialEffects();
                                            ShieldEffect.SetBeneficialEffects("Shield");
                                            ShieldEffect.SetTurns(2);

                                            UsingMonster.AddBeneficialEffect(ShieldEffect);

                                            break;
                                        }
                                }

                            }
                        }
                        else
                        {
                            foreach (MonsterScript M in Targets)
                            {
                                foreach (string S in SkillEffects)
                                {
                                    switch (S)
                                    {
                                        case ("Accuracy"):
                                            {
                                                BeneficialEffects AccuracyEffect = new BeneficialEffects();
                                                AccuracyEffect.SetBeneficialEffects("Accuracy");
                                                AccuracyEffect.SetTurns(2);

                                                M.AddBeneficialEffect(AccuracyEffect);

                                                break;
                                            }
                                        case ("Attack"):
                                            {
                                                BeneficialEffects AttackEffect = new BeneficialEffects();
                                                AttackEffect.SetBeneficialEffects("Attack");
                                                AttackEffect.SetTurns(2);

                                                M.AddBeneficialEffect(AttackEffect);

                                                break;
                                            }
                                        case ("CritRate"):
                                            {
                                                BeneficialEffects CritRateEffect = new BeneficialEffects();
                                                CritRateEffect.SetBeneficialEffects("CritRate");
                                                CritRateEffect.SetTurns(2);

                                                M.AddBeneficialEffect(CritRateEffect);

                                                break;
                                            }
                                        case ("Defence"):
                                            {
                                                BeneficialEffects DefenceEffect = new BeneficialEffects();
                                                DefenceEffect.SetBeneficialEffects("Defence");
                                                DefenceEffect.SetTurns(2);

                                                M.AddBeneficialEffect(DefenceEffect);

                                                break;
                                            }
                                        case ("Immunity"):
                                            {
                                                BeneficialEffects ImmunityEffect = new BeneficialEffects();
                                                ImmunityEffect.SetBeneficialEffects("Immunity");
                                                ImmunityEffect.SetTurns(2);

                                                M.AddBeneficialEffect(ImmunityEffect);

                                                break;
                                            }
                                        case ("Shield"):
                                            {
                                                BeneficialEffects ShieldEffect = new BeneficialEffects();
                                                ShieldEffect.SetBeneficialEffects("Shield");
                                                ShieldEffect.SetTurns(2);

                                                M.AddBeneficialEffect(ShieldEffect);

                                                break;
                                            }
                                    }

                                }


                            }
                        }

                        break;
                    }

            }

        }

        CurrentCoolDown = MaxCoolDown;
        return TempDamageReturn;
   }




    // these are the getters and setters for the information on the skill and what the skill does

    //this function sets the skill number
    public void SetSkillNumber(int SkillNum) { SKillNumber = SkillNum; }

    // this function sets the Skill main effect multiplier
    public void SetSkillMainEffectMultiplier(float SkillMult) { MainEffectMultiplier = SkillMult; }

    //this function sets the Skill secondary effect multiplier
    public void SetSkillSecondaryEffectMultiplier(float SkillMult) { SecondaryEffectMultipleir = SkillMult; }

    // this function sets the skill effects that the skill can apply
    public void SetSkillEffects(List<string> Effects)
    {
        SkillEffects = Effects;
    }

    // this function sets the skill AOE effect
    public void SetSkillAOE(bool AOE) { AOESKill = AOE; }

    // this function sets the skill main effect
    public void SetSkillMainEffect(string Effect) { MainEffect = Effect; }

    // this function sets the skill secondary effect
    public void SetSkillSecondaryeffect(string Effect) { SecondaryEffect = Effect; }

    // this function sets the skills max cooldown
    public void SetSkillMaxCoolDown(int Cooldown) { MaxCoolDown = Cooldown; }

    // this function sets the skills current cooldown
    public void SetSkillCurrentCooldown(int cooldown) { CurrentCoolDown = cooldown; }

    // this function will get the skills number
    public int GetSkillNumber() { return SKillNumber; }

    // this function will get the skills main effect multiplier
    public float GetSkillMainMultiplier() { return MainEffectMultiplier; }

    // this function will get the skills secondary effect multiplier
    public float GetSkillSecondaryMultiplier() { return SecondaryEffectMultipleir; }

    // this function will get the skilles effects that it can apply
    public List<string> GetSkillEffects() { return SkillEffects; }

    // this function will return wether the skill is an AOE or not
    public bool ReturnSkillAOE() { return AOESKill; }

    // this function will get the skills main effect
    public string GetSkillMainEffect() { return MainEffect; }

    // this function will get the skills secondary effect
    public string GetSkillSecondaryEffect() { return SecondaryEffect; }

    // this function will get the skills max cooldown
    public int GetSkillsMaxCooldown() { return MaxCoolDown; }

    // this function will get the skills current cooldown
    public int GetSkillCurrentCooldown() { return CurrentCoolDown; }


}
