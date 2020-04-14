using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

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


    // Start is called before the first frame update
    void Start()
    {
        
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
                        SkillDescriptionText.text = "This Skill <color=darkblue>Heals</color> All Allies by a large amount. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill will also <color=darkblue>heal</color> all allies by a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply ";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " To All Allies. ";

                                    break;
                                }
                        }
                    }
                    else
                    {
                        SkillDescriptionText.text = "This Skill <color=darkblue>Heals</color> A single Ally by a large amount. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill will also <color=darkblue>heal</color> one ally by a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply ";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
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
                            SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " To all Allies. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=darkblue>heal</color> all allies for a small amount. ";
                        }

                    }
                    else
                    {
                        SkillDescriptionText.text = "this skill will apply";

                        for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                        {
                            SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " To one Ally. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=darkblue>heal</color> one ally for a small amount. ";
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
                            SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " to all enemies. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Damage")
                        {
                            SkillDescriptionText.text += "this skill will also apply <color=darkblue>damage</color> to all enemies proportiionate to your attack power. ";
                        }
                        else if(TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }
                    else
                    {
                        SkillDescriptionText.text = "this skill applies ";

                        for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                        {
                            SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                        }

                        SkillDescriptionText.text += " to one enemy. ";

                        if (TheSkill.GetSkillSecondaryEffect() == "Damage")
                        {
                            SkillDescriptionText.text += "this skill will also apply <color=darkblue>damage</color> to one enemy proportiionate to your attack power. ";
                        }
                        else if (TheSkill.GetSkillSecondaryEffect() == "Healing")
                        {
                            SkillDescriptionText.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if (TheSkill.ReturnSkillAOE())
                    {
                        SkillDescriptionText.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to all enemies monsters. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill also <color=darkblue>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " to all enemies. ";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillDescriptionText.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to one enemy monsters. ";

                        switch (TheSkill.GetSkillSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillDescriptionText.text += "this skill also <color=darkblue>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
                                    }

                                    SkillDescriptionText.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillDescriptionText.text += "this skill will also apply";

                                    for (int i = 0; i < TheSkill.GetSkillEffects().Count; i++)
                                    {
                                        SkillDescriptionText.text += ", <color=darkblue>" + TheSkill.GetSkillEffects()[i] + "</color>";
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

        if(CurrentMonster.GetMonsterSKills()[SkillSelectedNumber - 1].ReturnSkillAOE())
        {
            switch (SkillSelectedNumber)
            {
                case (1):
                    {
                        if(CurrentMonster.ReturnrSkillOneMainEffect() == "Healing" || CurrentMonster.ReturnrSkillOneMainEffect() == "BeneficialEffect")
                        {
                            CurrentMonster.GetMonsterSKills()[0].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster);
                            
                        }
                        else
                        {
                            CurrentMonster.GetMonsterSKills()[0].UseSkill(Targets, CurrentMonster);
                        }

                        BattleManagerRef.EndCurrentTurn();
                        UpdateCurrentMonsterImage();
                        break;
                    }
                case (2):
                    {
                        if (CurrentMonster.ReturnSkillTwoMainEffect() == "Healing" || CurrentMonster.ReturnSkillTwoMainEffect() == "BeneficialEffect")
                        {
                            CurrentMonster.GetMonsterSKills()[1].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster);

                        }
                        else
                        {
                            CurrentMonster.GetMonsterSKills()[1].UseSkill(Targets, CurrentMonster);
                        }

                        BattleManagerRef.EndCurrentTurn();
                        UpdateCurrentMonsterImage();
                        break;
                    }
                case (3):
                    {
                        if (CurrentMonster.ReturnSkillThreeMainEffect() == "Healing" || CurrentMonster.ReturnSkillThreeMainEffect() == "BeneficialEffect")
                        {
                            CurrentMonster.GetMonsterSKills()[2].UseSkill(BattleManagerRef.ReturnPlayerMonsters(), CurrentMonster);

                        }
                        else
                        {
                            CurrentMonster.GetMonsterSKills()[2].UseSkill(Targets, CurrentMonster);
                        }

                        BattleManagerRef.EndCurrentTurn();
                        UpdateCurrentMonsterImage();
                        break;
                    }
            }

            MonsterSKilldescription.SetActive(false);
        }
        else
        {
            EnemySelectionPanel.SetActive(true);
            MonsterSKilldescription.SetActive(false);
        }
    }


    // a function to use the monster first skill
    // this function is specifically for when the skill is not an AOE and target is picked manually
    public void UseSkillOne()
    {

        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        CurrentMonster.GetMonsterSKills()[0].UseSkill(EnemyTarget, CurrentMonster);

        BattleManagerRef.EndCurrentTurn();
        UpdateCurrentMonsterImage();
    }

    // a function that uses the monsters second skill
    // this function is specifically for when the skill is not an AOE skill
    public void UseSkillTwo()
    {
        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        CurrentMonster.GetMonsterSKills()[1].UseSkill(EnemyTarget, CurrentMonster);

        BattleManagerRef.EndCurrentTurn();
        UpdateCurrentMonsterImage();
    }

    // a function that uses the monsters third skill
    // this function is specifically for when the skill is not an AOE Skill
    public void UseSKillThree()
    {
        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        CurrentMonster.GetMonsterSKills()[2].UseSkill(EnemyTarget, CurrentMonster);

        BattleManagerRef.EndCurrentTurn();
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
                        CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[BattleManagerRef.ReturnTargetMonsterNumber() -1];
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
                        CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[BattleManagerRef.ReturnTargetMonsterNumber() -1];
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
                        CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[BattleManagerRef.ReturnTargetMonsterNumber() -1];
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
    public void UpdateDamageNumberS(MonsterSkillScript TheSkill)
    {
        switch (TheSkill.GetSkillMainEffect())
        {

        }

    }

}
