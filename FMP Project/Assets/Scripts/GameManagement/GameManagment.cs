using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameManagment : MonoBehaviour
{
    // the games data for the player
    Data GameData;

    // this is a test monster and will be removed later on
    public MonsterScript TestSaveMonster;

    // a private list of the runes that the player currently owns
    private List<string> RuneNames = new List<string>();

    // a private list of the monsters that the player currently owns
    private List<string> MonsterNames = new List<string>();


    void Start()
    {
        GameData = new Data();
    }

    public void Save()
    {
        BinaryFormatter BinFormatter = new BinaryFormatter();
        FileStream DataFile = File.Create(Application.persistentDataPath + "/PlayerData.dat");
       
        BinFormatter.Serialize(DataFile, GameData);
        DataFile.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter BinFormatter = new BinaryFormatter();
            FileStream DataFile = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            Data data = (Data)BinFormatter.Deserialize(DataFile);
            DataFile.Close();

            GameData.PlayerInformation = data.PlayerInformation;
        }
    }

    // a function specifically made to add Runes to the players information
    public void AddRuneToData(RuneScript RuneAdded)
    { 
        GameData.PlayerInformation.AddSelectedRune(RuneAdded);
        Save();
    }

    //a function specifically made to add monsters to the players infomration
    public void AddMonsterToData(MonsterScript MonsterData)
    {
        GameData.PlayerInformation.AddSelectedMonster(MonsterData);
        Save();
    }


    // function used to clear players data to load in the rune for testing
    public void ClearData()
    {
        GameData.PlayerInformation.ClearRunes();
        GameData.PlayerInformation.ClearMonsters();

    }

    public void LoadRuneIn()
    {

        FindObjectOfType<UITest>().SetRuneBiengUsed(GameData.PlayerInformation.ReturnSelectedRune(0));

    }

    public void LoadInMonsterName()
    {
        FindObjectOfType<UIMonsterTest>().SetMonsterBiengUsed(GameData.PlayerInformation.ReturnSelectedMonster(0));
    }

    // this function is made to get all of the names of runes the playuer currently owns
    public void GetAllRunes()
    {
        RuneNames.Clear();
        foreach(RuneScript R in GameData.PlayerInformation.ReturnAllPlayerRunes())
        {
            RuneNames.Add(R.ReturnRuneName());
        }
    }

    // this function is made to get all of the names of monsters the player currently owns
    public void GetAllMonsters()
    {
        MonsterNames.Clear();
        foreach(MonsterScript M in GameData.PlayerInformation.ReturnAllPlayerMonsters())
        {
            MonsterNames.Add(M.ReturnMonsterName());
        }
    }

    //function to return the runes
    public List<string> ReturnRuneNames()
    {
        return RuneNames;
    }

    //function to return the monsters
    public List<string> ReturnMonsterNames()
    {
        return MonsterNames;
    }


    // a function to return the number of runes within the players inventory
    public int ReturnRuneCount()
    {
        if(GameData != null)
        {
            return GameData.PlayerInformation.ReturnAllPlayerRunes().Count;
        }
        return 0;
    }

    // a function to return the number of monsters within the player inventory
    public int ReturnMonsterCount()
    {
        if(GameData != null)
        {
            return GameData.PlayerInformation.ReturnAllPlayerMonsters().Count;
        }
        return 0;
    }


    // this function will load the new rune that has been selected from the drop down menu
    // this function may need to change to find the name of the rune with that number then find the rune that has that name (testing needed)
    public RuneScript SelectedDropDownRuneLoad(int DropDownValue)
    {
        return GameData.PlayerInformation.ReturnSelectedRune(DropDownValue);
    }

    //this function will load the new monster that has been selected from the drop down menu
    public MonsterScript SelectedDropDownMonsterLoad(int DropDownValue)
    {
        return GameData.PlayerInformation.ReturnSelectedMonster(DropDownValue);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}





[System.Serializable]
class Data
{
    public PlayerData PlayerInformation = new PlayerData();
    public RuneScript Rune1;
}
