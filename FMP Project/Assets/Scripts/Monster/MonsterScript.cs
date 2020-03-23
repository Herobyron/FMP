using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// everything that is not accesible in the inspector will have comments above
// everything that is accessible within the inspect will have a tool tip to act like a comment both in code and in inspector

[System.Serializable]
public class MonsterScript 
{
    // this is the monsters data. this will store all of the important information on the monster so it can be stored and saved
    [SerializeField]
    private MonsterData ThisData = new MonsterData();

    [Tooltip("this is the monsters name. used to identify the monsters as well as to help with sorting and data management")]
    [SerializeField]
    private string MonsterName = "Blank";

    // this is the monsters base health (the monsters health stat)
    [Tooltip("This is the base health of the monster that it will start out with")]
    [SerializeField]
    private float BaseHealth = 0.0f;

    [Tooltip("this is the base damage that the monster will have (monsters attack stat)")]
    [SerializeField]
    private float BaseDamage = 0.0f;

    [Tooltip("this is the base Defence that the monster will have (the monsters Defence stat)")]
    [SerializeField]
    private float BaseDefence = 0.0f;

    [Tooltip("this is the base Speed that the monster will have (the monsters Speed stat)")]
    [SerializeField]
    private float BaseSpeed = 0.0f;

    [Tooltip("this is the monster base Crit Rate (MonstersBase Crit Rate stat)")]
    [SerializeField]
    private float BaseCritRate = 0.0f;

    [Tooltip("this is the base Crit Damage that the monster will have (monsters crit damage stat)")]
    [SerializeField]
    private float BaseCritDamage = 0.0f;

    [Tooltip("this is the Accuracy of the monster when it comes to applying debuffs (monsters Accuracy stat)")]
    [SerializeField]
    private float BaseAccuracy = 0.0f;

    [Tooltip("this is the base resistance that the monster will have (the monsters resistance stat)")]
    [SerializeField]
    private float BaseResistance = 0.0f;

    [Tooltip("This is the monsters current health during the game (the monsters current health)")]
    [SerializeField]
    private float CurrentHealth = 0.0f;

    [Tooltip("this is the current stars of the monster (how many stars does the monster have)")]
    [SerializeField]
    private int Stars = 0;

    [Tooltip("this is the increased Health of the runes stats added to the monster")]
    [SerializeField]
    private float IncreasedHealth = 0.0f;

    [Tooltip("this is the increased Defence of the runes stats added to the monster")]
    [SerializeField]
    private float IncreasedDefence = 0.0f;

    [Tooltip("this is the increased Damage of the runes stats added to the monster")]
    [SerializeField]
    private float IncreasedAttack = 0.0f;

    [Tooltip("this is the increased Speed of the runes stats added to the monster")]
    [SerializeField]
    private float IncreasedSpeed = 0.0f;

    [Tooltip("This is the increased Accuracy of the runes stats added to the monster")]
    [SerializeField]
    private float IncreasedAccuracy = 0.0f;

    [Tooltip("this is the increased Resisatnce of the runes stats added to the monster")]
    [SerializeField]
    private float IncreasedResistance = 0.0f;

    [Tooltip("this is the increased crit rate of the runes stats added to the monster")]
    [SerializeField]
    private float IncreasedCritRate = 0.0f;

    [Tooltip("this is the increased crit damage of the runes stats added to the monster ")]
    [SerializeField]
    private float IncreasedCritDamage = 0.0f;

    // this is an enum that holds all of the types that a monster can be
    private enum MonsterType {Defence, Attack, Health };

    [Tooltip("this is the monsters type that has been selected frrm the enum (what type do you want this monster to be)")]
    [SerializeField]
    private MonsterType Type = MonsterType.Attack;

    [Tooltip("this is the monsters type but displayed as a string for use of information transfer")]
    [SerializeField]
    private string TheMonsterType = "";

    [Tooltip("the level that you want the monster to be")]
    [SerializeField]
    private int MonsterLevel = 0;

    [Tooltip("The Current Max level of the monster")]
    [SerializeField]
    private int MonsterMaxLevel = 15;


    [Tooltip("this is a bool that determines wether the monster has been awakened yet")]
    [SerializeField]
    private bool Awakened = false;

    [Tooltip("this is the multiplier that is applied to the monsters stats. (this will be multiplied with the level and then with the stats to increase the base stats")]
    [SerializeField]
    private float LevelMultiplier = 0.01f;

    [Tooltip("this is the multiplier applied to the monsters stats depending on wether the monster is awakened (this will be multiplied with the stats and then added on to the base to increase the base)")]
    [SerializeField]
    private float AwakenMultiplier = 0.5f;

    [Tooltip("this is the multipleir applied to the monsters stats depending on how many stars that the monster has (this will be multiplied with the stats and then added on to the base to increase the base)")]
    [SerializeField]
    private float StarsMultiplier = 0.3f;

    [Tooltip("this is the base stars that the monster will have ")]
    [SerializeField]
    private int BaseStars = 1;

    // Type enum seen in design (monster type is already included not sure wether is still needed)


    // these are the runes that the monster can have equiped
    // this will need testing to see wether it needs to be a gameobject or not

    [Tooltip("This is the First rune that the monster can equip")]
    [SerializeField]
    private RuneScript RuneOne = null;

    [Tooltip("This is the second rune that the monster can equip")]
    [SerializeField]
    private RuneScript RuneTwo = null;

    [Tooltip("this is the third rune that the monster can equip")]
    [SerializeField]
    private RuneScript RuneThree = null;

    [Tooltip("this is the fourth rune that the monster can equip")]
    [SerializeField]
    private RuneScript RuneFour = null;

    [Tooltip("this is the fifth rune that the monster can equip")]
    [SerializeField]
    private RuneScript RuneFive = null;

    [Tooltip("this is the sixth rune that the monster can equip")]
    [SerializeField]
    private RuneScript RuneSix = null;

    //this is a list of all of the runes that are equiped on to this monster (i may change this to serilised so that in stead of equiping each rune seperalty it just stores in this list)
    //this list is for storing the runes so that it can be used in a function later on
    private List<RuneScript> Runes = new List<RuneScript>();

    // these are the Skills that the monster can have and the skills information
    // this will need testing to see wether it needs to be a gameobject or not

    [Tooltip("this is the main effect that the monsters first skill will do (this will be used to create the monsters skill")]
    [SerializeField]
    private string SkillOneMainEffect = "";

    [Tooltip("this is the secondary effect that the monsters first skill will do (this can do nothing or could do something")]
    [SerializeField]
    private string SkillOneSecondaryEffect = "";

    [Tooltip("A bool to determine wether the first skill is an AOE skill")]
    private bool SkillOneAOE = false;

