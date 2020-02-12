using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// everything that is not accesible in the inspector will have comments above
// everything that is accessible within the inspect will have a tool tip to act like a comment both in code and in inspector


public class MonsterScript : MonoBehaviour
{

    // this is the monsters base health (the monsters health stat)
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

    // this is an enum that holds all of the types that a monster can be
    private enum MonsterType {Defence, Attack, Health };

    [Tooltip("this is the monsters type that has been selected frrm the enum (what type do you want this monster to be)")]
    [SerializeField]
    private MonsterType Type = MonsterType.Attack;

    [Tooltip("the level that you want the monster to be")]
    [SerializeField]
    private int MonsterLevel = 0;

    [Tooltip("this is a bool that determines wether the monster has been awakened yet")]
    [SerializeField]
    private bool Awakened = false;

    [Tooltip("this is the multiplier that is applied to the monsters stats. (this will be multiplied with the level and then with the stats to increase the base stats")]
    [SerializeField]
    private float LevelMultiplier = 0.2f;

    [Tooltip("this is the multiplier applied to the monsters stats depending on wether the monster is awakened (this will be multiplied with the stats and then added on to the base to increase the base)")]
    [SerializeField]
    private float AwakenMultiplier = 0.3f;

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
    private RuneObject RuneOne = null;

    [Tooltip("This is the second rune that the monster can equip")]
    [SerializeField]
    private RuneObject RuneTwo = null;

    [Tooltip("this is the third rune that the monster can equip")]
    [SerializeField]
    private RuneObject RuneThree = null;

    [Tooltip("this is the fourth rune that the monster can equip")]
    [SerializeField]
    private RuneObject RuneFour = null;

    [Tooltip("this is the fifth rune that the monster can equip")]
    [SerializeField]
    private RuneObject RuneFive = null;

    [Tooltip("this is the sixth rune that the monster can equip")]
    [SerializeField]
    private RuneObject RuneSix = null;

    //this is a list of all of the runes that are equiped on to this monster (i may change this to serilised so that in stead of equiping each rune seperalty it just stores in this list)
    //this list is for storing the runes so that it can be used in a function later on
    private List<RuneObject> Runes = new List<RuneObject>();

    // these are the Skills that the monster can have
    // this will need testing to see wether it needs to be a gameobject or not

    [Tooltip("This is the first skill that the monster is able to use")]
    [SerializeField]
    private Skillsscript SkillOne = null;

    [Tooltip("This is the second skill that the monster is able to use")]
    [SerializeField]
    private Skillsscript SkillTwo = null;

    [Tooltip("This is the third skill that the monster is able to use")]
    [SerializeField]
    private Skillsscript SkillThree = null;

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

    [Tooltip("the leader skill that you want the monster to be able to use (this is a special skill that affects the stats of all monsters)")]
    [SerializeField]
    private Skillsscript LeaderSkill = null;

    [Tooltip("the string to determine who owns the monster wether it be the player or the AI")]
    [SerializeField]
    private string OwnerName = null;

    [Tooltip("a bool to determine if it is the monsters turn or not used for when the monster is battling")]
    [SerializeField]
    private bool CurrentTurn;

    [Tooltip("how important it is for when the Ai is controlling the monster to use the first skill (the higher the number the more important the skill is)")]
    [SerializeField]
    private int SkillOneImportance = 0;

    [Tooltip("how important it is for when the Ai is controlling the monster to use the second skill (the higher the number the more important the skill is)")]
    [SerializeField]
    private int SkillTwoImportance = 0;

    [Tooltip("how important it is for when the Ai is controlling the monster to use the third skill (the higher the number the more important the skill is)")]
    [SerializeField]
    private int SkillThreeImportance = 0;

    [Tooltip("the skill cooldown for the second skill the monster has")]
    [SerializeField]
    private int SkillTwoCoolDown = 0;

    [Tooltip("The skill cooldown for the third skill the monster has")]
    [SerializeField]
    private int SkillThreeCoolDown = 0;

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

 
    // this is the enum for what type of state the monster is in
    // idle means they are just standing there and will not be battling any time soon
    // Battle means the monster is in combat and will be attacking or taking damage
    private enum Monsterstate {Idle, Battle };

    [Tooltip("a enum to determine the monsters current state")]
    [SerializeField]
    private Monsterstate state = Monsterstate.Idle;



    // Start is called before the first frame update
    void Start()
    {
        Runes.Add(RuneOne);
        Runes.Add(RuneTwo);
        Runes.Add(RuneThree);
        Runes.Add(RuneFour);
        Runes.Add(RuneFive);
        Runes.Add(RuneSix);

        SkillOne = new BasicSkill();


    }

