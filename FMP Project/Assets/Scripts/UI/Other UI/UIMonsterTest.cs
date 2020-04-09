using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    // Monster Skill Importance
    public Text SkillOneImportance;
    public Text SkillTwoImportance;
    public Text SkillThreeImportance;


    // DropDown Commponents
    //public Dropdown MonsterDisplay;
    public Dropdown SkillImportanceSelectionOne;
    public Dropdown SkillImportanceSelectionTwo;
    public Dropdown SkillImportanceSelectionThree;

    // bool to determine the wether the rune has been loaded
    public bool LoadTheRuneOnce = false;

    // the monster data that has currently been loaded
    private MonsterScript MonsterBiengUsed = null;

    // the game management
    private GameManagment TheManager;

    //the list of options for the Importance selection (these are predefined)
    private List<string> ImportanceSelectionOptions = new List<string>();

    [Tooltip("the list of buttons that will be used to display each monster")]
    [SerializeField]
    private List<GameObject> MonsterButtons = new List<GameObject>();

    [Tooltip("this is the amount of monsters within the list")]
    [SerializeField]
    private int MonsterButtonCount = 0;

    [Tooltip("thiis is the button template that will be used to create the button")]
    [SerializeField]
    private GameObject ButtonTemplate = null;

    [Tooltip("this is the Panel to display the monsters for the monster UI")]
    [SerializeField]
    private GameObject MonsterSelectionPanel = null;

    [Tooltip("this is a list of images to be used for the monsters")]
    [SerializeField]
    private List<Sprite> SpriteList = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        TheManager = FindObjectOfType<GameManagment>();

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

    // a function to generate buttons for the monsters scrolling UI
    public void GenerateMonsterButtons()
    {
        foreach(GameObject G in MonsterButtons)
        {
            Destroy(G);
        }

        MonsterButtons.Clear();
        MonsterButtonCount = 0;

        foreach(MonsterScript M in TheManager.ReturnPlayerMonsters())
        {
            GameObject NewMonster = Instantiate(ButtonTemplate) as GameObject;
            NewMonster.SetActive(true);
            NewMonster.name = "Monster " + MonsterButtonCount;
            NewMonster.GetComponent<Image>().sprite = SpriteList[Random.Range(0, SpriteList.Count)];
            MonsterButtonCount++;
            NewMonster.transform.SetParent(ButtonTemplate.transform.parent, false);
            MonsterButtons.Add(NewMonster);
        }

    }

    // this updates the UI for the monsters stats
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

    // this function displays all of the skill descritption information and makes it so specific information is displayed to the player
    public void SkillDescriptionFunc()
    {
        switch (MonsterBiengUsed.ReturnrSkillOneMainEffect())
        {
            case ("Healing"):
                {
                    if(MonsterBiengUsed.ReturnSkillOneAOE())
                    {
                        SkillOneDescription.text = "This Skill <color=darkblue>Heals</color> All Allies by a large amount. ";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill will also <color=darkblue>heal</color> all allies by a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply ";

                                    for(int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                                    }

                                    SkillOneDescription.text += " To All Allies. ";

                                    break;
                                }
                        }
                    }
                    else
                    {
                        SkillOneDescription.text = "This Skill <color=darkblue>Heals</color> A single Ally by a large amount. ";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill will also <color=darkblue>heal</color> one ally by a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                                    }

                                    SkillOneDescription.text += " To one Allies. ";

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
                            SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                        }

                        SkillOneDescription.text += " To all Allies. ";

                        if(MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Healing")
                        {
                            SkillOneDescription.text += "this skill will also <color=darkblue>heal</color> all allies for a small amount. ";
                        }

                    }
                    else
                    {
                        SkillOneDescription.text = "this skill will apply";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                        {
                            SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                        }

                        SkillOneDescription.text += " To one Ally. ";

                        if(MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Healing")
                        {
                            SkillOneDescription.text += "this skill will also <color=darkblue>heal</color> one ally for a small amount. ";                        }


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
                            SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                        }

                        SkillOneDescription.text += " to all enemies. ";

                        if(MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Damage")
                        {
                            SkillOneDescription.text += "this skill will also apply <color=darkblue>damage</color> to all enemies proportiionate to your attack power. ";
                        }
                        else
                        {
                            SkillOneDescription.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }
                    else
                    {
                        SkillOneDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                        {
                            SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                        }

                        SkillOneDescription.text += " to one enemy. ";

                        if (MonsterBiengUsed.ReturnSkillOneSecondaryEffect() == "Damage")
                        {
                            SkillOneDescription.text += "this skill will also apply <color=darkblue>damage</color> to one enemy proportiionate to your attack power. ";
                        }
                        else
                        {
                            SkillOneDescription.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if(MonsterBiengUsed.ReturnSkillOneAOE())
                    {
                        SkillOneDescription.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to all enemies monsters. ";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill also <color=darkblue>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                                    }

                                    SkillOneDescription.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                                    }

                                    SkillOneDescription.text += " to all enemies. ";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillOneDescription.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to one enemy monsters. ";

                        switch (MonsterBiengUsed.ReturnSkillOneSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillOneDescription.text += "this skill also <color=darkblue>heals<color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                                    }

                                    SkillOneDescription.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillOneDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillOneEffects().Count; i++)
                                    {
                                        SkillOneDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillOneEffects()[i] + "</color>";
                                    }

                                    SkillOneDescription.text += " to one enemy. ";


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
                        SkillTwoDescription.text = "This Skill <color=darkblue>Heals</color> All Allies by a large amount. ";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill will also <color=darkblue>heal</color> all allies by a small amount after. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                                    }

                                    SkillTwoDescription.text += " To All Allies. ";

                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillTwoDescription.text = "This Skill <color=darkblue>Heals</color> A single Ally by a large amount. ";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill will also <color=darkblue>heal</color> one ally by a small amount after. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                                    }

                                    SkillTwoDescription.text += " To one Ally. ";

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
                            SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                        }

                        SkillTwoDescription.text += " To all Allies. ";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Healing")
                        {
                            SkillTwoDescription.text += "this skill will also <color=darkblue>heal</color> all allies for a small amount. ";
                        }

                    }
                    else
                    {
                        SkillTwoDescription.text = "this skill will apply";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                        {
                            SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                        }

                        SkillTwoDescription.text += " To one Ally. ";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Healing")
                        {
                            SkillTwoDescription.text += "this skill will also <color=darkblue>heal</color> one ally for a small amount. ";
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
                            SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                        }

                        SkillTwoDescription.text += " to all enemies. ";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Damage")
                        {
                            SkillTwoDescription.text += "this skill will also apply <color=darkblue>damage</color> to all enemies proportiionate to your attack power. ";
                        }
                        else
                        {
                            SkillTwoDescription.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }
                    else
                    {
                        SkillTwoDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                        {
                            SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                        }

                        SkillTwoDescription.text += " to one enemy. ";

                        if (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect() == "Damage")
                        {
                            SkillTwoDescription.text += "this skill will also apply <color=darkblue>damage</color> to one enemy proportiionate to your attack power. ";
                        }
                        else
                        {
                            SkillTwoDescription.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if (MonsterBiengUsed.ReturnSkillTwoAOE())
                    {
                        SkillTwoDescription.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to all enemies monsters. ";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill also <color=darkblue>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply. ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                                    }

                                    SkillTwoDescription.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply. ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                                    }

                                    SkillTwoDescription.text += " to all enemies. ";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillTwoDescription.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to one enemy monsters. ";

                        switch (MonsterBiengUsed.ReturnSkillTwoSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillTwoDescription.text += "this skill also <color=darkblue>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                                    }

                                    SkillTwoDescription.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillTwoDescription.text += "this skill will also apply. ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillTwoEffects().Count; i++)
                                    {
                                        SkillTwoDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillTwoEffects()[i] + "</color>";
                                    }

                                    SkillTwoDescription.text += " to one enemy. ";


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
                        SkillThreeDescription.text = "This Skill <color=darkblue>Heals</color> All Allies by a large amount. ";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill will also <color=darkblue>heal</color> all allies by a small amount after. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i] + "</color>";
                                    }

                                    SkillThreeDescription.text += " To All Allies. ";

                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillThreeDescription.text = "This Skill <color=darkblue>Heals</color> A single Ally by a large amount. ";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill will also <color=darkblue>heal</color> one ally by a small amount after. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i]  + "</color>";
                                    }

                                    SkillThreeDescription.text += " To one Ally. ";

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
                            SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i] + "</color>";
                        }

                        SkillThreeDescription.text += " To all Allies. ";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Healing")
                        {
                            SkillThreeDescription.text += "this skill will also <color=darkblue>heal</color> all allies for a small amount. ";
                        }

                    }
                    else
                    {
                        SkillThreeDescription.text = "this skill will apply ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                        {
                            SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i] + "</color>";
                        }

                        SkillThreeDescription.text += " To one Ally. ";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Healing")
                        {
                            SkillThreeDescription.text += "this skill will also <color=darkblue>heal</color> one ally for a small amount. ";
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
                            SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i] + "</color>";
                        }

                        SkillThreeDescription.text += " to all enemies. ";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Damage")
                        {
                            SkillThreeDescription.text += "this skill will also apply <color=darkblue>damage</color> to all enemies proportiionate to your attack power. ";
                        }
                        else
                        {
                            SkillThreeDescription.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }
                    else
                    {
                        SkillThreeDescription.text = "this skill applies ";

                        for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                        {
                            SkillThreeDescription.text += ", " + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i];
                        }

                        SkillThreeDescription.text += " to one enemy";

                        if (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect() == "Damage")
                        {
                            SkillThreeDescription.text += "this skill will also apply <color=darkblue>damage</color> to one enemy proportiionate to your attack power. ";
                        }
                        else
                        {
                            SkillThreeDescription.text += "this skill will also <color=darkblue>heal</color> you for a small amount. ";
                        }
                    }

                    break;
                }
            case ("Damage"):
                {

                    if (MonsterBiengUsed.ReturnSkillThreeAOE())
                    {
                        SkillThreeDescription.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to all enemies monsters. ";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill also <color=darkblue>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i] + "</color>";
                                    }

                                    SkillThreeDescription.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i] + "</color>";
                                    }

                                    SkillThreeDescription.text += " to all enemies. ";


                                    break;
                                }
                        }

                    }
                    else
                    {
                        SkillThreeDescription.text = "this skill applies <color=darkblue>damage</color> proportionate to your attack to one enemy monsters. ";

                        switch (MonsterBiengUsed.ReturnSkillThreeSecondaryEffect())
                        {
                            case ("Healing"):
                                {
                                    SkillThreeDescription.text += "this skill also <color=darkblue>heals</color> you for a small amount. ";
                                    break;
                                }
                            case ("BeneficialEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i]  + "</color>";
                                    }

                                    SkillThreeDescription.text += " to you. ";

                                    break;
                                }
                            case ("HarmfulEffect"):
                                {
                                    SkillThreeDescription.text += "this skill will also apply ";

                                    for (int i = 0; i < MonsterBiengUsed.ReturnAllSkillThreeEffects().Count; i++)
                                    {
                                        SkillThreeDescription.text += ", <color=darkblue>" + MonsterBiengUsed.ReturnAllSkillThreeEffects()[i]  +"</color>";
                                    }

                                    SkillThreeDescription.text += " to one enemy. ";


                                    break;
                                }
                        }
                    }

                    break;
                }
        }


    }

    // function that sets the current monster bieng used
    public void SetMonsterBiengUsed(MonsterScript TheMonster)
    {
        MonsterBiengUsed = TheMonster;
    }

    // a function to change the importance for the monsters first skill
    public void ChangeSkillOneImportance()
    {
        MonsterBiengUsed.SetSkillOneImportance(SkillImportanceSelectionOne.value + 1);
    }

    // a function to change the importance for the monsters second skill
    public void ChangeSkillTwoImportance()
    {
        MonsterBiengUsed.SetSkillTwoImportance(SkillImportanceSelectionTwo.value + 1);
    }


    // a functoin to change the importance for the monsters third skill
    public void ChangeSkillThreeImportance()
    {
        MonsterBiengUsed.SetSkillthreeImportance(SkillImportanceSelectionThree.value + 1);
    }

    // a function to open and close the monster selection panel
    public void OpenCloseMonsterSelection()
    {
        MonsterSelectionPanel.SetActive(!MonsterSelectionPanel.activeSelf);
    }

    // a function that sets the monster to be used that the player selected.
    // this function also refreshes the UI
    public void SetMonsterInUSe()
    {
        MonsterBiengUsed = TheManager.ReturnSelectedMonster(EventSystem.current.currentSelectedGameObject.name);
        ChangeUI();
    
    }
}
