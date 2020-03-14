﻿using System.Collections;
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
        MonsterScriptGenerated = new MonsterScript();

        GenerateMonsterFunc();
        MonsterDataGenerated.SetMonsterName("Monster" + MonsterNumberAt);
        MonsterDataGenerated.SetMonsterOwner("Player");
        
        MonsterNumberAt++;
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

        int TempDefence = Random.Range(100, 200);
        TempDefence = (TempDefence * (10 * MonsterDataGenerated.ReturnMonsterStars()));

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Attack"):
                {
                    TempDefence -= Random.Range(200, 300);
                    break;
                }
            case ("Defence"):
                {
                    TempDefence += Random.Range(300, 400);
                    break;
                }
            case ("Health"):
                {
                    TempDefence -= Random.Range(100, 200);
                    break;
                }
        }

        MonsterDataGenerated.SetMonsterDefence(TempDefence);

        // Attack generation for the monster

        int TempAttack = Random.Range(100, 200);
        TempAttack = (TempAttack * (10 * MonsterDataGenerated.ReturnMonsterStars()));

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Attack"):
                {
                    TempAttack += Random.Range(300, 400);
                    break;
                }
            case ("Defence"):
                {
                    TempAttack -= Random.Range(100, 200);
                    break;
                }
            case ("Health"):
                {
                    TempAttack -= Random.Range(200, 300);
                    break;
                }
        }

        MonsterDataGenerated.SetMonsterAttack(TempAttack);

        // Speed Generation for the monster
        int TempSpeed = Random.Range(90, 120);
        TempSpeed = (TempSpeed + (5 + MonsterDataGenerated.ReturnMonsterStars()));

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Attack"):
                {
                    TempSpeed += Random.Range(2, 3);
                    break;
                }
            case ("Defence"):
                {
                    TempSpeed += Random.Range(1, 3);
                    break;
                }
            case ("Health"):
                {
                    TempSpeed += Random.Range(3, 5);
                    break;
                }
        }

        MonsterDataGenerated.SetMonsterSpeed(TempSpeed);

        //Crit Rate Generation for the monster
        int TempCritRate = Random.Range(10, 30);
        TempCritRate = (TempCritRate + (5 + MonsterDataGenerated.ReturnMonsterStars()));

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Attack"):
                {
                    TempCritRate += Random.Range(3, 5);
                    break;
                }
            case ("Defence"):
                {
                    TempCritRate -= Random.Range(3, 5);
                    break;
                }
            case ("Health"):
                {
                    TempCritRate -= Random.Range(3, 5);
                    break;
                }
        }


        MonsterDataGenerated.SetMonsterCritRate(TempCritRate);


        //Crit Damage Generation for the monster
        int TempCritDamage = Random.Range(80, 110);
        TempCritDamage = (TempCritDamage + (Random.Range(10, 15) + MonsterDataGenerated.ReturnMonsterStars()));

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Attack"):
                {
                    TempCritDamage += Random.Range(5, 10);
                    break;
                }
            case ("Defence"):
                {
                    TempCritDamage -= 10;
                    break;
                }
            case ("Health"):
                {
                    TempCritDamage -= 10;
                    break;
                }
        }

        MonsterDataGenerated.SetMonsterCritDamage(TempCritDamage);

        //Accuracy Generation for the monster
        int TempAccuracy = Random.Range(10,20);
        TempAccuracy = (TempAccuracy + MonsterDataGenerated.ReturnMonsterStars());

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Defence"):
                {
                    TempAccuracy += Random.Range(5,10);
                    break;
                }
            case ("Health"):
                {
                    TempAccuracy += Random.Range(5, 10);
                    break;
                }
        }

        MonsterDataGenerated.SetMonsterAccuracy(TempAccuracy);


        // the Resistance of the monster generation
        int TempResistance = Random.Range(10, 20);
        TempResistance = (TempResistance + (3 * MonsterDataGenerated.ReturnMonsterStars()));

        switch (MonsterDataGenerated.ReturnMonsterType())
        {
            case ("Defence"):
                {
                    TempResistance += Random.Range(1, 5);
                    break;
                }
            case ("Health"):
                {
                    TempResistance += Random.Range(1, 5);
                    break;
                }
            case ("Attack"):
                {
                    TempResistance -= Random.Range(5, 10);
                    break;
                }
        }

        MonsterDataGenerated.SetMonsterResistance(TempResistance);

        // now the final step is generating the skills for the monster.
        
        //first skill 
        // first skill deciding if its an AOE
        if(Random.Range(1, 100) > 30)
        {
            MonsterDataGenerated.SetSkillOneAOE(false);
        }
        else
        {
            MonsterDataGenerated.SetSkillOneAOE(true);
        }

        // determines what type of skill the first skill will be
        int SKillTemp = Random.Range(1, 100);
        if (SKillTemp >= 1 && SKillTemp < 33)
        {
            MonsterDataGenerated.SetSkillOneMainEffect("Healing");
        }
        else if (SKillTemp >= 33 && SKillTemp < 66)
        {
            MonsterDataGenerated.SetSkillOneMainEffect("Damage");
        }
        else
        {
            if(Random.Range(1, 100) > 50)
            {
                MonsterDataGenerated.SetSkillOneMainEffect("BeneficialEffect");
                //adding effects
                int TempEffects = Random.Range(1, 3);

                for(int i = 0; i < TempEffects; i++)
                {
                    int TempChosenEffects = Random.Range(1, 2);

                    switch (i)
                    {
                        case (1):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("Accuracy");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("Attack");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (2):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("CritRate");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("Defence");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (3):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("Immunity");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("Shield");
                                            break;
                                        }
                                }

                                break;
                            }
                    }

                    
                   

                }

            }
            else
            {
                MonsterDataGenerated.SetSkillOneMainEffect("HarmfulEffect");

                int TempEffects = Random.Range(1, 3);

                for (int i = 0; i < TempEffects; i++)
                {
                    int TempChosenEffects = Random.Range(1, 2);

                    switch (i)
                    {
                        case (1):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("AttackDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("CritDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (2):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("DefenceDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("ImmunityDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (3):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("MissDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectFirstSkill("ShieldDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                    }




                }

            }
        }

        //now determins if the first skill will have a secondary effect
        SKillTemp = Random.Range(1, 2);
        if(SKillTemp == 1)
        {

            switch (MonsterDataGenerated.ReturnSkillOneMainEffect())
            {
                case ("Healing"):
                    {
                        SKillTemp = Random.Range(1, 100);

                        if(SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterDataGenerated.SetSkillOneSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterDataGenerated.SetSkillOneSecondaryEffect("BeneficialEffect");
                            int TempEffects = Random.Range(1, 3);

                            for (int i = 0; i < TempEffects; i++)
                            {
                                int TempChosenEffects = Random.Range(1, 2);

                                switch (i)
                                {
                                    case (1):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectFirstSkill("Accuracy");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectFirstSkill("Attack");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                    case (2):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectFirstSkill("CritRate");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectFirstSkill("Defence");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                    case (3):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectFirstSkill("Immunity");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectFirstSkill("Shield");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                }

                            }
                        }

                        break;
                    }
                case ("Damage"):
                    {
                        SKillTemp = Random.Range(1, 100);
                        if(SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterDataGenerated.SetSkillOneSecondaryEffect("Healing");
                        }
                        else
                        {
                            if (Random.Range(1, 100) > 50)
                            {
                                MonsterDataGenerated.SetSkillOneSecondaryEffect("BeneficialEffect");
                                //adding effects
                                int TempEffects = Random.Range(1, 3);

                                for (int i = 0; i < TempEffects; i++)
                                {
                                    int TempChosenEffects = Random.Range(1, 2);

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("Accuracy");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("Attack");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("CritRate");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("Defence");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("Immunity");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("Shield");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                    }




                                }

                            }
                            else
                            {
                                MonsterDataGenerated.SetSkillOneSecondaryEffect("HarmfulEffect");

                                int TempEffects = Random.Range(1, 3);

                                for (int i = 0; i < TempEffects; i++)
                                {
                                    int TempChosenEffects = Random.Range(1, 2);

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("AttackDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("CritDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("DefenceDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("ImmunityDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("MissDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectFirstSkill("ShieldDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                    }




                                }

                            }
                        }

                        break;
                    }
                case ("BeneficialEffect"):
                    {
                        MonsterDataGenerated.SetSkillOneSecondaryEffect("Healing");
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        if (Random.Range(1, 2) == 1)
                        {
                            MonsterDataGenerated.SetSkillOneSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterDataGenerated.SetSkillOneSecondaryEffect("Damage");
                        }

                        break;
                    }
            }


        }




        //determines the Second skill for the monster and what the second skill will have
        SKillTemp = Random.Range(1, 100);
        if (SKillTemp >= 1 && SKillTemp < 33)
        {
            MonsterDataGenerated.SetSkillTwoMainEffect("Healing");
        }
        else if (SKillTemp >= 33 && SKillTemp < 66)
        {
            MonsterDataGenerated.SetSkillTwoMainEffect("Damage");
        }
        else
        {
            if (Random.Range(1, 100) > 50)
            {
                MonsterDataGenerated.SetSkillTwoMainEffect("BeneficialEffect");
                //adding effects
                int TempEffects = Random.Range(1, 3);

                for (int i = 0; i < TempEffects; i++)
                {
                    int TempChosenEffects = Random.Range(1, 2);

                    switch (i)
                    {
                        case (1):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("Accuracy");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("Attack");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (2):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("CritRate");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("Defence");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (3):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("Immunity");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("Shield");
                                            break;
                                        }
                                }

                                break;
                            }
                    }




                }

            }
            else
            {
                MonsterDataGenerated.SetSkillTwoMainEffect("HarmfulEffect");

                int TempEffects = Random.Range(1, 3);

                for (int i = 0; i < TempEffects; i++)
                {
                    int TempChosenEffects = Random.Range(1, 2);

                    switch (i)
                    {
                        case (1):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("AttackDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("CritDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (2):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("DefenceDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("ImmunityDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (3):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("MissDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectSecondSkill("ShieldDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                    }




                }

            }
        }

        //now determins if the first skill will have a secondary effect
        SKillTemp = Random.Range(1, 2);
        if (SKillTemp == 1)
        {

            switch (MonsterDataGenerated.ReturnSkillTwoMainEffect())
            {
                case ("Healing"):
                    {
                        SKillTemp = Random.Range(1, 100);

                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterDataGenerated.SetSkillTwoSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterDataGenerated.SetSkillTwoSecondaryEffect("BeneficialEffect");
                            int TempEffects = Random.Range(1, 3);

                            for (int i = 0; i < TempEffects; i++)
                            {
                                int TempChosenEffects = Random.Range(1, 2);

                                switch (i)
                                {
                                    case (1):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectSecondSkill("Accuracy");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectSecondSkill("Attack");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                    case (2):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectSecondSkill("CritRate");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectSecondSkill("Defence");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                    case (3):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectSecondSkill("Immunity");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectSecondSkill("Shield");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                }

                            }
                        }

                        break;
                    }
                case ("Damage"):
                    {
                        SKillTemp = Random.Range(1, 100);
                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterDataGenerated.SetSkillTwoSecondaryEffect("Healing");
                        }
                        else
                        {
                            if (Random.Range(1, 100) > 50)
                            {
                                MonsterDataGenerated.SetSkillTwoSecondaryEffect("BeneficialEffect");
                                //adding effects
                                int TempEffects = Random.Range(1, 3);

                                for (int i = 0; i < TempEffects; i++)
                                {
                                    int TempChosenEffects = Random.Range(1, 2);

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("Accuracy");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("Attack");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("CritRate");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("Defence");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("Immunity");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("Shield");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                    }




                                }

                            }
                            else
                            {
                                MonsterDataGenerated.SetSkillTwoSecondaryEffect("HarmfulEffect");

                                int TempEffects = Random.Range(1, 3);

                                for (int i = 0; i < TempEffects; i++)
                                {
                                    int TempChosenEffects = Random.Range(1, 2);

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("AttackDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("CritDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("DefenceDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("ImmunityDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("MissDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectSecondSkill("ShieldDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                    }




                                }

                            }
                        }

                        break;
                    }
                case ("BeneficialEffect"):
                    {
                        MonsterDataGenerated.SetSkillTwoSecondaryEffect("Healing");
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        if (Random.Range(1, 2) == 1)
                        {
                            MonsterDataGenerated.SetSkillTwoSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterDataGenerated.SetSkillTwoSecondaryEffect("Damage");
                        }

                        break;
                    }
            }


        }


        //determines the third skill and its effects
        SKillTemp = Random.Range(1, 100);
        if (SKillTemp >= 1 && SKillTemp < 33)
        {
            MonsterDataGenerated.SetSkillThreeMainEffect("Healing");
        }
        else if (SKillTemp >= 33 && SKillTemp < 66)
        {
            MonsterDataGenerated.SetSkillThreeMainEffect("Damage");
        }
        else
        {
            if (Random.Range(1, 100) > 50)
            {
                MonsterDataGenerated.SetSkillThreeMainEffect("BeneficialEffect");
                //adding effects
                int TempEffects = Random.Range(1, 3);

                for (int i = 0; i < TempEffects; i++)
                {
                    int TempChosenEffects = Random.Range(1, 2);

                    switch (i)
                    {
                        case (1):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("Accuracy");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("Attack");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (2):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("CritRate");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("Defence");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (3):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("Immunity");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("Shield");
                                            break;
                                        }
                                }

                                break;
                            }
                    }




                }

            }
            else
            {
                MonsterDataGenerated.SetSkillThreeMainEffect("HarmfulEffect");

                int TempEffects = Random.Range(1, 3);

                for (int i = 0; i < TempEffects; i++)
                {
                    int TempChosenEffects = Random.Range(1, 2);

                    switch (i)
                    {
                        case (1):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("AttackDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("CritDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (2):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("DefenceDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("ImmunityDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                        case (3):
                            {
                                switch (TempChosenEffects)
                                {
                                    case (1):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("MissDeBuff");
                                            break;
                                        }
                                    case (2):
                                        {
                                            MonsterDataGenerated.AddEffectThirdSkill("ShieldDeBuff");
                                            break;
                                        }
                                }

                                break;
                            }
                    }




                }

            }
        }

        //now determins if the first skill will have a secondary effect
        SKillTemp = Random.Range(1, 2);
        if (SKillTemp == 1)
        {

            switch (MonsterDataGenerated.ReturnSkillThreeMainEffect())
            {
                case ("Healing"):
                    {
                        SKillTemp = Random.Range(1, 100);

                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterDataGenerated.SetSkillThreeSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterDataGenerated.SetSkillThreeSecondaryEffect("BeneficialEffect");
                            int TempEffects = Random.Range(1, 3);

                            for (int i = 0; i < TempEffects; i++)
                            {
                                int TempChosenEffects = Random.Range(1, 2);

                                switch (i)
                                {
                                    case (1):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectThirdSkill("Accuracy");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectThirdSkill("Attack");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                    case (2):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectThirdSkill("CritRate");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectThirdSkill("Defence");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                    case (3):
                                        {
                                            switch (TempChosenEffects)
                                            {
                                                case (1):
                                                    {
                                                        MonsterDataGenerated.AddEffectThirdSkill("Immunity");
                                                        break;
                                                    }
                                                case (2):
                                                    {
                                                        MonsterDataGenerated.AddEffectThirdSkill("Shield");
                                                        break;
                                                    }
                                            }

                                            break;
                                        }
                                }

                            }
                        }

                        break;
                    }
                case ("Damage"):
                    {
                        SKillTemp = Random.Range(1, 100);
                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterDataGenerated.SetSkillThreeSecondaryEffect("Healing");
                        }
                        else
                        {
                            if (Random.Range(1, 100) > 50)
                            {
                                MonsterDataGenerated.SetSkillThreeSecondaryEffect("BeneficialEffect");
                                //adding effects
                                int TempEffects = Random.Range(1, 3);

                                for (int i = 0; i < TempEffects; i++)
                                {
                                    int TempChosenEffects = Random.Range(1, 2);

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("Accuracy");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("Attack");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("CritRate");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("Defence");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("Immunity");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("Shield");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                    }




                                }

                            }
                            else
                            {
                                MonsterDataGenerated.SetSkillThreeSecondaryEffect("HarmfulEffect");

                                int TempEffects = Random.Range(1, 3);

                                for (int i = 0; i < TempEffects; i++)
                                {
                                    int TempChosenEffects = Random.Range(1, 2);

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("AttackDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("CritDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("DefenceDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("ImmunityDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                switch (TempChosenEffects)
                                                {
                                                    case (1):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("MissDeBuff");
                                                            break;
                                                        }
                                                    case (2):
                                                        {
                                                            MonsterDataGenerated.AddEffectThirdSkill("ShieldDeBuff");
                                                            break;
                                                        }
                                                }

                                                break;
                                            }
                                    }




                                }

                            }
                        }

                        break;
                    }
                case ("BeneficialEffect"):
                    {
                        MonsterDataGenerated.SetSkillThreeSecondaryEffect("Healing");
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        if (Random.Range(1, 2) == 1)
                        {
                            MonsterDataGenerated.SetSkillThreeSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterDataGenerated.SetSkillThreeSecondaryEffect("Damage");
                        }

                        break;
                    }
            }


        }

        //final step is to calculate the multiplier of each of the skills. this is a number that will be used in the skill script to determine the effectiveness of each skill
        MonsterDataGenerated.SetFirstSkillMultiplier(Random.Range(0.1f, 0.4f));

        MonsterDataGenerated.SetSecondSkillMultipler(Random.Range(0.3f, 0.7f));

        MonsterDataGenerated.SetThirdSkillMultiplier(Random.Range(0.8f, 1.2f));

    }
}