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

        
        NewRune.AddComponent<RuneScript>();

         

        string Path = "Assets/ " + NewRune.name + ".prefab";
        Path = AssetDatabase.GenerateUniqueAssetPath(Path);

        

        GenerateRune(NewRune.GetComponent<RuneScript>());


        PrefabUtility.SaveAsPrefabAssetAndConnect(NewRune, Path, InteractionMode.UserAction);
    }


    // this function is callled at the end of the create rune function as it generates all of the runes stats and information and saves them
    public void GenerateRune(RuneScript GeneratedRune)
    {
        // the first part of the function will set the runes stars
        int LevelChance = Random.Range(0, 100);

        if (LevelChance <= 30)
        {
            GeneratedRune.SetRuneStars(1);
        }
        else if (LevelChance > 30 && LevelChance <= 55)
        {
            GeneratedRune.SetRuneStars(2);
        }
        else if (LevelChance > 55 && LevelChance <= 75)
        {
            GeneratedRune.SetRuneStars(3);
        }
        else if (LevelChance > 75 && LevelChance <= 85)
        {
            GeneratedRune.SetRuneStars(4);
        }
        else if (LevelChance > 85 && LevelChance <= 95)
        {
            GeneratedRune.SetRuneStars(5);
        }
        else if(LevelChance > 95 && LevelChance <= 100)
        {
            GeneratedRune.SetRuneStars(6);
        }

        
       

        // then the function will create the Rareity of the rune
        int RarityChance = Random.Range(0, 100);

        if(RarityChance <= 50)
        {
            GeneratedRune.SetRuneRarty(1);
        }
        else if (RarityChance > 50 && RarityChance <= 70)
        {
            GeneratedRune.SetRuneRarty(2);
        }
        else if(RarityChance > 70 && RarityChance <= 85)
        {
            GeneratedRune.SetRuneRarty(3);
        }
        else if(RarityChance > 85 && RarityChance <= 95)
        {
            GeneratedRune.SetRuneRarty(4);
        }
        else if(RarityChance > 95 && RarityChance <= 100)
        {
            GeneratedRune.SetRuneRarty(5);
        }

        // this randomly makes the runes slot 
        GeneratedRune.SetRuneSlot(Random.Range(1, 6));

        // the next part goes into detail on creating the main stat of the rune 
        GeneratedRune.GenerateMainRuneStat();

        // now depending on the rarity of the rune changes the amount of sub stats that the rune will start off with

        switch (GeneratedRune.ReturnRuneRarity())
        {
            case ("Common"):
            {
                //a common rune does not start with any substats
                break;
            }
            case ("Uncommon"):
            {
                    // the uncommon rune starts off with one base stat
                    GeneratedRune.GenerateRuneStat(1);
                break;
            }
            case ("Rare"):
            {
                    // the rare rune starts off with two base stats
                    GeneratedRune.GenerateRuneStat(1);
                    GeneratedRune.GenerateRuneStat(2);
                break;
            }
            case ("Epic"):
            {
                    // the epic rune starts off with three base stats
                    GeneratedRune.GenerateRuneStat(1);
                    GeneratedRune.GenerateRuneStat(2);
                    GeneratedRune.GenerateRuneStat(3);
                break;
            }
            case ("Legendary"):
            {
                    // the legendary rune starts off with the maximum of four base stats
                    GeneratedRune.GenerateRuneStat(1);
                    GeneratedRune.GenerateRuneStat(2);
                    GeneratedRune.GenerateRuneStat(3);
                    GeneratedRune.GenerateRuneStat(4);
                break;
            }
        }



    }



}
