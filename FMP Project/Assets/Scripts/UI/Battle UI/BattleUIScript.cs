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
    public void UpdateSkillsDisplay()
    {

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
    }

    // a function that uses the monsters second skill
    // this function is specifically for when the skill is not an AOE skill
    public void UseSkillTwo()
    {
        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        CurrentMonster.GetMonsterSKills()[1].UseSkill(EnemyTarget, CurrentMonster);

        BattleManagerRef.EndCurrentTurn();
    }

    // a function that uses the monsters third skill
    // this function is specifically for when the skill is not an AOE Skill
    public void UseSKillThree()
    {
        List<MonsterScript> EnemyTarget = new List<MonsterScript>();
        EnemyTarget.Add(CurrentMonsterTarget);

        CurrentMonster.GetMonsterSKills()[2].UseSkill(EnemyTarget, CurrentMonster);

        BattleManagerRef.EndCurrentTurn();
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
                        CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[0];
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
                    if(CurrentMonster.ReturnSkillTwoMainEffect() == "Healing" || CurrentMonster.ReturnSkillTwoSecondaryEffect() == "BeneficialEffect")
                    {
                        CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[1];
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

                    if (CurrentMonster.ReturnSkillThreeMainEffect() == "Healing" || CurrentMonster.ReturnSkillThreeSecondaryEffect() == "BeneficialEffect")
                    {
                        CurrentMonsterTarget = BattleManagerRef.ReturnPlayerMonsters()[2];
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
    }

}
