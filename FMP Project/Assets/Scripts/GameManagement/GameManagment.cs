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

    // a rpivate list of the runes that the player currently owns
    private List<string> RuneNames = new List<string>();


    void Start()
    {
        GameData = new Data();
    }

    public void Save()
    {
        BinaryFormatter BinFormatter = new BinaryFormatter();
        FileStream DataFile = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        
        // this part will need to be changed to find the players runes and save them not just find the generated rune
        // if there is no generated rune it will saveit as null
        //GameData.Rune1 = FindObjectOfType<GenerateRunes>().RuneScriptGenerated;




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
        //GameData.Rune1 = RuneAdded;
        GameData.PlayerInformation.AddSelectedRune(RuneAdded);
        GameData.PlayerInformation.AddSelectedMonster(TestSaveMonster.ReturnMonsterData());
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
       
        FindObjectOfType<UITest>().RuneBiengUsed = GameData.PlayerInformation.ReturnSelectedRune(0);

    }


    public void LoadInMOnsterName()
    {
        FindObjectOfType<UITest>().MonsterBiengUsed = GameData.PlayerInformation.ReturnSelectedMonster(0);
    }

    // this function is made to get all of the names of runes the playuer currently posses
    public void GetAllRunes()
    {
        foreach(RuneScript R in GameData.PlayerInformation.ReturnAllPlayerRunes())
        {
            RuneNames.Add(R.ReturnRuneName());
        }
    }

    //function to return the runes
    public List<string> ReturnRuneNames()
    {
        return RuneNames;
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


    // this function will load the new rune that has been selected from the drop down menu
    // this function may need to change to find the name of the rune with that number then find the rune that has that name (testing needed)
    public RuneScript SelectedDropDownRuneLoad(int DropDownValue)
    {
        return GameData.PlayerInformation.ReturnSelectedRune(DropDownValue );
    }


}





[System.Serializable]
class Data
{
    public PlayerData PlayerInformation = new PlayerData();
    public RuneScript Rune1;
}
