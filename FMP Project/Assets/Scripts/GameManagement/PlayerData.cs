using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// this script is for storing the data that will be based around the player and thie rrunes and monsters 
public class PlayerData 
{
// Variables

    // this is the players runes
    private List<RuneScript> PlayerRunes = new List<RuneScript>();

    // this is a list of the players monsters
    private List<MonsterScript> PlayerMonsters = new List<MonsterScript>();

    // this is the amount of Mana that the player has
    private int PlayerMana;

    // this is the amount of Scrolls that the player has
    private int PlayerScrolls;


// Functions

    // this function will allow to add a rune to the list of rune scripts. only after checking to make sure it is not a duplicate rune
    // Params:
    // - TheRune : this is the rune that is going to be checked and then added to the players rune list
    public void AddSelectedRune(RuneScript TheRune)
    {
        bool RuneSeen = false;

        foreach(RuneScript R in PlayerRunes)
        {
            if(R.ReturnRuneName() == TheRune.ReturnRuneName())
            {
                RuneSeen = true;
            }
        }


        if(!RuneSeen)
        {
            PlayerRunes.Add(TheRune);
        }
    }


    // this function will allow to add monsters to the list of monsters. this function will no go through a check as the player will be able to have as many monsters as they want
    //Params:
    // - TheMonster : this is the monster that is going to be added to the players monster list
    public void AddSelectedMonster(MonsterScript TheMonster)
    {
        PlayerMonsters.Add(TheMonster);
    }


    // this allows to return a selected rune with a certain name
    // Params: 
    // - RuneName : this is the rune that you want to try to find within the runes the player owns
    public RuneScript ReturnSelectedRune(string RuneName)
    {
        foreach(RuneScript R in PlayerRunes)
        {
            if(R.ReturnRuneName() == RuneName)
            {
                return R;
            }
        
        }

        return null;
    }

    // this function returns the rune at a certain point within the players list
    // Params:
    // - RuneNumber : the place in the list that the rune will be got from 
    public RuneScript ReturnSelectedRune(int RuneNumber)
    {
        return PlayerRunes[RuneNumber];
    }


    // a function that allows you to return the monster depending on the name 
    // Params: 
    // - MonsterName : this is the monster that you want to try to find within the monsters that the player owns 
    public MonsterScript ReturnSelectedMonster(string MonsterName)
    {
        foreach(MonsterScript M in PlayerMonsters)
        {
            if(M.ReturnMonsterName() == MonsterName)
            {
                return M;
            }
           
        }


        return null;
    }

    // this function returns the monster at a certain point within the players list
    // Params:
    // - MonsterNumber : this is the number in which monster will be selected from the list
    public MonsterScript ReturnSelectedMonster(int MonsterNumber)
    {
        return PlayerMonsters[MonsterNumber];
    }



    // this function returns the amount of MANA that the player has 
    public int ReturnPlayerMana()
    {
       return PlayerMana;
    }

    // this function will allow for decrease the amount of mana that the player has
    // Params:
    // - ManaAmount : this is the amount of mana that the players mana will be reduced by
    public void ReduceMana(int ManaAmount)
    {
        PlayerMana -= ManaAmount;
    }

    // this function returns the amount of scrolls that the player has
    public int ReturnPlayerScrolls()
    {
        return PlayerScrolls;
    }


    // this function will allow for the decrease in the amount of scrolls the player has
    // Params:
    // - ScrollAmount : this is the amount of scrolls that the function will decrease the players scrolls by
    public void ReduceScrolls(int ScrollAmount)
    {
        PlayerScrolls -= ScrollAmount;
    }
}
