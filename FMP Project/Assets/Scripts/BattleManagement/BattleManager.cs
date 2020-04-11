using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    [Tooltip("A bool to detemrin if PlayerMon1 has had a turn")]
    [SerializeField]
    private bool PlayerMonOneHadTurn = false;

    [Tooltip("A bool to detemrin if PlayerMon2 has had a turn")]
    [SerializeField]
    private bool PlayerMonTwoHadTurn = false;

    [Tooltip("A bool to detemrin if PlayerMon3 has had a turn")]
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
    private int NumberOfRounds;


    // Start is called before the first frame update
    void Start()
    {
        if(CurrentState == BattleState.Training)
        {
            EnemyMonOneHadTurn = true;
            EnemyMonTwoHadTurn = true;
            EnemyMonThreeHadTurn = true;
        }
    }

    // Update is called once per frame and will check wether to change a monsters turn or not
    void Update()
    {
        
    }


    // this function sets the monster for the player in battle
    public void SetPlayerBattleMonsters(List<MonsterScript> TheMonsters)
    {
        PlayersMonsters = TheMonsters;
    }

    // this is used to caculate who's turn it is when its a training battle
    public void TurnCalculateTraining()
    {
        if (PlayerMonOneHadTurn && PlayerMonTwoHadTurn && PlayerMonThreeHadTurn)
        {
            NumberOfRounds++;

            // speed calcualtion
            // set the current turn to that monster
            // send that information to the UI

        }
        else
        {
            // speed calculation
            // check if they have had a turn
            // if they have then find the person in second and third and check them
            // set the current turn
            // send that information to the UI
        }
    }

    // a function to set a specific monsters turn to be completed
    public void SetTurnEnd(int MonsterNumber)
    {
        switch (MonsterNumber)
        {
            case (1):
                {
                    PlayerMonOneHadTurn = true;
                    break;
                }
            case (2):
                {
                    PlayerMonTwoHadTurn = true;
                    break;
                }
            case (3):
                {
                    PlayerMonThreeHadTurn = true;
                    break;
                }
        }

    }


    // this is a used to calculate who's turn it is when its a regular battle
    public void TurnCalculate()
    {
        if(PlayerMonOneHadTurn && PlayerMonTwoHadTurn && PlayerMonThreeHadTurn && TrainingDummyHadTurn && EnemyMonOneHadTurn && EnemyMonTwoHadTurn && EnemyMonThreeHadTurn)
        {

        }
    }

}