    [Tooltip("how important it is for when the Ai is controlling the monster to use the first skill (the higher the number the more important the skill is)")]
    [SerializeField]
    private int SkillOneImportance = 0;

    [Tooltip("this is a list of the effects the first skill can apply if it has an effect type skill")]
    [SerializeField]
    private List<string> SkillOneEffects = new List<string>();

    [Tooltip("this is the multiplier that affects the skills ")]
    private float SkillOneMultiplier = 0.0f;

    [Tooltip("this is the multiplier for the first skills secondary effect")]
    private float SkillOneSecondaryEffectMultiplier = 0.0f;

    //this will be wehere the skill script should go when the skill script has been adapted

    [Tooltip("this is the main effect that the monsters first skill will do (this will be used to create the monsters skill")]
    [SerializeField]
    private string SkillTwoMainEffect = "";

    [Tooltip("this is the secondary effect that the monsters first skill will do (this can do nothing or could do something")]
    [SerializeField]
    private string SkillTwoSecondaryEffect = "";

    [Tooltip("A bool to determine wether the first skill is an AOE skill")]
    private bool SkillTwoAOE = false;

    [Tooltip("how important it is for when the Ai is controlling the monster to use the first skill (the higher the number the more important the skill is)")]
    [SerializeField]
    private int SkillTwoImportance = 0;

    [Tooltip("this is a list of the effects the first skill can apply if it has an effect type skill")]
    [SerializeField]
    private List<string> SkillTwoEffects = new List<string>();

    [Tooltip("this is the multiplier that affects the skills ")]
    private float SkillTwoMultiplier = 0.0f;

    [Tooltip("this is the multiplier for the Second skills secondary effect")]
    private float SkillTwoSecondaryEffectMultiplier = 0.0f;

    [Tooltip("the skill cooldown for the second skill the monster has")]
    [SerializeField]
    private int SkillTwoCoolDown = 0;

    //this will be where the skill script should go when the skill script is adapted 

    [Tooltip("this is the main effect that the monsters first skill will do (this will be used to create the monsters skill")]
    [SerializeField]
    private string SkillThreeMainEffect = "";

    [Tooltip("this is the secondary effect that the monsters first skill will do (this can do nothing or could do something")]
    [SerializeField]
    private string SkillThreeSecondaryEffect = "";

    [Tooltip("A bool to determine wether the first skill is an AOE skill")]
    private bool SkillThreeAOE = false;

    [Tooltip("how important it is for when the Ai is controlling the monster to use the first skill (the higher the number the more important the skill is)")]
    [SerializeField]
    private int SkillThreeImportance = 0;

    [Tooltip("this is a list of the effects the first skill can apply if it has an effect type skill")]
    [SerializeField]
    private List<string> SkillThreeEffects = new List<string>();

    [Tooltip("this is the multiplier that affects the skills ")]
    private float SkillThreeMultiplier = 0.0f;

    [Tooltip("this is the multiplier for the Third skills secondary effect")]
    private float SkillThreeSecondaryEffectMultiplier = 0.0f;

    [Tooltip("the skill cooldown for the second skill the monster has")]
    [SerializeField]
    private int SkillThreeCoolDown = 0;


    [Tooltip("this is the list of harmful effects that can be applied on the monster")]
    public List<HarmfulEffects> EffectsHarmful = new List<HarmfulEffects>();

    [Tooltip("this is the list of Beneficial effects that can be applied on the monster")]
    public List<BeneficialEffects> EffectsBeneficial = new List<BeneficialEffects>();

    [Tooltip("a list of the names for all of the runes the monster has equiped")]
    [SerializeField]
    private List<string> RuneNames = new List<string>();

    [Tooltip("the Maximum amount of effects that the monster is able to hold")]
    [SerializeField]
    private int MaxEffects = 10;

    //[Tooltip("the leader skill that you want the monster to be able to use (this is a special skill that affects the stats of all monsters)")]
    //[SerializeField]
    //private Skillsscript LeaderSkill = null;

    [Tooltip("the string to determine who owns the monster wether it be the player or the AI")]
    [SerializeField]
    private string OwnerName = null;

    [Tooltip("a bool to determine if it is the monsters turn or not used for when the monster is battling")]
    [SerializeField]
    private bool CurrentTurn;

    [Tooltip("a bool to determine if the first runes have been applied to the monsters base stats")]
    [SerializeField]
    private bool RuneOneApplied = false;

    [Tooltip("a bool to determine if the second rune has been applied to the monsters base stats ")]
    [SerializeField]
    private bool RuneTwoApplied = false;

    [Tooltip("a bool to determine if the third rune has been applied to the monsters base stats")]
    [SerializeField]
    private bool RuneThreeApplied = false;

    [Tooltip("a bool to determine if the fourth rune has been applied to the monsters base stats")]
    [SerializeField]
    private bool RuneFourApplied = false;

    [Tooltip("a bool to determine if the fifth rune has been applied to the monsters base stats")]
    [SerializeField]
    private bool RuneFiveApplied = false;

    [Tooltip("a bool to determine if the sixth rune has been applied to the monsters base stats")]
    [SerializeField]
    private bool RuneSixApplied = false;

    [Tooltip("this is a bool to determine is no runes are currently equiped")]
    [SerializeField]
    private bool RunesEquiped = false;
 
    // this is the enum for what type of state the monster is in
    // idle means they are just standing there and will not be battling any time soon
    // Battle means the monster is in combat and will be attacking or taking damage
    private enum Monsterstate {Idle, Battle };

    [Tooltip("a enum to determine the monsters current state")]
    [SerializeField]
    private Monsterstate state = Monsterstate.Idle;

