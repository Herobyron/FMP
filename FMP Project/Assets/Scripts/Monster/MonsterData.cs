using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// this script is to be used to store a monster key information when it is spawned and is only edited when a monster is saved (as thier runes can change)
public class MonsterData 
{
    // this is the name of the monster 
    private string MonsterName = "";

    // this is the monsters base health
    private float BaseHealth = 0.0f;

    // this is the monsters base damage
    private float BaseDamage = 0.0f;

    // this is the monsters base defence
    private float BaseDefence = 0.0f;

    // this is the monsters base speed
    private float BaseSpeed = 0.0f;

    // this is the monsters base critrate
    private float BaseCritRate = 0.0f;

    // this is the monsters base crit damage
    private float BaseCritDamage = 0.0f;

    // this is the monsters base accuracy
    private float BaseAccuracy = 0.0f;

    // this is the monsters base resistance
    private float BaseResistance = 0.0f;

    // this is the monster current stars
    private int Stars = 0;

    // this the monsters type
    private string TheMonsterType = "";

    // this is the monsters level
    private int MonsterLevel = 0;

    // this is a bool to determine if the monster is awakened
    private bool Awakened = false;

    // this is the monsters first rune
    private string RuneOneName = "";

    // this is the monsters second rune
    private string RuneTwoName = "";

    // this is the monsters third rune
    private string RuneThreeName = "";

    // this is the monsters fourth rune
    private string RuneFourName = "";

    // this is the monsters fifth rune
    private string RuneFiveName = "";

    // this is the monsters sixth rune
    private string RuneSixName = "";

    // this is the monsters first skill and first effect
    private string SkillOneMainEffect = "";

    // this is the monsters secondary effect on skill one
    private string SkillOneSecondaryEffect = "";

    // a bool to determine if this skill will be an AOE skill
    private bool SkillOneAOE = false;

    // this is the monsters second skill
    private string SkillTwoMainEffect = "";

    // this is the monsters secondary effect on the second skill
    private string SkillTwoSecondaryEffect = "";

    //this is the bool to determine wether the second skill is AOE
    private bool SkillTwoAOE = false;

    // this is the monsters third name and first effect
    private string SkillThreeMainEffect = "";

    // this is the monsters third skill and secondary effect
    private string SkillThreeSecondaryEffect = "";

    // this is the monsters third skill aoe to determine if it is AOE
    private bool SkillThreeAOE = false;

    // this is the importance of the first skill
    private int SkillOneImportance = 0;

    // this is the importance of the second skill
    private int SkillTwoImportance = 0;

    // this is the importance of the thirs skill
    private int SkillThreeImportance = 0;

    // this is the effects the monster can apply on thier first skill (for main and secondary effects)
    private List<string> SkillOneEffects = new List<string>();

    // this is the effects the monster can apply on thier second skill (for main and secondary effects)
    private List<string> SkillTwoEffects = new List<string>();

    //this is the effects that the monster can apply with third skill (for main and secondary effect)
    private List<string> SkillThreeEffects = new List<string>();

    // this is the float that stores the multiplier for the monsters first skill
    private float SkillOneMulitplier = 0.0f;

    // this is the float that stores the multiplier for the monsters second skill
    private float SkillTwoMultiplier = 0.0f;

    // this is the float that stores the multiplier for the monsters third skill
    private float SkillThreeMultiplier = 0.0f;

    //this is the owner of the monster
    private string MonsterOwner;

    // this function returns the rune name 
    public string ReturnMonsterName()
    {
        return MonsterName;
    }

    //this function returns the monster saved base health
    public float ReturnMonsterBaseHealth() { return BaseHealth; }

    //this function returns the monster saved base damage
    public float ReturnMonsterBaseDamage() { return BaseDamage; }

    // this function returns the monster saved base defence
    public float ReturnMonsterBaseDefence() { return BaseDefence; }

    // this function returns the monster saved base speed
    public float ReturnMonsterBaseSpeed() { return BaseSpeed; }

    // this function returns the monster saved base crit damage
    public float ReturnMonsterBaseCritDamage() { return BaseCritDamage; }

