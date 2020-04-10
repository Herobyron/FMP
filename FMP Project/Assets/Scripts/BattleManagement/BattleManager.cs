using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Tooltip("this is the list of monsters for the player to use within battle")]
    [SerializeField]
    private List<MonsterScript> PlayersMonsters = new List<MonsterScript>();

    // this is the battle state of the current battle;
    private enum BattleState { Training, Regular};

    [Tooltip("this is an enum to determine what kind of battle this manager is doing (this determines what monsters are spawned and ")]
    [SerializeField]
    private BattleState CurrentState = BattleState.Training;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // this function sets the monster for the player in battle
    public void SetPlayerBattleMonsters(List<MonsterScript> TheMonsters)
    {
        PlayersMonsters = TheMonsters;
    }

}