    //this function will upgrade the monsters level and will stop it from going further depending on what the stars of the monster is
    public void LevelUpMonster()
    {
        if (MonsterLevel != 40)
        {
            if(MonsterLevel < MonsterMaxLevel)
            {
                if(RuneOneApplied || RuneTwoApplied || RuneThreeApplied || RuneFourApplied || RuneFiveApplied || RuneSixApplied )
                {
                    MonsterLevel++;
                    LevelMultiplier += (MonsterLevel / 100);
                    BaseHealth += ((15 * Stars) + (100 * LevelMultiplier));
                    BaseDefence += ((15 * Stars) + (100 * LevelMultiplier));
                    BaseDamage += ((15 * Stars) + (100 * LevelMultiplier));
                }
                else
                {
                    MonsterLevel++;
                    LevelMultiplier += (MonsterLevel / 100);
                    BaseHealth += ((15 * Stars) + (100 * LevelMultiplier));
                    BaseDefence += ((15 * Stars) + (100 * LevelMultiplier));
                    BaseDamage += ((15 * Stars) + (100 * LevelMultiplier));

                    IncreasedAttack = 0;
                    IncreasedDefence = 0;
                    IncreasedHealth = 0;
                    IncreasedSpeed = 0;
                    IncreasedResistance = 0;
                    IncreasedAccuracy = 0;
                    IncreasedCritRate = 0;
                    IncreasedCritDamage = 0;

                    if(RuneOneApplied)
                    {
                        ApplyRuneEffects(1);
                    }
                    
                    if(RuneTwoApplied)
                    {
                        ApplyRuneEffects(2);
                    }

                    if (RuneThreeApplied)
                    {
                        ApplyRuneEffects(3);
                    }

                    if(RuneFourApplied)
                    {
                        ApplyRuneEffects(4);
                    }

                    if(RuneFiveApplied)
                    {
                        ApplyRuneEffects(5);
                    }

                    if(RuneSixApplied)
                    {
                        ApplyRuneEffects(6);
                    }
                }
                
            }

            

        }
    }

    // a function that would allow the player to increase the monsters stars
    public void IncreaseStars()
    {
        if(Stars <= 5)
        {
            if (MonsterLevel == MonsterMaxLevel)
            {
                Stars++;

                switch (Stars)
                {

                    case (2):
                        {
                            MonsterMaxLevel = 20;
                            LevelMultiplier = 0.05f;
                            break;
                        }
                    case (3):
                        {
                            MonsterMaxLevel = 25;
                            LevelMultiplier = 0.1f;
                            break;
                        }
                    case (4):
                        {
                            MonsterMaxLevel = 30;
                            LevelMultiplier = 0.15f;
                            break;
                        }
                    case (5):
                        {
                            MonsterMaxLevel = 35;
                            LevelMultiplier = 0.20f;
                            break;
                        }
                    case (6):
                        {
                            MonsterMaxLevel = 40;
                            LevelMultiplier = 0.25f;
                            break;
                        }
                }
            }
        }
    }

    // a function to allow for the monster to be awakened.
    public void Awaken()
    {
        if(!Awakened)
        {
            Awakened = true;
            switch(TheMonsterType)
            {
                case ("Attack"):
                    {
                        BaseDamage += 500;
                        BaseDefence += 250;
                        BaseHealth += 250;
                        BaseSpeed += 10;

                        SkillOneMultiplier += 0.1f;
                        SkillOneSecondaryEffectMultiplier += 0.1f;

                        SkillTwoMultiplier += 0.2f;
                        SkillTwoSecondaryEffectMultiplier += 0.2f;

                        SkillThreeMultiplier += 0.3f;
                        SkillThreeSecondaryEffectMultiplier += 0.3f;

                        break;
                    }
                case ("Health"):
                    {
                        BaseDamage += 250;
                        BaseDefence += 250;
                        BaseHealth += 500;
                        BaseSpeed += 15;

                        SkillOneMultiplier += 0.1f;
                        SkillOneSecondaryEffectMultiplier += 0.1f;

                        SkillTwoMultiplier += 0.2f;
                        SkillTwoSecondaryEffectMultiplier += 0.2f;

                        SkillThreeMultiplier += 0.3f;
                        SkillThreeSecondaryEffectMultiplier += 0.3f;

                        break;
                    }
                case ("Defence"):
                    {
                        BaseDamage += 250;
                        BaseDefence += 500;
                        BaseHealth += 250;
                        BaseSpeed += 5;

                        SkillOneMultiplier += 0.1f;
                        SkillOneSecondaryEffectMultiplier += 0.1f;

                        SkillTwoMultiplier += 0.2f;
                        SkillTwoSecondaryEffectMultiplier += 0.2f;

                        SkillThreeMultiplier += 0.3f;
                        SkillThreeSecondaryEffectMultiplier += 0.3f;

                        break;
                    }
            }

        }
    }

    // this function is to apply damage to this monster. 
    // apply damage will particularly be used when a monster attacks this one and that skill function will call apply damage when necisary
    //Variables :
    // - the float is the other monsters attack as this will be the main component for the math calculation
    // - the first list is the beneficail effects that are applied on the monster that is attacking this one
    // - the second list is the harmful effects that are apllied on the monster that is attacking this one
    public void ApplyDamage(float OtherMonsterAttack, List<BeneficialEffects> OtherMonsterBeneficialEffects, List<HarmfulEffects> OtherMonsterHarmfulEffects)
    {

        // this step of set all of the numbers and bools ready for the damage calculation step
        // all the attacking type buffs and defubs are calculated by enemy monster
        // all of the defence type buffs and debuffs are calculated by this monster

        bool MissAttack = false;
        bool CritBuff = false;
        float AttackDown = 0.0f;
        float AttackUp = 0.0f;
        float DefenceDown = 0.0f;
        float DefenceUp = 0.0f;

        if(OtherMonsterHarmfulEffects.Count > 0)
        {
            foreach(HarmfulEffects H in OtherMonsterHarmfulEffects)
            {
                if(H.ReturnDebuffType() == HarmfulEffects.Bufftype.MissDeBuff)
                {
                    MissAttack = true;
                }

                if(H.ReturnDebuffType() == HarmfulEffects.Bufftype.AttackDeBuff)
                {
                    AttackDown = 500;
                }

            }

        }

        if(OtherMonsterBeneficialEffects.Count > 0)
        {
            foreach(BeneficialEffects B in OtherMonsterBeneficialEffects)
            {
                if(B.ReturnBuffType() == BeneficialEffects.Bufftype.CritRateBuff)
                {
                    CritBuff = true;
                }

                if(B.ReturnBuffType() == BeneficialEffects.Bufftype.AttackBuff)
                {
                    AttackUp = 500;
                }
            }
        }

        if(EffectsBeneficial.Count > 0)
        {
            foreach(BeneficialEffects B in EffectsBeneficial)
            {
                if(B.ReturnBuffType() == BeneficialEffects.Bufftype.DefenceBuff)
                {
                    DefenceUp = 500;
                }
            }
        }

        if(EffectsHarmful.Count > 0)
        {
            foreach(HarmfulEffects H in EffectsHarmful)
            {
                if(H.ReturnDebuffType() == HarmfulEffects.Bufftype.DefenceDeBuff)
                {
                    DefenceDown = 500;
                }
            }
        }
   


        // this is the step for calculating the actual damage to be applied to the monster
        // need to check for miss and crit rate and then do the calculation of the damage after

        if(MissAttack)
        {
            // if the number is greater then 20 attack missed
           if(Random.Range(0, 100) >= 20)
           {
               float TempDamage = OtherMonsterAttack + AttackUp + DefenceDown - DefenceUp - AttackDown ;
               TempDamage *= 0.7f;
               CurrentHealth -= TempDamage;
           }
           else // else the attack has hit with the debuff and now check crit
           {
                if(CritBuff) // the crit rate buff gives and extra 30% chance to the crit rate
                {
                    if(Random.Range(0,100) >= (BaseCritRate + 30)) // if the random range is greater then the base crit rate + the extra chance then its regular damage
                    {
                        CurrentHealth -= OtherMonsterAttack + AttackUp + DefenceDown - DefenceUp - AttackDown;
                    }
                    else // else if the number isnt bigger then the attack landed as a crit
                    {
                        float TempDamage = OtherMonsterAttack + AttackUp + DefenceDown - DefenceUp - AttackDown;
                        TempDamage += TempDamage + (TempDamage * BaseCritDamage);
                        CurrentHealth -= TempDamage;
                    }
                }
           }
        }
        else //if there is no miss debuff then it goes strait to checking crit rate
        {
            if (CritBuff) // the crit rate buff gives and extra 30% chance to the crit rate
            {
                if (Random.Range(0, 100) >= (BaseCritRate + 30)) // if the random range is greater then the base crit rate + the extra chance then its regular damage
                {
                    CurrentHealth -= OtherMonsterAttack + AttackUp + DefenceDown - DefenceUp - AttackDown;
                }
                else // else if the number isnt bigger then the attack landed as a crit
                {
                    float TempDamage = OtherMonsterAttack + AttackUp + DefenceDown - DefenceUp - AttackDown;
                    TempDamage += TempDamage + (TempDamage * BaseCritDamage);
                    CurrentHealth -= TempDamage;
                }
            }
            else
            {
                if (Random.Range(0, 100) >= BaseCritRate) // if the random range is greater then the base crit rate + the extra chance then its regular damage
                {
                    CurrentHealth -= OtherMonsterAttack + AttackUp + DefenceDown - DefenceUp - AttackDown;
                }
                else // else if the number isnt bigger then the attack landed as a crit
                {
                    float TempDamage = OtherMonsterAttack + AttackUp + DefenceDown - DefenceUp - AttackDown;
                    TempDamage += TempDamage + (TempDamage * BaseCritDamage);
                    CurrentHealth -= TempDamage;
                }
            }
        }

    }