    // this function returns the monster saved base crit rate
    public float ReturnMonsterBaseCritRate() { return BaseCritRate; }

    // this function returns the monster saved base Accuracy
    public float ReturnMonsterBaseAccuracy() { return BaseAccuracy; }

    // this function returns the monster saved base resistance
    public float ReturnMonsterBaseResistance() { return BaseResistance; }

    // this function returns the monsters saved stars
    public int ReturnMonsterStars() { return Stars; }

    // this function returns the monster saved base type
    public string ReturnMonsterType() { return TheMonsterType; }

    // this function returns the monsters saved level
    public int ReturnMonsterLevel() { return MonsterLevel; }

    // this function returns the monsters saved awakening
    public bool ReturnMonsterAwakened() { return Awakened; }

    // this function returns the monsters saved first rune name
    public string ReturnRuneOneName() { return RuneOneName; }

    // this function returns the monsters saved second rune name
    public string ReturnRuneTwoName() { return RuneTwoName; }

    // this function returns the monsters saved third rune name
    public string ReturnRuneThreeName() { return RuneThreeName; }

    // this function returns the monsters saved fourth rune name
    public string ReturnRuneFourName() { return RuneFourName; }

    // this function returns the monsters saved fifth rune name
    public string ReturnRuneFiveName() { return RuneFiveName; }

    // this function returns the monster saved sixth rune name
    public string ReturnRuneSixName() { return RuneSixName; }

    // this function returns the monsters main effect of skill one
    public string ReturnSkillOneMainEffect() { return SkillOneMainEffect; }

    // this function returns the monster secondary effect of skill two
    public string ReturnSkillOneSecondaryEffect() { return SkillOneSecondaryEffect; }

    // this function returns wether or not the first skill is an AOE skill
    public bool ReturnSkillOneAOE() { return SkillOneAOE; }

    //this function returns the main effect of the second skill
    public string ReturnSkillTwoMainEffect() { return SkillTwoMainEffect; }

    // this function returns the secondary effect of the Second Skill
    public string ReturnSkillTwoSecondaryEffect() { return SkillTwoSecondaryEffect; }

    //this function returns wether the secondary skill is an AOE effect or not
    public bool ReturnSkillTwoAOE() { return SkillTwoAOE; }


    // this function returns the main effect of the third skill
    public string ReturnSkillThreeMainEffect() { return SkillThreeMainEffect; }

    // this function will return the secondary effect of the third skill
    public string ReturnSkillThreeSecondaryEffect() { return SkillThreeSecondaryEffect; }

    // this function will return wether or not the third skill is a AOE or not
    public bool ReturnSkillThreeAOE() { return SkillThreeAOE; }

    // this function returns the monsters first skill importance
    public int ReturnSkillOneImportance() { return SkillOneImportance; }

    //this function returns the monsters second skill importance
    public int ReturnSkillTwoImportance() { return SkillTwoImportance; }

    // this function returns the monsters thrid skill importance
    public int ReturnSkillThreeImportance() { return SkillThreeImportance; }

    //this function will return the list of effects that the first skill can use
    public List<string> ReturnAllSkillOneEffects() { return SkillOneEffects; }

    // this function will return the list of effect that the second skill can use
    public List<string> ReturnAllSkillTwoEffects() { return SkillTwoEffects; }

    // this function will return the list of effects that the third skill can use
    public List<string> ReturnAllSkillThreeEffects() { return SkillThreeEffects; }

    //this function will return the monsters first skill multiplier
    public float ReturnMonsterSkillOneMultipler() { return SkillOneMulitplier; }
    
    //this function will return the monsters second skill multipler
    public float ReturnMonsterSkillTwoMultipler() { return SkillTwoMultiplier; }
    
    //this function will return the monsters third skill multipler
    public float ReturnMonsterSkillThreeMultipler() { return SkillThreeMultiplier; }

    //this function will return the monsters owner
    public string ReturnMonsterOwner() { return MonsterOwner; }

    //this function will set the monsters name
    public void SetMonsterName(string Name) { MonsterName = Name; }

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

