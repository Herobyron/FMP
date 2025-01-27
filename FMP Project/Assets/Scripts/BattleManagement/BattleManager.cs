﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Tooltip("this is the list of monsters for the player to use within battle")]
    [SerializeField]
    private List<MonsterScript> PlayersMonsters = new List<MonsterScript>();

    [Tooltip("this is the list of enemy monsters that will be going against the player")]
    [SerializeField]
    private List<MonsterScript> EnemyMonsters = new List<MonsterScript>();

    // this is the battle state of the current battle;
    private enum BattleState { Training, Regular };

    [Tooltip("this is an enum to determine what kind of battle this manager is doing (this determines what monsters are spawned and ")]
    [SerializeField]
    private BattleState CurrentState = BattleState.Training;

    // an enum that holds all of the monsters that could possibly take a turn
    private enum CurrentTurnMonster { PlayerMon1, PlayerMon2, PlayerMon3, EnemyMon1, EnemyMon2, EnemyMon3, TrainingDummy };

    [Tooltip("this is an enum that determines whos turn it is out of the players monsters and the enemies monsters")]
    [SerializeField]
    private CurrentTurnMonster MonstersTurn = CurrentTurnMonster.PlayerMon1;

    // these are bools to detemrine who has had a turn
    [Tooltip("A bool to detemrin if the first monster has had a turn")]
    [SerializeField]
    private bool PlayerMonOneHadTurn = false;

    [Tooltip("A bool to detemrin if the second monster has had a turn")]
    [SerializeField]
    private bool PlayerMonTwoHadTurn = false;

    [Tooltip("A bool to detemrin if the third monster has had a turn")]
    [SerializeField]
    private bool PlayerMonThreeHadTurn = false;

    [Tooltip("A bool to detemrin if EnemyMon1 has had a turn")]
    [SerializeField]
    private bool EnemyMonOneHadTurn = false;

    [Tooltip("A bool to detemrin if EnemyMon2 has had a turn")]
    [SerializeField]
    private bool EnemyMonTwoHadTurn = false;

    [Tooltip("A bool to detemrin if EnemyMon3 has had a turn")]
    [SerializeField]
    private bool EnemyMonThreeHadTurn = false;

    [Tooltip("A bool to detemrin if Training Dummy has had a turn")]
    [SerializeField]
    private bool TrainingDummyHadTurn = false;


    // a int to keep a track of how many rounds have passed
    [Tooltip("this is the number of rounds that have passed ")]
    [SerializeField]
    private int NumberOfRounds = 0;


    // these are the string for the player monsters on who will move, first second and third
    [SerializeField]
    private string PlayerMonFirst = "";

    [SerializeField]
    private string PlayerMonSecond = "";

    [SerializeField]
    private string PlayerMonThird = "";


    //this is the monster whos turn it is
    private MonsterScript CurrentMonster = null;


    [Tooltip("this is a refernce to the current Battle UI script")]
    [SerializeField]
    private BattleUIScript BattleUI = null;

    [Tooltip("this is the refercne to the new battle UI script")]
    [SerializeField]
    private RealBattleUIScript TheBattleUI = null;

    // this is the training dummy Monster Script
    private MonsterScript TrainingDummy;

    //these are private scripts that are a complete copy of the monster scripts.
    [SerializeField]
    private MonsterScript FirstMonster = null;

    [SerializeField]
    private MonsterScript SecondMonster = null;

    [SerializeField]
    private MonsterScript ThirdMonster = null;

    [Tooltip("this is the target monster number. this will be used for player monsters as well as enemy monsters")]
    [SerializeField]
    private int TargetMonsterNumber = 0;


    //this is the siz strings use to detrmine which monsters are going in what positions for when battling agianst the AI
    [Tooltip("this is the first monster in battle the one with fastest speed")]
    [SerializeField]
    private string TheFirstMonster = "";

    [Tooltip("this is the first monster in battle script. this script is stored seperate from the lists")]
    [SerializeField]
    private MonsterScript TheFirstMonsterScript = null;

    [Tooltip("this is a bool to determine is the first monster has had a turn")]
    [SerializeField]
    private bool FirstMonsterHadTurn = false;

    [Tooltip("this is the second monster in battle with the second fastest speed")]
    [SerializeField]
    private string TheSecondMonster = "";

    [Tooltip("this is the second monster in battle script. this script is stored seperate from the lists")]
    [SerializeField]
    private MonsterScript TheSecondMonsterScript = null;

    [Tooltip("this is a bool to determine is the Second monster has had a turn")]
    [SerializeField]
    private bool SecondMonsterHadTurn = false;

    [Tooltip("this is the third monster in battle. the one with the third fastest speed")]
    [SerializeField]
    private string TheThirdMonster = "";

    [Tooltip("this is the third monster in battle script. this script is stored seperte from the lists")]
    [SerializeField]
    private MonsterScript TheThirdMonsterScript = null;

    [Tooltip("this is a bool to determine is the Third monster has had a turn")]
    [SerializeField]
    private bool ThirdMonsterHadTurn = false;


    [Tooltip("this is the fourth monster in battle. the one with the forth fastest speed")]
    [SerializeField]
    private string TheFourthMonster = "";

    [Tooltip("this is the fourth monster in battle script. this script is stored seperate from the lists")]
    [SerializeField]
    private MonsterScript TheForthMonsterScript = null;

    [Tooltip("this is a bool to determine is the Fourth monster has had a turn")]
    [SerializeField]
    private bool FourthMonsterHadTurn = false;


    [Tooltip("this is the fifth monster in battle. the one with the fifth fastest speed")]
    [SerializeField]
    private string TheFifthMonster = "";

    [Tooltip("this is the fifth monster in battle script. this script is stored seperate form the lists")]
    [SerializeField]
    private MonsterScript TheFifthMonsterScript = null;

    [Tooltip("this is a bool to determine is the Fifth monster has had a turn")]
    [SerializeField]
    private bool FifthMonsterHadTurn = false;


    [Tooltip("this is the sixth monster in battle. the one with the slowest speed")]
    [SerializeField]
    private string TheSixthMonster = "";

    [Tooltip("this is the sixth monster in battle script. this script is stored seperate from the lists")]
    [SerializeField]
    private MonsterScript TheSixthMonsterScript = null;


    [Tooltip("this is a bool to determine is the Sixth monster has had a turn")]
    [SerializeField]
    private bool SixthMonsterHadTurn = false;


    // this is the battle UI for when fighting against AI
    [Tooltip("UI that is used to battle against AI")]
    [SerializeField]
    private RealBattleUIScript AIBattleUI = null;

    // this is the AI script
    TheAIScript AIScript;

    TheDecisions TargetDecisions = new TheDecisions();

    bool BattleStart = false;

    // this is a bool to deal with the battle summary
    [SerializeField]
    private bool BattleSummary = false;

    // this is all the bools to determine if a monster is dead or not
    [SerializeField]
    private bool EnemyMonOneDead = false;

    [SerializeField]
    private bool EnemyMonTwoDead = false;

    [SerializeField]
    private bool EnemyMonThreeDead = false;

    [SerializeField]
    private bool PlayerMonOneDead = false;

    [SerializeField]
    private bool PlayerMonTwoDead = false;

    [SerializeField]
    private bool PlayerMonThreeDead = false;


    [SerializeField]
    private bool FirstMonsterDead = false;

    [SerializeField]
    private bool SecondMonsterDead = false;

    [SerializeField]
    private bool ThirdMonsterDead = false;

    [SerializeField]
    private bool FourthMonsterDead = false;

    [SerializeField]
    private bool FifthMonsterDead = false;

    [SerializeField]
    private bool SixthMonsterDead = false;


    // these are the gameobjects for the monsters and their graves
    [SerializeField]
    private GameObject PlayerMonObjectOne = null;

    [SerializeField]
    private GameObject PlayerMonObjectTwo = null;

    [SerializeField]
    private GameObject PlayerMonObjectThree = null;

    [SerializeField]
    private GameObject EnemyMonObjectOne = null;

    [SerializeField]
    private GameObject EnemyMonObjectTwo = null;

    [SerializeField]
    private GameObject EnemyMonObjectThree = null;

    [SerializeField]
    private GameObject PlayerOneGrave = null;

    [SerializeField]
    private GameObject PlayerTwoGrave = null;

    [SerializeField]
    private GameObject PlayerThreeGrave = null;

    [SerializeField]
    private GameObject EnemyOneGrave = null;

    [SerializeField]
    private GameObject EnemyTwoGrave = null;

    [SerializeField]
    private GameObject EnemyThreeGrave = null;

    // these are the components for the end game screen
    [Tooltip("this is the game object that is linked to the end game screen when the battle has ended")]
    [SerializeField]
    private GameObject EndGameScreen = null;

    [Tooltip("this is the text component for the Title Text of the end screen. changed depending on the outcome of battle")]
    [SerializeField]
    private Text EndScreenTitleText = null;

    [Tooltip("this is the GameObject holding the vicotry image that dispalys at the end of the game")]
    [SerializeField]
    private GameObject VictoryImage = null;

    [Tooltip("this is the GameObject holding the defeat image that displays at the end of the game")]
    [SerializeField]
    private GameObject DefeatImage = null;

    [Tooltip("this is the battle UI screen that was used previously")]
    [SerializeField]
    private GameObject BattleUIScreen = null;




    // this is for initialising the decisions for the tree
    private void Awake()
    {
        // the starting node should be to test if skill three is on cooldown
        TheDecisions SkillThreeDecision = new TheDecisions();
        TheDecisionNode SkillThreeDecisionNode = new TheDecisionNode();
        SkillThreeDecisionNode.DecisionType = "SkillThree";
        SkillThreeDecisionNode.SetTheDecision(SkillThreeDecision);

        // if the decision is no then it should be an action node and use the skill three
        // as the question it is asking is... is skill three on cooldown?
        TheActions SkillThreeAction = new TheActions();
        TheActionNode SkillThreeActionNode = new TheActionNode();
        SkillThreeActionNode.SetActionName("SkillThree");
        SkillThreeActionNode.SetAction(SkillThreeAction);
        SkillThreeDecisionNode.AddNoNode(SkillThreeActionNode);


        // if the decision is yes then it should be a decsision node for the second skill
        // because if skill three is on cooldown then it needs to check
        TheDecisions SkillTwoDecision = new TheDecisions();
        TheDecisionNode SkillTwoDecsisionNode = new TheDecisionNode();
        SkillTwoDecsisionNode.DecisionType = "SkillTwo";
        SkillTwoDecsisionNode.SetTheDecision(SkillTwoDecision);
        SkillThreeDecisionNode.AddYesNode(SkillTwoDecsisionNode);

        // if the decision for the skill two decsision is yes then should be action node to use skill one
        TheActions SkillOneAction = new TheActions();
        TheActionNode SkillOneActionNode = new TheActionNode();
        SkillOneActionNode.SetActionName("SkillOne");
        SkillOneActionNode.SetAction(SkillOneAction);
        SkillTwoDecsisionNode.AddYesNode(SkillOneActionNode);

        // if the decsision for the skill two decision is no then should be action node to use skill two
        TheActions SkillTwoAction = new TheActions();
        TheActionNode SkillTwoActionNode = new TheActionNode();
        SkillTwoActionNode.SetActionName("SkillTwo");
        SkillTwoActionNode.SetAction(SkillTwoAction);
        SkillTwoDecsisionNode.AddNoNode(SkillTwoActionNode);




        AIScript = new TheAIScript(SkillThreeDecisionNode);

    }


    // Start is called before the first frame update
    void Start()
    {
     
        InitialiseTrainingDummy();
    }

    // Update is called once per frame and will check wether to change a monsters turn or not
    void Update()
    {
        if(PlayerMonOneDead && PlayerMonTwoDead && PlayerMonThreeDead)
        {
            BattleStart = false;
            EndGameScreen.SetActive(true);
            BattleUIScreen.SetActive(false);
            DefeatImage.SetActive(true);

            if(EnemyMonOneDead && EnemyMonTwoDead || EnemyMonOneDead && EnemyMonThreeDead || EnemyMonTwoDead && EnemyMonThreeDead)
            {
                EndScreenTitleText.text = "Close Defeat";
            }
            else if(EnemyMonThreeDead || EnemyMonTwoDead || EnemyMonOneDead)
            {
                EndScreenTitleText.text = "Agonising Loss";
            }
            else
            {
                EndScreenTitleText.text = "Humiliating Defeat";
            }

        }
        else if(EnemyMonOneDead && EnemyMonTwoDead && EnemyMonThreeDead)
        {
            BattleStart = false;
            EndGameScreen.SetActive(true);
            BattleUIScreen.SetActive(false);
            VictoryImage.SetActive(true);

            if (PlayerMonOneDead && PlayerMonTwoDead || PlayerMonOneDead && PlayerMonThreeDead || PlayerMonTwoDead && PlayerMonThreeDead)
            {
                EndScreenTitleText.text = "Hard Fought Victory";
            }
            else if (PlayerMonThreeDead || PlayerMonTwoDead || PlayerMonOneDead)
            {
                EndScreenTitleText.text = "Tactical Win";
            }
            else
            {
                EndScreenTitleText.text = "Astonishing Vicotry";
            }
        }


        if (CurrentMonster != null)
        {
            if (BattleStart)
            {


                if (BattleSummary == false)
                {
                    if (!AIBattleUI.ReturnAnimating())
                    {

                        if (CurrentMonster.ReturnMonsterOwner() == "AI")
                        {

                            TheBattleUI.SetEnemyTargets(TargetDecisions.PickEnemyTarget(PlayersMonsters, EnemyMonsters, CurrentMonster.GetMonsterSKills()));

                            if (TheBattleUI.ReturnMonsterTargets().Count > 1)
                            {

                            }
                            else
                            {
                                if (TheBattleUI.ReturnMonsterTargets()[0].ReturnMonsterName() == EnemyMonsters[0].ReturnMonsterName())
                                {
                                    TargetMonsterNumber = 0;
                                }
                                else if (TheBattleUI.ReturnMonsterTargets()[0].ReturnMonsterName() == EnemyMonsters[1].ReturnMonsterName())
                                {
                                    TargetMonsterNumber = 1;
                                }
                                else if (TheBattleUI.ReturnMonsterTargets()[0].ReturnMonsterName() == EnemyMonsters[2].ReturnMonsterName())
                                {
                                    TargetMonsterNumber = 2;
                                }
                                else if (TheBattleUI.ReturnMonsterTargets()[0].ReturnMonsterName() == PlayersMonsters[0].ReturnMonsterName())
                                {
                                    TargetMonsterNumber = 0;
                                }
                                else if (TheBattleUI.ReturnMonsterTargets()[0].ReturnMonsterName() == PlayersMonsters[1].ReturnMonsterName())
                                {
                                    TargetMonsterNumber = 1;
                                }
                                else if (TheBattleUI.ReturnMonsterTargets()[0].ReturnMonsterName() == PlayersMonsters[2].ReturnMonsterName())
                                {
                                    TargetMonsterNumber = 2;
                                }
                            }


                            AIScript.Execute(AIBattleUI, CurrentMonster);

                        }
                    }
                }
            }
        }

        if(BattleStart)
        {
            UpdateMonsterDeadStat();
        }
        
    }




    public void InitialiseTrainingDummy()
    {
        if (CurrentState == BattleState.Training)
        {
            MonsterScript NewMonster = new MonsterScript();
            NewMonster.SetMonsterHealth(100000);
            NewMonster.SetMonsterDefence(1000);
            NewMonster.SetMonsterAttack(1);
            NewMonster.SetMonsterName("Dummy");
            NewMonster.SetMonsterResistance(1);
            NewMonster.SetMonsterAccuracy(1);
            NewMonster.SetMonsterCritDamage(1);
            NewMonster.SetMonsterCritRate(1);
            NewMonster.SetMonsterSpeed(1);
            NewMonster.SetMonsterCurrentHealth(1000000);

            TrainingDummy = NewMonster;


            BattleUI.ReturnTrainingDummySlider().maxValue = TrainingDummy.ReturnCurrentHealth();
            BattleUI.ReturnTrainingDummySlider().value = TrainingDummy.ReturnCurrentHealth();
        }
    }

    //this function will randomly generate the three monsters and store them in the enemy monster list
    public void InitialseEnemyMonstersRandom()
    {
        EnemyMonsters.Add(FindObjectOfType<GenerateMonster>().CreateEnemyMonster(EnemyMonsters.Count));
        EnemyMonsters.Add(FindObjectOfType<GenerateMonster>().CreateEnemyMonster(EnemyMonsters.Count));
        EnemyMonsters.Add(FindObjectOfType<GenerateMonster>().CreateEnemyMonster(EnemyMonsters.Count));

        for (int i = 0; i < EnemyMonsters[0].ReturnMonsterMaxLevel(); i++)
        {
            EnemyMonsters[0].LevelUpMonster();
        }

        for (int i = 0; i < EnemyMonsters[1].ReturnMonsterMaxLevel(); i++)
        {
            EnemyMonsters[1].LevelUpMonster();
        }

        for (int i = 0; i < EnemyMonsters[2].ReturnMonsterMaxLevel(); i++)
        {
            EnemyMonsters[2].LevelUpMonster();
        }

    }

    public void InitialiseMonstersCurrentHealth()
    {
        foreach (MonsterScript M in PlayersMonsters)
        {
            M.SetMonsterCurrentHealth(M.ReturnBaseHealth() + M.ReturnIncreasedHealth());
        }

        foreach (MonsterScript M in EnemyMonsters)
        {
            M.SetMonsterCurrentHealth(M.ReturnBaseHealth() + M.ReturnIncreasedHealth());
        }


        if (CurrentState == BattleState.Training)
        {
            BattleUI.ReturnMonsterOneSlider().maxValue = FirstMonster.ReturnCurrentHealth();
            BattleUI.ReturnMonsterOneSlider().value = FirstMonster.ReturnCurrentHealth();
            BattleUI.ReturnMonsterTwoSlider().maxValue = SecondMonster.ReturnCurrentHealth();
            BattleUI.ReturnMonsterTwoSlider().value = SecondMonster.ReturnCurrentHealth();
            BattleUI.ReturnMonsterThreeSlider().maxValue = ThirdMonster.ReturnCurrentHealth();
            BattleUI.ReturnMonsterThreeSlider().value = ThirdMonster.ReturnCurrentHealth();
        }

        if (CurrentState == BattleState.Regular)
        {
            AIBattleUI.ReturnEnemyOneSlider().maxValue = EnemyMonsters[0].ReturnCurrentHealth();
            AIBattleUI.ReturnEnemyOneSlider().value = EnemyMonsters[0].ReturnCurrentHealth();
            AIBattleUI.ReturnEnemyTwoSlider().maxValue = EnemyMonsters[1].ReturnCurrentHealth();
            AIBattleUI.ReturnEnemyTwoSlider().value = EnemyMonsters[1].ReturnCurrentHealth();
            AIBattleUI.ReturnEnemyThreeSlider().maxValue = EnemyMonsters[2].ReturnCurrentHealth();
            AIBattleUI.ReturnEnemyThreeSlider().value = EnemyMonsters[2].ReturnCurrentHealth();

            AIBattleUI.ReturnMonsterOneSlider().maxValue = PlayersMonsters[0].ReturnCurrentHealth();
            AIBattleUI.ReturnMonsterOneSlider().value = PlayersMonsters[0].ReturnCurrentHealth();
            AIBattleUI.ReturnMonsterTwoSlider().maxValue = PlayersMonsters[1].ReturnCurrentHealth();
            AIBattleUI.ReturnMonsterTwoSlider().value = PlayersMonsters[1].ReturnCurrentHealth();
            AIBattleUI.ReturnMonsterThreeslider().maxValue = PlayersMonsters[2].ReturnCurrentHealth();
            AIBattleUI.ReturnMonsterThreeslider().value = PlayersMonsters[2].ReturnCurrentHealth();
        }


    }

    // this function sets the monster for the player in battle
    public void SetPlayerBattleMonsters(List<MonsterScript> TheMonsters)
    {
        PlayersMonsters = TheMonsters;
    }

    // this is a function that returns all of the players monsters on the battle field
    public List<MonsterScript> ReturnPlayerMonsters()
    {
        return PlayersMonsters;
    }

    // this is a function that returns all of the enemies monsters on the battle field
    public List<MonsterScript> ReturnEnemyMonsters()
    {
        return EnemyMonsters;
    }

    // this is used to caculate who's turn it is when its a training battle
    public void TurnOrderCalculateTraining()
    {
        //NumberOfRounds++;



        SpeedCalculationPlayer(PlayersMonsters);

        foreach (MonsterScript M in PlayersMonsters)
        {
            if (M.ReturnMonsterName() == PlayerMonFirst)
            {
                CurrentMonster = M;
            }
        }

        BattleUI.SetCurrentMonster(CurrentMonster);
        BattleUI.SetCurrentMonsterNum(1);
        BattleUI.UpdateCurrentMonsterImage();


    }


    // this function will calculate the turn order for all of the monsters within the players and enemies monsters
    // this function also sends information to the battle UI this will be looked at later
    public void TurnOrderCalculateActualBattle()
    {
        List<MonsterScript> TempMons = new List<MonsterScript>();
        TempMons.AddRange(EnemyMonsters);
        TempMons.AddRange(PlayersMonsters);

        int Temp = 0;

        InitialseEnemyMonstersRandom();
        SpeedCalcualteAllMonster();


        foreach (MonsterScript M in PlayersMonsters)
        {

            if (M.ReturnMonsterName() == TheFirstMonster)
            {
                // if temp is 0 then its the first monster and so on
                CurrentMonster = M;
                AIBattleUI.SetCurrentMonster(TheFirstMonsterScript);
                AIBattleUI.SetCurrentMonsterNum(Temp);
                AIBattleUI.SetCurrentMonsterSide("Player");

            }

            Temp++;
        }

        Temp = 0;

        foreach (MonsterScript M in EnemyMonsters)
        {

            if (M.ReturnMonsterName() == TheFirstMonster)
            {
                // if temp is 0 then its the first monster and so on
                CurrentMonster = M;
                AIBattleUI.SetCurrentMonster(TheFirstMonsterScript);
                AIBattleUI.SetCurrentMonsterNum(Temp);
                AIBattleUI.SetCurrentMonsterSide("AI");

            }

            Temp++;
        }


        AIBattleUI.UpdateCurrentMonsterIcon();

    }

    // this function will calcualte the speed of all of the monsters bieng used from both sides and find out who is the faststes
    // this function will only run once at the begninig of battle and will need to be done after the enemy monsters have been generated
    public void SpeedCalcualteAllMonster()
    {
        List<MonsterScript> TempMons = new List<MonsterScript>();
        TempMons.AddRange(EnemyMonsters);
        TempMons.AddRange(PlayersMonsters);

        int TempSpeed = 0;
        MonsterScript TempMonster = new MonsterScript();


        foreach (MonsterScript M in TempMons)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                TheFirstMonster = M.ReturnMonsterName();
                TheFirstMonsterScript = M;
                TempMonster = M;
            }
        }

        TempSpeed = 0;

        foreach (MonsterScript M in TempMons)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed && M.ReturnMonsterName() != TheFirstMonster)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                TheSecondMonster = M.ReturnMonsterName();
                TheSecondMonsterScript = M;
                TempMonster = M;
            }
        }

        TempSpeed = 0;

        foreach (MonsterScript M in TempMons)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed && M.ReturnMonsterName() != TheFirstMonster && M.ReturnMonsterName() != TheSecondMonster)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                TheThirdMonster = M.ReturnMonsterName();
                TheThirdMonsterScript = M;
                TempMonster = M;
            }
        }

        TempSpeed = 0;

        foreach (MonsterScript M in TempMons)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed && M.ReturnMonsterName() != TheFirstMonster && M.ReturnMonsterName() != TheSecondMonster && M.ReturnMonsterName() != TheThirdMonster)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                TheFourthMonster = M.ReturnMonsterName();
                TheForthMonsterScript = M;
                TempMonster = M;
            }
        }

        TempSpeed = 0;

        foreach (MonsterScript M in TempMons)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed && M.ReturnMonsterName() != TheFirstMonster && M.ReturnMonsterName() != TheSecondMonster && M.ReturnMonsterName() != TheThirdMonster && M.ReturnMonsterName() != TheFourthMonster)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                TheFifthMonster = M.ReturnMonsterName();
                TheFifthMonsterScript = M;
                TempMonster = M;
            }
        }


        TempSpeed = 0;

        foreach (MonsterScript M in TempMons)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed && M.ReturnMonsterName() != TheFirstMonster && M.ReturnMonsterName() != TheSecondMonster && M.ReturnMonsterName() != TheThirdMonster && M.ReturnMonsterName() != TheFourthMonster && M.ReturnMonsterName() != TheFifthMonster)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                TheSixthMonster = M.ReturnMonsterName();
                TheSixthMonsterScript = M;
                TempMonster = M;
            }
        }



    }

    // this is a function to determine who's turn it is when battleing against AI
    // not finished
    public void CurrentTurnCalculationAIBattle()
    {
        int Temp = 0;

        if(FirstMonsterHadTurn && SecondMonsterHadTurn && ThirdMonsterHadTurn && FourthMonsterHadTurn && FifthMonsterHadTurn && SixthMonsterHadTurn)
        {
            FirstMonsterHadTurn = false;
            SecondMonsterHadTurn = false;
            ThirdMonsterHadTurn = false;
            FourthMonsterHadTurn = false;
            FifthMonsterHadTurn = false;
            SixthMonsterHadTurn = false;

            foreach (MonsterScript M in PlayersMonsters)
            {
                if (M.GetMonsterSKills()[1].GetSkillCurrentCooldown() > 0)
                {
                    M.GetMonsterSKills()[1].SetSkillCurrentCooldown(M.GetMonsterSKills()[1].GetSkillCurrentCooldown() - 1);
                }

                if (M.GetMonsterSKills()[2].GetSkillCurrentCooldown() > 0)
                {
                    M.GetMonsterSKills()[2].SetSkillCurrentCooldown(M.GetMonsterSKills()[2].GetSkillCurrentCooldown() - 1);
                }
            }

            foreach (MonsterScript M in EnemyMonsters)
            {
                if (M.GetMonsterSKills()[1].GetSkillCurrentCooldown() > 0)
                {
                    M.GetMonsterSKills()[1].SetSkillCurrentCooldown(M.GetMonsterSKills()[1].GetSkillCurrentCooldown() - 1);
                }

                if (M.GetMonsterSKills()[2].GetSkillCurrentCooldown() > 0)
                {
                    M.GetMonsterSKills()[2].SetSkillCurrentCooldown(M.GetMonsterSKills()[2].GetSkillCurrentCooldown() - 1);
                }
            }
        }

        if(TheFirstMonsterScript.ReturnCurrentHealth() <= 0)
        {
            FirstMonsterHadTurn = true;
        }
        
        if(TheSecondMonsterScript.ReturnCurrentHealth() <= 0)
        {
            SecondMonsterHadTurn = true;
        }

        if(TheThirdMonsterScript.ReturnCurrentHealth() <=0)
        {
            ThirdMonsterHadTurn = true;
        }

        if(TheForthMonsterScript.ReturnCurrentHealth() <= 0)
        {
            FourthMonsterHadTurn = true;
        }

        if(TheFifthMonsterScript.ReturnCurrentHealth() <= 0)
        {
            FifthMonsterHadTurn = true;
        }

        if(TheSixthMonsterScript.ReturnCurrentHealth() <= 0)
        {
            SixthMonsterHadTurn = true;
        }

        if (!FirstMonsterHadTurn )
        {

                CurrentMonster = TheFirstMonsterScript;

                // update all monster turns

                if (CurrentMonster.ReturnMonsterOwner() == "Player")
                {
                    Temp = 0;
                    foreach (MonsterScript M in PlayersMonsters)
                    {


                        if (M.ReturnMonsterName() == TheFirstMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("Player");

                        }

                        Temp++;
                    }
                }
                else
                {
                    Temp = 0;

                    foreach (MonsterScript M in EnemyMonsters)
                    {

                        if (M.ReturnMonsterName() == TheFirstMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("AI");
                        }

                        Temp++;
                    }
                }
            

            

            // decrese all skill cooldowns by one turn
            
        }
        else if ( !SecondMonsterHadTurn )
        {

           
                CurrentMonster = TheSecondMonsterScript;

                // update all monster turns

                if (CurrentMonster.ReturnMonsterOwner() == "Player")
                {
                    foreach (MonsterScript M in PlayersMonsters)
                    {


                        if (M.ReturnMonsterName() == TheSecondMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("Player");

                        }

                        Temp++;
                    }
                }
                else
                {
                    foreach (MonsterScript M in EnemyMonsters)
                    {

                        if (M.ReturnMonsterName() == TheSecondMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("AI");
                        }

                        Temp++;
                    }
                }
            


            
        }
        else if (!ThirdMonsterHadTurn )
        {

           
                CurrentMonster = TheThirdMonsterScript;
                if (CurrentMonster.ReturnMonsterOwner() == "Player")
                {
                    foreach (MonsterScript M in PlayersMonsters)
                    {


                        if (M.ReturnMonsterName() == TheThirdMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("Player");

                        }

                        Temp++;
                    }
                }
                else
                {
                    foreach (MonsterScript M in EnemyMonsters)
                    {

                        if (M.ReturnMonsterName() == TheThirdMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("AI");
                        }

                        Temp++;
                    }
                }
            


           
        }
        else if (!FourthMonsterHadTurn)
        {
            
                CurrentMonster = TheForthMonsterScript;
                if (CurrentMonster.ReturnMonsterOwner() == "Player")
                {
                    foreach (MonsterScript M in PlayersMonsters)
                    {


                        if (M.ReturnMonsterName() == TheFourthMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("Player");

                        }

                        Temp++;
                    }
                }
                else
                {
                    foreach (MonsterScript M in EnemyMonsters)
                    {

                        if (M.ReturnMonsterName() == TheFourthMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("AI");
                        }

                        Temp++;
                    }
                }
            

            
        }
        else if ( !FifthMonsterHadTurn)
        {

            
                CurrentMonster = TheFifthMonsterScript;
                if (CurrentMonster.ReturnMonsterOwner() == "Player")
                {
                    foreach (MonsterScript M in PlayersMonsters)
                    {


                        if (M.ReturnMonsterName() == TheFifthMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("Player");

                        }

                        Temp++;
                    }
                }
                else
                {
                    foreach (MonsterScript M in EnemyMonsters)
                    {

                        if (M.ReturnMonsterName() == TheFifthMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("AI");
                        }

                        Temp++;
                    }
                }
            
            
        }
        else if (!SixthMonsterHadTurn)
        {
            
                CurrentMonster = TheSixthMonsterScript;
                if (CurrentMonster.ReturnMonsterOwner() == "Player")
                {
                    foreach (MonsterScript M in PlayersMonsters)
                    {


                        if (M.ReturnMonsterName() == TheSixthMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("Player");

                        }

                        Temp++;
                    }
                }
                else
                {
                    foreach (MonsterScript M in EnemyMonsters)
                    {

                        if (M.ReturnMonsterName() == TheSixthMonster)
                        {
                            // if temp is 0 then its the first monster and so on
                            AIBattleUI.SetCurrentMonsterNum(Temp);
                            AIBattleUI.SetCurrentMonsterSide("AI");
                        }

                        Temp++;
                    }
                }
            

            
        }

        AIBattleUI.UpdateCurrentMonsterIcon();
        AIBattleUI.SetCurrentMonster(CurrentMonster);
        AIBattleUI.UpdateSkillCoolDownDisplay();
    }



    // a function that updates who's turn it currently is
    public void CurrentTurnCalc()
    {
        if (PlayerMonOneHadTurn && PlayerMonTwoHadTurn && PlayerMonThreeHadTurn)
        {
            PlayerMonOneHadTurn = false;
            PlayerMonTwoHadTurn = false;
            PlayerMonThreeHadTurn = false;

            foreach (MonsterScript M in PlayersMonsters)
            {
                if (M.ReturnMonsterName() == PlayerMonFirst)
                {
                    CurrentMonster = M;
                    BattleUI.SetCurrentMonsterNum(1);
                }
            }

            foreach (MonsterScript M in PlayersMonsters)
            {
                if (M.GetMonsterSKills()[1].GetSkillCurrentCooldown() > 0)
                {
                    M.GetMonsterSKills()[1].SetSkillCurrentCooldown(M.GetMonsterSKills()[1].GetSkillCurrentCooldown() - 1);
                }

                if (M.GetMonsterSKills()[2].GetSkillCurrentCooldown() > 0)
                {
                    M.GetMonsterSKills()[2].SetSkillCurrentCooldown(M.GetMonsterSKills()[2].GetSkillCurrentCooldown() - 1);
                }
            }

        }
        else if (PlayerMonOneHadTurn && !PlayerMonTwoHadTurn && !PlayerMonThreeHadTurn)
        {
            foreach (MonsterScript M in PlayersMonsters)
            {
                if (M.ReturnMonsterName() == PlayerMonSecond)
                {
                    CurrentMonster = M;
                    BattleUI.SetCurrentMonsterNum(2);
                }
            }
        }
        else if (PlayerMonOneHadTurn && PlayerMonTwoHadTurn && !PlayerMonThreeHadTurn)
        {
            foreach (MonsterScript M in PlayersMonsters)
            {
                if (M.ReturnMonsterName() == PlayerMonThird)
                {
                    CurrentMonster = M;
                    BattleUI.SetCurrentMonsterNum(3);
                }
            }
        }

        BattleUI.SetCurrentMonster(CurrentMonster);
        BattleUI.UpdateSkillCooldownDisplay();
    }



    // this function is used to find the speed in between all of the monsters given to the function (this is for the player)
    public void SpeedCalculationPlayer(List<MonsterScript> AllMons)
    {

        List<MonsterScript> TempMonList = new List<MonsterScript>();
        TempMonList = AllMons;

        int TempSpeed = 0;
        MonsterScript TempMon = new MonsterScript();

        foreach (MonsterScript M in TempMonList)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                PlayerMonFirst = M.ReturnMonsterName();
                FirstMonster = M;
                TempMon = M;
            }

        }

        //TempMonList.Remove(TempMon);
        TempSpeed = 0;

        foreach (MonsterScript M in TempMonList)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed && M.ReturnMonsterName() != PlayerMonFirst)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                PlayerMonSecond = M.ReturnMonsterName();
                SecondMonster = M;
                TempMon = M;
            }

        }

        //TempMonList.Remove(TempMon);
        TempSpeed = 0;

        foreach (MonsterScript M in TempMonList)
        {
            if ((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed()) > TempSpeed && M.ReturnMonsterName() != PlayerMonFirst && M.ReturnMonsterName() != PlayerMonSecond)
            {
                TempSpeed = (int)(M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed());
                PlayerMonThird = M.ReturnMonsterName();
                ThirdMonster = M;
                TempMon = M;
            }

        }

        //TempMonList.Remove(TempMon);


    }

    // a function to set a specific monsters turn to be completed
    public void SetTurnEnd(int MonsterNumber)
    {
        switch (MonsterNumber)
        {
            case (1):
                {
                    PlayerMonOneHadTurn = true;
                    BattleUI.SetCurrentMonsterNum(2);
                    break;
                }
            case (2):
                {
                    PlayerMonTwoHadTurn = true;
                    BattleUI.SetCurrentMonsterNum(3);
                    break;
                }
            case (3):
                {
                    PlayerMonThreeHadTurn = true;
                    BattleUI.SetCurrentMonsterNum(1);
                    break;
                }
        }

    }

    // a function to set a specific monster turn to be completed when in actual battle
    public void SetTurnEndAIBattle()
    {

    }

    // a function to set the end of the monsters turn and change the current monster in actual battle
    public void EndCurrentTurnAIBattle()
    {

        if (CurrentMonster.ReturnMonsterName() == TheFirstMonster)
        {
            FirstMonsterHadTurn = true;
        }
        else if (CurrentMonster.ReturnMonsterName() == TheSecondMonster)
        {
            SecondMonsterHadTurn = true;
        }
        else if (CurrentMonster.ReturnMonsterName() == TheThirdMonster)
        {
            ThirdMonsterHadTurn = true;
        }
        else if (CurrentMonster.ReturnMonsterName() == TheFourthMonster)
        {
            FourthMonsterHadTurn = true;
        }
        else if (CurrentMonster.ReturnMonsterName() == TheFifthMonster)
        {
            FifthMonsterHadTurn = true;
        }
        else if (CurrentMonster.ReturnMonsterName() == TheSixthMonster)
        {
            SixthMonsterHadTurn = true;
        }


        CurrentTurnCalculationAIBattle();

    }


    // a function to set the end of the monsters turn and change the current monster
    public void EndCurrentTurn()
    {
        if (CurrentMonster.ReturnMonsterName() == PlayerMonFirst)
        {
            PlayerMonOneHadTurn = true;
        }
        else if (CurrentMonster.ReturnMonsterName() == PlayerMonSecond)
        {
            PlayerMonTwoHadTurn = true;
        }
        else if (CurrentMonster.ReturnMonsterName() == PlayerMonThird)
        {
            PlayerMonThreeHadTurn = true;
        }

        CurrentTurnCalc();
    }


    // this is a function used to give the battle UI the taget monster
    // if the battle mode is training then it will just set the target to the training dummy
    // if the battle mode is an actual battle then it will use the int given to pick the target
    public void SetMonsterTarget(int TargetNumber)
    {
        TargetMonsterNumber = TargetNumber;

        if (CurrentState == BattleState.Training)
        {
            BattleUI.SetEnemySingleTarget(TrainingDummy);
        }
        else
        {
            AIBattleUI.SetEnemySingleTarget(EnemyMonsters[TargetNumber]);
        }
    }

    public int ReturnTargetMonsterNumber()
    {
        return TargetMonsterNumber;
    }

    public MonsterScript ReturnTrainingDummy()
    {
        return TrainingDummy;
    }

    public MonsterScript ReturnMonsterOne()
    {
        return FirstMonster;
    }

    public MonsterScript ReturnMonsterTwo()
    {
        return SecondMonster;
    }

    public MonsterScript ReturnMonsterThree()
    {
        return ThirdMonster;
    }


    // this function is used to give the battle UI the target monster when the skill is a healing skill
    // no matter the type of the battle the player will be able to select 
    public void SetTargetMonsterHeal()
    {

    }


    // this is a used to calculate who's turn it is when its a regular battle
    public void TurnCalculate()
    {
        if (PlayerMonOneHadTurn && PlayerMonTwoHadTurn && PlayerMonThreeHadTurn && TrainingDummyHadTurn && EnemyMonOneHadTurn && EnemyMonTwoHadTurn && EnemyMonThreeHadTurn)
        {

        }
    }

    // a function to get when the battle starts
    public void SetBattleStart(bool start)
    {
        BattleStart = start;
    }

    // a function to deal with seting the battle summary
    public void BattleSummarySet(bool SetSummary)
    {
        BattleSummary = SetSummary;
    }

    // a function to return the battle summary 
    public bool ReturnBattleSummary()
    {
        return BattleSummary;
    }


    // this is a function that checks all of the monsters health and then sets the bools to true accordingly
    public void UpdateMonsterDeadStat()
    {
        if (!PlayerMonOneDead)
        {
            if (PlayersMonsters[0].ReturnCurrentHealth() <= 0)
            {
                PlayerMonOneDead = true;
                PlayerMonObjectOne.SetActive(false);
                PlayerOneGrave.GetComponent<Rigidbody>().useGravity = true;
                AIBattleUI.PlayerMonOneDead();
            }
        }


        if (!PlayerMonTwoDead)
        {
            if(PlayersMonsters[1].ReturnCurrentHealth() <= 0)
            {
                PlayerMonTwoDead = true;
                PlayerMonObjectTwo.SetActive(false);
                PlayerTwoGrave.GetComponent<Rigidbody>().useGravity = true;
                AIBattleUI.PlayerMonTwoDead();
            }
        }

        if(!PlayerMonThreeDead)
        {
            if(PlayersMonsters[2].ReturnCurrentHealth() <= 0)
            {
                PlayerMonThreeDead = true;
                PlayerMonObjectThree.SetActive(false);
                PlayerThreeGrave.GetComponent<Rigidbody>().useGravity = true;
                AIBattleUI.PlayerMonThreeDead();
            }
        }

        if(!EnemyMonOneDead)
        {
            if(EnemyMonsters[0].ReturnCurrentHealth() <= 0)
            {
                EnemyMonOneDead = true;
                EnemyMonObjectOne.SetActive(false);
                EnemyOneGrave.GetComponent<Rigidbody>().useGravity = true;
                AIBattleUI.EnemyMonOneDead();
            }
        }

        if (!EnemyMonTwoDead)
        {
            if (EnemyMonsters[1].ReturnCurrentHealth() <= 0)
            {
                EnemyMonTwoDead = true;
                EnemyMonObjectTwo.SetActive(false);
                EnemyTwoGrave.GetComponent<Rigidbody>().useGravity = true;
                AIBattleUI.EnemyMonTwoDead();
            }
        }

        if (!EnemyMonThreeDead)
        {
            if (EnemyMonsters[2].ReturnCurrentHealth() <= 0)
            {
                EnemyMonThreeDead = true;
                EnemyMonObjectThree.SetActive(false);
                EnemyThreeGrave.GetComponent<Rigidbody>().useGravity = true;
                AIBattleUI.EnemyMonThreeDead();
            }
        }

        if(!FirstMonsterDead)
        {
            if(TheFirstMonsterScript.ReturnCurrentHealth() <= 0 )
            {
                FirstMonsterDead = true;
            }
        }

        if (!SecondMonsterDead)
        {
            if (TheSecondMonsterScript.ReturnCurrentHealth() <= 0)
            {
                SecondMonsterDead = true;
            }
        }

        if (!ThirdMonsterDead)
        {
            if (TheThirdMonsterScript.ReturnCurrentHealth() <= 0)
            {
                ThirdMonsterDead = true;
            }
        }

        if (!FourthMonsterDead)
        {
            if (TheForthMonsterScript.ReturnCurrentHealth() <= 0)
            {
                FourthMonsterDead = true;
            }
        }

        if (!FifthMonsterDead)
        {
            if (TheFifthMonsterScript.ReturnCurrentHealth() <= 0)
            {
                FifthMonsterDead = true;
            }
        }

        if (!SixthMonsterDead)
        {
            if (TheSixthMonsterScript.ReturnCurrentHealth() <= 0)
            {
                SixthMonsterDead = true;
            }
        }

    }



    // these are functions to return all of the dead boolian values

    public bool ReturnPlayerMonOneDead()
    {
        return PlayerMonOneDead;
    }

    public bool ReturnPlayerMonTwoDead()
    {
        return PlayerMonTwoDead;
    }

    public bool ReturnPlayerMonThreeDead()
    {
        return PlayerMonThreeDead;
    }

    public bool ReturnEnemyMonOneDead()
    {
        return EnemyMonOneDead;
    }

    public bool ReturnEnemyMonTwoDead()
    {
        return EnemyMonTwoDead;
    }

    public bool ReturnEnemyMonThreeDead()
    {
        return EnemyMonThreeDead;
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Monster");
    }
}
