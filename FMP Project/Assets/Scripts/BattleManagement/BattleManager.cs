using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Tooltip("this is the list of monsters for the player to use within battle")]
    [SerializeField]
    private List<MonsterScript> PlayersMonsters = new List<MonsterScript>();

    [Tooltip("this is the list of enemy monsters that will be going against the player")]
    [SerializeField]
    private List<MonsterScript> EnemyMonsters = new List<MonsterScript>();

    // this is the battle state of the current battle;
    private enum BattleState { Training, Regular};

    [Tooltip("this is an enum to determine what kind of battle this manager is doing (this determines what monsters are spawned and ")]
    [SerializeField]
    private BattleState CurrentState = BattleState.Training;

    // an enum that holds all of the monsters that could possibly take a turn
    private enum CurrentTurnMonster {PlayerMon1, PlayerMon2, PlayerMon3, EnemyMon1, EnemyMon2, EnemyMon3, TrainingDummy };

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

    // Start is called before the first frame update
    void Start()
    {
        //if(CurrentState == BattleState.Training)
        //{
        //    
        //    EnemyMonOneHadTurn = true;
        //    EnemyMonTwoHadTurn = true;
        //    EnemyMonThreeHadTurn = true;
        //
        //    TurnOrderCalculateTraining();
        //}

        InitialiseTrainingDummy();
    }

    // Update is called once per frame and will check wether to change a monsters turn or not
    void Update()
    {
        //CurrentTurnCalc();
    }

    public void InitialiseTrainingDummy()
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
        NewMonster.SetMonsterCurrentHealth(100000000);

        TrainingDummy = NewMonster;

    }

    public void InitialiseMonstersCurrentHealth()
    {
        foreach(MonsterScript M in PlayersMonsters)
        {
            M.SetMonsterCurrentHealth(M.ReturnBaseHealth() + M.ReturnIncreasedHealth()) ;
        }

        foreach(MonsterScript M in EnemyMonsters)
        {
            M.SetMonsterCurrentHealth(M.ReturnBaseHealth() + M.ReturnIncreasedHealth());
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

    // this is used to caculate who's turn it is when its a training battle
    public void TurnOrderCalculateTraining()
    {
        //NumberOfRounds++;

        

        SpeedCalculationPlayer(PlayersMonsters);

        foreach(MonsterScript M in PlayersMonsters)
        {
            if(M.ReturnMonsterName() == PlayerMonFirst)
            {
                CurrentMonster = M;
            }
        }

        BattleUI.SetCurrentMonster(CurrentMonster);
        BattleUI.SetCurrentMonsterNum(1);
        BattleUI.UpdateCurrentMonsterImage();

    }

    // a function that updates who's turn it currently is
    public void CurrentTurnCalc()
    {
        if(PlayerMonOneHadTurn && PlayerMonTwoHadTurn && PlayerMonThreeHadTurn)
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

        }
        else if(PlayerMonOneHadTurn && !PlayerMonTwoHadTurn && !PlayerMonThreeHadTurn)
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
            if((M.ReturnBaseSpeed() + M.ReturnIncreasedSpeed())  > TempSpeed)
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

    // a function to set the end of the monsters turn and change the current monster
    public void EndCurrentTurn()
    {
        if(CurrentMonster.ReturnMonsterName() == PlayerMonFirst)
        {
            PlayerMonOneHadTurn = true;
        }
        else if(CurrentMonster.ReturnMonsterName() == PlayerMonSecond)
        {
            PlayerMonTwoHadTurn = true;
        }
        else if(CurrentMonster.ReturnMonsterName() == PlayerMonThird)
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
        
        if(CurrentState == BattleState.Training)
        {
            BattleUI.SetEnemySingleTarget(TrainingDummy);
        }
        else
        {
            BattleUI.SetEnemySingleTarget(EnemyMonsters[TargetNumber]);
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
        if(PlayerMonOneHadTurn && PlayerMonTwoHadTurn && PlayerMonThreeHadTurn && TrainingDummyHadTurn && EnemyMonOneHadTurn && EnemyMonTwoHadTurn && EnemyMonThreeHadTurn)
        {

        }
    }

}