    //this is the function that will apply a heal to this monster
    // the skill that is using the heal will calculate how much health to heal and will 
    // Variables :
    // - the float is how much health will be given to this monster when they are healed
    public void ApplyHeal(float HealAmount)
    {
        // adds the heal amount to the health (heal amount is calculated in the monsters skill function not in apply heal
        // then if the current health is more then the max health then it sets the current health to the base health
        CurrentHealth += HealAmount;

        if(CurrentHealth > BaseHealth)
        {
            CurrentHealth = BaseHealth;
        }

    }

    // this function i want to change as i feel there is a better way of doing this so for now the function has been put on hold until a better way of doing it is found
    // a good thing to research
    // this is the function that will apply the rune effects and stats to the monster when one is equiped
    public void ApplyRuneEffects(int RuneNumber)
    {
        // this function checks to see what rune is appling the affect (depending on the rune number varaible given
        // then checks to see if this rune has already been applied (if it has then it wont apply the effect again)
        // then it checks the rune exists and if it does it increases the stat of the monster by the stats on the rune and then repeat

        if (RuneNumber == 1) 
        {
            if (!RuneOneApplied) 
            {
                if (RuneOne != null)  
                {
                    RuneStatIncrease(RuneOne); 
                }
            }
        }
        else if(RuneNumber == 2) 
        {
            if(!RuneTwoApplied) 
            {
                if(RuneTwo != null) 
                {
                    RuneStatIncrease(RuneTwo);
                }
            }
        }
        else if(RuneNumber == 3)
        {
            if(!RuneThreeApplied) 
            {
                if(RuneThree != null) 
                {
                    RuneStatIncrease(RuneThree);
                }
            }
        }
        else if(RuneNumber == 4)
        {
            if(!RuneFourApplied) 
            {
                if(RuneFour != null) 
                {
                    RuneStatIncrease(RuneFour);
                }
            }
        }
        else if(RuneNumber == 5)
        {
            if(!RuneFiveApplied) 
            {
                if(RuneFive != null)
                {
                    RuneStatIncrease(RuneFive);
                }
            }
        }
        else if(RuneNumber == 6)
        {
            if(!RuneSixApplied) 
            {
                if(RuneSix != null)
                {
                    RuneStatIncrease(RuneSix);
                }
            }
        }
        
    }

