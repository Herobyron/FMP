﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleUIScript : MonoBehaviour
{
    [Tooltip("this is the current Monster that is bieng used")]
    [SerializeField]
    private MonsterScript CurrentMonster = null;

    [Tooltip("this is the current Monster that is in game ")]
    [SerializeField]
    private int CurrentMonsterNum = 0;

    [Tooltip("this is a list of the current targets")]
    [SerializeField]
    private List<MonsterScript> Targets;

    [Tooltip("this is the current target for the monster when the monsters skill is not an AOE")]
    [SerializeField]
    private MonsterScript CurrentMonsterTarget = null;

    [Tooltip("this is the panel that allows the player to select a monster")]
    [SerializeField]
    private GameObject EnemySelectionPanel = null;

    [Tooltip("this is the panel that displays the monsters skill sectiption")]
    [SerializeField]
    private GameObject MonsterSKilldescription = null;

    [Tooltip("this is the skill that has been selected most recently")]
    [SerializeField]
    private int SkillSelectedNumber = 0;

    [Tooltip("this is a refernce to the battle UI")]
    [SerializeField]
    private BattleManager BattleManagerRef = null;

    // this is the UI text components for the current monsters stats
    [Tooltip("this is the current monsters current health")]
    [SerializeField]
    private Text CurrentMonsterCurrentHealth = null;

    [Tooltip("this is the current monsters Attack")]
    [SerializeField]
    private Text CurrentMonsterAttack = null;

    [Tooltip("this is the current monsters speed")]
    [SerializeField]
    private Text CurrentMonsterSpeed = null;

    [Tooltip("this is the current monsters defence")]
    [SerializeField]
    private Text CurrentMonsterDefence = null;

    // these are the text compoents for the skill decription and name
    [Tooltip("this is the text information on the skill number")]
    [SerializeField]
    private Text SkillNumberText = null;

    [Tooltip("this is the text information on the skill description")]
    [SerializeField]
    private Text SkillDescriptionText = null;

    // these are the gameobject used to display the current monster
    [Tooltip("this is the game object to show the first monster is the current monster")]
    [SerializeField]
    private GameObject CurrentMonOne;

    [Tooltip("this is the game object to show the Second monster is the current monster")]
    [SerializeField]
    private GameObject CurrentMonTwo;

    [Tooltip("this is the game object to show the Third monster is the current monster")]
    [SerializeField]
    private GameObject CurrentMonThree;

    // these are the UI objects that display the monsters effects
    [Tooltip("this is the game object that displays the first monsters current effects")]
    [SerializeField]
    private GameObject MonsterOneEffectDisplay = null;

    [Tooltip("this is the game object that displays the second monsters current effects")]
    [SerializeField]
    private GameObject MonsterTwoEffectDisplay = null;

    [Tooltip("this is the game object that displays the third monsters current effects")]
    [SerializeField]
    private GameObject MonsterThreeEffectDisplay = null;

    [Tooltip("this is the game object that displays the training dummy current effects")]
    [SerializeField]
    private GameObject TrainingDummyEffectDisplay = null;

    // these are the text elements for the damage numbers
    [Tooltip("this is the text component for the damage numbers for the monster one")]
    [SerializeField]
    private Text MonsterOneDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the monster Two")]
    [SerializeField]
    private Text MonsterTwoDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the monster Three")]
    [SerializeField]
    private Text MonsterThreeDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the monster Dummy")]
    [SerializeField]
    private Text MonsterDummyDamageText = null;


    // this the Effect Template for the Effects of the training dummy
    [Tooltip("Template for the effects for the training dummy")]
    [SerializeField]
    private GameObject DummyEffectTemplate = null;

    [Tooltip("Template for the effects for the First Monster")]
    [SerializeField]
    private GameObject MonsterOneEffectTemplate = null;

    [Tooltip("Template for the effects for the Second Monster")]
    [SerializeField]
    private GameObject MonsterTwoEffectTemplate = null;

    [Tooltip("Template for the effects for the Third Monster")]
    [SerializeField]
    private GameObject MonsterThreeEffectTemplate = null;

    // these are the list of effects currently bieng displayed for each of the monsters in the training scene
    [Tooltip("this is the list of buttons for the training dummy effects")]
    [SerializeField]
    private List<GameObject> TrainingDummyEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the Monster One effects")]
    [SerializeField]
    private List<GameObject> MonsterOneEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the Monster Two effects")]
    [SerializeField]
    private List<GameObject> MonsterTwoEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the Monster Three effects")]
    [SerializeField]
    private List<GameObject> MonsterThreeEffectButtons = new List<GameObject>();

    // this is all of the sprites for the monster effects
    [SerializeField]
    private Sprite AttackUp = null;

    [SerializeField]
    private Sprite AttackDown = null;

    [SerializeField]
    private Sprite Accuracy = null;

    [SerializeField]
    private Sprite CritRateBuff = null;

    [SerializeField]
    private Sprite CritRateDeBuff = null;

    [SerializeField]
    private Sprite DefenceUp = null;

    [SerializeField]
    private Sprite DefenceDown = null;

    [SerializeField]
    private Sprite Immunity = null;

    [SerializeField]
    private Sprite Shield = null;

    [SerializeField]
    private Sprite ImmunityDown = null;

    [SerializeField]
    private Sprite MissDeBuff = null;

    [SerializeField]
    private Sprite ShieldDeBuff = null;

    // this is the count for how many buttons has been created
    private int EffectButtonCount = 0;

    // these are all of the skills buttons when the player wants to use the skills
    [Tooltip("the button for skill two")]
    [SerializeField]
    private GameObject SkillTwoButton = null;

    [Tooltip("the button for skill three")]
    [SerializeField]
    private GameObject SkillThreeButton = null;

    // this is the text component to display for who the player to attack
    [Tooltip("this is the text component to tell the player what type of monster to target")]
    [SerializeField]
    private Text TargetSelectionText = null;

    // these are the three buttons the player can use to select the target
    [Tooltip("this is the button representing the first monster selection")]
    [SerializeField]
    private GameObject SelectionButtonOne = null;

    [Tooltip("this is the button representing the second monster selection")]
    [SerializeField]
    private GameObject SelectionButtpnTwo = null;

    [Tooltip("this is the button representing the third monster selection")]
    [SerializeField]
    private GameObject SelectionButtonThree = null;

    // these are the three text compoents for the three buttons the player can use to select the target
    [Tooltip("this is the text component for the first monster selection button")]
    [SerializeField]
    private Text MonsterSelectionOne = null;

    [Tooltip("this is the text component for the second monster selection button")]
    [SerializeField]
    private Text MonsterSelectionTwo = null;

    [Tooltip("this is the text component for the third monster selection button")]
    [SerializeField]
    private Text MonsterSelectionThree = null;

    // these are the text elements for the second and third skill cooldowns
    [Tooltip("this is the text component for the second skill of the monster")]
    [SerializeField]
    private Text SkillTwoCooldownText = null;

    [Tooltip("this is the text component for the third skill of the monster")]
    [SerializeField]
    private Text SkillThreeCooldownText = null;

    //these are the health components and UI objects for the monsters health bars

    [SerializeField]
    private Slider MonsterOneSlider = null;

    [SerializeField]
    private Slider MonsterTwoSlider = null;

    [SerializeField]
    private Slider MonsterThreeSlider = null;

    [SerializeField]
    private Slider TrainingDummySlider = null;


    // these are the text compoents for the secondary effect damage or healing numbers
    [SerializeField]
    private Text TrainingDummySeoncdaryDamageNumber = null;

    [SerializeField]
    private Text MonsterOneSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterTwoSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterThreeSeoncdaryDamageNumber = null;


    // these are the text components to display the monsters and training dummy level
    [SerializeField]
    private Text TrainingDummyLevelText = null;

    [SerializeField]
    private Text MonsterOneLevel = null;

    [SerializeField]
    private Text MonsterTwoLevel = null;

    [SerializeField]
    private Text MonsterThreeLevel = null;

    //these are all of the tutorial panels that will be used in the tutorial 
    [Tooltip("this is the tutorial one panel")]
    [SerializeField]
    private GameObject TutorialPanelOne = null;

    [Tooltip("this is the tutorial Two panel")]
    [SerializeField]
    private GameObject TutorialPanelTwo = null;

    [Tooltip("this is the tutorial three panel")]
    [SerializeField]
    private GameObject TutorialPanelThree = null;

    [Tooltip("this is the tutorial four panel")]
    [SerializeField]
    private GameObject TutorialPanelFour = null;

    [Tooltip("this is the tutorial five panel")]
    [SerializeField]
    private GameObject TutorialPanelFive = null;

    [Tooltip("this is the tutorial six panel")]
    [SerializeField]
    private GameObject TutorialPanelSix = null;

    [Tooltip("this is the tutorial Background")]
    [SerializeField]
    private GameObject TutorialBackground = null;

    // this is the text for the critical hit
    [SerializeField]
    private Text CritText = null;

    // this bool is made to make sure that the tutorial only runs once at the begining
    private bool once = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        LevelDisplaySet();

        if (!once)
        {
            StartCoroutine(BattleTutorialPlay());
            once = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        UpdateStatsDisplay();
    }

    // a function to set the current monster who will be used
    public void SetCurrentMonster(MonsterScript TheMon)
    {
        CurrentMonster = TheMon;
    }

    // function used at the start when all the monsters have been selected
    public void SetMonsterHealthBarsStart()
    {
        MonsterOneSlider.maxValue = BattleManagerRef.ReturnMonsterOne().ReturnCurrentHealth();
        MonsterOneSlider.value = BattleManagerRef.ReturnMonsterOne().ReturnCurrentHealth();

        MonsterTwoSlider.maxValue = BattleManagerRef.ReturnMonsterTwo().ReturnCurrentHealth();
        MonsterTwoSlider.value = BattleManagerRef.ReturnMonsterTwo().ReturnCurrentHealth();

        MonsterThreeSlider.maxValue = BattleManagerRef.ReturnMonsterThree().ReturnCurrentHealth();
        MonsterThreeSlider.value = BattleManagerRef.ReturnMonsterThree().ReturnCurrentHealth();

        TrainingDummySlider.maxValue = BattleManagerRef.ReturnTrainingDummy().ReturnCurrentHealth();
        TrainingDummySlider.value = BattleManagerRef.ReturnTrainingDummy().ReturnCurrentHealth();
    }

    // a functoin used to update the monsters current health
    // Params:
    // - health = the current health of the monster
    // - AOE = this determines if the skill is AOE
    // - monster = determines what monster to update when the skill isnt AOE (this is for healing)
    // - if it is damage or healing, damage will decrease and healing will increase the value
    public void SetMonsterCurrentHealthBar(bool AOE, string type)
    {
        if(AOE)
        {
            if(type == "Healing")
            {
                MonsterOneSlider.value = BattleManagerRef.ReturnMonsterOne().ReturnCurrentHealth();
                MonsterTwoSlider.value = BattleManagerRef.ReturnMonsterTwo().ReturnCurrentHealth();
                MonsterThreeSlider.value = BattleManagerRef.ReturnMonsterThree().ReturnCurrentHealth();
            }
            else
            {
                TrainingDummySlider.value = BattleManagerRef.ReturnTrainingDummy().ReturnCurrentHealth();
            }
        }
        else
        {
            if(type == "Healing")
            {
                if(CurrentMonsterTarget == BattleManagerRef.ReturnMonsterOne())
                {
                    MonsterOneSlider.value = BattleManagerRef.ReturnMonsterOne().ReturnCurrentHealth();
                }
                else if(CurrentMonsterTarget == BattleManagerRef.ReturnMonsterTwo())
                {
                    MonsterTwoSlider.value = BattleManagerRef.ReturnMonsterTwo().ReturnCurrentHealth();
                }
                else if(CurrentMonsterTarget == BattleManagerRef.ReturnMonsterThree())
                {
                    MonsterThreeSlider.value = BattleManagerRef.ReturnMonsterThree().ReturnCurrentHealth();
                }

            }
            else
            {
                TrainingDummySlider.value = BattleManagerRef.ReturnTrainingDummy().ReturnCurrentHealth();
            }
        }
    }


    // a function to update the skills display of the current monster
    public void UpdateSkillsDisplay(int SelectedSkill, MonsterSkillScript TheSkill)
    {
        SkillNumberText.text = "Skill Number: " + SelectedSkill;

        switch (TheSkill.GetSkillMainEffect())
        {
            case ("Healing"):
                {
                    if (TheSkill.ReturnSkillAOE())
                    {
                        SkillDescriptionText.text = "This Skill <color=orange>Heals</color> All Allies by a large amount. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill will also <color=orange>heal</color> all allies by a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply ";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " To All Allies. ";

                                    break;
                                }
                        }
                    }
                    else
                    {
                        SkillDescriptionText.text = "This Skill <color=orange>Heals</color> A single Ally by a large amount. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill will also <color=orange>heal</color> one ally by a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply ";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " To one Allies. ";

                                    break;
                                }
                        }

                    }
                    break;
                }
            case ("BeneficialEffect"):
                {
                    if (TheSkill.ReturnSkillAOE())
                    {
                        SkillDescriptionText.text = "this skill will apply ";

                        for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                        {
                            SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " To all Allies. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=orange>heal</color> all allies for a small amount. ";
                        }

                    }
                    else
                    {
                        SkillDescriptionText.text = "this skill will apply";

                        for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                        {
                            SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " To one Ally. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=orange>heal</color> one ally for a small amount. ";
                        }


                    }
                    break;
                }
            case ("HarmfulEffect"):
                {
                    if (TheSkill.ReturnSkillAOE())
                    {
                        SkillDescriptionText.text = "this skill applies ";

                        for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                        {
                            SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " to all enemies. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Damage")
                        {
                            SkillDescriptionText.text += "this skill will also apply <color=orange>damage</color> to all enemies proportiionate to your attack power. ";
                        }
                        else if(TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=orange>heal</color> you for a small amount. ";
                        }
                    }
                    else
                    {
                        SkillDescriptionText.text = "this skill applies ";

                        for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                        {
                            SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " to one enemy. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Damage")
                        {
                            SkillDescriptionText.text += "this skill will also apply <color=orange>damage</color> to one enemy proportiionate to your attack power. ";
                        }
                        else if (TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=orange>heal</color> you for a small amount. ";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if (TheSkill.ReturnSkillAOE())
                    {
                        SkillDescriptionText.text = "this skill applies <color=orange>damage</color> proportionate to your attack to all enemies monsters. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill also <color=orange>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " to all enemies. ";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillDescriptionText.text = "this skill applies <color=orange>damage</color> proportionate to your attack to one enemy monsters. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill also <color=orange>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=orange>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " to one enemy. ";


                                    break;
                                }
                        }
                    }

                    break;
                }
        }

    }    

    // a function to update the stats display of the current monster
    public void UpdateStatsDisplay()
    {
        CurrentMonsterCurrentHealth.text = "Health: " + CurrentMonster.ReturnCurrentHealth();
        CurrentMonsterAttack.text = "Attack: " + (CurrentMonster.ReturnBaseDamage() + CurrentMonster.ReturnIncreasedAttack());
        CurrentMonsterDefence.text = "Defence: " + (CurrentMonster.ReturnBaseDefence() + CurrentMonster.ReturnIncreasedDefence());
        CurrentMonsterSpeed.text = "Speed: " + (CurrentMonster.ReturnBaseSpeed() + CurrentMonster.ReturnIncreasedSpeed());
    }

    // a function that lets the player pick the target for the specific skill if its not aoe. 
    // if the skill is AOE then it sets all of the skils
    public void SkillTarget()
    {
        // this will need to be updated when using more then one target like haveing multiple enemies when fighting against AI
        Targets.Clear();
        Targets.Add(BattleManagerRef.ReturnTrainingDummy());

        if(CurrentMonster.GetMonsterSKills()[SkillSelectedNumber - 1].ReturnSkillAOE())
        {
            switch (SkillSelectedNumber)
            {
                case (1):
                    {
                        if(CurrentMonster.ReturnrSkillOneMainEffect() == "Healing" || CurrentMonster.ReturnrSkillOneMainEffect() == "BeneficialEffect")
                        {
                            StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[0], CurrentMonster.GetMonsterSKills()[0].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster)));
                        }
                        else
                        {
                            StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[0], CurrentMonster.GetMonsterSKills()[0].UseSkill(Targets, CurrentMonster)));
                            //CurrentMonster.GetMonsterSKills()[0].UseSkill(Targets, CurrentMonster);
                        }

                        SetMonsterCurrentHealthBar(true, CurrentMonster.ReturnrSkillOneMainEffect());
                        UpdateEffectsDisplay();
                        BattleManagerRef.EndCurrentTurn();
                        UpdateCurrentMonsterImage();
                        

                        break;
                    }
                case (2):
                    {
                        if (CurrentMonster.ReturnSkillTwoMainEffect() == "Healing" || CurrentMonster.ReturnSkillTwoMainEffect() == "BeneficialEffect")
                        {
                            //CurrentMonster.GetMonsterSKills()[1].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster);
                            StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster)));
                        }
                        else
                        {
                            StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(Targets, CurrentMonster)));
                            //CurrentMonster.GetMonsterSKills()[1].UseSkill(Targets, CurrentMonster);
                        }

                        SetMonsterCurrentHealthBar(true, CurrentMonster.ReturnSkillTwoMainEffect());
                        UpdateEffectsDisplay();
                        BattleManagerRef.EndCurrentTurn();
                        UpdateCurrentMonsterImage();
                        

                        break;
                    }
                case (3):
                    {
                        if (CurrentMonster.ReturnSkillThreeMainEffect() == "Healing" || CurrentMonster.ReturnSkillThreeMainEffect() == "BeneficialEffect")
                        {
                            //CurrentMonster.GetMonsterSKills()[2].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster);
                            StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster)));

                        }
                        else
                        {
                            StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(Targets, CurrentMonster)));
                            //CurrentMonster.GetMonsterSKills()[2].UseSkill(Targets, CurrentMonster);
                        }

                        SetMonsterCurrentHealthBar(true, CurrentMonster.ReturnSkillThreeMainEffect());
                        UpdateEffectsDisplay();
                        BattleManagerRef.EndCurrentTurn();
                        UpdateCurrentMonsterImage();
                        

                        break;
                    }
            }

            MonsterSKilldescription.SetActive(false);
        }
        else
        {

            switch (SkillSelectedNumber)
            {
                case (1):
                    {
                        if (CurrentMonster.ReturnrSkillOneMainEffect() == "Healing" || CurrentMonster.ReturnrSkillOneMainEffect() == "BeneficialEffect")
                        {
                            UpdateTargetdisplay("Health");
                        }
                        else
                        {
                            UpdateTargetdisplay("Damage");
                        }
                        break;
                    }
                case (2):
                    {
                        if (CurrentMonster.ReturnSkillTwoMainEffect() == "Healing" || CurrentMonster.ReturnSkillTwoMainEffect() == "BeneficialEffect")
                        {
                            UpdateTargetdisplay("Health");
                        }
                        else
                        {
                            UpdateTargetdisplay("Damage");
                        }
                        break;
                    }
                case (3):
                    {
                        if (CurrentMonster.ReturnSkillThreeMainEffect() == "Healing" || CurrentMonster.ReturnSkillThreeMainEffect() == "BeneficialEffect")
                        {
                            UpdateTargetdisplay("Health");
                        }
                        else
                        {
                            UpdateTargetdisplay("Damage");
                        }
                        break;
                    }
            }




            EnemySelectionPanel.SetActive(true);
            MonsterSKilldescription.SetActive(false);
        }
    }


    // a function to use the monster first skill
    // this function is specifically for when the skill is not an AOE and target is picked manually
    public void UseSkillOne()
    {
        int damagenumber = 0;
        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        damagenumber = CurrentMonster.GetMonsterSKills()[0].UseSkill(EnemyTarget, CurrentMonster);
        StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[0], damagenumber));
        SetMonsterCurrentHealthBar(false, CurrentMonster.ReturnrSkillOneMainEffect());
        BattleManagerRef.EndCurrentTurn();
        UpdateEffectsDisplay();
        UpdateCurrentMonsterImage();
        
    }

    // a function that uses the monsters second skill
    // this function is specifically for when the skill is not an AOE skill
    public void UseSkillTwo()
    {
        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(EnemyTarget, CurrentMonster)));
        SetMonsterCurrentHealthBar(false, CurrentMonster.ReturnSkillTwoMainEffect());
        BattleManagerRef.EndCurrentTurn();
        UpdateEffectsDisplay();
        UpdateCurrentMonsterImage();
        
    }

    // a function that uses the monsters third skill
    // this function is specifically for when the skill is not an AOE Skill
    public void UseSKillThree()
    {
        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        StartCoroutine(DamageTextDisplayTime(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(EnemyTarget, CurrentMonster)));
        SetMonsterCurrentHealthBar(false, CurrentMonster.ReturnSkillThreeMainEffect());
        BattleManagerRef.EndCurrentTurn();
        UpdateEffectsDisplay();
        UpdateCurrentMonsterImage();
        
    }


    // a function to use the monsters skills
    public void UseSkill()
    {
        switch (SkillSelectedNumber)
        {
            case (1):
                {

                    if (CurrentMonster.ReturnrSkillOneMainEffect() == "Healing" || CurrentMonster.ReturnrSkillOneMainEffect() == "BeneficialEffect")
                    {
                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterOne();
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterTwo();
                                    break;
                                }
                            case (2):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterThree();
                                    break;
                                }
                        }


                        //CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[BattleManagerRef.ReturnTargetMonsterNumber()];
                        UseSkillOne();
                    }
                    else
                    {
                        UseSkillOne();
                    }
                    break;
                }
            case (2):
                {
                    if(CurrentMonster.ReturnSkillTwoMainEffect() == "Healing" || CurrentMonster.ReturnSkillTwoMainEffect() == "BeneficialEffect")
                    {

                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterOne();
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterTwo();
                                    break;
                                }
                            case (2):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterThree();
                                    break;
                                }
                        }

                        //CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[BattleManagerRef.ReturnTargetMonsterNumber()];
                        UseSkillTwo();
                    }
                    else
                    {
                        UseSkillTwo();
                    }
                    
                    break;
                }
            case (3):
                {

                    if (CurrentMonster.ReturnSkillThreeMainEffect() == "Healing" || CurrentMonster.ReturnSkillThreeMainEffect() == "BeneficialEffect")
                    {

                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterOne();
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterTwo();
                                    break;
                                }
                            case (2):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnMonsterThree();
                                    break;
                                }
                        }


                        //CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[BattleManagerRef.ReturnTargetMonsterNumber()];
                        UseSKillThree();
                    }
                    else
                    {
                        UseSKillThree();
                    }
                    break;
                }
        }

    }



    // a function to be used to set all of the possible targets
    public void SetEnemyTargets(List<MonsterScript> EnemyTargets)
    {
        Targets = EnemyTargets;
    }


    // a function to set the current target monster when skill is not AOE
    public void SetEnemySingleTarget(MonsterScript Target)
    {
        CurrentMonsterTarget = Target;
    }

    public void SetSkillNumber(int num)
    {
        SkillSelectedNumber = num;
        UpdateSkillsDisplay(num, CurrentMonster.GetMonsterSKills()[num - 1]);
    }

    // a functoin that updates the display to show who the current monster is
    public void UpdateCurrentMonsterImage()
    {
        switch (CurrentMonsterNum)
        {
            case (1):
                {
                    CurrentMonOne.SetActive(true);
                    CurrentMonTwo.SetActive(false);
                    CurrentMonThree.SetActive(false);
                    break;
                }
            case (2):
                {
                    CurrentMonOne.SetActive(false);
                    CurrentMonTwo.SetActive(true);
                    CurrentMonThree.SetActive(false);
                    break;
                }
            case (3):
                {
                    CurrentMonOne.SetActive(false);
                    CurrentMonTwo.SetActive(false);
                    CurrentMonThree.SetActive(true);
                    break;
                }
        }

    }

    // a function used to updated the current monster number 
    public void SetCurrentMonsterNum(int MonsterNum)
    {
        CurrentMonsterNum = MonsterNum;
    }




    // this function is used to update the damage numbers so when a monster is healed or damage the number can be seen
    public void UpdateDamageNumberS(MonsterSkillScript TheSkill, int DamageNumber)
    {



        switch (TheSkill.GetSkillMainEffect())
        {
            case ("Damage"):
                {
                    MonsterDummyDamageText.gameObject.SetActive(true);
                    MonsterDummyDamageText.text = "<color=red>" + DamageNumber + "</color>";

                    if (TheSkill.ReturnCriticalLanded())
                    {
                        CritText.gameObject.SetActive(true);
                    }

                    break;
                }
            case ("Healing"):
                {
                    if (TheSkill.ReturnSkillAOE())
                    {
                        MonsterOneDamageText.gameObject.SetActive(true);
                        MonsterOneDamageText.text = "<color=green>" + DamageNumber + "</color>";

                        MonsterTwoDamageText.gameObject.SetActive(true);
                        MonsterTwoDamageText.text = "<color=green>" + DamageNumber + "</color>";

                        MonsterThreeDamageText.gameObject.SetActive(true);
                        MonsterThreeDamageText.text = "<color=green>" + DamageNumber + "</color>";
                    }
                    else
                    {

                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    MonsterOneDamageText.gameObject.SetActive(true);
                                    MonsterOneDamageText.text = "<color=green>" + DamageNumber + "</color>";
                                    break;
                                }
                            case (1):
                                {
                                    MonsterTwoDamageText.gameObject.SetActive(true);
                                    MonsterTwoDamageText.text = "<color=green>" + DamageNumber + "</color>";
                                    break;
                                }
                            case (2):
                                {
                                    MonsterThreeDamageText.gameObject.SetActive(true);
                                    MonsterThreeDamageText.text = "<color=green>" + DamageNumber + "</color>";
                                    break;
                                }
                        }
                    }

                    break;
                }
        }



    }

    // this function updates the display of the monsters effects
    // this takes the monster unsing the skill and the targets and updates thier 
    public void UpdateEffectsDisplay()
    {
        foreach(GameObject G in TrainingDummyEffectButtons)
        {
            Destroy(G);
        }

        foreach(GameObject G in MonsterOneEffectButtons)
        {
            Destroy(G);
        }

        foreach(GameObject G in MonsterTwoEffectButtons)
        {
            Destroy(G);
        }

        foreach(GameObject G in MonsterThreeEffectButtons)
        {
            Destroy(G);
        }

        TrainingDummyEffectButtons.Clear();
        MonsterOneEffectButtons.Clear();
        MonsterTwoEffectButtons.Clear();
        MonsterThreeEffectButtons.Clear();
        EffectButtonCount = 0;


        foreach(BeneficialEffects B in BattleManagerRef.ReturnTrainingDummy().ReturnBeneficialEffects())
        {
            GameObject NewButton = Instantiate(DummyEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = B.ReturnBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(DummyEffectTemplate.transform.parent, false);

            switch (B.ReturnBuffTypeString())
            {
                case ("Attack"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackUp;
                        break;
                    }
                case ("Accuracy"):
                    {
                        NewButton.GetComponent<Image>().sprite = Accuracy;
                        break;
                    }
                case ("CritRate"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateBuff;
                        break;
                    }
                case ("Defence"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceUp;
                        break;
                    }
                case ("Immunity"):
                    {
                        NewButton.GetComponent<Image>().sprite = Immunity;
                        break;
                    }
                case ("Shield"):
                    {
                        NewButton.GetComponent<Image>().sprite = Shield;
                        break;
                    }
            }

            TrainingDummyEffectButtons.Add(NewButton);
        }


        foreach(HarmfulEffects H in BattleManagerRef.ReturnTrainingDummy().ReturnHarmfulEffects())
        {
            GameObject NewButton = Instantiate(DummyEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = H.ReturnDeBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(DummyEffectTemplate.transform.parent, false);

            switch (H.ReturnDeBuffTypeString())
            {
                case ("AttackDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackDown;
                        break;
                    }
                case ("CritRateDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateDeBuff;
                        break;
                    }
                case ("DefenceDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceDown;
                        break;
                    }
                case ("ImmunityDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ImmunityDown;
                        break;
                    }
                case ("MissDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = MissDeBuff;
                        break;
                    }
                case ("ShieldDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ShieldDeBuff;
                        break;
                    }
            }

            TrainingDummyEffectButtons.Add(NewButton);
        }

        EffectButtonCount = 0;
        if(TrainingDummyEffectButtons.Count >= 1)
        {
            TrainingDummyEffectDisplay.SetActive(true);
        }

        foreach (BeneficialEffects B in BattleManagerRef.ReturnMonsterOne().ReturnBeneficialEffects())
        {
            GameObject NewButton = Instantiate(MonsterOneEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = B.ReturnBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(MonsterOneEffectTemplate.transform.parent, false);

            switch (B.ReturnBuffTypeString())
            {
                case ("Attack"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackUp;
                        break;
                    }
                case ("Accuracy"):
                    {
                        NewButton.GetComponent<Image>().sprite = Accuracy;
                        break;
                    }
                case ("CritRate"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateBuff;
                        break;
                    }
                case ("Defence"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceUp;
                        break;
                    }
                case ("Immunity"):
                    {
                        NewButton.GetComponent<Image>().sprite = Immunity;
                        break;
                    }
                case ("Shield"):
                    {
                        NewButton.GetComponent<Image>().sprite = Shield;
                        break;
                    }
            }

            MonsterOneEffectButtons.Add(NewButton);
        }


        foreach (HarmfulEffects H in BattleManagerRef.ReturnMonsterOne().ReturnHarmfulEffects())
        {
            GameObject NewButton = Instantiate(MonsterOneEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = H.ReturnDeBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(MonsterOneEffectTemplate.transform.parent, false);

            switch (H.ReturnDeBuffTypeString())
            {
                case ("AttackDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackDown;
                        break;
                    }
                case ("CritRateDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateDeBuff;
                        break;
                    }
                case ("DefenceDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceDown;
                        break;
                    }
                case ("ImmunityDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ImmunityDown;
                        break;
                    }
                case ("MissDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = MissDeBuff;
                        break;
                    }
                case ("ShieldDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ShieldDeBuff;
                        break;
                    }
            }

            MonsterOneEffectButtons.Add(NewButton);
        }

        EffectButtonCount = 0;

        if (MonsterOneEffectButtons.Count >= 1)
        {
            MonsterOneEffectDisplay.SetActive(true);
        }


        foreach (BeneficialEffects B in BattleManagerRef.ReturnMonsterTwo().ReturnBeneficialEffects())
        {
            GameObject NewButton = Instantiate(MonsterTwoEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = B.ReturnBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(MonsterTwoEffectTemplate.transform.parent, false);

            switch (B.ReturnBuffTypeString())
            {
                case ("Attack"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackUp;
                        break;
                    }
                case ("Accuracy"):
                    {
                        NewButton.GetComponent<Image>().sprite = Accuracy;
                        break;
                    }
                case ("CritRate"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateBuff;
                        break;
                    }
                case ("Defence"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceUp;
                        break;
                    }
                case ("Immunity"):
                    {
                        NewButton.GetComponent<Image>().sprite = Immunity;
                        break;
                    }
                case ("Shield"):
                    {
                        NewButton.GetComponent<Image>().sprite = Shield;
                        break;
                    }
            }

            MonsterTwoEffectButtons.Add(NewButton);
        }


        foreach (HarmfulEffects H in BattleManagerRef.ReturnMonsterTwo().ReturnHarmfulEffects())
        {
            GameObject NewButton = Instantiate(MonsterTwoEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = H.ReturnDeBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(MonsterTwoEffectTemplate.transform.parent, false);

            switch (H.ReturnDeBuffTypeString())
            {
                case ("AttackDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackDown;
                        break;
                    }
                case ("CritRateDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateDeBuff;
                        break;
                    }
                case ("DefenceDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceDown;
                        break;
                    }
                case ("ImmunityDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ImmunityDown;
                        break;
                    }
                case ("MissDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = MissDeBuff;
                        break;
                    }
                case ("ShieldDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ShieldDeBuff;
                        break;
                    }
            }

            MonsterTwoEffectButtons.Add(NewButton);
        }

        EffectButtonCount = 0;

        if (MonsterTwoEffectButtons.Count >= 1)
        {
            MonsterTwoEffectDisplay.SetActive(true);
        }


        foreach (BeneficialEffects B in BattleManagerRef.ReturnMonsterThree().ReturnBeneficialEffects())
        {
            GameObject NewButton = Instantiate(MonsterThreeEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = B.ReturnBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(MonsterThreeEffectTemplate.transform.parent, false);

            switch (B.ReturnBuffTypeString())
            {
                case ("Attack"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackUp;
                        break;
                    }
                case ("Accuracy"):
                    {
                        NewButton.GetComponent<Image>().sprite = Accuracy;
                        break;
                    }
                case ("CritRate"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateBuff;
                        break;
                    }
                case ("Defence"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceUp;
                        break;
                    }
                case ("Immunity"):
                    {
                        NewButton.GetComponent<Image>().sprite = Immunity;
                        break;
                    }
                case ("Shield"):
                    {
                        NewButton.GetComponent<Image>().sprite = Shield;
                        break;
                    }
            }

            MonsterThreeEffectButtons.Add(NewButton);
        }


        foreach (HarmfulEffects H in BattleManagerRef.ReturnMonsterThree().ReturnHarmfulEffects())
        {
            GameObject NewButton = Instantiate(MonsterThreeEffectTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = H.ReturnDeBuffTypeString();
            EffectButtonCount++;
            NewButton.transform.SetParent(MonsterThreeEffectTemplate.transform.parent, false);

            switch (H.ReturnDeBuffTypeString())
            {
                case ("AttackDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = AttackDown;
                        break;
                    }
                case ("CritRateDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = CritRateDeBuff;
                        break;
                    }
                case ("DefenceDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = DefenceDown;
                        break;
                    }
                case ("ImmunityDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ImmunityDown;
                        break;
                    }
                case ("MissDeBuff"):
                    {
                        NewButton.GetComponent<Image>().sprite = MissDeBuff;
                        break;
                    }
                case ("ShieldDown"):
                    {
                        NewButton.GetComponent<Image>().sprite = ShieldDeBuff;
                        break;
                    }
            }

            MonsterThreeEffectButtons.Add(NewButton);



        }

        if (MonsterThreeEffectButtons.Count >= 1)
        {
            MonsterThreeEffectDisplay.SetActive(true);
        }


    }
    
    // this function updates the skills cooldowns images depending on thier cooldown
    // this functoin checks the curent monster and then looks at its current available skills
    public void UpdateSkillCooldownDisplay()
    {
       
        if(CurrentMonster.GetMonsterSKills()[1].GetSkillCurrentCooldown() > 0)
        {
            SkillTwoButton.SetActive(true);
            SkillTwoCooldownText.text = "Cooldown: " + CurrentMonster.GetMonsterSKills()[1].GetSkillCurrentCooldown();
        }
        else
        {
            SkillTwoButton.SetActive(false);
        }

        if(CurrentMonster.GetMonsterSKills()[2].GetSkillCurrentCooldown() > 0)
        {
            SkillThreeButton.SetActive(true);
            SkillThreeCooldownText.text = "Cooldown: " + CurrentMonster.GetMonsterSKills()[2].GetSkillCurrentCooldown();
        }
        else
        {
            SkillThreeButton.SetActive(false);
        }

    }

    // this function updates the target display depending on the skill bieng used
    public void UpdateTargetdisplay(string SkillType)
    {
        if(SkillType == "Health")
        {
            TargetSelectionText.text = "Select a teammate to heal";
            SelectionButtonOne.SetActive(true);
            SelectionButtpnTwo.SetActive(true);
            SelectionButtonThree.SetActive(true);

            MonsterSelectionOne.text = "Ally One";
            MonsterSelectionTwo.text = "Ally Two";
            MonsterSelectionThree.text = "Ally Three";
        }
        else
        {
            TargetSelectionText.text = "Select the Target dummy";

            SelectionButtonOne.SetActive(false);
            SelectionButtpnTwo.SetActive(true);
            SelectionButtonThree.SetActive(false);

            MonsterSelectionTwo.text = "Training Dummy";
        }
    }

    // this function returns the first monsters health slider
    public Slider ReturnMonsterOneSlider()
    {
        return MonsterOneSlider;
    }

    // this function returns the second monsters health slider
    public Slider ReturnMonsterTwoSlider()
    {
        return MonsterTwoSlider;
    }

    // this function Returns  Monster Three slider
    public Slider ReturnMonsterThreeSlider()
    {
        return MonsterThreeSlider;
    }

    // this function returns training dummy slider
    public Slider ReturnTrainingDummySlider()
    {
        return TrainingDummySlider;
    }

    // this function sets the levels of all of the monsters at the beggining of the battle
    public void LevelDisplaySet()
    {
        TrainingDummyLevelText.text = "" + BattleManagerRef.ReturnTrainingDummy().ReturnMonsterLevel();
        MonsterOneLevel.text = "" + BattleManagerRef.ReturnMonsterOne().ReturnMonsterLevel();
        MonsterTwoLevel.text = "" + BattleManagerRef.ReturnMonsterTwo().ReturnMonsterLevel();
        MonsterThreeLevel.text = "" + BattleManagerRef.ReturnMonsterThree().ReturnMonsterLevel();
    }

    // this is the function that is used to display the tutorial
    // each panel will be available for five second before moving onto the next one
    IEnumerator BattleTutorialPlay()
    {
        TutorialBackground.SetActive(true);
        TutorialPanelOne.SetActive(false);
        TutorialPanelTwo.SetActive(false);
        TutorialPanelThree.SetActive(false);
        TutorialPanelFour.SetActive(false);
        TutorialPanelFive.SetActive(false);
        TutorialPanelSix.SetActive(false);

        for (float i = 0; i < 5.0f; i += Time.deltaTime)
        {
            TutorialPanelOne.SetActive(true);
            yield return null;
        }

        TutorialPanelOne.SetActive(false);

        for (float i = 0; i < 5.0f; i += Time.deltaTime)
        {
            TutorialPanelTwo.SetActive(true);
            yield return null;
        }

        TutorialPanelTwo.SetActive(false);

        for (float i = 0; i < 5.0f; i += Time.deltaTime)
        {
            TutorialPanelThree.SetActive(true);
            yield return null;
        }

        TutorialPanelThree.SetActive(false);

        for (float i = 0; i < 5.0f; i += Time.deltaTime)
        {
            TutorialPanelFour.SetActive(true);
            yield return null;
        }

        TutorialPanelFour.SetActive(false);

        for (float i = 0; i < 5.0f; i += Time.deltaTime)
        {
            TutorialPanelFive.SetActive(true);
            yield return null;
        }

        TutorialPanelFive.SetActive(false);

        for (float i = 0; i < 5.0f; i += Time.deltaTime)
        {
            TutorialPanelSix.SetActive(true);
            yield return null;
        }

        TutorialPanelSix.SetActive(false);

        TutorialBackground.SetActive(false);

        
    }


    // this is the enumerator to display the damage text for a small amount of time 
    IEnumerator DamageTextDisplayTime(float DisplayTime, MonsterSkillScript TheSkill, int DamageNumber)
    {
        MonsterOneSecondaryDamageNumber.gameObject.SetActive(true);
        MonsterTwoSecondaryDamageNumber.gameObject.SetActive(true);
        MonsterThreeSeoncdaryDamageNumber.gameObject.SetActive(true);

        MonsterOneSecondaryDamageNumber.text = "";
        MonsterTwoSecondaryDamageNumber.text = "";
        MonsterThreeSeoncdaryDamageNumber.text = "";

        int Temp = CurrentMonsterNum;

        for (float i = 0; i < DisplayTime; i+= Time.deltaTime)
        {
            UpdateDamageNumberS(TheSkill, DamageNumber);

            if(TheSkill.GetSkillSecondaryEffect() == "Healing")
            {
                if(TheSkill.ReturnSkillAOE())
                {
                    if(TheSkill.GetSkillMainEffect() == "Damage" || TheSkill.GetSkillMainEffect() == "HarmfulEffect")
                    {
                        switch (Temp)
                        {
                            case (1):
                                {
                                    MonsterOneSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                            case (2):
                                {
                                    MonsterTwoSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                            case (3):
                                {
                                    MonsterThreeSeoncdaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                        }

                    }
                    else
                    {
                        MonsterOneSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                        MonsterTwoSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                        MonsterThreeSeoncdaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                    }
                    
                }
                else
                {
                    if (TheSkill.GetSkillMainEffect() == "Healing" || TheSkill.GetSkillMainEffect() == "BeneficialEffect")
                    {
                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    MonsterOneSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                            case (1):
                                {
                                    MonsterTwoSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                            case (2):
                                {
                                    MonsterThreeSeoncdaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                        }
                    }
                    else if (TheSkill.GetSkillMainEffect() == "Damage" || TheSkill.GetSkillMainEffect() == "HarmfulEffect")
                    {
                        
                        switch (Temp)
                        {
                            case (1):
                                {
                                    MonsterOneSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                            case (2):
                                {
                                    MonsterTwoSecondaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                            case (3):
                                {
                                    MonsterThreeSeoncdaryDamageNumber.text = "<color=green>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    break;
                                }
                        }

                    }
                }
            }
            else if(TheSkill.GetSkillSecondaryEffect() == "Damage")
            {
                TrainingDummySeoncdaryDamageNumber.gameObject.SetActive(true);
                TrainingDummySeoncdaryDamageNumber.text = "<color=red>" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";

                if (TheSkill.ReturnCriticalLanded())
                {
                    CritText.gameObject.SetActive(true);
                }
            }


            

            yield return null;
        }


        MonsterDummyDamageText.gameObject.SetActive(false);
        MonsterOneDamageText.gameObject.SetActive(false);
        MonsterTwoDamageText.gameObject.SetActive(false);
        MonsterThreeDamageText.gameObject.SetActive(false);
        TrainingDummySeoncdaryDamageNumber.gameObject.SetActive(false);
        MonsterOneSecondaryDamageNumber.gameObject.SetActive(false);
        MonsterTwoSecondaryDamageNumber.gameObject.SetActive(false);
        MonsterThreeSeoncdaryDamageNumber.gameObject.SetActive(false);
        CritText.gameObject.SetActive(false);
    }





}
