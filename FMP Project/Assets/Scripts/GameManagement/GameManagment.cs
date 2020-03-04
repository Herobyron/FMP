using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameManagment : MonoBehaviour
{
    Data GameData;
    public MonsterScript TestSaveMonster;

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
        GameData.Rune1 = null;

    }

    public void LoadRuneIn()
    {
       
        FindObjectOfType<UITest>().RuneBiengUsed = GameData.PlayerInformation.ReturnSelectedRune(0);
    }


    public void LoadInMOnsterName()
    {
        FindObjectOfType<UITest>().MonsterBiengUsed = GameData.PlayerInformation.ReturnSelectedMonster(0);
    }
}





[System.Serializable]
class Data
{
    public PlayerData PlayerInformation = new PlayerData();
    public RuneScript Rune1;
}
