using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameManagment : MonoBehaviour
{
    Data GameData;

    void Start()
    {
        GameData = new Data();
    }

    public void Save()
    {
        BinaryFormatter BinFormatter = new BinaryFormatter();
        FileStream DataFile = File.Create(Application.persistentDataPath + "/PlayerData.dat");
        

        GameData.Rune1 = FindObjectOfType<GenerateRunes>().RuneScriptGenerated;

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

            GameData.Rune1 = data.Rune1;
        }
    }

    // a function specifically made to add Runes to the players information
    public void AddRuneToData(RuneScript RuneAdded)
    {
        GameData.Rune1 = RuneAdded;
    }

}





[System.Serializable]
class Data
{
    public RuneScript Rune1;
}
