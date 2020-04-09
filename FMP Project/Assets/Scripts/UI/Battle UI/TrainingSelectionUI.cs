using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrainingSelectionUI : MonoBehaviour
{
    [Tooltip("this is the Game Manager that holds the players information")]
    [SerializeField]
    private GameManagment TheManager = null;

    [Tooltip("this is the layout for the monsters that will be displayed to the player to pick from")]
    [SerializeField]
    private GridLayoutGroup GridGroup = null;

    [Tooltip("this is the button template that will be used to display each monster seperatly")]
    [SerializeField]
    private GameObject ButtonTemplate = null;

    [Tooltip("this is the monster that has been selected and is currently bieng displayed to the player")]
    [SerializeField]
    private MonsterScript MonsterBiengDisplayed = null;

    [Tooltip("this is the count for the buttons to determine how many monsters have been loaded and what monster is bieng selected")]
    [SerializeField]
    private int MonsterButtonCount = 0;

    [Tooltip("A list of the monster buttons that were generated from the monsters inventory")]
    [SerializeField]
    private List<GameObject> MonsterButtons = new List<GameObject>();

    [Tooltip("this is a list of all the selected monsters (MAX 3) and will be given to the battle manager to use ")]
    [SerializeField]
    private List<MonsterScript> SelectedMonsters = new List<MonsterScript>();

    [Tooltip("this is the text for the name of curent monster the player is looking at")]
    [SerializeField]
    private Text MonsterLookingAtName = null;

    [Tooltip("this is the Rune One Image")]
    [SerializeField]
    private Image RuneOneImage = null;

    [Tooltip("this is the Rune Two Image")]
    [SerializeField]
    private Image RuneTwoImage = null;

    [Tooltip("this is the Rune Three Image")]
    [SerializeField]
    private Image RuneThreeImage = null;

    [Tooltip("this is the Rune Four Image")]
    [SerializeField]
    private Image RuneFourImage = null;

    [Tooltip("this is the Rune Five Image")]
    [SerializeField]
    private Image RuneFiveImage = null;

    [Tooltip("this is the Rune Six Image")]
    [SerializeField]
    private Image RuneSixImage = null;

    [Tooltip("this is the image for the first selected monster")]
    [SerializeField]
    private Image SelectedMonsterOne = null;

    [Tooltip("this is the image for the second selected monster")]
    [SerializeField]
    private Image SelectedMonsterTwo = null;

    [Tooltip("this is the image for the third selected monster")]
    [SerializeField]
    private Image SelectedMonsterThree = null;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function uses the game manager to load in the information from the manager to here
    public void LoadInformation()
    {
        TheManager.Load();
        GenerateMonsterButtons();

    }

    // this function gets all of the players monsters and create buttons for them
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
            GameObject NewButton = Instantiate(ButtonTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.name = "Monster" + MonsterButtonCount;

            MonsterButtonCount++;

            NewButton.transform.SetParent(ButtonTemplate.transform.parent, false);
            MonsterButtons.Add(NewButton);

            //something to set the image of the button after (generating a number for monster)
        }
    }

    // this function adds the monster bieng viewed to the selected monster list
    public void AddMonsterToSelection()
    {
        SelectedMonsters.Add(MonsterBiengDisplayed);
    }

    // this function adds the selected monster to the viewed monster so the runes can be viewed
    public void AddMonsterToView()
    {
        MonsterBiengDisplayed = TheManager.ReturnSelectedMonster(EventSystem.current.currentSelectedGameObject.name);
        RefreshViewedMonsterUI();
    }

    // this function refreshes the UI of the viewed Monster
    public void RefreshViewedMonsterUI()
    {

    }

}
