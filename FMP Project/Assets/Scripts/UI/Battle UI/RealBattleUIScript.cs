﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealBattleUIScript : MonoBehaviour
{
    [Tooltip("this is the current Monster that is bieng used")]
    [SerializeField]
    private MonsterScript CurrentMonster = null;

    [Tooltip("this is the current Monster that is in game ")]
    [SerializeField]
    private int CurrentMonsterNum = 0;

    [Tooltip("this is a string that determines what side the current monster is on Player or AI")]
    [SerializeField]
    private string CurrentMonsterSide = "";

    [Tooltip("this is a list of the current targets")]
    [SerializeField]
    private List<MonsterScript> Targets;

    [Tooltip("this is the current target for the monster when the monsters skill is not an AOE")]
    [SerializeField]
    private MonsterScript CurrentMonsterTarget = null;

    [Tooltip("this is the monster target mainly for the AI")]
    [SerializeField]
    private List<MonsterScript> CurrentMonsterTargetsAI = null;

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

    [Tooltip("this is the game object to show the first enemy monster is the current monster")]
    [SerializeField]
    private GameObject EnemyMonOne;

    [Tooltip("this is the game object to show the second enemy monster is the current monster")]
    [SerializeField]
    private GameObject EnemyMonTwo;

    [Tooltip("this is the game object to show the third enemy monster is the current monster")]
    [SerializeField]
    private GameObject EnemyMonThree;

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

    [Tooltip("this is the game object that displays the first enemy monsters current effects")]
    [SerializeField]
    private GameObject EnemyOneEffectDisplay = null;

    [Tooltip("this is the game object that displays the second enemy monster current effects")]
    [SerializeField]
    private GameObject EnemyTwoEffectDisplay = null;

    [Tooltip("this is the game object that displays the third enemy monster current effects")]
    [SerializeField]
    private GameObject EnemyThreeEffectDisplay = null;



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

    [Tooltip("this is the text component for the damage numbers for the first enemy monster")]
    [SerializeField]
    private Text EnemyMonsterOneDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the second enemy monster")]
    [SerializeField]
    private Text EnemyMonsterTwoDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the third enemy monster")]
    [SerializeField]
    private Text EnemyMonsterThreeDamageText = null;


    // this the Effect Template for the Effects of the training dummy
    [Tooltip("Template for the effects for the first enemy monster")]
    [SerializeField]
    private GameObject EnemyOneEffectTemplate = null;

    [Tooltip("Template for the effects for the second enemy monster")]
    [SerializeField]
    private GameObject EnemyTwoEffectTemplate = null;

    [Tooltip("Template for the effects for the third enemy monster")]
    [SerializeField]
    private GameObject EnemyThreeEffectTemplate = null;

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
    [Tooltip("this is the list of buttons for the first enemy monster")]
    [SerializeField]
    private List<GameObject> EnemyOneEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the second enemy monster")]
    [SerializeField]
    private List<GameObject> EnemyTwoEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the third enemy monster")]
    [SerializeField]
    private List<GameObject> EnemyThreeEffectButtons = new List<GameObject>();

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
    private Slider EnemyOneSlider = null;

    [SerializeField]
    private Slider EnemyTwoSlider = null;

    [SerializeField]
    private Slider EnemyThreeSlider = null;


    // these are the text compoents for the secondary effect damage or healing numbers
    [SerializeField]
    private Text EnemyOneSecondaryDamageNumber = null;

    [SerializeField]
    private Text EnemyTwoSecondaryDamageNumber = null;

    [SerializeField]
    private Text EnemythreeSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterOneSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterTwoSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterThreeSeoncdaryDamageNumber = null;


    // these are the text components to display the monsters and training dummy level
    [SerializeField]
    private Text EnemyOneLevelText = null;

    [SerializeField]
    private Text EnemyTwoLevelText = null;

    [SerializeField]
    private Text EnemyThreeLevelText = null;

    [SerializeField]
    private Text MonsterOneLevel = null;

    [SerializeField]
    private Text MonsterTwoLevel = null;

    [SerializeField]
    private Text MonsterThreeLevel = null;


    // this is a panel that stops the player from selecting skills when its the AI's turn
    [Tooltip("Panel to stop player pressing skills with AI")]
    [SerializeField]
    private GameObject SkillBlockPanel = null;

    // this is a text component for the current monster. this is only used for text display because the monsters are switching positions too quickly for it to handle
    private string TheCurrentMonsterOwner = "";

    [SerializeField]
    private GameObject SummaryButtonPanel = null;

    [SerializeField]
    private Text SummaryMoveOne = null;

    [SerializeField]
    private Text SummaryMoveTwo = null;

    [SerializeField]
    private Text SummaryDamageOne = null;

    [SerializeField]
    private Text SummaryDamageTwo = null;


    // this is the animation stuff for the models (to test we will only be using the first enemy mon)
    [SerializeField]
    private Animator TheEnenmyOneAnimator = null;

    [SerializeField]
    private Animator TheEnemyTwoAnimator = null;

    [SerializeField]
    private Animator TheEnemyThreeAnimator = null;


    [SerializeField]
    private Animator ThePlayerOneAnimator = null;

    [SerializeField]
    private Animator ThePlayerTwoAnimator = null;

    [SerializeField]
    private Animator ThePlayerThreeAnimator = null;

    [SerializeField]
    private bool Animating = false;

    // this is all of the monster stats (used to disapear when the monster is dead)

    [SerializeField]
    private GameObject PlayerMonOneStats = null;

    [SerializeField]
    private GameObject PlayerMonTwoStats = null;

    [SerializeField]
    private GameObject PlayerMonThreeStats = null;

    [SerializeField]
    private GameObject EnemyMonOneStats = null;

    [SerializeField]
    private GameObject EnemyMonTwoStats = null;

    [SerializeField]
    private GameObject EnemyMonThreeStats = null;

    [Tooltip("this is the text element for when the player lands a critical hit")]
    [SerializeField]
    private Text CriticalHitText = null;

    private void OnEnable()
    {
        SetLevelDisplays();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMonsterStatsDisplay();
        BattleManagerRef.SetBattleStart(true);
    }

    // a function to update the monsters stat display
    public void UpdateMonsterStatsDisplay()
    {
        CurrentMonsterCurrentHealth.text = "Health: " + CurrentMonster.ReturnCurrentHealth();
        CurrentMonsterAttack.text = "Attack: " + (CurrentMonster.ReturnBaseDamage() + CurrentMonster.ReturnIncreasedAttack());
        CurrentMonsterDefence.text = "Defence: " + (CurrentMonster.ReturnBaseDefence() + CurrentMonster.ReturnIncreasedDefence());
        CurrentMonsterSpeed.text = "Speed: " + (CurrentMonster.ReturnBaseSpeed() + CurrentMonster.ReturnIncreasedSpeed());


        if(CurrentMonster.ReturnMonsterOwner() == "AI")
        {
            SkillBlockPanel.SetActive(true);
        }
        else
        {
            SkillBlockPanel.SetActive(false);
        }
    }

    // a function to set the levels of the monsters at the start of battle
    public void SetLevelDisplays()
    {
      
       MonsterOneLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterLevel();
       MonsterTwoLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterLevel();
       MonsterThreeLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterLevel();
       
       EnemyOneLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterLevel();
       EnemyTwoLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterLevel();
       EnemyThreeLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterLevel();

    }

    // a function to update who the current monster is
    public void UpdateCurrentMonsterIcon()
    {
        UpdateCurrentMonsterDisplayImage();
    }

    // this is a function used to update the health bar of the monster when a skill is used
    public void SetMonsterCurrentHealthBar(bool AOE)
    {
       
                MonsterOneSlider.value = BattleManagerRef.ReturnPlayerMonsters()[0].ReturnCurrentHealth();
                MonsterTwoSlider.value = BattleManagerRef.ReturnPlayerMonsters()[1].ReturnCurrentHealth();
                MonsterThreeSlider.value = BattleManagerRef.ReturnPlayerMonsters()[2].ReturnCurrentHealth();

                EnemyOneSlider.value = BattleManagerRef.ReturnEnemyMonsters()[0].ReturnCurrentHealth();
                EnemyTwoSlider.value = BattleManagerRef.ReturnEnemyMonsters()[1].ReturnCurrentHealth();
                EnemyThreeSlider.value = BattleManagerRef.ReturnEnemyMonsters()[2].ReturnCurrentHealth();

    
    }

    // this is a function that will update the skill display when a certain skill is pressed when its the players turn
    public void UpdateMonsterSkillDisplay(int SelectedSkill, MonsterSkillScript TheSkill)
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
                        else if (TheSkill.GetSkillSecondaryEffect() == "Healing")
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

    // a function that lets the player pick the target for the soecific skill if its not AOE
    // if the skill is AOE then it sets all of the skils
    public void SkillTarget()
    {
        Targets.Clear();

        if(CurrentMonster.GetMonsterSKills()[SkillSelectedNumber - 1].ReturnSkillAOE())
        {
            Targets.AddRange(BattleManagerRef.ReturnEnemyMonsters());

            switch (SkillSelectedNumber)
            {
                case (1):
                    {
                        // do the corutine for damage number whilst using monster skill one
                        if (CurrentMonster.ReturnrSkillOneMainEffect() == "Healing" || CurrentMonster.ReturnrSkillOneMainEffect() == "BeneficialEffect")
                        {
                            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
                            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[0], CurrentMonster.GetMonsterSKills()[0].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster)));
                        }
                        else
                        {
                            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
                            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[0], CurrentMonster.GetMonsterSKills()[0].UseSkill(Targets, CurrentMonster)));
                        }

                           
                        SetMonsterCurrentHealthBar(true);
                        UpdateEffectDisplay();
                        BattleManagerRef.EndCurrentTurnAIBattle();
                        UpdateCurrentMonsterIcon();
                        break;
                    }
                case (2):
                    {
                        // do the corutine for damage number whilst using monster skill two
                        if (CurrentMonster.ReturnSkillTwoMainEffect() == "Healing" || CurrentMonster.ReturnSkillTwoMainEffect() == "BeneficialEffect")
                        {
                            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
                            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster)));
                        }
                        else
                        {
                            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
                            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(Targets, CurrentMonster)));
                        }


                        SetMonsterCurrentHealthBar(true);
                        UpdateEffectDisplay();
                        BattleManagerRef.EndCurrentTurnAIBattle();
                        UpdateCurrentMonsterIcon();
                        break;
                    }
                case (3):
                    {
                        // do the corutine for damage number whilst using skill three
                        if (CurrentMonster.ReturnSkillThreeMainEffect() == "Healing" || CurrentMonster.ReturnSkillThreeMainEffect() == "BeneficialEffect")
                        {
                            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
                            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster)));
                        }
                        else
                        {
                            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
                            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(Targets, CurrentMonster)));
                        }


                        SetMonsterCurrentHealthBar(true);
                        UpdateEffectDisplay();
                        BattleManagerRef.EndCurrentTurnAIBattle();
                        UpdateCurrentMonsterIcon();
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
    public void UseSkillOneSingle()
    {
        
        List<MonsterScript> TheTarget = new List<MonsterScript>();
        TheTarget.Add(CurrentMonsterTarget);

        if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
        {
            ThePlayerOneAnimator.SetBool("Attacking", true);
        }
        else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
        {
            ThePlayerTwoAnimator.SetBool("Attacking", true);
        }
        else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
        {
            ThePlayerThreeAnimator.SetBool("Attacking", true);
        }

        TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
        StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[0], CurrentMonster.GetMonsterSKills()[0].UseSkill(TheTarget, CurrentMonster)));
        SetMonsterCurrentHealthBar(false);
        BattleManagerRef.EndCurrentTurnAIBattle();
        UpdateEffectDisplay();
        UpdateCurrentMonsterIcon();
    }

    // this is a function specifically suited to the AI monsters 
    // this function will act similar to the normal skill one but will be able to hold both AOE and non AOE scenarios
    public void UseSkillOneAI()
    {
        if (CurrentMonster.GetMonsterSKills()[0].ReturnSkillAOE())
        {
            //List<MonsterScript> TheTarget = new List<MonsterScript>();
            //TheTarget.AddRange(BattleManagerRef.ReturnPlayerMonsters());
            MonsterSkillScript TempSkill = CurrentMonster.GetMonsterSKills()[0];
            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
            MonsterScript TempMon = CurrentMonster;

            if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
            {
                TheEnenmyOneAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
            {
                TheEnemyTwoAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
            {
                TheEnemyThreeAnimator.SetBool("Attacking", true);
            }


            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[0], CurrentMonster.GetMonsterSKills()[0].UseSkill(CurrentMonsterTargetsAI, CurrentMonster)));
            SetMonsterCurrentHealthBar(false);
            BattleManagerRef.EndCurrentTurnAIBattle();
            UpdateEffectDisplay();
            UpdateCurrentMonsterIcon();
            EnableBattleSummary(TempSkill);
        }
        else
        {
            //List<MonsterScript> TheTarget = new List<MonsterScript>();
            //TheTarget.Add(CurrentMonsterTarget);
            MonsterSkillScript TempSkill = CurrentMonster.GetMonsterSKills()[0];
            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();

            if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
            {
                TheEnenmyOneAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
            {
                TheEnemyTwoAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
            {
                TheEnemyThreeAnimator.SetBool("Attacking", true);
            }


            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[0], CurrentMonster.GetMonsterSKills()[0].UseSkill(CurrentMonsterTargetsAI, CurrentMonster)));
            SetMonsterCurrentHealthBar(false);
            BattleManagerRef.EndCurrentTurnAIBattle();
            UpdateEffectDisplay();
            UpdateCurrentMonsterIcon();
            EnableBattleSummary(TempSkill);
        }
    }


    // a function to use the monster second skill
    // this function is specifically for when the skill is not an AOE and target is picked manually
    public void UseSKillTwoSingle()
    {

        List<MonsterScript> TheTarget = new List<MonsterScript>();
        TheTarget.Add(CurrentMonsterTarget);

        if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
        {
            ThePlayerOneAnimator.SetBool("Attacking", true);
        }
        else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
        {
            ThePlayerTwoAnimator.SetBool("Attacking", true);
        }
        else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
        {
            ThePlayerThreeAnimator.SetBool("Attacking", true);
        }


        TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
        StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(TheTarget, CurrentMonster)));
        SetMonsterCurrentHealthBar(false);
        BattleManagerRef.EndCurrentTurnAIBattle();
        UpdateEffectDisplay();
        UpdateCurrentMonsterIcon();
    }

    // this is a function specifically suited to the AI monsters 
    // this function will act similar to the normal skill one but will be able to hold both AOE and non AOE scenarios
    public void UseSkillTwoAI()
    {
        if (CurrentMonster.GetMonsterSKills()[1].ReturnSkillAOE())
        {
            //List<MonsterScript> TheTarget = new List<MonsterScript>();
            //TheTarget.AddRange(BattleManagerRef.ReturnPlayerMonsters());
            MonsterSkillScript TempSkill = CurrentMonster.GetMonsterSKills()[1];
            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();

            if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
            {
                TheEnenmyOneAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
            {
                TheEnemyTwoAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
            {
                TheEnemyThreeAnimator.SetBool("Attacking", true);
            }


            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(CurrentMonsterTargetsAI, CurrentMonster)));
            SetMonsterCurrentHealthBar(false);
            BattleManagerRef.EndCurrentTurnAIBattle();
            UpdateEffectDisplay();
            UpdateCurrentMonsterIcon();
            EnableBattleSummary(TempSkill);
        }
        else
        {
            //List<MonsterScript> TheTarget = new List<MonsterScript>();
            //TheTarget.Add(CurrentMonsterTarget);
            MonsterSkillScript TempSkill = CurrentMonster.GetMonsterSKills()[1];
            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();

            if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
            {
                TheEnenmyOneAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
            {
                TheEnemyTwoAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
            {
                TheEnemyThreeAnimator.SetBool("Attacking", true);
            }


            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[1], CurrentMonster.GetMonsterSKills()[1].UseSkill(CurrentMonsterTargetsAI, CurrentMonster)));
            SetMonsterCurrentHealthBar(false);
            BattleManagerRef.EndCurrentTurnAIBattle();
            UpdateEffectDisplay();
            UpdateCurrentMonsterIcon();
            EnableBattleSummary(TempSkill);
        }
    }



    // a function to use the monster third skill
    // this function is specifically for when the skill is not an AOE and target is picked manually
    public void USeSkillThreeSingle()
    {

        List<MonsterScript> TheTarget = new List<MonsterScript>();
        TheTarget.Add(CurrentMonsterTarget);

        if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
        {
            ThePlayerOneAnimator.SetBool("Attacking", true);
        }
        else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
        {
            ThePlayerTwoAnimator.SetBool("Attacking", true);
        }
        else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
        {
            ThePlayerThreeAnimator.SetBool("Attacking", true);
        }


        TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
        StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(TheTarget, CurrentMonster)));
        SetMonsterCurrentHealthBar(false);
        BattleManagerRef.EndCurrentTurnAIBattle();
        UpdateEffectDisplay();
        UpdateCurrentMonsterIcon();
    }

    // this is a function specifically suited to the AI monsters 
    // this function will act similar to the normal skill one but will be able to hold both AOE and non AOE scenarios
    public void UseSkillThreeAI()
    {
        if (CurrentMonster.GetMonsterSKills()[2].ReturnSkillAOE())
        {
            //List<MonsterScript> TheTarget = new List<MonsterScript>();
            //TheTarget.AddRange(BattleManagerRef.ReturnPlayerMonsters());
            MonsterSkillScript TempSkill = CurrentMonster.GetMonsterSKills()[2];
            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();


            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(CurrentMonsterTargetsAI, CurrentMonster)));

            if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
            {
                TheEnenmyOneAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
            {
                TheEnemyTwoAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
            {
                TheEnemyThreeAnimator.SetBool("Attacking", true);
            }

            SetMonsterCurrentHealthBar(false);
            BattleManagerRef.EndCurrentTurnAIBattle();
            UpdateEffectDisplay();
            UpdateCurrentMonsterIcon();
            EnableBattleSummary(TempSkill);
        }
        else
        {
            //List<MonsterScript> TheTarget = new List<MonsterScript>();
            //TheTarget.Add(CurrentMonsterTarget);
            MonsterSkillScript TempSkill = CurrentMonster.GetMonsterSKills()[2];
            TheCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();

            StartCoroutine(DamageDisplayTextTIme(3.0f, CurrentMonster.GetMonsterSKills()[2], CurrentMonster.GetMonsterSKills()[2].UseSkill(CurrentMonsterTargetsAI, CurrentMonster)));

            if(CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
            {
                TheEnenmyOneAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
            {
                TheEnemyTwoAnimator.SetBool("Attacking", true);
            }
            else if (CurrentMonster.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
            {
                TheEnemyThreeAnimator.SetBool("Attacking", true);
            }

            SetMonsterCurrentHealthBar(false);
            BattleManagerRef.EndCurrentTurnAIBattle();
            UpdateEffectDisplay();
            UpdateCurrentMonsterIcon();
            EnableBattleSummary(TempSkill);
        }
    }

    public void EnableBattleSummary(MonsterSkillScript TheSkill)
    {
        BattleManagerRef.BattleSummarySet(true);
        SummaryButtonPanel.SetActive(true);

        SummaryMoveOne.text = "";
        SummaryMoveTwo.text = "";

        if(TheSkill.ReturnSkillAOE())
        {
            switch (TheSkill.GetSkillMainEffect())
            {
                case ("Healing"):
                    {
                        SummaryMoveOne.text = "The Enemy healed all of thier allies";
                        break;
                    }
                case ("Damage"):
                    {
                        SummaryMoveOne.text = "The Enemy damaged all of your monsters";
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        SummaryMoveOne.text = "The Enemy applied ";
                        
                        foreach(string H in TheSkill.GetSkillEffects())
                        {
                            SummaryMoveOne.text += "<color=darkblue> " + H + " " + " </color>";
                        }

                        SummaryMoveOne.text += "To all your monsters";
                        break;
                    }
                case ("BeneficialEffect"):
                    {
                        SummaryMoveOne.text = "The Enemy applied ";

                        foreach (string H in TheSkill.GetSkillEffects())
                        {
                            SummaryMoveOne.text += "<color=darkblue> " + H + " " + " </color>";
                        }

                        SummaryMoveOne.text += "To all Thier monsters";
                        break;
                    }
            }

            if (TheSkill.GetSkillSecondaryEffect() != "")
            {
                SummaryMoveTwo.gameObject.SetActive(true);

                switch (TheSkill.GetSkillSecondaryEffect())
                {
                    case ("Healing"):
                        {
                            SummaryMoveTwo.text = "The Enemy also healed all of thier allies";
                            break;
                        }
                    case ("Damage"):
                        {
                            SummaryMoveTwo.text = "The Enemy also damaged all of your monsters";
                            break;
                        }
                    case ("HarmfulEffect"):
                        {
                            SummaryMoveTwo.text = "The Enemy also applied ";

                            foreach (string H in TheSkill.GetSkillEffects())
                            {
                                SummaryMoveTwo.text += "<color=darkblue> " + H + " " + " </color>";
                            }

                            SummaryMoveTwo.text += "To all your monsters";
                            break;
                        }
                    case ("BeneficialEffect"):
                        {
                            SummaryMoveTwo.text = "The Enemy also applied ";

                            foreach (string H in TheSkill.GetSkillEffects())
                            {
                                SummaryMoveTwo.text += "<color=darkblue> " + H + " " + " </color>";
                            }

                            SummaryMoveTwo.text += "To all Thier monsters";
                            break;
                        }
                }
            }
            else
            {
                SummaryMoveTwo.text = "";
            }


        }
        else
        {
            switch (TheSkill.GetSkillMainEffect())
            {
                case ("Healing"):
                    {
                        SummaryMoveOne.text = "The Enemy healed One of thier allies";
                        break;
                    }
                case ("Damage"):
                    {
                        SummaryMoveOne.text = "The Enemy damaged One of your monsters";
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        SummaryMoveOne.text = "The Enemy applied ";

                        foreach (string H in TheSkill.GetSkillEffects())
                        {
                            SummaryMoveOne.text += "<color=darkblue>" + H + " " + "</color>";
                        }

                        SummaryMoveOne.text += "To One your monsters";
                        break;
                    }
                case ("BeneficialEffect"):
                    {
                        SummaryMoveOne.text = "The Enemy applied ";

                        foreach (string H in TheSkill.GetSkillEffects())
                        {
                            SummaryMoveOne.text += "<color=darkblue>" + H + " " + "</color>";
                        }

                        SummaryMoveOne.text += "To One Thier monsters";
                        break;
                    }
            }

            if (TheSkill.GetSkillSecondaryEffect() != "")
            {
                SummaryMoveTwo.gameObject.SetActive(true);

                switch (TheSkill.GetSkillSecondaryEffect())
                {
                    case ("Healing"):
                        {
                            SummaryMoveTwo.text = "The Enemy also healed One of thier allies";
                            break;
                        }
                    case ("Damage"):
                        {
                            SummaryMoveTwo.text = "The Enemy also damaged One of your monsters";
                            break;
                        }
                    case ("HarmfulEffect"):
                        {
                            SummaryMoveTwo.text = "The Enemy also applied ";

                            foreach (string H in TheSkill.GetSkillEffects())
                            {
                                SummaryMoveTwo.text += "<color=darkblue>" + H + " " + "</color>";
                            }

                            SummaryMoveTwo.text += "To One your monsters";
                            break;
                        }
                    case ("BeneficialEffect"):
                        {
                            SummaryMoveTwo.text = "The Enemy also applied ";

                            foreach (string H in TheSkill.GetSkillEffects())
                            {
                                SummaryMoveTwo.text += "<color=darkblue>" + H + " " + "</color>";
                            }

                            SummaryMoveTwo.text += "To One Thier monsters";
                            break;
                        }
                }
            }
        }

    }

    // a function that uses the monster skills 
    // this is using single target attacks and not AOE skills
    public void UseTheSKill()
    {
        switch (SkillSelectedNumber)
        {
            case (1):
                {
                    if(CurrentMonster.ReturnrSkillOneMainEffect() == "Healing" || CurrentMonster.ReturnrSkillOneMainEffect() == "BeneficialEffect")
                    {
                        switch(BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[0];
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[1];
                                    break;
                                }
                            case (2):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[2];
                                    break;
                                }
                        }

                        UseSkillOneSingle();
                    }
                    else
                    {
                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[0];
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[1];
                                    break;
                                }
                            case (2):
                                {

                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[2];
                                    break;
                                }
                        }

                        UseSkillOneSingle();
                    }

                    break;
                }
            case (2):
                {
                    if (CurrentMonster.ReturnSkillTwoMainEffect() == "Healing" || CurrentMonster.ReturnSkillTwoMainEffect() == "BeneficialEffect")
                    {
                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[0];
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[1];
                                    break;
                                }
                            case (2):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[2];
                                    break;
                                }
                        }

                        UseSKillTwoSingle();
                    }
                    else
                    {
                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[0];
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[1];
                                    break;
                                }
                            case (2):
                                {

                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[2];
                                    break;
                                }
                        }

                        UseSKillTwoSingle();
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
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[0];
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[1];
                                    break;
                                }
                            case (2):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[2];
                                    break;
                                }
                        }

                        USeSkillThreeSingle();
                    }
                    else
                    {
                        switch (BattleManagerRef.ReturnTargetMonsterNumber())
                        {
                            case (0):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[0];
                                    break;
                                }
                            case (1):
                                {
                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[1];
                                    break;
                                }
                            case (2):
                                {

                                    CurrentMonsterTarget = BattleManagerRef.ReturnEnemyMonsters()[2];
                                    break;
                                }
                        }

                        USeSkillThreeSingle();
                    }

                    break;
                }
        }

    }

    // a function to set the enemy target when skill is a single target attack
    public void SetEnemySingleTarget(MonsterScript Target)
    {
        CurrentMonsterTarget = Target;
    }

    public void SetEnemyTargets(List<MonsterScript> Targets)
    {
        CurrentMonsterTargetsAI = Targets;
    }

    // a function to set the skill number of the skill that is bieng used for displaying
    public void SetSkillNumber(int Num)
    {
        SkillSelectedNumber = Num;
        UpdateMonsterSkillDisplay(Num, CurrentMonster.GetMonsterSKills()[Num - 1]);
    }

    // a function that update the display to show who the current monster is
    public void UpdateCurrentMonsterDisplayImage()
    {
        List<MonsterScript> MonsterList = new List<MonsterScript>();
        MonsterList.AddRange(BattleManagerRef.ReturnPlayerMonsters());
        MonsterList.AddRange(BattleManagerRef.ReturnEnemyMonsters());

        if (CurrentMonster.ReturnMonsterName() == MonsterList[0].ReturnMonsterName())
        {
            CurrentMonOne.SetActive(true);
            CurrentMonTwo.SetActive(false);
            CurrentMonThree.SetActive(false);
            EnemyMonOne.SetActive(false);
            EnemyMonTwo.SetActive(false);
            EnemyMonThree.SetActive(false);
        }
        else if (CurrentMonster.ReturnMonsterName() == MonsterList[1].ReturnMonsterName())
        {
            CurrentMonOne.SetActive(false);
            CurrentMonTwo.SetActive(true);
            CurrentMonThree.SetActive(false);
            EnemyMonOne.SetActive(false);
            EnemyMonTwo.SetActive(false);
            EnemyMonThree.SetActive(false);
        }
        else if(CurrentMonster.ReturnMonsterName() == MonsterList[2].ReturnMonsterName())
        {
            CurrentMonOne.SetActive(false);
            CurrentMonTwo.SetActive(false);
            CurrentMonThree.SetActive(true);
            EnemyMonOne.SetActive(false);
            EnemyMonTwo.SetActive(false);
            EnemyMonThree.SetActive(false);
        }
        else if(CurrentMonster.ReturnMonsterName() == MonsterList[3].ReturnMonsterName())
        {
            CurrentMonOne.SetActive(false);
            CurrentMonTwo.SetActive(false);
            CurrentMonThree.SetActive(false);
            EnemyMonOne.SetActive(true);
            EnemyMonTwo.SetActive(false);
            EnemyMonThree.SetActive(false);
        }
        else if(CurrentMonster.ReturnMonsterName() == MonsterList[4].ReturnMonsterName())
        {
            CurrentMonOne.SetActive(false);
            CurrentMonTwo.SetActive(false);
            CurrentMonThree.SetActive(false);
            EnemyMonOne.SetActive(false);
            EnemyMonTwo.SetActive(true);
            EnemyMonThree.SetActive(false);
        }
        else if(CurrentMonster.ReturnMonsterName() == MonsterList[5].ReturnMonsterName())
        {
            CurrentMonOne.SetActive(false);
            CurrentMonTwo.SetActive(false);
            CurrentMonThree.SetActive(false);
            EnemyMonOne.SetActive(false);
            EnemyMonTwo.SetActive(false);
            EnemyMonThree.SetActive(true);
        }

    }

    // this function is used to update the damage numvers so when a monster is healed or damaged the number can be seen
    public void UpdateMonsterDamageNumber(MonsterSkillScript TheSkill, int DamageNumber, string MonsterOwner, int TargetNumber)
    {
        switch (TheSkill.GetSkillMainEffect())
        {
            case ("Damage"):
                {
                    if(TheSkill.ReturnSkillAOE())
                    {
                        if(MonsterOwner == "Player")
                        {
                            if (!BattleManagerRef.ReturnEnemyMonOneDead())
                            {
                                EnemyMonsterOneDamageText.gameObject.SetActive(true);
                                EnemyMonsterOneDamageText.text = "<color=red>" + DamageNumber + "</color>";
                            }

                            if (!BattleManagerRef.ReturnEnemyMonTwoDead())
                            {
                                EnemyMonsterTwoDamageText.gameObject.SetActive(true);
                                EnemyMonsterTwoDamageText.text = "<color=red>" + DamageNumber + "</color>";
                            }


                            if (!BattleManagerRef.ReturnEnemyMonThreeDead())
                            {
                                EnemyMonsterThreeDamageText.gameObject.SetActive(true);
                                EnemyMonsterThreeDamageText.text = "<color=red>" + DamageNumber + "</color>";
                            }
                        }
                        else
                        {

                            if (!BattleManagerRef.ReturnPlayerMonOneDead())
                            {
                                MonsterOneDamageText.gameObject.SetActive(true);
                                MonsterOneDamageText.text = "<color=red>" + DamageNumber + "</color>";
                            }

                            if (!BattleManagerRef.ReturnPlayerMonTwoDead())
                            {
                                MonsterTwoDamageText.gameObject.SetActive(true);
                                MonsterTwoDamageText.text = "<color=red>" + DamageNumber + "</color>";
                            }


                            if (!BattleManagerRef.ReturnPlayerMonThreeDead())
                            {
                                MonsterThreeDamageText.gameObject.SetActive(true);
                                MonsterThreeDamageText.text = "<color=red>" + DamageNumber + "</color>";
                            }

                        }
                    }
                    else
                    {

                        if (MonsterOwner == "Player")
                        {

                            switch (TargetNumber)
                            {
                                case (0):
                                    {
                                        EnemyMonsterOneDamageText.gameObject.SetActive(true);
                                        EnemyMonsterOneDamageText.text = "<color=red>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (1):
                                    {
                                        EnemyMonsterTwoDamageText.gameObject.SetActive(true);
                                        EnemyMonsterTwoDamageText.text = "<color=red>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (2):
                                    {
                                        EnemyMonsterThreeDamageText.gameObject.SetActive(true);
                                        EnemyMonsterThreeDamageText.text = "<color=red>" + DamageNumber + "</color>";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            
                            switch (TargetNumber)
                            {
                                case (0):
                                    {
                                        MonsterOneDamageText.gameObject.SetActive(true);
                                        MonsterOneDamageText.text = "<color=red>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (1):
                                    {
                                        MonsterTwoDamageText.gameObject.SetActive(true);
                                        MonsterTwoDamageText.text = "<color=red>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (2):
                                    {
                                        MonsterThreeDamageText.gameObject.SetActive(true);
                                        MonsterThreeDamageText.text = "<color=red>" + DamageNumber + "</color>";
                                        break;
                                    }
                            }

                        }

                       
                    }

                    break;
                }
            case ("Healing"):
                {
                    if (TheSkill.ReturnSkillAOE())
                    {
                        if (MonsterOwner == "Player")
                        {
                            if (!BattleManagerRef.ReturnPlayerMonOneDead())
                            {
                                MonsterOneSecondaryDamageNumber.gameObject.SetActive(true);
                                MonsterOneSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                            }

                            if (!BattleManagerRef.ReturnPlayerMonTwoDead())
                            {
                                MonsterTwoSecondaryDamageNumber.gameObject.SetActive(true);
                                MonsterTwoSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                            }

                            if (!BattleManagerRef.ReturnPlayerMonThreeDead())
                            {
                                MonsterThreeSeoncdaryDamageNumber.gameObject.SetActive(true);
                                MonsterThreeSeoncdaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                            }
                        }
                        else
                        {

                            if (!BattleManagerRef.ReturnEnemyMonOneDead())
                            {
                                EnemyOneSecondaryDamageNumber.gameObject.SetActive(true);
                                EnemyOneSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                            }

                            if (!BattleManagerRef.ReturnEnemyMonTwoDead())
                            {
                                EnemyTwoSecondaryDamageNumber.gameObject.SetActive(true);
                                EnemyTwoSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                            }


                            if (!BattleManagerRef.ReturnEnemyMonThreeDead())
                            {
                                EnemythreeSecondaryDamageNumber.gameObject.SetActive(true);
                                EnemythreeSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                            }
                        }
                    }
                    else
                    {
                        if (MonsterOwner == "Player")
                        {
                            switch (TargetNumber)
                            {
                                case (0):
                                    {
                                        MonsterOneSecondaryDamageNumber.gameObject.SetActive(true);
                                        MonsterOneSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (1):
                                    {
                                        MonsterTwoSecondaryDamageNumber.gameObject.SetActive(true);
                                        MonsterTwoSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (2):
                                    {
                                        MonsterThreeSeoncdaryDamageNumber.gameObject.SetActive(true);
                                        MonsterThreeSeoncdaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                                        break;
                                    }
                            }


                           
                        }
                        else
                        {

                            switch (TargetNumber)
                            {
                                case (0):
                                    {
                                        EnemyOneSecondaryDamageNumber.gameObject.SetActive(true);
                                        EnemyOneSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (1):
                                    {
                                        EnemyTwoSecondaryDamageNumber.gameObject.SetActive(true);
                                        EnemyTwoSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                                        break;
                                    }
                                case (2):
                                    {
                                        EnemythreeSecondaryDamageNumber.gameObject.SetActive(true);
                                        EnemythreeSecondaryDamageNumber.text = "<color=green>" + DamageNumber + "</color>";
                                        break;
                                    }
                            }

                        }
                    }
                        break;
                }
        }

    }

    // this function will be used to update the effects for all of the monsters that are on the field
    // it is done for all monsters no matter who the skill is used by
    public void UpdateEffectDisplay()
    {
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

        foreach(GameObject G in EnemyOneEffectButtons)
        {
            Destroy(G);
        }

        foreach(GameObject G in EnemyTwoEffectButtons)
        {
            Destroy(G);
        }

        foreach(GameObject G in EnemyThreeEffectButtons)
        {
            Destroy(G);
        }

        MonsterOneEffectButtons.Clear();
        MonsterTwoEffectButtons.Clear();
        MonsterThreeEffectButtons.Clear();
        EnemyOneEffectButtons.Clear();
        EnemyTwoEffectButtons.Clear();
        EnemyThreeEffectButtons.Clear();
        EffectButtonCount = 0;


        // player monster one
        if (!BattleManagerRef.ReturnPlayerMonOneDead())
        {


            foreach (BeneficialEffects B in BattleManagerRef.ReturnPlayerMonsters()[0].ReturnBeneficialEffects())
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


            foreach (HarmfulEffects H in BattleManagerRef.ReturnPlayerMonsters()[0].ReturnHarmfulEffects())
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
        }


        // player monster two
        if (!BattleManagerRef.ReturnPlayerMonTwoDead())
        {
            foreach (BeneficialEffects B in BattleManagerRef.ReturnPlayerMonsters()[1].ReturnBeneficialEffects())
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


            foreach (HarmfulEffects H in BattleManagerRef.ReturnPlayerMonsters()[1].ReturnHarmfulEffects())
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

        }

        // player monster three
        if (!BattleManagerRef.ReturnPlayerMonThreeDead())
        {
            foreach (BeneficialEffects B in BattleManagerRef.ReturnPlayerMonsters()[2].ReturnBeneficialEffects())
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


            foreach (HarmfulEffects H in BattleManagerRef.ReturnPlayerMonsters()[2].ReturnHarmfulEffects())
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

            EffectButtonCount = 0;

            if (MonsterThreeEffectButtons.Count >= 1)
            {
                MonsterThreeEffectDisplay.SetActive(true);
            }
        }

        // the enemys first monster effects
        if (!BattleManagerRef.ReturnEnemyMonOneDead())
        {
            foreach (BeneficialEffects B in BattleManagerRef.ReturnEnemyMonsters()[0].ReturnBeneficialEffects())
            {
                GameObject NewButton = Instantiate(EnemyOneEffectTemplate) as GameObject;
                NewButton.SetActive(true);
                NewButton.name = B.ReturnBuffTypeString();
                EffectButtonCount++;
                NewButton.transform.SetParent(EnemyOneEffectTemplate.transform.parent, false);

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

                EnemyOneEffectButtons.Add(NewButton);
            }


            foreach (HarmfulEffects H in BattleManagerRef.ReturnEnemyMonsters()[0].ReturnHarmfulEffects())
            {
                GameObject NewButton = Instantiate(EnemyOneEffectTemplate) as GameObject;
                NewButton.SetActive(true);
                NewButton.name = H.ReturnDeBuffTypeString();
                EffectButtonCount++;
                NewButton.transform.SetParent(EnemyOneEffectTemplate.transform.parent, false);

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

                EnemyOneEffectButtons.Add(NewButton);
            }

            EffectButtonCount = 0;

            if (EnemyOneEffectButtons.Count >= 1)
            {
                EnemyOneEffectDisplay.SetActive(true);
            }
        }

        // the effects for the second enemy monster
        if (!BattleManagerRef.ReturnEnemyMonTwoDead())
        {
            foreach (BeneficialEffects B in BattleManagerRef.ReturnEnemyMonsters()[1].ReturnBeneficialEffects())
            {
                GameObject NewButton = Instantiate(EnemyTwoEffectTemplate) as GameObject;
                NewButton.SetActive(true);
                NewButton.name = B.ReturnBuffTypeString();
                EffectButtonCount++;
                NewButton.transform.SetParent(EnemyTwoEffectTemplate.transform.parent, false);

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

                EnemyTwoEffectButtons.Add(NewButton);
            }


            foreach (HarmfulEffects H in BattleManagerRef.ReturnEnemyMonsters()[1].ReturnHarmfulEffects())
            {
                GameObject NewButton = Instantiate(EnemyTwoEffectTemplate) as GameObject;
                NewButton.SetActive(true);
                NewButton.name = H.ReturnDeBuffTypeString();
                EffectButtonCount++;
                NewButton.transform.SetParent(EnemyTwoEffectTemplate.transform.parent, false);

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

                EnemyTwoEffectButtons.Add(NewButton);
            }

            EffectButtonCount = 0;

            if (EnemyTwoEffectButtons.Count >= 1)
            {
                EnemyTwoEffectDisplay.SetActive(true);
            }
        }

        // enemy three effects display
        if (!BattleManagerRef.ReturnEnemyMonThreeDead())
        {
            foreach (BeneficialEffects B in BattleManagerRef.ReturnEnemyMonsters()[2].ReturnBeneficialEffects())
            {
                GameObject NewButton = Instantiate(EnemyThreeEffectTemplate) as GameObject;
                NewButton.SetActive(true);
                NewButton.name = B.ReturnBuffTypeString();
                EffectButtonCount++;
                NewButton.transform.SetParent(EnemyThreeEffectTemplate.transform.parent, false);

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

                EnemyThreeEffectButtons.Add(NewButton);
            }


            foreach (HarmfulEffects H in BattleManagerRef.ReturnEnemyMonsters()[2].ReturnHarmfulEffects())
            {
                GameObject NewButton = Instantiate(EnemyThreeEffectTemplate) as GameObject;
                NewButton.SetActive(true);
                NewButton.name = H.ReturnDeBuffTypeString();
                EffectButtonCount++;
                NewButton.transform.SetParent(EnemyThreeEffectTemplate.transform.parent, false);

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

                EnemyThreeEffectButtons.Add(NewButton);
            }

            EffectButtonCount = 0;

            if (EnemyThreeEffectButtons.Count >= 1)
            {
                EnemyThreeEffectDisplay.SetActive(true);
            }
        }

    }

    // this function will update the skill cooldown display for the player when needed
    public void UpdateSkillCoolDownDisplay()
    {
        if(CurrentMonster.ReturnMonsterOwner() == "Player")
        {
            if (CurrentMonster.GetMonsterSKills()[1].GetSkillCurrentCooldown() > 0)
            {
                SkillTwoButton.SetActive(true);
                SkillTwoCooldownText.text = "Cooldown: " + CurrentMonster.GetMonsterSKills()[1].GetSkillCurrentCooldown();
            }
            else
            {
                SkillTwoButton.SetActive(false);
            }

            if (CurrentMonster.GetMonsterSKills()[2].GetSkillCurrentCooldown() > 0)
            {
                SkillThreeButton.SetActive(true);
                SkillThreeCooldownText.text = "Cooldown: " + CurrentMonster.GetMonsterSKills()[2].GetSkillCurrentCooldown();
            }
            else
            {
                SkillThreeButton.SetActive(false);
            }
        }

    }

    // this function will update the target display depending on the skill bieng used
    public void UpdateTargetdisplay(string SkillType)
    {
        if (SkillType == "Health")
        {
            TargetSelectionText.text = "Select a teammate to heal";

            if(BattleManagerRef.ReturnPlayerMonOneDead())
            {
                MonsterSelectionOne.text = "";
                SelectionButtonOne.SetActive(false);
            }
            else
            {
                MonsterSelectionOne.text = "Ally One";
                SelectionButtonOne.SetActive(true);
            }

            if(BattleManagerRef.ReturnPlayerMonTwoDead())
            {
                MonsterSelectionTwo.text = "";
                SelectionButtpnTwo.SetActive(false);
            }
            else
            {
                MonsterSelectionTwo.text = "Ally Two";
                SelectionButtpnTwo.SetActive(true);
            }

            if(BattleManagerRef.ReturnPlayerMonThreeDead())
            {
                MonsterSelectionThree.text = "";
                SelectionButtonThree.SetActive(false);
            }
            else
            {
                MonsterSelectionThree.text = "Ally Three";
                SelectionButtonThree.SetActive(true);
            }

            
        }
        else
        {
            TargetSelectionText.text = "Select the Enemy too attack dummy";

            if(BattleManagerRef.ReturnEnemyMonOneDead())
            {
                MonsterSelectionOne.text = "";
                SelectionButtonOne.SetActive(false);
            }
            else
            {
                MonsterSelectionOne.text = "Enemy One";
                SelectionButtonOne.SetActive(true);
            }


            if(BattleManagerRef.ReturnEnemyMonTwoDead())
            {
                MonsterSelectionTwo.text = "";
                SelectionButtpnTwo.SetActive(false);
            }
            else
            {
                MonsterSelectionTwo.text = "Enemy Two";
                SelectionButtpnTwo.SetActive(true);
            }

            if(BattleManagerRef.ReturnEnemyMonThreeDead())
            {
                MonsterSelectionThree.text = "";
                SelectionButtonThree.SetActive(false);
            }
            else
            {
                MonsterSelectionThree.text = "Enemy Three";
                SelectionButtonThree.SetActive(true);
            }

            
           

            
            
            
        }
    }



    // this function is used to set the monsters level at the begnining of the battle
    public void LevelDisplaySet()
    {
        MonsterOneLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterLevel();
        MonsterTwoLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterLevel();
        MonsterThreeLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterLevel();

        EnemyOneLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterLevel();
        EnemyTwoLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterLevel();
        EnemyThreeLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterLevel();
    }

    // this is an enumerator that displays the damage text for a small period of time before disapearing
    IEnumerator DamageDisplayTextTIme(float DisplayTime, MonsterSkillScript TheSkill, int DamageNumber)
    {
        bool calculated = false;

        MonsterOneSecondaryDamageNumber.gameObject.SetActive(true);
        MonsterTwoSecondaryDamageNumber.gameObject.SetActive(true);
        MonsterThreeSeoncdaryDamageNumber.gameObject.SetActive(true);
        EnemyOneSecondaryDamageNumber.gameObject.SetActive(true);
        EnemyTwoSecondaryDamageNumber.gameObject.SetActive(true);
        EnemythreeSecondaryDamageNumber.gameObject.SetActive(true);


        MonsterOneDamageText.text = "";
        MonsterTwoDamageText.text = "";
        MonsterThreeDamageText.text = "";
        MonsterOneSecondaryDamageNumber.text = "";
        MonsterTwoSecondaryDamageNumber.text = "";
        MonsterThreeSeoncdaryDamageNumber.text = "";
        EnemyMonsterOneDamageText.text = "";
        EnemyMonsterTwoDamageText.text = "";
        EnemyMonsterThreeDamageText.text = "";
        EnemyOneSecondaryDamageNumber.text = "";
        EnemyTwoSecondaryDamageNumber.text = "";
        EnemythreeSecondaryDamageNumber.text = "";

        int Temp = CurrentMonsterNum;

        int tempdamage;
        if (DamageNumber > 0)
        {
            tempdamage = DamageNumber;
        }
        else
        {
            tempdamage = 0;
        }
        
        string TempCurrentMonsterOwner = CurrentMonster.ReturnMonsterOwner();
        string CurrentMonsterName = CurrentMonster.ReturnMonsterName();
        bool CrititcalHit = CurrentMonster.ReturnLastSkillCrit();
        int TempTargetNumber = BattleManagerRef.ReturnTargetMonsterNumber();
        
       
        if(CrititcalHit)
        {
            CriticalHitText.gameObject.SetActive(true);
        }

        

        for (float i = 0; i < DisplayTime; i+= Time.deltaTime)
        {
            if (!calculated)
            {
                UpdateMonsterDamageNumber(TheSkill, tempdamage, TempCurrentMonsterOwner, TempTargetNumber);
                calculated = false;
            }
            switch (TheSkill.GetSkillSecondaryEffect())
                {
                    case ("Damage"):
                        {
        
                            if (!TheSkill.ReturnSkillAOE())
                            {
                                if (TempCurrentMonsterOwner == "Player")
                                {
                                    if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
                                    {
                                        EnemyMonsterOneDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    }
                                    else if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
                                    {
                                        EnemyMonsterTwoDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    }
                                    else if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
                                    {
                                        EnemyMonsterThreeDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    }
        
                                }
                                else
                                {
                                    if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
                                    {
                                        MonsterOneDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    }
                                    else if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
                                    {
                                        MonsterTwoDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    }
                                    else if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
                                    {
                                        MonsterThreeDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    }
                                }
                            }
                            else
                            {
                                if (TempCurrentMonsterOwner == "Player")
                                {
                                    EnemyMonsterOneDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    EnemyMonsterTwoDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    EnemyMonsterThreeDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                }
                                else
                                {
                                    MonsterOneDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    MonsterTwoDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                    MonsterThreeDamageText.text += "<color=red>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
        
                                }
                            }
                            break;
                        }
                    case ("Healing"):
                        {

                            switch (TheSkill.GetSkillMainEffect())
                            {
                                case ("Damage"):
                                    {
                                        if(CurrentMonsterName == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
                                        {
                                            MonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if(CurrentMonsterName == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
                                        {
                                            MonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
                                        {
                                            MonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if(CurrentMonsterName == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
                                        {
                                            EnemyMonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
                                        {
                                            EnemyMonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
                                        {
                                            EnemyMonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }

                                        break;
                                    }
                                case ("HarmfulEffect"):
                                    {
                                        if (CurrentMonsterName == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
                                        {
                                            MonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
                                        {
                                            MonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
                                        {
                                            MonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
                                        {
                                            EnemyMonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
                                        {
                                            EnemyMonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else if (CurrentMonsterName == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
                                        {
                                            EnemyMonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }

                                        break;
                                    }
                                case ("Healing"):
                                    {
                                         if (!TheSkill.ReturnSkillAOE())
                                         {
                                             if (TempCurrentMonsterOwner == "Player")
                                             {
                                        
                                        
                                                 if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
                                                 {
                                                     MonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 }
                                                 else if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
                                                 {
                                                     MonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 }
                                                 else if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
                                                 {
                                                     MonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 }
                                        
                                             }
                                             else
                                             {
                                                 if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
                                                 {
                                                     EnemyMonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 }
                                                 else if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
                                                 {
                                                     EnemyMonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 }
                                                 else if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
                                                 {
                                                     EnemyMonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 }
                                             }
                                         }
                                         else
                                         {
                                             if (TempCurrentMonsterOwner == "Player")
                                             {
                                        
                                        
                                                 MonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 MonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 MonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                             }
                                             else
                                             {
                                        
                                                 EnemyMonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 EnemyMonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                                 EnemyMonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                             }
                                         }
                                        break;
                                    }
                                case ("BeneficialEffect"):
                                    {
                                    if (!TheSkill.ReturnSkillAOE())
                                    {
                                        if (TempCurrentMonsterOwner == "Player")
                                        {


                                            if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterName())
                                            {
                                                MonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            }
                                            else if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterName())
                                            {
                                                MonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            }
                                            else if (CurrentMonsterTarget.ReturnMonsterName() == BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterName())
                                            {
                                                MonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            }

                                        }
                                        else
                                        {
                                            if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterName())
                                            {
                                                EnemyMonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            }
                                            else if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterName())
                                            {
                                                EnemyMonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            }
                                            else if (CurrentMonsterTargetsAI[0].ReturnMonsterName() == BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterName())
                                            {
                                                EnemyMonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (TempCurrentMonsterOwner == "Player")
                                        {


                                            MonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            MonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            MonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                        else
                                        {

                                            EnemyMonsterOneDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            EnemyMonsterTwoDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                            EnemyMonsterThreeDamageText.text += "<color=green>" + " +" + TheSkill.ReturnSecondaryEffectDamageNumber() + "</color>";
                                        }
                                    }
                                    break;
                                    }
                            }


                           
                            break;
                        }
            }


            
            yield return null;
            
        }

        //if (CurrentMonster.ReturnMonsterOwner() == "AI")
        //    EnableBattleSummary(TheSkill);

        //if (CurrentMonster.ReturnMonsterOwner() == "AI")
        //{
        //    SetMonsterCurrentHealthBar(false);
        //    BattleManagerRef.EndCurrentTurnAIBattle();
        //    UpdateEffectDisplay();
        //    UpdateCurrentMonsterIcon();
        //}
        


        MonsterOneDamageText.text = "";
        MonsterTwoDamageText.text = "";
        MonsterThreeDamageText.text = "";
        MonsterOneSecondaryDamageNumber.text = "";
        MonsterTwoSecondaryDamageNumber.text = "";
        MonsterThreeSeoncdaryDamageNumber.text = "";
        EnemyMonsterOneDamageText.text = "";
        EnemyMonsterTwoDamageText.text = "";
        EnemyMonsterThreeDamageText.text = "";
        EnemyOneSecondaryDamageNumber.text = "";
        EnemyTwoSecondaryDamageNumber.text = "";
        EnemythreeSecondaryDamageNumber.text = "";

   
        CriticalHitText.gameObject.SetActive(false);
    }





    // this function sets what monster is the current monster
    public void SetCurrentMonster(MonsterScript Mon)
    {
        CurrentMonster = Mon;
    }

    // this sets the number of the current monster
    public void SetCurrentMonsterNum(int MonsterNum)
    {
        CurrentMonsterNum = MonsterNum;
    }

    // this function sets the side the current monster is on
    public void SetCurrentMonsterSide(string Side)
    {
        CurrentMonsterSide = Side;
    }

    // functoin to return the slider for the first player monster health bar
    public Slider ReturnMonsterOneSlider()
    {
        return MonsterOneSlider;
    }

    // function to return the slider for the second player monster health bar
    public Slider ReturnMonsterTwoSlider()
    {
        return MonsterTwoSlider;
    }

    // function to return the slider for the third player monster health bar
    public Slider ReturnMonsterThreeslider()
    {
        return MonsterThreeSlider;
    }

    // function to return the slider for the first enemy monster health bar
    public Slider ReturnEnemyOneSlider()
    {
        return EnemyOneSlider;
    }


    // function to return the slider for the first enemy monster health bar
    public Slider ReturnEnemyTwoSlider()
    {
        return EnemyTwoSlider;
    }

    // function to return the slider for the first enemy monster health bar
    public Slider ReturnEnemyThreeSlider()
    {
        return EnemyThreeSlider;
    }

    // a function to set the current monster owner
    public void SetCurrentMonsterOwner(string CurrentMonsterOwner)
    {
        TheCurrentMonsterOwner = CurrentMonsterOwner;
    }
  
    // a function to return all of the monster targets
    public List<MonsterScript> ReturnMonsterTargets()
    {
        return CurrentMonsterTargetsAI;
    }
  
    public void SetAnimating(int anim)
    {
        if(anim == 1)
        {
            Animating = true;

        }
        else
        {
            Animating = false;
            TheEnenmyOneAnimator.SetBool("Attacking", false);
            TheEnemyTwoAnimator.SetBool("Attacking", false);
            TheEnemyThreeAnimator.SetBool("Attacking", false);
            ThePlayerOneAnimator.SetBool("Attacking", false);
            ThePlayerTwoAnimator.SetBool("Attacking", false);
            ThePlayerThreeAnimator.SetBool("Attacking", false);
        }
    }

    public bool ReturnAnimating()
    {
        return Animating;
    }


    public void PlayerMonOneDead()
    {
        MonsterOneEffectDisplay.SetActive(false);
        PlayerMonOneStats.SetActive(false);
        
    }

    public void PlayerMonTwoDead()
    {
        MonsterTwoEffectDisplay.SetActive(false);
        PlayerMonTwoStats.SetActive(false);
    }

    public void PlayerMonThreeDead()
    {
        MonsterThreeEffectDisplay.SetActive(false);
        PlayerMonThreeStats.SetActive(false);
    }

    public void EnemyMonOneDead()
    {
        EnemyOneEffectDisplay.SetActive(false);
        EnemyMonOneStats.SetActive(false);
    }

    public void EnemyMonTwoDead()
    {
        EnemyTwoEffectDisplay.SetActive(false);
        EnemyMonTwoStats.SetActive(false);
    }

    public void EnemyMonThreeDead()
    {
        EnemyThreeEffectDisplay.SetActive(false);
        EnemyMonThreeStats.SetActive(false);
    }
}