    //this will set the monsters star
    public void SetMonsterStars(int StarsAmount) { Stars = StarsAmount; }

    // this will set the monsters type
    public void SetMonsterstype(string MonsterType) { TheMonsterType = MonsterType; }

    //this will set the monsters level
    public void SetMonsterlevel(int level) { MonsterLevel = level; }

    //this will set the monsters awakening
    public void SetMonsterAwakening(bool IsAwakened) { Awakened = IsAwakened; }

    //this will set the rune one name
    public void SetRuneNameOne(string TheRuneOneName) { RuneOneName = TheRuneOneName; }

    //this will set the rune two name
    public void SetRuneNameTwo(string TheRuneTwoName) { RuneTwoName = TheRuneTwoName; }

    //this will set the rune three name
    public void SetRuneNameThree(string TheRuneThreeName) { RuneThreeName = TheRuneThreeName; }

    //this will set the rune four name
    public void SetRuneNameFour(string TheRunefourName) { RuneFourName = TheRunefourName; }

    //this will set the rune five name 
    public void SetRuneNameFive(string TheRunefiveName) { RuneFiveName = TheRunefiveName; }

    //this will set the rune six name
    public void SetRuneNameSix(string TheRuneSixName) { RuneSixName = TheRuneSixName; }

    //this will set the the main effect of the first skill
    public void SetSkillOneMainEffect(string SkillName) { SkillOneMainEffect = SkillName; }

    // this will set the second effect of the first skill
    public void SetSkillOneSecondaryEffect(string SKillName) { SkillOneSecondaryEffect = SKillName; }

    // this will set wether or not the first skill is an AOE skill
    public void SetSkillOneAOE(bool ISAOE) { SkillOneAOE = ISAOE; }

    //this will set the main effect of the second skill
    public void SetSkillTwoMainEffect(string SkillName) { SkillTwoMainEffect = SkillName; }

    // this will set the secondary effect of the second skill
    public void SetSkillTwoSecondaryEffect(string SkillName) { SkillTwoSecondaryEffect = SkillName; }

    // this will set wether or not the second skill is an AOE skill
    public void SetSkillTwoAOE(bool ISAOE) { SkillTwoAOE = ISAOE; }
    
    //this function sets the main effect of the thrid skill
    public void SetSkillThreeMainEffect(string SkillName) { SkillThreeMainEffect = SkillName; }

    // this function sets the secondary effect of the third skill
    public void SetSkillThreeSecondaryEffect(string SkillName) { SkillThreeSecondaryEffect = SkillName; }

    // this function sets wether or not the third skill is an AOE skill
    public void SetSkillThreeAOE(bool ISAOE) { SkillThreeAOE = ISAOE; }

    //this will set the skill one importance
    public void SetSkillOneImportance(int Improtance) { SkillOneImportance = Improtance; }

    //this will set the skill two importance
    public void SetSkillTwoImportance(int Importance) { SkillTwoImportance = Importance; }

    //this will set the skill three importance
    public void SetSkillthreeImportance(int Importance) { SkillThreeImportance = Importance; }

    // this function will add to the effects the monster can apply on the first skill
    public void AddEffectFirstSkill(string Effect) { SkillOneEffects.Add(Effect); }

    // this function will add to the effects the monsetr can apply on the second skill
    public void AddEffectSecondSkill(string Effect) { SkillTwoEffects.Add(Effect); }

    // this function will add to the effects the monster can apply on the third skill
    public void AddEffectThirdSkill(string Effect) { SkillThreeEffects.Add(Effect); }

    //this is the function that will set the monsters first skill multipler
    public void SetFirstSkillMultiplier(float Multiplier) { SkillOneMulitplier = Multiplier; }

    //this is the function that will set the monsters second skill multiplier
    public void SetSecondSkillMultipler(float Multiplier) { SkillTwoMultiplier = Multiplier; }

    // this is the function that will set the monsters third skill multiplier
    public void SetThirdSkillMultiplier(float Multiplier) { SkillThreeMultiplier = Multiplier; }

    //this functoin will set the monsters owner
    public void SetMonsterOwner(string OwnerName) { MonsterOwner = OwnerName; }
}
