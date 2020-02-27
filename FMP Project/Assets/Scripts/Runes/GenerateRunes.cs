using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

// this class is going to use the rune class in order to create a rune with completly randmo stats
public class GenerateRunes : MonoBehaviour
{


    
    [Tooltip("This is the base rune that you want the rune to be based off of")]
    [SerializeField]
    private GameObject RuneBase;

    private RuneScript RuneScriptGenerated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    // this function creates the new rune and makes the rune a prefab
    public void CreateRune()
    {
        GameObject NewRune = new GameObject();

        
        RuneScriptGenerated = NewRune.AddComponent<RuneScript>();
       
         

        string Path = "Assets/Assets/Prefabs/RunesPrefabs/ " + NewRune.name + ".prefab";
        Path = AssetDatabase.GenerateUniqueAssetPath(Path);

        

        GenerateRune();
        

        NewRune.name = "Rune " + NewRune.GetComponent<RuneScript>().ReturnRuneSlot();
        NewRune.GetComponent<RuneScript>().SetRuneName(NewRune.name);
        NewRune.GetComponent<RuneScript>().SetRuneOwner("Player");


        //PrefabUtility.SaveAsPrefabAssetAndConnect(NewRune, Path, InteractionMode.UserAction);
        PrefabUtility.SaveAsPrefabAsset(NewRune, Path);

        AssetDatabase.Refresh();
        AssetDatabase.RenameAsset(Path, "Rune");
        AssetDatabase.SaveAssets();
        



    }


    // this function is callled at the end of the create rune function as it generates all of the runes stats and information and saves them
    public void GenerateRune()
    {
        // the first part of the function will set the runes stars
        int LevelChance = Random.Range(0, 100);

        if (LevelChance <= 30)
        {
            RuneScriptGenerated.SetRuneStars(1);
        }
        else if (LevelChance > 30 && LevelChance <= 55)
        {
            RuneScriptGenerated.SetRuneStars(2);
        }
        else if (LevelChance > 55 && LevelChance <= 75)
        {
            RuneScriptGenerated.SetRuneStars(3);
        }
        else if (LevelChance > 75 && LevelChance <= 85)
        {
            RuneScriptGenerated.SetRuneStars(4);
        }
        else if (LevelChance > 85 && LevelChance <= 95)
        {
            RuneScriptGenerated.SetRuneStars(5);
        }
        else if(LevelChance > 95 && LevelChance <= 100)
        {
            RuneScriptGenerated.SetRuneStars(6);
        }

        
       

        // then the function will create the Rareity of the rune
        int RarityChance = Random.Range(70, 100);

        if(RarityChance <= 50)
        {
            RuneScriptGenerated.SetRuneRarty(1);
        }
        else if (RarityChance > 50 && RarityChance <= 70)
        {
            RuneScriptGenerated.SetRuneRarty(2);
        }
        else if(RarityChance > 70 && RarityChance <= 85)
        {
            RuneScriptGenerated.SetRuneRarty(3);
        }
        else if(RarityChance > 85 && RarityChance <= 95)
        {
            RuneScriptGenerated.SetRuneRarty(4);
        }
        else if(RarityChance > 95 && RarityChance <= 100)
        {
            RuneScriptGenerated.SetRuneRarty(5);
        }

        // this randomly makes the runes slot 
        RuneScriptGenerated.SetRuneSlot(Random.Range(1, 6));

        // the next part goes into detail on creating the main stat of the rune 
        RuneScriptGenerated.GenerateMainRuneStat();

        // now depending on the rarity of the rune changes the amount of sub stats that the rune will start off with

        switch (RuneScriptGenerated.ReturnRuneRarity())
        {
            case ("Common"):
            {
                //a common rune does not start with any substats
                break;
            }
            case ("Uncommon"):
            {
                    // the uncommon rune starts off with one base stat
                    RuneScriptGenerated.GenerateRuneStat(1);
                break;
            }
            case ("Rare"):
            {
                    // the rare rune starts off with two base stats
                    RuneScriptGenerated.GenerateRuneStat(1);
                    RuneScriptGenerated.GenerateRuneStat(2);
                break;
            }
            case ("Epic"):
            {
                    // the epic rune starts off with three base stats
                    RuneScriptGenerated.GenerateRuneStat(1);
                    RuneScriptGenerated.GenerateRuneStat(2);
                    RuneScriptGenerated.GenerateRuneStat(3);
                break;
            }
            case ("Legendary"):
            {
                    // the legendary rune starts off with the maximum of four base stats
                    RuneScriptGenerated.GenerateRuneStat(1);
                    RuneScriptGenerated.GenerateRuneStat(2);
                    RuneScriptGenerated.GenerateRuneStat(3);
                    RuneScriptGenerated.GenerateRuneStat(4);
                break;
            }
        }



    }



}