    // Update is called once per frame
    void Update()
    {
        
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
                if (RuneOne)  
                {
                    RuneStatIncrease(RuneOne); 
                }
            }
        }
        else if(RuneNumber == 2) 
        {
            if(!RuneTwoApplied) 
            {
                if(RuneTwo) 
                {
                    RuneStatIncrease(RuneTwo);
                }
            }
        }
        else if(RuneNumber == 3)
        {
            if(!RuneThreeApplied) 
            {
                if(RuneThree) 
                {
                    RuneStatIncrease(RuneThree);
                }
            }
        }
        else if(RuneNumber == 4)
        {
            if(!RuneFourApplied) 
            {
                if(RuneFour) 
                {
                    RuneStatIncrease(RuneFour);
                }
            }
        }
        else if(RuneNumber == 5)
        {
            if(!RuneFiveApplied) 
            {
                if(RuneFive)
                {
                    RuneStatIncrease(RuneFive);
                }
            }
        }
        else if(RuneNumber == 6)
        {
            if(!RuneSixApplied) 
            {
                if(RuneSix)
                {
                    RuneStatIncrease(RuneSix);
                }
            }
        }
        
    }

    // this function is used to apply the stats that are held on the rune to the monsters base stats
    // Parameters:
    // - the rune that will be checked for what stats it has and also apply it to the monster
    private void RuneStatIncrease(RuneObject TheRune)
    {
        // the function first checks to make sure that the rune has a stat on it (so if the rune stat two is zero then it dosent have two stats and shouldnt try to apply it)
        // then it will go through all of the stats and find which type of stats are on the rune
        // and then apply the stats to the correct base stat

        if (TheRune.ReturnRuneStatOne() > 0.0f)
        {
            switch (TheRune.ReturnRuneStatOneType()) // gets the runes first stat
            {
                case ("Health"):
                    {
                        BaseHealth += BaseHealth * TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Damage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Defence"):
                    {
                        BaseDefence += BaseDefence * TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Speed"):
                    {
                        BaseSpeed += BaseSpeed * TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("CritRate"):
                    {
                        BaseCritRate += BaseCritRate * TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("CritDamage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Accuracy"):
                    {
                        BaseAccuracy += BaseAccuracy * TheRune.ReturnRuneStatOne();
                        break;
                    }
                case ("Resistance"):
                    {
                        BaseResistance += BaseResistance * TheRune.ReturnRuneStatOne();
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
                        BaseHealth += BaseHealth * TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Damage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Defence"):
                    {
                        BaseDefence += BaseDefence * TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Speed"):
                    {
                        BaseSpeed += BaseSpeed * TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("CritRate"):
                    {
                        BaseCritRate += BaseCritRate * TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("CritDamage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Accuracy"):
                    {
                        BaseAccuracy += BaseAccuracy * TheRune.ReturnRuneStatTwo();
                        break;
                    }
                case ("Resistance"):
                    {
                        BaseResistance += BaseResistance * TheRune.ReturnRuneStatTwo();
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
                        BaseHealth += BaseHealth * TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Damage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Defence"):
                    {
                        BaseDefence += BaseDefence * TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Speed"):
                    {
                        BaseSpeed += BaseSpeed * TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("CritRate"):
                    {
                        BaseCritRate += BaseCritRate * TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("CritDamage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Accuracy"):
                    {
                        BaseAccuracy += BaseAccuracy * TheRune.ReturnRuneStatThree();
                        break;
                    }
                case ("Resistance"):
                    {
                        BaseResistance += BaseResistance * TheRune.ReturnRuneStatThree();
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
                        BaseHealth += BaseHealth * TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Damage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Defence"):
                    {
                        BaseDefence += BaseDefence * TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Speed"):
                    {
                        BaseSpeed += BaseSpeed * TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("CritRate"):
                    {
                        BaseCritRate += BaseCritRate * TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("CritDamage"):
                    {
                        BaseDamage += BaseDamage * TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Accuracy"):
                    {
                        BaseAccuracy += BaseAccuracy * TheRune.ReturnRuneStatFour();
                        break;
                    }
                case ("Resistance"):
                    {
                        BaseResistance += BaseResistance * TheRune.ReturnRuneStatFour();
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
                    //function that removes the stats of the rune
                    RuneOneApplied = false;
                    RuneOne = null;
                    break;
                }
            case (2):
                {
                    //function that removes the stats of the rune
                    RuneTwoApplied = false;
                    RuneTwo = null;
                    break;
                }
            case (3):
                {
                    //function that removes the stats of the rune
                    RuneThreeApplied = false;
                    RuneThree = null;
                    break;
                }
            case (4):
                {
                    //function that removes the stats of the rune
                    RuneFourApplied = false;
                    RuneFour = null;
                    break;
                }
            case (5):
                {
                    //function that removes the stats of the rune
                    RuneFiveApplied = false;
                    RuneFive = null;
                    break;
                }
            case (6):
                {
                    //function that removes the stats of the rune
                    RuneSixApplied = false;
                    RuneSix = null;
                    break;
                }
        }

    }

    // this function will return the rune that has the same name as the rune name given in the variables
    //Variables : 
    // - the name of the rune that will be returned
    public RuneObject ReturnRune(int RuneNumber)
    {
        return Runes[RuneNumber];
    }

    // this function will use the rune and equip it to the monster and will also use the applyRuneEffect function to apply that runes stats to the monster
    // the rune already has what slot it needs to be equiped in so it can be determined what rune slot it needs to go in
    // Variables :
    // - the rune that you want equiped to the monster
    public void EquipRune(RuneObject TheRune)
    {
        //checks to see if the rune is already equiped on something
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

    //this function will use the skill that has the same name as the one specified in the variable
    //Variables : 
    // - the string is the name of the skill that you want to be used withhin this function
    public void UseSkill(string SkillName)
    {

    }

    // this function is used to set the skill cool down of the second skill
    //Variables :
    // - the float is to determine how much you want to set this skill cooldown by
    public void SetSkillTwoCoolDown(int CoolDown)
    {

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
}
