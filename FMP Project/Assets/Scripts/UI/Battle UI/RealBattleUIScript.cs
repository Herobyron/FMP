using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealBattleUIScript : MonoBehaviour
{
    [Tooltip("this is the current Monster that is bieng used")]
    [SerializeField]
    private MonsterScript CurrentMonster = null;

    [Tooltip("this is the current Monster that is in game ")]
    [SerializeField]
    private int CurrentMonsterNum = 0;

    [Tooltip("this is a string that determines what side the current monster is on Player or AI")]
    [SerializeField]
    private string CurrentMonsterSide = "";

    [Tooltip("this is a list of the current targets")]
    [SerializeField]
    private List<MonsterScript> Targets;

    [Tooltip("this is the current target for the monster when the monsters skill is not an AOE")]
    [SerializeField]
    private MonsterScript CurrentMonsterTarget = null;

    [Tooltip("this is the panel that allows the player to select a monster")]
    [SerializeField]
    private GameObject EnemySelectionPanel = null;

    [Tooltip("this is the panel that displays the monsters skill sectiption")]
    [SerializeField]
    private GameObject MonsterSKilldescription = null;

    [Tooltip("this is the skill that has been selected most recently")]
    [SerializeField]
    private int SkillSelectedNumber = 0;

    [Tooltip("this is a refernce to the battle UI")]
    [SerializeField]
    private BattleManager BattleManagerRef = null;

    // this is the UI text components for the current monsters stats
    [Tooltip("this is the current monsters current health")]
    [SerializeField]
    private Text CurrentMonsterCurrentHealth = null;

    [Tooltip("this is the current monsters Attack")]
    [SerializeField]
    private Text CurrentMonsterAttack = null;

    [Tooltip("this is the current monsters speed")]
    [SerializeField]
    private Text CurrentMonsterSpeed = null;

    [Tooltip("this is the current monsters defence")]
    [SerializeField]
    private Text CurrentMonsterDefence = null;

    // these are the text compoents for the skill decription and name
    [Tooltip("this is the text information on the skill number")]
    [SerializeField]
    private Text SkillNumberText = null;

    [Tooltip("this is the text information on the skill description")]
    [SerializeField]
    private Text SkillDescriptionText = null;

    // these are the gameobject used to display the current monster
    [Tooltip("this is the game object to show the first monster is the current monster")]
    [SerializeField]
    private GameObject CurrentMonOne;

    [Tooltip("this is the game object to show the Second monster is the current monster")]
    [SerializeField]
    private GameObject CurrentMonTwo;

    [Tooltip("this is the game object to show the Third monster is the current monster")]
    [SerializeField]
    private GameObject CurrentMonThree;

    [Tooltip("this is the game object to show the first enemy monster is the current monster")]
    [SerializeField]
    private GameObject EnemyMonOne;

    [Tooltip("this is the game object to show the second enemy monster is the current monster")]
    [SerializeField]
    private GameObject EnemyMonTwo;

    [Tooltip("this is the game object to show the third enemy monster is the current monster")]
    [SerializeField]
    private GameObject EnemyMonThree;

    // these are the UI objects that display the monsters effects
    [Tooltip("this is the game object that displays the first monsters current effects")]
    [SerializeField]
    private GameObject MonsterOneEffectDisplay = null;

    [Tooltip("this is the game object that displays the second monsters current effects")]
    [SerializeField]
    private GameObject MonsterTwoEffectDisplay = null;

    [Tooltip("this is the game object that displays the third monsters current effects")]
    [SerializeField]
    private GameObject MonsterThreeEffectDisplay = null;

    [Tooltip("this is the game object that displays the first enemy monsters current effects")]
    [SerializeField]
    private GameObject EnemyOneEffectDisplay = null;

    [Tooltip("this is the game object that displays the second enemy monster current effects")]
    [SerializeField]
    private GameObject EnemyTwoEffectDisplay = null;

    [Tooltip("this is the game object that displays the third enemy monster current effects")]
    [SerializeField]
    private GameObject EnemyThreeEffectDisplay = null;



    // these are the text elements for the damage numbers
    [Tooltip("this is the text component for the damage numbers for the monster one")]
    [SerializeField]
    private Text MonsterOneDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the monster Two")]
    [SerializeField]
    private Text MonsterTwoDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the monster Three")]
    [SerializeField]
    private Text MonsterThreeDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the first enemy monster")]
    [SerializeField]
    private Text EnemyMonsterOneDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the second enemy monster")]
    [SerializeField]
    private Text EnemyMonsterTwoDamageText = null;

    [Tooltip("this is the text component for the damage numbers for the third enemy monster")]
    [SerializeField]
    private Text EnemyMonsterThreeDamageText = null;


    // this the Effect Template for the Effects of the training dummy
    [Tooltip("Template for the effects for the first enemy monster")]
    [SerializeField]
    private GameObject EnemyOneEffectTemplate = null;

    [Tooltip("Template for the effects for the second enemy monster")]
    [SerializeField]
    private GameObject EnemyTwoEffectTemplate = null;

    [Tooltip("Template for the effects for the third enemy monster")]
    [SerializeField]
    private GameObject EnemyThreeEffectTemplate = null;

    [Tooltip("Template for the effects for the First Monster")]
    [SerializeField]
    private GameObject MonsterOneEffectTemplate = null;

    [Tooltip("Template for the effects for the Second Monster")]
    [SerializeField]
    private GameObject MonsterTwoEffectTemplate = null;

    [Tooltip("Template for the effects for the Third Monster")]
    [SerializeField]
    private GameObject MonsterThreeEffectTemplate = null;

    // these are the list of effects currently bieng displayed for each of the monsters in the training scene
    [Tooltip("this is the list of buttons for the first enemy monster")]
    [SerializeField]
    private List<GameObject> EnemyOneEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the second enemy monster")]
    [SerializeField]
    private List<GameObject> EnemyTwoEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the third enemy monster")]
    [SerializeField]
    private List<GameObject> EnemyThreeEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the Monster One effects")]
    [SerializeField]
    private List<GameObject> MonsterOneEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the Monster Two effects")]
    [SerializeField]
    private List<GameObject> MonsterTwoEffectButtons = new List<GameObject>();

    [Tooltip("this is the list of buttons for the Monster Three effects")]
    [SerializeField]
    private List<GameObject> MonsterThreeEffectButtons = new List<GameObject>();

    // this is all of the sprites for the monster effects
    [SerializeField]
    private Sprite AttackUp = null;

    [SerializeField]
    private Sprite AttackDown = null;

    [SerializeField]
    private Sprite Accuracy = null;

    [SerializeField]
    private Sprite CritRateBuff = null;

    [SerializeField]
    private Sprite CritRateDeBuff = null;

    [SerializeField]
    private Sprite DefenceUp = null;

    [SerializeField]
    private Sprite DefenceDown = null;

    [SerializeField]
    private Sprite Immunity = null;

    [SerializeField]
    private Sprite Shield = null;

    [SerializeField]
    private Sprite ImmunityDown = null;

    [SerializeField]
    private Sprite MissDeBuff = null;

    [SerializeField]
    private Sprite ShieldDeBuff = null;

    // this is the count for how many buttons has been created
    private int EffectButtonCount = 0;

    // these are all of the skills buttons when the player wants to use the skills
    [Tooltip("the button for skill two")]
    [SerializeField]
    private GameObject SkillTwoButton = null;

    [Tooltip("the button for skill three")]
    [SerializeField]
    private GameObject SkillThreeButton = null;

    // this is the text component to display for who the player to attack
    [Tooltip("this is the text component to tell the player what type of monster to target")]
    [SerializeField]
    private Text TargetSelectionText = null;

    // these are the three buttons the player can use to select the target
    [Tooltip("this is the button representing the first monster selection")]
    [SerializeField]
    private GameObject SelectionButtonOne = null;

    [Tooltip("this is the button representing the second monster selection")]
    [SerializeField]
    private GameObject SelectionButtpnTwo = null;

    [Tooltip("this is the button representing the third monster selection")]
    [SerializeField]
    private GameObject SelectionButtonThree = null;

    // these are the three text compoents for the three buttons the player can use to select the target
    [Tooltip("this is the text component for the first monster selection button")]
    [SerializeField]
    private Text MonsterSelectionOne = null;

    [Tooltip("this is the text component for the second monster selection button")]
    [SerializeField]
    private Text MonsterSelectionTwo = null;

    [Tooltip("this is the text component for the third monster selection button")]
    [SerializeField]
    private Text MonsterSelectionThree = null;

    // these are the text elements for the second and third skill cooldowns
    [Tooltip("this is the text component for the second skill of the monster")]
    [SerializeField]
    private Text SkillTwoCooldownText = null;

    [Tooltip("this is the text component for the third skill of the monster")]
    [SerializeField]
    private Text SkillThreeCooldownText = null;

    //these are the health components and UI objects for the monsters health bars

    [SerializeField]
    private Slider MonsterOneSlider = null;

    [SerializeField]
    private Slider MonsterTwoSlider = null;

    [SerializeField]
    private Slider MonsterThreeSlider = null;

    [SerializeField]
    private Slider EnemyOneSlider = null;

    [SerializeField]
    private Slider EnemyTwoSlider = null;

    [SerializeField]
    private Slider EnemyThreeSlider = null;


    // these are the text compoents for the secondary effect damage or healing numbers
    [SerializeField]
    private Text EnemyOneSecondaryDamageNumber = null;

    [SerializeField]
    private Text EnemyTwoSecondaryDamageNumber = null;

    [SerializeField]
    private Text EnemythreeSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterOneSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterTwoSecondaryDamageNumber = null;

    [SerializeField]
    private Text MonsterThreeSeoncdaryDamageNumber = null;


    // these are the text components to display the monsters and training dummy level
    [SerializeField]
    private Text EnemyOneLevelText = null;

    [SerializeField]
    private Text EnemyTwoLevelText = null;

    [SerializeField]
    private Text EnemyThreeLevelText = null;

    [SerializeField]
    private Text MonsterOneLevel = null;

    [SerializeField]
    private Text MonsterTwoLevel = null;

    [SerializeField]
    private Text MonsterThreeLevel = null;



    private void OnEnable()
    {
        SetLevelDisplays();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMonsterStatsDisplay();
    }

    // a function to update the monsters stat display
    public void UpdateMonsterStatsDisplay()
    {
        CurrentMonsterCurrentHealth.text = "Health: " + CurrentMonster.ReturnCurrentHealth();
        CurrentMonsterAttack.text = "Attack: " + (CurrentMonster.ReturnBaseDamage() + CurrentMonster.ReturnIncreasedAttack());
        CurrentMonsterDefence.text = "Defence: " + (CurrentMonster.ReturnBaseDefence() + CurrentMonster.ReturnIncreasedDefence());
        CurrentMonsterSpeed.text = "Speed: " + (CurrentMonster.ReturnBaseSpeed() + CurrentMonster.ReturnIncreasedSpeed());
    }

    // a function to set the levels of the monsters at the start of battle
    public void SetLevelDisplays()
    {
        MonsterOneLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[0].ReturnMonsterLevel();
        MonsterTwoLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[1].ReturnMonsterLevel();
        MonsterThreeLevel.text = "" + BattleManagerRef.ReturnPlayerMonsters()[2].ReturnMonsterLevel();

        EnemyOneLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[0].ReturnMonsterLevel();
        EnemyTwoLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[1].ReturnMonsterLevel();
        EnemyThreeLevelText.text = "" + BattleManagerRef.ReturnEnemyMonsters()[2].ReturnMonsterLevel();

    }

    // a function to update who the current monster is
    public void UpdateCurrentMonsterIcon()
    {
        if(CurrentMonsterSide == "Player")
        {
            switch (CurrentMonsterNum)
            {
                case (0):
                    {
                        CurrentMonOne.SetActive(true);
                        break;
                    }
                case (1):
                    {
                        CurrentMonTwo.SetActive(true);
                        break;
                    }
                case (2):
                    {
                        CurrentMonThree.SetActive(true);
                        break;
                    }

            }

        }
        else if(CurrentMonsterSide == "AI")
        {
            switch (CurrentMonsterNum)
            {
                case (0):
                    {
                        EnemyMonOne.SetActive(true);
                        break;
                    }
                case (1):
                    {
                        EnemyMonTwo.SetActive(true);
                        break;
                    }
                case (2):
                    {
                        EnemyMonThree.SetActive(true);
                        break;
                    }
            }

        }
    }

    // this is a function used to update the health bar of the monster when a skill is used
    public void SetMonsterCurrentHealthBar(bool AOE)
    {
        if(AOE)
        {
                MonsterOneSlider.value = BattleManagerRef.ReturnPlayerMonsters()[0].ReturnCurrentHealth();
                MonsterTwoSlider.value = BattleManagerRef.ReturnPlayerMonsters()[1].ReturnCurrentHealth();
                MonsterThreeSlider.value = BattleManagerRef.ReturnPlayerMonsters()[2].ReturnCurrentHealth();

                EnemyOneSlider.value = BattleManagerRef.ReturnEnemyMonsters()[0].ReturnCurrentHealth();
                EnemyTwoSlider.value = BattleManagerRef.ReturnEnemyMonsters()[1].ReturnCurrentHealth();
                EnemyThreeSlider.value = BattleManagerRef.ReturnEnemyMonsters()[2].ReturnCurrentHealth();

        }
        else
        {
         
            if(CurrentMonsterTarget == BattleManagerRef.ReturnPlayerMonsters()[0])
            {
                MonsterOneSlider.value = BattleManagerRef.ReturnPlayerMonsters()[0].ReturnCurrentHealth();
            }
            else if(CurrentMonsterTarget == BattleManagerRef.ReturnPlayerMonsters()[1])
            {
                MonsterTwoSlider.value = BattleManagerRef.ReturnPlayerMonsters()[1].ReturnCurrentHealth();
            }
            else if (CurrentMonsterTarget == BattleManagerRef.ReturnPlayerMonsters()[2])
            {
                MonsterThreeSlider.value = BattleManagerRef.ReturnPlayerMonsters()[2].ReturnCurrentHealth();
            }
            else if(CurrentMonsterTarget == BattleManagerRef.ReturnEnemyMonsters()[0])
            {
                EnemyOneSlider.value = BattleManagerRef.ReturnEnemyMonsters()[0].ReturnCurrentHealth();
            }
            else if (CurrentMonsterTarget == BattleManagerRef.ReturnEnemyMonsters()[1])
            {
                EnemyTwoSlider.value = BattleManagerRef.ReturnEnemyMonsters()[1].ReturnCurrentHealth();
            }
            else if (CurrentMonsterTarget == BattleManagerRef.ReturnEnemyMonsters()[2])
            {
                EnemyThreeSlider.value = BattleManagerRef.ReturnEnemyMonsters()[2].ReturnCurrentHealth();
            }


        }
    }

    // this is a function that will update the skill display when a certain skill is pressed when its the players turn
    public void UpdateMonsterSkillDisplay(int SelectedSkill, MonsterSkillScript TheSkill)
    {
        SkillNumberText.text = "Skill Number: " + SelectedSkill;


    }

    // this function sets what monster is the current monster
    public void SetCurrentMonster(MonsterScript Mon)
    {
        CurrentMonster = Mon;
    }

    // this sets the number of the current monster
    public void SetCurrentMonsterNum(int MonsterNum)
    {
        CurrentMonsterNum = MonsterNum;
    }

    // this function sets the side the current monster is on
    public void SetCurrentMonsterSide(string Side)
    {
        CurrentMonsterSide = Side;
    }

    // functoin to return the slider for the first player monster health bar
    public Slider ReturnMonsterOneSlider()
    {
        return MonsterOneSlider;
    }

    // function to return the slider for the second player monster health bar
    public Slider ReturnMonsterTwoSlider()
    {
        return MonsterTwoSlider;
    }

    // function to return the slider for the third player monster health bar
    public Slider ReturnMonsterThreeslider()
    {
        return MonsterThreeSlider;
    }

    // function to return the slider for the first enemy monster health bar
    public Slider ReturnEnemyOneSlider()
    {
        return EnemyOneSlider;
    }


    // function to return the slider for the first enemy monster health bar
    public Slider ReturnEnemyTwoSlider()
    {
        return EnemyTwoSlider;
    }

    // function to return the slider for the first enemy monster health bar
    public Slider ReturnEnemyThreeSlider()
    {
        return EnemyThreeSlider;
    }

}