    // this function is used to apply the stats that are held on the rune to the monsters base stats
    // Parameters:
    // - the rune that will be checked for what stats it has and also apply it to the monster
    private void RuneStatIncrease(RuneScript TheRune)
    {
        // the function first checks to make sure that the rune has a stat on it (so if the rune stat two is zero then it dosent have two stats and shouldnt try to apply it)
        // then it will go through all of the stats and find which type of stats are on the rune
        // and then apply the stats to the correct base stat

        switch (TheRune.ReturnMainRuneStatType())
        {
            case ("Attack"):
                {
                    IncreasedAttack += TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Health"):
                {
                    IncreasedHealth += TheRune.ReturnMainRuneStat();
                    break;
                }
            case("Defence"):
                {
                    IncreasedDefence += TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Speed"):
                {
                    IncreasedSpeed += TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("CritRate"):
                {
                    IncreasedCritRate += TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("CritDamage"):
                {
                    IncreasedCritDamage += TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Accuracy"):
                {
                    IncreasedAccuracy += TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Resistance"):
                {
                    IncreasedResistance += TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("HealthPercentage"):
                {
                    IncreasedHealth += (BaseHealth * TheRune.ReturnMainRuneStat());
                    break;
                }
            case ("DefencePercentage"):
                {
                    IncreasedDefence += (BaseDefence * TheRune.ReturnMainRuneStat());
                    break;
                }
            case ("AttackPercentage"):
                {
                    IncreasedAttack += (BaseDamage * TheRune.ReturnMainRuneStat());
                    break;
                }
        }



        if (TheRune.ReturnRuneStatOne() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatOneType()) // gets the runes first stat
            {
                case ("Health"):
                    {
                        IncreasedHealth += TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Attack"):
                    {
                        IncreasedAttack += TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence += TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed +=  TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate += TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage += TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy += TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance += TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth += (BaseHealth * TheRune.ReturnRuneStatOne());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence += (BaseDefence * TheRune.ReturnRuneStatOne());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack += (BaseDamage * TheRune.ReturnRuneStatOne());
                        break;
                    }
            }
        }


        if (TheRune.ReturnRuneStatTwo() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatTwoType())
            {
                case ("Health"):
                    {
                        IncreasedHealth += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Damage"):
                    {
                        IncreasedAttack += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance += TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth += (BaseHealth * TheRune.ReturnRuneStatTwo());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence += (BaseDefence * TheRune.ReturnRuneStatTwo());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack += (BaseDamage * TheRune.ReturnRuneStatTwo());
                        break;
                    }
            }
        }


        if (TheRune.ReturnRuneStatThree() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatThreeType())
            {
                case ("Health"):
                    {
                        IncreasedHealth += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Damage"):
                    {
                        IncreasedAttack += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance += TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth += (BaseHealth * TheRune.ReturnRuneStatThree());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence += (BaseDefence * TheRune.ReturnRuneStatThree());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack += (BaseDamage * TheRune.ReturnRuneStatThree());
                        break;
                    }
            }
        }


        if (TheRune.ReturnRuneStatFour() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatFourType())
            {
                case ("Health"):
                    {
                        IncreasedHealth += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Damage"):
                    {
                        IncreasedAttack += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance += TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth += (BaseHealth * TheRune.ReturnRuneStatFour());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence += (BaseHealth * TheRune.ReturnRuneStatFour());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack += (BaseDamage * TheRune.ReturnRuneStatFour());
                        break;
                    }
            }
        }
    }


    private void RuneStatDecrease(RuneScript TheRune)
    {
        // the function first checks to make sure that the rune has a stat on it (so if the rune stat two is zero then it dosent have two stats and shouldnt try to apply it)
        // then it will go through all of the stats and find which type of stats are on the rune
        // and then apply the stats to the correct base stat

        switch (TheRune.ReturnMainRuneStatType())
        {
            case ("Attack"):
                {
                    IncreasedAttack -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Health"):
                {
                    IncreasedHealth -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Defence"):
                {
                    IncreasedDefence -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Speed"):
                {
                    IncreasedSpeed -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("CritRate"):
                {
                    IncreasedCritRate -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("CritDamage"):
                {
                    IncreasedCritDamage -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Accuracy"):
                {
                    IncreasedAccuracy -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("Resistance"):
                {
                    IncreasedResistance -= TheRune.ReturnMainRuneStat();
                    break;
                }
            case ("HealthPercentage"):
                {
                    IncreasedHealth -= (BaseHealth * TheRune.ReturnMainRuneStat());
                    break;
                }
            case ("DefencePercentage"):
                {
                    IncreasedDefence -= (BaseDefence * TheRune.ReturnMainRuneStat());
                    break;
                }
            case ("AttackPercentage"):
                {
                    IncreasedAttack -= (BaseDamage * TheRune.ReturnMainRuneStat());
                    break;
                }
        }



        if (TheRune.ReturnRuneStatOne() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatOneType()) // gets the runes first stat
            {
                case ("Health"):
                    {
                        IncreasedHealth -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Attack"):
                    {
                        IncreasedAttack -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance -= TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth -= (BaseHealth * TheRune.ReturnRuneStatOne());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence -= (BaseDefence * TheRune.ReturnRuneStatOne());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack -= (BaseDamage * TheRune.ReturnRuneStatOne());
                        break;
                    }
            }
        }


        if (TheRune.ReturnRuneStatTwo() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatTwoType())
            {
                case ("Health"):
                    {
                        IncreasedHealth -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Damage"):
                    {
                        IncreasedAttack -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance -= TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth -= (BaseHealth * TheRune.ReturnRuneStatTwo());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence -= (BaseDefence * TheRune.ReturnRuneStatTwo());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack -= (BaseDamage * TheRune.ReturnRuneStatTwo());
                        break;
                    }
            }
        }


        if (TheRune.ReturnRuneStatThree() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatThreeType())
            {
                case ("Health"):
                    {
                        IncreasedHealth -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Damage"):
                    {
                        IncreasedAttack -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance -= TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth -= (BaseHealth * TheRune.ReturnRuneStatThree());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence -= (BaseDefence * TheRune.ReturnRuneStatThree());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack -= (BaseDamage * TheRune.ReturnRuneStatThree());
                        break;
                    }
            }
        }


        if (TheRune.ReturnRuneStatFour() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatFourType())
            {
                case ("Health"):
                    {
                        IncreasedHealth -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Damage"):
                    {
                        IncreasedAttack -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Defence"):
                    {
                        IncreasedDefence -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Speed"):
                    {
                        IncreasedSpeed -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("CritRate"):
                    {
                        IncreasedCritRate -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("CritDamage"):
                    {
                        IncreasedCritDamage -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Accuracy"):
                    {
                        IncreasedAccuracy -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Resistance"):
                    {
                        IncreasedResistance -= TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("HealthPercentage"):
                    {
                        IncreasedHealth -= (BaseHealth * TheRune.ReturnRuneStatFour());
                        break;
                    }
                case ("DefencePercentage"):
                    {
                        IncreasedDefence -= (BaseHealth * TheRune.ReturnRuneStatFour());
                        break;
                    }
                case ("AttackPercentage"):
                    {
                        IncreasedAttack -= (BaseDamage * TheRune.ReturnRuneStatFour());
                        break;
                    }
            }
        }
    }



    // this function is used to unequip runes. this will also decrease the stats accordingly when the rune is unequiped
    //Variables : 
    // - the number is to determine which rune is going to be unequiped
    public void UnequipRune(int RuneNumber)
    {
        //finds the rune number and then unequips the rune specified

        switch (RuneNumber)
        {
            case (1):
                {
                    
                    RuneStatDecrease(RuneOne);
                    RuneOneApplied = false;
                    RuneOne = null;
                    break;
                }
            case (2):
                {
                    
                    RuneStatDecrease(RuneTwo);
                    RuneTwoApplied = false;
                    RuneTwo = null;
                    break;
                }
            case (3):
                {
                    
                    RuneStatDecrease(RuneThree);
                    RuneThreeApplied = false;
                    RuneThree = null;
                    break;
                }
            case (4):
                {
                    
                    RuneStatDecrease(RuneFour);
                    RuneFourApplied = false;
                    RuneFour = null;
                    break;
                }
            case (5):
                {
                    
                    RuneStatDecrease(RuneFive);
                    RuneFiveApplied = false;
                    RuneFive = null;
                    break;
                }
            case (6):
                {
                   
                    RuneStatDecrease(RuneSix);
                    RuneSixApplied = false;
                    RuneSix = null;
                    break;
                }
        }

    }


    // this function will return the rune that has the same name as the rune name given in the variables
    //Variables : 
    // - the name of the rune that will be returned
    public RuneScript ReturnRune(int RuneNumber)
    {
        return Runes[RuneNumber];
    }

    // this function will use the rune and equip it to the monster and will also use the applyRuneEffect function to apply that runes stats to the monster
    // the rune already has what slot it needs to be equiped in so it can be determined what rune slot it needs to go in
    // Variables :
    // - the rune that you want equiped to the monster
    public void EquipRune(RuneScript TheRune)
    {
        // checks to see if the rune is already equiped on something
        // then finds what number this rune is and applied it to that rune slot

        if(!TheRune.ReturnRuneEquiped())
        {
            switch (TheRune.ReturnRuneNumber())
            {
                case (1):
                    {
                        RuneOne = TheRune;
                        ApplyRuneEffects(TheRune.ReturnRuneNumber());
                        RuneOneApplied = true;
                        break;
                    }
                case (2):
                    {
                        RuneTwo = TheRune;
                        ApplyRuneEffects(TheRune.ReturnRuneNumber());
                        RuneTwoApplied = true;
                        break;
                    }
                case (3):
                    {
                        RuneThree = TheRune;
                        ApplyRuneEffects(TheRune.ReturnRuneNumber());
                        RuneThreeApplied = true;
                        break;
                    }
                case (4):
                    {
                        RuneFour = TheRune;
                        ApplyRuneEffects(TheRune.ReturnRuneNumber());
                        RuneFourApplied = true;
                        break;
                    }
                case (5):
                    {
                        RuneFive = TheRune;
                        ApplyRuneEffects(TheRune.ReturnRuneNumber());
                        RuneFiveApplied = true;
                        break;
                    }
                case (6):
                    {
                        RuneSix = TheRune;
                        ApplyRuneEffects(TheRune.ReturnRuneNumber());
                        RuneSixApplied = true;
                        break;
                    }
            }

        }

    }

    //this is a function that will be returning this monsters name
    public string ReturnMonsterName()
    {
        return MonsterName;
    }


    // this is a function that will be returning this monsters base health stat
    public float ReturnBaseHealth()
    {
        return BaseHealth;
    }

    // this is a function that will return the base damage of the monster
    public float ReturnBaseDamage()
    {
        return BaseDamage;
    }

    // this function will return the base speed of the monster
    public float ReturnBaseSpeed()
    {
        return BaseSpeed;
    }

    // this function will return the base Defence of the monster
    public float ReturnBaseDefence()
    {
        return BaseDefence;
    }

    // this function will return the base crit rate of the monster
    public float ReturnBaseCritRate()
    {
        return BaseCritRate;
    }

    // this function will return the base crit damage of the monster
    public float ReturnBaseCritDamage()
    {
        return BaseCritDamage;
    }

    // this function will return the base Accuracy of the monster
    public float ReturnBaseAccuracy()
    {
        return BaseAccuracy;
    }

    // this function will return the base Resistance of the monster
    public float ReturnBaseResistance()
    {
        return BaseResistance;
    }

    // this function will return the monsters current Health
    public float ReturnCurrentHealth()
    {
        return CurrentHealth;
    }

    //this function will return the monsters Increased Health
    public float ReturnIncreasedHealth()
    {
        return IncreasedHealth;
    }

    //this function will return the monsters Increased Defence
    public float ReturnIncreasedDefence()
    {
        return IncreasedDefence;
    }

    //this function will return the monsters Increased Attack
    public float ReturnIncreasedAttack()
    {
        return IncreasedAttack;
    }

    //this function will return the monsters increased Speed
    public float ReturnIncreasedSpeed()
    {
        return IncreasedSpeed;
    }

    //this function will return the monsters increased crit rate
    public float ReturnIncreasedCritRate()
    {
        return IncreasedCritRate;
    }

    //this function will return the monsters increased crit damage
    public float ReturnIncreasedCritDamage()
    {
        return IncreasedCritDamage;
    }

    //this function will return the monsters increased accuracy
    public float ReturnIncreasedAccuracy()
    {
        return IncreasedAccuracy;
    }

    //this function will returns the monsters increased Resistance
    public float ReturnIncreasedResistance()
    {
        return IncreasedResistance;
    }

    // this function will return the monsters saved stars
    public int ReturnMonsterStars()
    {
        return Stars;
    }

    // this function will return the monsters type
    public string ReturnMonsterType()
    {
        return TheMonsterType;
    }

    // this function will return the monsters Level
    public int ReturnMonsterLevel()
    {
        return MonsterLevel;
    }

    // this function will return wether the monster is awakened or not
    public bool ReturnMonsterAwkaned()
    {
        return Awakened;
    }

    // this function will return the monsters first rune name
    public string ReturnRuneOneName()
    {
        return RuneOne.ReturnRuneName();
    }

    // this function will return the monsters second rune name
    public string ReturnRuneTwoName()
    {
        return RuneTwo.ReturnRuneName();
    }

    // this function will return the monsters third rune name
    public string ReturnRuneThreeName()
    {
        return RuneThree.ReturnRuneName();
    }

    // this function will return the monsters fourth rune name
    public string ReturnRuneFourthName()
    {
        return RuneFour.ReturnRuneName();
    }

    // this function will return the monsters fith rune name
    public string ReturnRuneFifthName()
    {
        return RuneFive.ReturnRuneName();
    }

    // this function will return the monsters sixth Rune name
    public string ReturnRuneSixName()
    {
        return RuneSix.ReturnRuneName();
    }

    //this function returns the monsters main effect of skill one
    public string ReturnrSkillOneMainEffect()
    {
        return SkillOneMainEffect;
    }

    // this function returns the monster secondary effect of skill two
    public string ReturnSkillOneSecondaryEffect()
    {
        return SkillOneSecondaryEffect;
    }

    // this function returns wether or not the first skill is an AOE skill
    public bool ReturnSkillOneAOE()
    {
        return SkillOneAOE;
    }

    //this function returns the main effect of the second skill
    public string ReturnSkillTwoMainEffect()
    {
        return SkillTwoMainEffect;
    }

    // this function returns the secondary effect of the Second Skill
    public string ReturnSkillTwoSecondaryEffect()
    {
        return SkillTwoSecondaryEffect;
    }

    //this function returns wether the secondary skill is an AOE effect or not
    public bool ReturnSkillTwoAOE()
    {
        return SkillTwoAOE;
    }


    // this function returns the main effect of the third skill
    public string ReturnSkillThreeMainEffect()
    {
        return SkillThreeMainEffect;
    }

    // this function will return the secondary effect of the third skill
    public string ReturnSkillThreeSecondaryEffect()
    {
        return SkillThreeSecondaryEffect;
    }

    // this function will return wether or not the third skill is a AOE or not
    public bool ReturnSkillThreeAOE()
    {
        return SkillThreeAOE;
    }

    // this function returns the monsters first skill importance
    public int ReturnSkillOneImportance()
    {
        return SkillOneImportance;
    }

    //this function returns the monsters second skill importance
    public int ReturnSkillTwoImportance()
    {
        return SkillTwoImportance;
    }

    // this function returns the monsters thrid skill importance
    public int ReturnSkillThreeImportance()
    {
        return SkillThreeImportance;
    }

    //this function will return the list of effects that the first skill can use
    public List<string> ReturnAllSkillOneEffects()
    {
        return SkillOneEffects;
    }

    // this function will return the list of effect that the second skill can use
    public List<string> ReturnAllSkillTwoEffects()
    {
        return SkillTwoEffects;
    }

    // this function will return the list of effects that the third skill can use
    public List<string> ReturnAllSkillThreeEffects()
    {
        return SkillThreeEffects;
    }

    //this function will return the monsters first skill multiplier
    public float ReturnMonsterSkillOneMultipler()
    {
        return SkillOneMultiplier;
    }

    //this function will return the monsters second skill multipler
    public float ReturnMonsterSkillTwoMultipler()
    {
        return SkillTwoMultiplier;
    }

    //this function will return the monsters third skill multipler
    public float ReturnMonsterSkillThreeMultipler()
    {
        return SkillThreeMultiplier;
    }

    public float ReturnMonsterSkillOneSecondMultiplier()
    {
        return SkillOneSecondaryEffectMultiplier;
    }

    public float ReturnMonsterSkillTwoSecondMultiplier()
    {
        return SkillTwoSecondaryEffectMultiplier;
    }

    public float ReturnMonsterSkillThreeSecondMultiplier()
    {
        return SkillThreeSecondaryEffectMultiplier;
    }

    //this function returns the monsters Owner
    public string ReturnMonsterOwner()
    {
        return OwnerName;
    }


    //function that sets the monster name
    public void SetMonsterName(string Name)
    {
        MonsterName = Name;
    }

    // this function will set the monsters health
    public void SetMonsterHealth(float Health) { BaseHealth = Health; }

    // this function will set the monsters attack
    public void SetMonsterAttack(float Attack) { BaseDamage = Attack; }

    // this function will set the monsters defence
    public void SetMonsterDefence(float Defence) { BaseDefence = Defence; }

    // this function will set the monsters speed
    public void SetMonsterSpeed(float Speed) { BaseSpeed = Speed; }

    // this function will set the monsters accuracy
    public void SetMonsterAccuracy(float Accuracy) { BaseAccuracy = Accuracy; }

    // this will set the monsters resistance
    public void SetMonsterResistance(float Resistance) { BaseResistance = Resistance; }

    // this will set the monsters crit rate
    public void SetMonsterCritRate(float CritRate) { BaseCritRate = CritRate; }

    // this will set the monsters crit damage
    public void SetMonsterCritDamage(float CritDamage) { BaseCritDamage = CritDamage; }

    //this will set the monsters Increased Health
    public void SetMonsterIncreasedHealth(float increasedhealth) { IncreasedHealth = increasedhealth; }

    //this will set the monsters Increased Defence
    public void SetMonstersIncreasedDefence(float increaseddefence) { IncreasedDefence = increaseddefence; }

    //this will set the monsters Increased Attack
    public void SetMonstersIncreasedAttack(float increasedattack) { IncreasedAttack = increasedattack; }

    //this function will set the monsters increased speed
    public void SetMonstersIncreasedSpeed(float increasedspeed) { IncreasedSpeed = increasedspeed; }

    //this function will set the monsters increased crit rate
    public void SetMonstersIncreasedCritRate(float increasedcritrate) { IncreasedCritRate = increasedcritrate; }

    //this function will set the monsters increased crit damage
    public void SetMonstersIncreasedCritDamage(float increasedcritdamage) { IncreasedCritDamage = increasedcritdamage; }

    //this function will set the monsters increased accuracy
    public void SetMonstersIncreasedAccuracy(float increasedaccuracy) { IncreasedAccuracy = increasedaccuracy; }

    //this functoin will set the monsters increased resistance
    public void SetMonstersIncreasedResistance(float increasedresistance) { IncreasedResistance = increasedresistance; }
    
    //this will set the monsters star
    public void SetMonsterStars(int StarsAmount) { Stars = StarsAmount; }

    // this will set the monsters type
    public void SetMonsterstype(string MonsterType) { TheMonsterType = MonsterType; }

    //this will set the monsters level
    public void SetMonsterlevel(int level) { MonsterLevel = level; }

    //this will set the monsters awakening
    public void SetMonsterAwakening(bool IsAwakened) { Awakened = IsAwakened; }

    //this will set the rune one name
    public void SetRuneNameOne(string TheRuneOneName)
    {
        RuneOne.SetRuneName(TheRuneOneName);
    }

    //this will set the rune two name
    public void SetRuneNameTwo(string TheRuneTwoName)
    {
        RuneTwo.SetRuneName(TheRuneTwoName);
    }

    //this will set the rune three name
    public void SetRuneNameThree(string TheRuneThreeName)
    {
        RuneThree.SetRuneName(TheRuneThreeName);
    }

    //this will set the rune four name
    public void SetRuneNameFour(string TheRuneFourName)
    {
        RuneFour.SetRuneName(TheRuneFourName);
    }

    //this will set the rune five name 
    public void SetRuneNameFive(string TheRuneFiveName)
    {
        RuneFive.SetRuneName(TheRuneFiveName);
    }

    //this will set the rune six name
    public void SetRuneNameSix(string TheRuneSixName)
    {
        RuneSix.SetRuneName(TheRuneSixName);
    }

    //this will set the the main effect of the first skill
    public void SetSkillOneMainEffect(string SkillName)
    {
        SkillOneMainEffect = SkillName;
    }

    // this will set the second effect of the first skill
    public void SetSkillOneSecondaryEffect(string SKillName)
    {
        SkillOneSecondaryEffect = SKillName;
    }

    // this will set wether or not the first skill is an AOE skill
    public void SetSkillOneAOE(bool ISAOE)
    {
        SkillOneAOE = ISAOE;
    }

    //this will set the main effect of the second skill
    public void SetSkillTwoMainEffect(string SkillName)
    {
        SkillTwoMainEffect = SkillName;
    }

    // this will set the secondary effect of the second skill
    public void SetSkillTwoSecondaryEffect(string SkillName)
    {
        SkillTwoSecondaryEffect = SkillName;
    }

    // this will set wether or not the second skill is an AOE skill
    public void SetSkillTwoAOE(bool ISAOE)
    {
        SkillTwoAOE = ISAOE;
    }

    //this function sets the main effect of the thrid skill
    public void SetSkillThreeMainEffect(string SkillName)
    {
        SkillThreeMainEffect = SkillName;
    }

    // this function sets the secondary effect of the third skill
    public void SetSkillThreeSecondaryEffect(string SkillName)
    {
        SkillThreeSecondaryEffect = SkillName;
    }

    // this function sets wether or not the third skill is an AOE skill
    public void SetSkillThreeAOE(bool ISAOE)
    {
        SkillThreeAOE = ISAOE;
    }

    //this will set the skill one importance
    public void SetSkillOneImportance(int Improtance)
    {
        SkillOneImportance = Improtance;
    }

    //this will set the skill two importance
    public void SetSkillTwoImportance(int Importance)
    {
        SkillTwoImportance = Importance;
    }

    //this will set the skill three importance
    public void SetSkillthreeImportance(int Importance)
    {
        SkillThreeImportance = Importance;
    }

    // this function will add to the effects the monster can apply on the first skill
    public void AddEffectFirstSkill(string Effect)
    {
        SkillOneEffects.Add(Effect);
    }

    // this function will add to the effects the monsetr can apply on the second skill
    public void AddEffectSecondSkill(string Effect)
    {
        SkillTwoEffects.Add(Effect);
    }

    // this function will add to the effects the monster can apply on the third skill
    public void AddEffectThirdSkill(string Effect)
    {
        SkillThreeEffects.Add(Effect);
    }

    //this is the function that will set the monsters first skill multipler
    public void SetFirstSkillMultiplier(float Multiplier)
    {
        SkillOneMultiplier = Multiplier;
    }

    //this is the function that will set the monsters second skill multiplier
    public void SetSecondSkillMultipler(float Multiplier)
    {
        SkillTwoMultiplier = Multiplier;
    }

    // this is the function that will set the monsters third skill multiplier
    public void SetThirdSkillMultiplier(float Multiplier)
    {
        SkillThreeMultiplier = Multiplier;
    }

    public void SetFirstSkillSecondaryMultiplier(float Multiplier)
    {
        SkillOneSecondaryEffectMultiplier = Multiplier;
    }

    public void SetSecondSkillSecondaryMultiplier(float Multiplier)
    {
        SkillTwoSecondaryEffectMultiplier = Multiplier;
    }

    public void SetThirdSkillSecondaryMultiplier(float Multiplier)
    {
        SkillThreeSecondaryEffectMultiplier = Multiplier;
    }

    //this function will set the monsters owner to the player
    public void SetMonsterOwner(string Owner)
    {
        OwnerName = Owner;
    }

    public void SetMonsterMaxLevel(int MaxLevel)
    {
        MonsterMaxLevel = MaxLevel;
    }

    public void SetMonsterMultiplier(float multipleir)
    {
        LevelMultiplier = multipleir;
    }

    // this function is used to set the skill cool down of the second skill
    //Variables :
    // - the float is to determine how much you want to set this skill cooldown by
    public void SetSkillTwoCoolDown(int CoolDown)
    {
        SkillTwoCoolDown = CoolDown;
    }

    // this function is used to get the skill cooldown of the second skill
    public int ReturnSkillTwoCoolDown()
    {
        return SkillTwoCoolDown;
    }

    // this function is used to set the skill cooldown of the third skill
    //Variables : 
    // - the float is to determine how much you want to set this skill cooldown by
    public void SetSkillThreeCoolDown(int CoolDown)
    {
        SkillThreeCoolDown = CoolDown;
    }

    //this function is used to get the current skill cooldown of the third skill 
    public int ReturnSkillThreeCoolDown()
    {
        return SkillThreeCoolDown;
    }

    // this function is used to add beneficial effects to the monster
    //Variables : 
    // - the effect that you want to be added to the monster
    public void AddBeneficialEffect(BeneficialEffects BeneficialEffect)
    {
        //checks to see if the effect is already applied
        // if the affect is then it extends the turns
        // if it isnt and the max effects is not full then it applied the affect

        bool TempAffectApplied = false;

        foreach(BeneficialEffects B in EffectsBeneficial)
        {
            if(B == BeneficialEffect)
            {
                TempAffectApplied = true;
                B.SetTurns(3);
            }
        }

        if(!TempAffectApplied)
        {
            if((EffectsBeneficial.Count + EffectsHarmful.Count) < MaxEffects)
            {
                EffectsBeneficial.Add(BeneficialEffect);
            }
        }

    }

    //this function is used to remove beneficial effects from the monster
    // this will work by checking all of the beneficial effects timers and removing all the ones at zero
    public void RemoveBeneficialEffects()
    {
        // finds all of the beneficial effects that have zero turns and removes them

        foreach(BeneficialEffects B in EffectsBeneficial)
        {
            if(B.ReturnTurnsLeft() <= 0)
            {
                EffectsBeneficial.Remove(B);
            }
        }
    }

    // this function is used to add Harmful Effects to the monster 
    //Variables :
    // - the effect that you want to be added to the monster
    public void AddHarmfulEffects(HarmfulEffects HarmfulEffect)
    {
        // checks to see if this harmful affect is already applied
        // if it is then it will be extended
        // if it isnt and the max effects are not exceeded then it will apply the effect


        bool TempAffectApplied = false;

        foreach(HarmfulEffects H in EffectsHarmful)
        {
            if(H == HarmfulEffect)
            {
                TempAffectApplied = true;
                H.SetTurns(3);
            }
        }

        if(!TempAffectApplied)
        {
            if((EffectsBeneficial.Count + EffectsHarmful.Count) < MaxEffects)
            {
                EffectsHarmful.Add(HarmfulEffect);
            }
        }

    }

    // this function is used to remove harmfull effects from the monster
    // this will work by checking all of the harmful effects timers and removing all the ones at zero
    public void RemoveHarmfulEffects()
    {
        //goes through all of the harmful effects applied if there are any at zero turns they will be removed

        foreach(HarmfulEffects H in EffectsHarmful)
        {
            if(H.ReturnturnsLeft() <=- 0)
            {
                EffectsHarmful.Remove(H);
            }
        }
    }

    // returns the list of beneficial effects applied on the monster
    public List<BeneficialEffects> ReturnBeneficialEffects()
    {
        return EffectsBeneficial;
    }

    // returns the list of harmful effects applied on the monster
    public List<HarmfulEffects> ReturnHarmfulEffects()
    {
        return EffectsHarmful;
    }

    public MonsterData ReturnMonsterData()
    {
        return ThisData;
    }

   
}
