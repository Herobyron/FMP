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
    [SerializeField]
    private List<HarmfulEffects> EffectsHarmful = new List<HarmfulEffects>();

    [Tooltip("this is the list of Beneficial effects that can be applied on the monster")]
    [SerializeField]
    private List<BeneficialEffects> EffectsBeneficial = new List<BeneficialEffects>();

    [Tooltip("a list of the names for all of the runes the monster has equiped")]
    [SerializeField]
    private List<string> RuneNames = new List<string>();

    [Tooltip("the Maximum amount of effects that the monster is able to hold")]
    [SerializeField]
    private int MaxEffects;

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
    private bool RunefourApplied = false;

    [Tooltip("a bool to determine if the fifth rune has been applied to the monsters base stats")]
    [SerializeField]
    private bool RuneFiveApplied = false;

    [Tooltip("a bool to determine if the sixth rune has been applied to the monsters base stats")]
    [SerializeField]
    private bool RuneSixApplied = false;

 
    //commment it 
    private enum Monsterstate {idle };

    [Tooltip("a enum to determine the monsters current state")]
    [SerializeField]
    private Monsterstate state = Monsterstate.idle;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
