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
        MonsterScriptGenerated = new MonsterScript();

        GenerateMonsterFunc();
        MonsterScriptGenerated.SetMonsterName("Monster " + MonsterNumberAt); 
        MonsterScriptGenerated.SetMonsterOwner("Player");

        TheManager.AddMonsterToData(MonsterScriptGenerated);
        MonsterNumberAt++;
    }

    // this function create a monster that is specifically designed to be used for the battle Mechanic against the AI
    // the monster generated will be the same as it would be generated for the player exceopt the name will be changed and the function will return the script instead of adding it to the game manager
    // this script will be attached to battle manager so it can be used
    public MonsterScript CreateEnemyMonster(int MonsterNumberAt)
    {
        // a way to track a number (for multiple enemies)

        MonsterScriptGenerated = new MonsterScript();
        GenerateMonsterFunc();
        MonsterScriptGenerated.SetMonsterName("Enemy Monster " + MonsterNumberAt);
        MonsterScriptGenerated.SetMonsterOwner("AI");

       
        return MonsterScriptGenerated;
    }

    //this function goes about actually generating the information for the monster
    public void GenerateMonsterFunc()
    {
        //setting the monster image number
        MonsterScriptGenerated.SetMonsterImageNumber(Random.Range(1, 4));

        //this first part makes it so stars are generated

        int StarChance = Random.Range(0, 101);

        if(StarChance <= 30)
        {
            MonsterScriptGenerated.SetMonsterStars(1);
        }
        else if(StarChance > 30 && StarChance <= 65)
        {
            MonsterScriptGenerated.SetMonsterStars(2);
        }
        else if(StarChance > 65 && StarChance <= 80)
        {
            MonsterScriptGenerated.SetMonsterStars(3);
        }
        else if(StarChance > 80 && StarChance <= 95)
        {
            MonsterScriptGenerated.SetMonsterStars(4);
        }
        else if(StarChance > 95 && StarChance <= 100)
        {
            MonsterScriptGenerated.SetMonsterStars(5);
        }

        switch (MonsterScriptGenerated.ReturnMonsterStars())
        {
            case (1):
                {
                    MonsterScriptGenerated.SetMonsterMaxLevel(15);
                    MonsterScriptGenerated.SetMonsterMultiplier(0.01f);
                    break; 
                }
            case (2):
                {
                    MonsterScriptGenerated.SetMonsterMaxLevel(20);
                    MonsterScriptGenerated.SetMonsterMultiplier(0.05f);
                    break;
                }
            case (3):
                {
                    MonsterScriptGenerated.SetMonsterMaxLevel(25);
                    MonsterScriptGenerated.SetMonsterMultiplier(0.1f);
                    break;
                }
            case (4):
                {
                    MonsterScriptGenerated.SetMonsterMaxLevel(30);
                    MonsterScriptGenerated.SetMonsterMultiplier(0.15f);
                    break;
                }
            case (5):
                {
                    MonsterScriptGenerated.SetMonsterMaxLevel(35);
                    MonsterScriptGenerated.SetMonsterMultiplier(0.20f);
                    break;
                }

        }


        // this part will now generate the type of monster that this one will be
        int MonsterTypeChance = Random.Range(0, 93);

        if(MonsterTypeChance <= 30)
        {
            MonsterScriptGenerated.SetMonsterstype("Attack");
        }
        else if(MonsterTypeChance >= 31 && MonsterTypeChance <= 61)
        {
            MonsterScriptGenerated.SetMonsterstype("Health");
        }
        else if(MonsterTypeChance >= 62 && MonsterTypeChance <= 92)
        {
            MonsterScriptGenerated.SetMonsterstype("Defence");
        }


        //this part will now generate the stats for the monster (they will chnage depending on the stars and 
        //health generation for the monster
        int TempHealth = Random.Range(100, 200);
        TempHealth = (TempHealth * (10 * MonsterScriptGenerated.ReturnMonsterStars()));

        switch (MonsterScriptGenerated.ReturnMonsterType())
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

        MonsterScriptGenerated.SetMonsterHealth(TempHealth);


        //defence generation for the monster

        int TempDefence = Random.Range(100, 200);
        TempDefence = (TempDefence * (10 * MonsterScriptGenerated.ReturnMonsterStars()));

        switch (MonsterScriptGenerated.ReturnMonsterType())
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

        MonsterScriptGenerated.SetMonsterDefence(TempDefence);

        // Attack generation for the monster

        int TempAttack = Random.Range(100, 200);
        TempAttack = (TempAttack * (10 * MonsterScriptGenerated.ReturnMonsterStars()));

        switch (MonsterScriptGenerated.ReturnMonsterType())
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

        MonsterScriptGenerated.SetMonsterAttack(TempAttack);

        // Speed Generation for the monster
        int TempSpeed = Random.Range(90, 120);
        TempSpeed = (TempSpeed + (5 + MonsterScriptGenerated.ReturnMonsterStars()));

        switch (MonsterScriptGenerated.ReturnMonsterType())
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

        MonsterScriptGenerated.SetMonsterSpeed(TempSpeed);

        //Crit Rate Generation for the monster
        int TempCritRate = Random.Range(10, 30);
        TempCritRate = (TempCritRate + (5 + MonsterScriptGenerated.ReturnMonsterStars()));

        switch (MonsterScriptGenerated.ReturnMonsterType())
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


        MonsterScriptGenerated.SetMonsterCritRate(TempCritRate);


        //Crit Damage Generation for the monster
        int TempCritDamage = Random.Range(80, 110);
        TempCritDamage = (TempCritDamage + (Random.Range(10, 15) + MonsterScriptGenerated.ReturnMonsterStars()));

        switch (MonsterScriptGenerated.ReturnMonsterType())
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

        MonsterScriptGenerated.SetMonsterCritDamage(TempCritDamage);

        //Accuracy Generation for the monster
        int TempAccuracy = Random.Range(10,20);
        TempAccuracy = (TempAccuracy + MonsterScriptGenerated.ReturnMonsterStars());

        switch (MonsterScriptGenerated.ReturnMonsterType())
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

        MonsterScriptGenerated.SetMonsterAccuracy(TempAccuracy);


        // the Resistance of the monster generation
        int TempResistance = Random.Range(10, 20);
        TempResistance = (TempResistance + (3 * MonsterScriptGenerated.ReturnMonsterStars()));

        switch (MonsterScriptGenerated.ReturnMonsterType())
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

        MonsterScriptGenerated.SetMonsterResistance(TempResistance);

        // now the final step is generating the skills for the monster.
        
        //first skill 
        // first skill deciding if its an AOE
        if(Random.Range(1, 100) > 40)
        {
            MonsterScriptGenerated.SetSkillOneAOE(false);
        }
        else
        {
            MonsterScriptGenerated.SetSkillOneAOE(true);
        }

        // determines what type of skill the first skill will be
        int SKillTemp = Random.Range(1, 100);
        if (SKillTemp >= 1 && SKillTemp < 33)
        {
            MonsterScriptGenerated.SetSkillOneMainEffect("Healing");
            MonsterScriptGenerated.SetFirstSkillMultiplier(Random.Range(0.1f, 0.3f));
        }
        else if (SKillTemp >= 33 && SKillTemp < 66)
        {
            MonsterScriptGenerated.SetSkillOneMainEffect("Damage");
            MonsterScriptGenerated.SetFirstSkillMultiplier(Random.Range(0.1f, 0.3f));
        }
        else
        {
            if(Random.Range(1, 100) > 50)
            {
                MonsterScriptGenerated.SetSkillOneMainEffect("BeneficialEffect");
                //adding effects
                int TempEffects = Random.Range(1, 4);

                for(int i = 0; i <= TempEffects; i++)
                {
                    int TempChosenEffects = 0;

                    switch (i)
                    {
                        case (1):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("Accuracy");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("Attack");
                                }


                                break;
                            }
                        case (2):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("CritRate");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("Defence");
                                }

                                

                                break;
                            }
                        case (3):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("Immunity");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("Shield");
                                }


                                break;
                            }
                    }

                    
                   

                }

            }
            else
            {
                MonsterScriptGenerated.SetSkillOneMainEffect("HarmfulEffect");

                int TempEffects = Random.Range(1, 4);

                for (int i = 0; i <= TempEffects; i++)
                {
                    int TempChosenEffects = 0;

                    switch (i)
                    {
                        case (1):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("AttackDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("CritDeBuff");
                                }


                                break;
                            }
                        case (2):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("DefenceDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("ImmunityDeBuff");
                                }

                             

                                break;
                            }
                        case (3):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("MissDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectFirstSkill("ShieldDeBuff");
                                }

                                break;
                            }
                    }




                }

            }
        }

        //now determins if the first skill will have a secondary effect
        SKillTemp = Random.Range(1, 3);
        if(SKillTemp == 1)
        {

            switch (MonsterScriptGenerated.ReturnrSkillOneMainEffect())
            {
                case ("Healing"):
                    {
                        SKillTemp = Random.Range(1, 100);
                        MonsterScriptGenerated.SetFirstSkillSecondaryMultiplier(Random.Range(0.1f, 0.3f));

                        if(SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterScriptGenerated.SetSkillOneSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterScriptGenerated.SetSkillOneSecondaryEffect("BeneficialEffect");
                            int TempEffects = Random.Range(1, 4);

                            for (int i = 0; i <= TempEffects; i++)
                            {
                                int TempChosenEffects = 0;

                                switch (i)
                                {
                                    case (1):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectFirstSkill("Accuracy");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectFirstSkill("Attack");
                                            }

                                            

                                            break;
                                        }
                                    case (2):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectFirstSkill("CritRate");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectFirstSkill("Defence");
                                            }

                                          

                                            break;
                                        }
                                    case (3):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectFirstSkill("Immunity");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectFirstSkill("Shield");
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
                        MonsterScriptGenerated.SetFirstSkillSecondaryMultiplier(Random.Range(0.1f, 0.3f));
                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterScriptGenerated.SetSkillOneSecondaryEffect("Healing");
                        }
                        else
                        {
                            if (Random.Range(1, 100) > 50)
                            {
                                MonsterScriptGenerated.SetSkillOneSecondaryEffect("BeneficialEffect");
                                //adding effects
                                int TempEffects = Random.Range(1, 4);

                                for (int i = 0; i <= TempEffects; i++)
                                {
                                    int TempChosenEffects = 0;

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("Accuracy");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("Attack");
                                                }



                                                break;
                                            }
                                        case (2):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("CritRate");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("Defence");
                                                }

                                               

                                                break;
                                            }
                                        case (3):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("Immunity");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("Shield");
                                                }

                                              

                                                break;
                                            }
                                    }




                                }

                            }
                            else
                            {
                                MonsterScriptGenerated.SetSkillOneSecondaryEffect("HarmfulEffect");

                                int TempEffects = Random.Range(1, 4);

                                for (int i = 0; i <= TempEffects; i++)
                                {
                                    int TempChosenEffects = 0;

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("AttackDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("CritDeBuff");
                                                }


                                                break;
                                            }
                                        case (2):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("DefenceDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("ImmunityDeBuff");
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("MissDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectFirstSkill("ShieldDeBuff");
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
                        MonsterScriptGenerated.SetSkillOneSecondaryEffect("Healing");
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        if (Random.Range(1, 3) == 1)
                        {
                            MonsterScriptGenerated.SetSkillOneSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterScriptGenerated.SetSkillOneSecondaryEffect("Damage");
                        }

                        break;
                    }
            }


        }




        //determines the Second skill for the monster and what the second skill will have
        SKillTemp = Random.Range(1, 100);
        if (SKillTemp >= 1 && SKillTemp < 33)
        {
            MonsterScriptGenerated.SetSkillTwoMainEffect("Healing");
            MonsterScriptGenerated.SetSecondSkillMultipler(Random.Range(0.3f, 0.5f));
        }
        else if (SKillTemp >= 33 && SKillTemp < 66)
        {
            MonsterScriptGenerated.SetSkillTwoMainEffect("Damage");
            MonsterScriptGenerated.SetSecondSkillMultipler(Random.Range(0.3f, 0.5f));
        }
        else
        {
            if (Random.Range(1, 100) > 50)
            {
                MonsterScriptGenerated.SetSkillTwoMainEffect("BeneficialEffect");
                //adding effects
                int TempEffects = Random.Range(1, 4);

                for (int i = 0; i <= TempEffects; i++)
                {
                    int TempChosenEffects = 0;

                    switch (i)
                    {
                        case (1):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("Accuracy");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("Attack");
                                }


                                break;
                            }
                        case (2):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("CritRate");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("Defence");
                                }


                                break;
                            }
                        case (3):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("Immunity");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("Shield");
                                }


                                break;
                            }
                    }




                }

            }
            else
            {
                MonsterScriptGenerated.SetSkillTwoMainEffect("HarmfulEffect");

                int TempEffects = Random.Range(1, 4);

                for (int i = 0; i <= TempEffects; i++)
                {
                    int TempChosenEffects = 0;

                    switch (i)
                    {
                        case (1):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("AttackDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("CritDeBuff");
                                }


                                break;
                            }
                        case (2):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("DefenceDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("ImmunityDeBuff");
                                }


                                break;
                            }
                        case (3):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("MissDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectSecondSkill("ShieldDeBuff");
                                }


                                break;
                            }
                    }




                }

            }
        }

        //now determins if the first skill will have a secondary effect
        SKillTemp = Random.Range(1, 3);
        if (SKillTemp == 1)
        {

            switch (MonsterScriptGenerated.ReturnSkillTwoMainEffect())
            {
                case ("Healing"):
                    {
                        SKillTemp = Random.Range(1, 100);
                        
                        MonsterScriptGenerated.SetSecondSkillSecondaryMultiplier(Random.Range(0.3f, 0.5f));

                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterScriptGenerated.SetSkillTwoSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterScriptGenerated.SetSkillTwoSecondaryEffect("BeneficialEffect");
                            int TempEffects = Random.Range(1, 4);

                            for (int i = 0; i <= TempEffects; i++)
                            {
                                int TempChosenEffects = 0;

                                switch (i)
                                {
                                    case (1):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectSecondSkill("Accuracy");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectSecondSkill("Attack");
                                            }


                                            break;
                                        }
                                    case (2):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectSecondSkill("CritRate");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectSecondSkill("Defence");
                                            }


                                            break;
                                        }
                                    case (3):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectSecondSkill("Immunity");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectSecondSkill("Shield");
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
                        MonsterScriptGenerated.SetSecondSkillSecondaryMultiplier(Random.Range(0.3f, 0.5f));
                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterScriptGenerated.SetSkillTwoSecondaryEffect("Healing");
                        }
                        else
                        {
                            if (Random.Range(1, 100) > 50)
                            {
                                MonsterScriptGenerated.SetSkillTwoSecondaryEffect("BeneficialEffect");
                                //adding effects
                                int TempEffects = Random.Range(1, 4);

                                for (int i = 0; i <= TempEffects; i++)
                                {
                                    int TempChosenEffects = 0;

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("Accuracy");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("Attack");
                                                }


                                                break;
                                            }
                                        case (2):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("CritRate");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("Defence");
                                                }


                                                break;
                                            }
                                        case (3):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("Immunity");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("Shield");
                                                }


                                                break;
                                            }
                                    }




                                }

                            }
                            else
                            {
                                MonsterScriptGenerated.SetSkillTwoSecondaryEffect("HarmfulEffect");

                                int TempEffects = Random.Range(1, 4);

                                for (int i = 0; i <= TempEffects; i++)
                                {
                                    int TempChosenEffects = 0;

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("AttackDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("CritDeBuff");
                                                }


                                                break;
                                            }
                                        case (2):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("DefenceDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("ImmunityDeBuff");
                                                }


                                                break;
                                            }
                                        case (3):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("MissDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectSecondSkill("ShieldDeBuff");
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
                        MonsterScriptGenerated.SetSkillTwoSecondaryEffect("Healing");
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        if (Random.Range(1, 3) == 1)
                        {
                            MonsterScriptGenerated.SetSkillTwoSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterScriptGenerated.SetSkillTwoSecondaryEffect("Damage");
                        }

                        break;
                    }
            }


        }


        //determines the third skill and its effects
        SKillTemp = Random.Range(1, 100);
        if (SKillTemp >= 1 && SKillTemp < 33)
        {
            MonsterScriptGenerated.SetSkillThreeMainEffect("Healing");
            MonsterScriptGenerated.SetThirdSkillMultiplier(Random.Range(0.5f, 0.7f));
        }
        else if (SKillTemp >= 33 && SKillTemp < 66)
        {
            MonsterScriptGenerated.SetSkillThreeMainEffect("Damage");
            MonsterScriptGenerated.SetThirdSkillMultiplier(Random.Range(0.5f, 0.7f));
        }
        else
        {
            if (Random.Range(1, 100) > 50)
            {
                MonsterScriptGenerated.SetSkillThreeMainEffect("BeneficialEffect");
                //adding effects
                int TempEffects = Random.Range(1, 4);

                for (int i = 0; i <= TempEffects; i++)
                {
                    int TempChosenEffects = 0;

                    switch (i)
                    {
                        case (1):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("Accuracy");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("Attack");
                                }

                                break;
                            }
                        case (2):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("CritRate");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("Defence");
                                }

                                break;
                            }
                        case (3):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("Immunity");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("Shield");
                                }

                                break;
                            }
                    }




                }

            }
            else
            {
                MonsterScriptGenerated.SetSkillThreeMainEffect("HarmfulEffect");

                int TempEffects = Random.Range(1, 4);

                for (int i = 0; i <= TempEffects; i++)
                {
                    int TempChosenEffects = 0;

                    switch (i)
                    {
                        case (1):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("AttackDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("CritDeBuff");
                                }

                                break;
                            }
                        case (2):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("DefenceDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("ImmunityDeBuff");
                                }


                                break;
                            }
                        case (3):
                            {
                                TempChosenEffects = Random.Range(1, 100);

                                if (TempChosenEffects < 50)
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("MissDeBuff");
                                }
                                else
                                {
                                    MonsterScriptGenerated.AddEffectThirdSkill("ShieldDeBuff");
                                }


                                break;
                            }
                    }




                }

            }
        }

        //now determins if the first skill will have a secondary effect
        SKillTemp = Random.Range(1, 3);
        if (SKillTemp == 1)
        {

            switch (MonsterScriptGenerated.ReturnSkillThreeMainEffect())
            {
                case ("Healing"):
                    {
                        SKillTemp = Random.Range(1, 100);
                        MonsterScriptGenerated.SetThirdSkillSecondaryMultiplier(Random.Range(0.5f, 0.7f));
                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterScriptGenerated.SetSkillThreeSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterScriptGenerated.SetSkillThreeSecondaryEffect("BeneficialEffect");
                            int TempEffects = Random.Range(1, 4);

                            for (int i = 0; i <= TempEffects; i++)
                            {
                                int TempChosenEffects = 0;

                                switch (i)
                                {
                                    case (1):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectThirdSkill("Accuracy");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectThirdSkill("Attack");
                                            }

                                            break;
                                        }
                                    case (2):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectThirdSkill("CritRate");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectThirdSkill("Defence");
                                            }

                                            break;
                                        }
                                    case (3):
                                        {
                                            TempChosenEffects = Random.Range(1, 100);

                                            if (TempChosenEffects < 50)
                                            {
                                                MonsterScriptGenerated.AddEffectThirdSkill("Immunity");
                                            }
                                            else
                                            {
                                                MonsterScriptGenerated.AddEffectThirdSkill("Shield");
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
                        MonsterScriptGenerated.SetThirdSkillSecondaryMultiplier(Random.Range(0.5f, 0.7f));
                        if (SKillTemp >= 1 && SKillTemp < 50)
                        {
                            MonsterScriptGenerated.SetSkillThreeSecondaryEffect("Healing");
                        }
                        else
                        {
                            if (Random.Range(1, 100) > 50)
                            {
                                MonsterScriptGenerated.SetSkillThreeSecondaryEffect("BeneficialEffect");
                                //adding effects
                                int TempEffects = Random.Range(1, 4);

                                for (int i = 0; i <= TempEffects; i++)
                                {
                                    int TempChosenEffects = 0;

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("Accuracy");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("Attack");
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("CritRate");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("Defence");
                                                }

                                                break;
                                            }
                                        case (3):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("Immunity");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("Shield");
                                                }

                                                break;
                                            }
                                    }




                                }

                            }
                            else
                            {
                                MonsterScriptGenerated.SetSkillThreeSecondaryEffect("HarmfulEffect");

                                int TempEffects = Random.Range(1, 4);

                                for (int i = 0; i <= TempEffects; i++)
                                {
                                    int TempChosenEffects = 0;

                                    switch (i)
                                    {
                                        case (1):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("AttackDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("CritDeBuff");
                                                }

                                                break;
                                            }
                                        case (2):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("DefenceDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("ImmunityDeBuff");
                                                }


                                                break;
                                            }
                                        case (3):
                                            {
                                                TempChosenEffects = Random.Range(1, 100);

                                                if (TempChosenEffects < 50)
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("MissDeBuff");
                                                }
                                                else
                                                {
                                                    MonsterScriptGenerated.AddEffectThirdSkill("ShieldDeBuff");
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
                        MonsterScriptGenerated.SetSkillThreeSecondaryEffect("Healing");
                        break;
                    }
                case ("HarmfulEffect"):
                    {
                        if (Random.Range(1, 3) == 1)
                        {
                            MonsterScriptGenerated.SetSkillThreeSecondaryEffect("Healing");
                        }
                        else
                        {
                            MonsterScriptGenerated.SetSkillThreeSecondaryEffect("Damage");
                        }

                        break;
                    }
            }


        }

        //Semi final step is to calculate the multiplier of each of the skills. this is a number that will be used in the skill script to determine the effectiveness of each skill
        MonsterScriptGenerated.SetFirstSkillMultiplier(Random.Range(0.1f, 0.4f));

        MonsterScriptGenerated.SetSecondSkillMultipler(Random.Range(0.3f, 0.7f));

        MonsterScriptGenerated.SetThirdSkillMultiplier(Random.Range(0.8f, 1.2f));

        // final step is setting the max turns for the seconda and third skills on the monster

        MonsterScriptGenerated.SetSkillTwoMaxTurns(Random.Range(2,6));

        MonsterScriptGenerated.SetSkillThreeMaxTurns(Random.Range(2,6));

        // generating the skill scripts and storing them in the monster
        // skill one generated
        MonsterSkillScript SkillOne = new MonsterSkillScript();
        SkillOne.SetSkillAOE(MonsterScriptGenerated.ReturnSkillOneAOE());
        SkillOne.SetSkillMainEffect(MonsterScriptGenerated.ReturnrSkillOneMainEffect());
        SkillOne.SetSkillSecondaryeffect(MonsterScriptGenerated.ReturnSkillOneSecondaryEffect());
        SkillOne.SetSkillMainEffectMultiplier(MonsterScriptGenerated.ReturnMonsterSkillOneMultipler());
        SkillOne.SetSkillSecondaryEffectMultiplier(MonsterScriptGenerated.ReturnMonsterSkillOneSecondMultiplier());
        SkillOne.SetSkillEffects(MonsterScriptGenerated.ReturnAllSkillOneEffects());

        MonsterScriptGenerated.SetMonsterSkills(SkillOne);


        // Skill Two geerated

        MonsterSkillScript SkillTwo = new MonsterSkillScript();
        SkillTwo.SetSkillAOE(MonsterScriptGenerated.ReturnSkillTwoAOE());
        SkillTwo.SetSkillMainEffect(MonsterScriptGenerated.ReturnSkillTwoMainEffect());
        SkillTwo.SetSkillSecondaryeffect(MonsterScriptGenerated.ReturnSkillTwoSecondaryEffect());
        SkillTwo.SetSkillMainEffectMultiplier(MonsterScriptGenerated.ReturnMonsterSkillTwoMultipler());
        SkillTwo.SetSkillSecondaryEffectMultiplier(MonsterScriptGenerated.ReturnMonsterSkillTwoSecondMultiplier());
        SkillTwo.SetSkillEffects(MonsterScriptGenerated.ReturnAllSkillTwoEffects());
        SkillTwo.SetSkillMaxCoolDown(MonsterScriptGenerated.ReturnMonsterSkillTwoMaxTurns());
        MonsterScriptGenerated.SetMonsterSkills(SkillTwo);



        // skill three generated

        MonsterSkillScript SkillThree = new MonsterSkillScript();
        SkillThree.SetSkillAOE(MonsterScriptGenerated.ReturnSkillThreeAOE());
        SkillThree.SetSkillMainEffect(MonsterScriptGenerated.ReturnSkillThreeMainEffect());
        SkillThree.SetSkillSecondaryeffect(MonsterScriptGenerated.ReturnSkillThreeSecondaryEffect());
        SkillThree.SetSkillMainEffectMultiplier(MonsterScriptGenerated.ReturnMonsterSkillThreeMultipler());
        SkillThree.SetSkillSecondaryEffectMultiplier(MonsterScriptGenerated.ReturnMonsterSkillThreeSecondMultiplier());
        SkillThree.SetSkillEffects(MonsterScriptGenerated.ReturnAllSkillThreeEffects());
        SkillThree.SetSkillMaxCoolDown(MonsterScriptGenerated.ReturnMonsterSkillThreeMaxTurns());
        MonsterScriptGenerated.SetMonsterSkills(SkillThree);

    }
}
