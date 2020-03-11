using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour
{
    //this is the monster script that will be generated. this will be used to display things in the scene (this may not be needed as nothing is battleing only displaying information)
    public MonsterScript MonsterScriptGenerated;

    // this is the monster data that will be updated and stored in the player information
    private MonsterData MonsterDataGenerated;

    // this is used to access the game data to add to the players monsters
    public GameManagment TheManager;

    // this is the number of monster in which the player is at (every time a monster is created it is increased)
    private int MonsterNumberAt;

    // Start is called before the first frame update
    void Start()
    {
        MonsterNumberAt = TheManager.ReturnMonsterCount();
    }

    
    //this function creates the monster and all of its unique data and then adds it to the player inventory
    // the monsters data is then stored in a script which is made savable so can be loaded else where
    // everything about the monster will be randomlyb generated with vairables changing the chances to generate certain monsters
    public void CreateMonster()
    {
        MonsterNumberAt = TheManager.ReturnMonsterCount();
        MonsterDataGenerated = new MonsterData();

        GenerateMonsterFunc();
       
    }


    //this function goes about actually generating the information for the monster
    public void GenerateMonsterFunc()
    {

        //this first part makes it so stars are generated

        int StarChance = Random.Range(0, 100);

        if(StarChance <= 30)
        {
            MonsterDataGenerated.SetMonsterStars(1);
        }
        else if(StarChance > 30 && StarChance <= 65)
        {
            MonsterDataGenerated.SetMonsterStars(2);
        }
        else if(StarChance > 65 && StarChance <= 80)
        {
            MonsterDataGenerated.SetMonsterStars(3);
        }
        else if(StarChance > 80 && StarChance <= 95)
        {
            MonsterDataGenerated.SetMonsterStars(4);
        }
        else if(StarChance > 95 && StarChance <= 100)
        {
            MonsterDataGenerated.SetMonsterStars(5);
        }

        // this part will now generate the type of monster that this one will be
        int MonsterTypeChance = Random.Range(0, 92);

        if(MonsterTypeChance <= 30)
        {
            MonsterDataGenerated.SetMonsterstype("Attack");
        }
        else if(MonsterTypeChance >= 31 && MonsterTypeChance <= 61)
        {
            MonsterDataGenerated.SetMonsterstype("Health");
        }
        else if(MonsterTypeChance >= 62 && MonsterTypeChance <= 92)
        {
            MonsterDataGenerated.SetMonsterstype("Defence");
        }


        //this part will now generate the stats for the monster (they will chnage depending on the stars and 
        //health generation for the monster
        int TempHealth = Random.Range(100, 200);
        TempHealth = (TempHealth * (10 * MonsterDataGenerated.ReturnMonsterStars()));

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Attack"):
                {
                    TempHealth -= Random.Range(200, 300);
                    break;
                }
            case ("Defence"):
                {
                    TempHealth -= Random.Range(100, 200);
                    break;
                }
            case ("Health"):
                {
                    TempHealth += Random.Range(300, 400);
                    break;
                }
        }

        MonsterDataGenerated.SetMonsterHealth(TempHealth);

        
        //defence generation for the monster


    }
}
