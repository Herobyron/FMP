using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMonsterTest : MonoBehaviour
{
    // these are the text elements linked to the UI
    // Monster Stat
    public Text MonsterName;
    public Text MonsterHealth;
    public Text MonsterDefence;
    public Text MonsterAttack;
    public Text MonsterSpeed;
    public Text MonsterCritRate;
    public Text MonsterCritDamage;
    public Text MonsterAccuracy;
    public Text MonsterResistance;
    public Text MonsterStars;
    public Text MonsterLevel;
    public Text MonsterAwakened;
    public Text MonsterType;

    // Monster Skills
    public Text SkillOneDescription;
    public Text SkillTwoDescription;
    public Text SkillThreeDescription;

    public Text SkillOneImportance;
    public Text SkillTwoImportance;
    public Text SkillThreeImportance;


    // DropDown Commponents
    public Dropdown MonsterDisplay;
    public Dropdown SkillImportanceSelectionOne;
    public Dropdown SkillImportanceSelectionTwo;
    public Dropdown SkillImportanceSelectionThree;

    // bool to determine the wether the rune has been loaded
    public bool LoadTheRuneOnce = false;

    // the monster data that has currently been loaded
    private MonsterScript MonsterBiengUsed = null;

    // the game management
    private GameManagment TheManager;


    //list of the monsters names to be used for sorting through differnt monsters
    private List<string> Monsters = new List<string>();

    //the list of options for the Importance selection (these are predefined)
    private List<string> ImportanceSelectionOptions = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        TheManager = FindObjectOfType<GameManagment>();
        Monsters.Add("No Monster");
        MonsterDisplay.ClearOptions();
        MonsterDisplay.AddOptions(Monsters);

        ImportanceSelectionOptions.Add("Importance 1");
        ImportanceSelectionOptions.Add("Importance 2");
        ImportanceSelectionOptions.Add("Importance 3");

        SkillImportanceSelectionOne.ClearOptions();
        SkillImportanceSelectionOne.AddOptions(ImportanceSelectionOptions);

        SkillImportanceSelectionTwo.ClearOptions();
        SkillImportanceSelectionTwo.AddOptions(ImportanceSelectionOptions);

        SkillImportanceSelectionThree.ClearOptions();
        SkillImportanceSelectionThree.AddOptions(ImportanceSelectionOptions);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUI();
    }


    public void MonsterDisplayFunc()
    {
        Monsters.Clear();
        for(int i = 0; i < TheManager.ReturnMonsterNames().Count; i++)
        {
            Monsters.Add(TheManager.ReturnMonsterNames()[i]);
        }

        MonsterDisplay.ClearOptions();
        MonsterDisplay.AddOptions(Monsters);
        MonsterDisplay.value = 0;
        MonsterDisplay.Select();
        MonsterDisplay.RefreshShownValue();
    }


    public void ChangedValue()
    {
        if(TheManager.ReturnMonsterCount() == 0)
        {
            //do something with no monste used (for now does nothing)
        }
        else
        {
            MonsterBiengUsed = TheManager.SelectedDropDownMonsterLoad(MonsterDisplay.value);
        }

    }

    public void ChangeUI()
    {
        if(MonsterBiengUsed == null)
        {
            //this will change the display to display nothing (only once tests have been completed it will be implemented)
        }
        else if(MonsterBiengUsed != null)
        {
            MonsterName.text = "Monster Name : " + MonsterBiengUsed.ReturnMonsterName();
            MonsterHealth.text = "Monster Health : " + MonsterBiengUsed.ReturnBaseHealth();
            MonsterDefence.text = "Monster Defence : " + MonsterBiengUsed.ReturnBaseDefence();
            MonsterAttack.text = "Monster Attack : " + MonsterBiengUsed.ReturnBaseDamage();
            MonsterSpeed.text = "Monster Speed : " + MonsterBiengUsed.ReturnBaseSpeed();
            MonsterCritRate.text = "Monster CritRate : " + MonsterBiengUsed.ReturnBaseCritRate();
            MonsterCritDamage.text = "Monster CritDamage : " + MonsterBiengUsed.ReturnBaseCritDamage();
            MonsterAccuracy.text = "Monster Accuracy : " + MonsterBiengUsed.ReturnBaseAccuracy();
            MonsterResistance.text = "Monster Resistance : " + MonsterBiengUsed.ReturnBaseResistance();
            MonsterStars.text = "Stars : " + MonsterBiengUsed.ReturnMonsterStars();
            MonsterType.text = "Type : " + MonsterBiengUsed.ReturnMonsterType();
            MonsterAwakened.text = "Awakened : " + MonsterBiengUsed.ReturnMonsterAwkaned();
            MonsterLevel.text = "Level : " + MonsterBiengUsed.ReturnMonsterLevel();

            SkillDescriptionFunc();

            SkillOneImportance.text = "Skill One Importance : " + MonsterBiengUsed.ReturnSkillOneImportance();
            SkillTwoImportance.text = "Skill Two Importance : " + MonsterBiengUsed.ReturnSkillTwoImportance();
            SkillThreeImportance.text = "SKill Three Importance : " + MonsterBiengUsed.ReturnSkillThreeImportance();
        }
    }


    public void SkillDescriptionFunc()
    {
        switch (MonsterBiengUsed.ReturnrSkillOneMainEffect())
        {
            case ("Healing"):
                {
                    if(MonsterBiengUsed.ReturnSkillOneAOE())
                    {
                        SkillOneDescription.text = "This Skill Heals All Allies by a large amount";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill will also heal all allies by a small amount after";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply ";

                                    for(int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                                    }

                                    SkillOneDescription.text += "To All Allies";

                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillOneDescription.text = "This Skill Heals A single Allie by a large amount";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill will also heal one allies by a small amount after";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                                    }

                                    SkillOneDescription.text += "To one Allies";

                                    break;
                                }
                        }

                    }

                    break;
                }
            case ("BeneficialEffect"):
                {
                    if (MonsterBiengUsed.ReturnSkillOneAOE())
                    {
                        SkillOneDescription.text = "this skill will apply ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                        {
                            SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                        }

                        SkillOneDescription.text += "To all Allies";

                        if(MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Healing")
                        {
                            SkillOneDescription.text += "this skill will also heal all allies for a small amount";
                        }

                    }
                    else
                    {
                        SkillOneDescription.text = "this skill will apply";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                        {
                            SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                        }

                        SkillOneDescription.text += "To one Allie";

                        if(MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Healing")
                        {
                            SkillOneDescription.text += "this skill will also heal one allie for a small amount";                        }


                    }
                        break;
                }
            case ("HarmfulEffect"):
                {
                    if(MonsterBiengUsed.ReturnSkillOneAOE())
                    {
                        SkillOneDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                        {
                            SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                        }

                        SkillOneDescription.text += "to all enemies";

                        if(MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Damage")
                        {
                            SkillOneDescription.text += "this skill will also apply damage to all enemies proportiionate to your attack power";
                        }
                        else
                        {
                            SkillOneDescription.text += "this skill will also heal you for a small amount";
                        }
                    }
                    else
                    {
                        SkillOneDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                        {
                            SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                        }

                        SkillOneDescription.text += "to One enemy";

                        if (MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Damage")
                        {
                            SkillOneDescription.text += "this skill will also apply damage to one enemy proportiionate to your attack power";
                        }
                        else
                        {
                            SkillOneDescription.text += "this skill will also heal you for a small amount";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if(MonsterBiengUsed.ReturnSkillOneAOE())
                    {
                        SkillOneDescription.text = "this skill applies damage proportionate to your attack to all enemies monsters";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill also heals you for a small amount";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                                    }

                                    SkillOneDescription.text += "to you";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                                    }

                                    SkillOneDescription.text += "to all enemies";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillOneDescription.text = "this skill applies damage proportionate to your attack to one enemy monsters";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill also heals you for a small amount";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                                    }

                                    SkillOneDescription.text += "to you";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillOneEffects()[i];
                                    }

                                    SkillOneDescription.text += "to one enemies";


                                    break;
                                }
                        }
                    }

                    break;
                }
        }



        switch (MonsterBiengUsed.ReturnSkillTwoMainEffect())
        {
            case ("Healing"):
                {
                    if (MonsterBiengUsed.ReturnSkillTwoAOE())
                    {
                        SkillTwoDescription.text = "This Skill Heals All Allies by a large amount";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill will also heal all allies by a small amount after";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                                    }

                                    SkillTwoDescription.text += "To All Allies";

                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillTwoDescription.text = "This Skill Heals A single Allie by a large amount";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill will also heal one allies by a small amount after";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                                    }

                                    SkillTwoDescription.text += "To one Allies";

                                    break;
                                }
                        }

                    }

                    break;
                }
            case ("BeneficialEffect"):
                {
                    if (MonsterBiengUsed.ReturnSkillTwoAOE())
                    {
                        SkillTwoDescription.text = "this skill will apply ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                        {
                            SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                        }

                        SkillTwoDescription.text += "To all Allies";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Healing")
                        {
                            SkillTwoDescription.text += "this skill will also heal all allies for a small amount";
                        }

                    }
                    else
                    {
                        SkillTwoDescription.text = "this skill will apply";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                        {
                            SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                        }

                        SkillTwoDescription.text += "To one Allie";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Healing")
                        {
                            SkillTwoDescription.text += "this skill will also heal one allie for a small amount";
                        }


                    }
                    break;
                }
            case ("HarmfulEffect"):
                {
                    if (MonsterBiengUsed.ReturnSkillTwoAOE())
                    {
                        SkillTwoDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                        {
                            SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                        }

                        SkillTwoDescription.text += "to all enemies";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Damage")
                        {
                            SkillTwoDescription.text += "this skill will also apply damage to all enemies proportiionate to your attack power";
                        }
                        else
                        {
                            SkillTwoDescription.text += "this skill will also heal you for a small amount";
                        }
                    }
                    else
                    {
                        SkillTwoDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                        {
                            SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                        }

                        SkillTwoDescription.text += "to One enemy";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Damage")
                        {
                            SkillTwoDescription.text += "this skill will also apply damage to one enemy proportiionate to your attack power";
                        }
                        else
                        {
                            SkillTwoDescription.text += "this skill will also heal you for a small amount";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if (MonsterBiengUsed.ReturnSkillTwoAOE())
                    {
                        SkillTwoDescription.text = "this skill applies damage proportionate to your attack to all enemies monsters";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill also heals you for a small amount";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                                    }

                                    SkillTwoDescription.text += "to you";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                                    }

                                    SkillTwoDescription.text += "to all enemies";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillTwoDescription.text = "this skill applies damage proportionate to your attack to one enemy monsters";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill also heals you for a small amount";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                                    }

                                    SkillTwoDescription.text += "to you";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i];
                                    }

                                    SkillTwoDescription.text += "to one enemies";


                                    break;
                                }
                        }
                    }

                    break;
                }
        }

        switch (MonsterBiengUsed.ReturnSkillThreeMainEffect())
        {
            case ("Healing"):
                {
                    if (MonsterBiengUsed.ReturnSkillThreeAOE())
                    {
                        SkillThreeDescription.text = "This Skill Heals All Allies by a large amount";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill will also heal all allies by a small amount after";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                                    }

                                    SkillThreeDescription.text += "To All Allies";

                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillThreeDescription.text = "This Skill Heals A single Allie by a large amount";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill will also heal one allies by a small amount after";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                                    }

                                    SkillThreeDescription.text += "To one Allies";

                                    break;
                                }
                        }

                    }

                    break;
                }
            case ("BeneficialEffect"):
                {
                    if (MonsterBiengUsed.ReturnSkillThreeAOE())
                    {
                        SkillThreeDescription.text = "this skill will apply ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                        {
                            SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                        }

                        SkillThreeDescription.text += "To all Allies";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Healing")
                        {
                            SkillThreeDescription.text += "this skill will also heal all allies for a small amount";
                        }

                    }
                    else
                    {
                        SkillThreeDescription.text = "this skill will apply";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                        {
                            SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                        }

                        SkillThreeDescription.text += "To one Allie";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Healing")
                        {
                            SkillThreeDescription.text += "this skill will also heal one allie for a small amount";
                        }


                    }
                    break;
                }
            case ("HarmfulEffect"):
                {
                    if (MonsterBiengUsed.ReturnSkillThreeAOE())
                    {
                        SkillThreeDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                        {
                            SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                        }

                        SkillThreeDescription.text += "to all enemies";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Damage")
                        {
                            SkillThreeDescription.text += "this skill will also apply damage to all enemies proportiionate to your attack power";
                        }
                        else
                        {
                            SkillThreeDescription.text += "this skill will also heal you for a small amount";
                        }
                    }
                    else
                    {
                        SkillThreeDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                        {
                            SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                        }

                        SkillThreeDescription.text += "to One enemy";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Damage")
                        {
                            SkillThreeDescription.text += "this skill will also apply damage to one enemy proportiionate to your attack power";
                        }
                        else
                        {
                            SkillThreeDescription.text += "this skill will also heal you for a small amount";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if (MonsterBiengUsed.ReturnSkillThreeAOE())
                    {
                        SkillThreeDescription.text = "this skill applies damage proportionate to your attack to all enemies monsters";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill also heals you for a small amount";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                                    }

                                    SkillThreeDescription.text += "to you";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                                    }

                                    SkillThreeDescription.text += "to all enemies";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillThreeDescription.text = "this skill applies damage proportionate to your attack to one enemy monsters";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill also heals you for a small amount";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                                    }

                                    SkillThreeDescription.text += "to you";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                                    }

                                    SkillThreeDescription.text += "to one enemies";


                                    break;
                                }
                        }
                    }

                    break;
                }
        }


    }


    public void SetMonsterBiengUsed(MonsterScript TheMonster)
    {
        MonsterBiengUsed = TheMonster;
    }

    public void LevelUpMonster()
    {
        MonsterBiengUsed.LevelUpMonster();
    }

    public void AwakenMonster()
    {
        MonsterBiengUsed.Awaken();
    }

    public void IncreaseStars()
    {
        MonsterBiengUsed.IncreaseStars();
    }

    public void ChangeSkillOneImportance()
    {
        MonsterBiengUsed.SetSkillOneImportance(SkillImportanceSelectionOne.value + 1);
    }

    public void ChangeSkillTwoImportance()
    {
        MonsterBiengUsed.SetSkillTwoImportance(SkillImportanceSelectionTwo.value + 1);
    }

    public void ChangeSkillThreeImportance()
    {
        MonsterBiengUsed.SetSkillthreeImportance(SkillImportanceSelectionThree.value + 1);
    }

}
