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

    [Tooltip("this is a list of the images for the monster")]
    [SerializeField]
    private List<Sprite> MonsterImages = new List<Sprite>();

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
    private Image SelectedMonsterOneImage = null;

    [Tooltip("this is the image for the second selected monster")]
    [SerializeField]
    private Image SelectedMonsterTwoImage = null;

    [Tooltip("this is the image for the third selected monster")]
    [SerializeField]
    private Image SelectedMonsterThreeImage = null;

    [Tooltip("this is the replacement panel")]
    [SerializeField]
    private GameObject ReplaceMonsterPanel = null;

    [Tooltip("this is a panel to display what monster has been selected to give the player a notification")]
    [SerializeField]
    private GameObject MonsterSelectedPanel = null;

    [Tooltip("this is the text that is displayed when a monster is selected on the team")]
    [SerializeField]
    private Text SelectedMonsterdisplayText = null;

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
            NewButton.name = "Monster " + MonsterButtonCount;
            NewButton.GetComponent<Image>().sprite = MonsterImages[(TheManager.ReturnPlayerMonsters()[MonsterButtonCount].GetMonsterImageNumber() - 1)];
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

    // this function allows you to view the picked selected monster
    public void AddSelectedMonsterToView(int SelectedMonsterNum)
    {
        MonsterBiengDisplayed = SelectedMonsters[SelectedMonsterNum];
        RefreshViewedMonsterUI();
    }

    // this function refreshes the UI of the viewed Monster
    public void RefreshViewedMonsterUI()
    {

        MonsterLookingAtName.text = "Monster Name:" + MonsterBiengDisplayed.ReturnMonsterName();

        if (MonsterBiengDisplayed.ReturnRune(1) != null)
        {
            if (MonsterBiengDisplayed.ReturnRune(1).ReturnMainRuneStat() != 0)
            {
                RuneOneImage.gameObject.SetActive(true);
            }
        }

        if (MonsterBiengDisplayed.ReturnRune(2) != null)
        {
            if (MonsterBiengDisplayed.ReturnRune(2).ReturnMainRuneStat() != 0)
            {
                RuneTwoImage.gameObject.SetActive(true);
            }
        }

        if (MonsterBiengDisplayed.ReturnRune(3) != null)
        {
            if (MonsterBiengDisplayed.ReturnRune(3).ReturnMainRuneStat() != 0)
            {
                RuneThreeImage.gameObject.SetActive(true);
            }
        }

        if (MonsterBiengDisplayed.ReturnRune(4) != null)
        {
            if (MonsterBiengDisplayed.ReturnRune(4).ReturnMainRuneStat() != 0)
            {
                RuneFourImage.gameObject.SetActive(true);
            }
        }

        if (MonsterBiengDisplayed.ReturnRune(5) != null)
        {
            if (MonsterBiengDisplayed.ReturnRune(5).ReturnMainRuneStat() != 0)
            {
                RuneFiveImage.gameObject.SetActive(true);
            }
        }

        if (MonsterBiengDisplayed.ReturnRune(6) != null)
        {
            if (MonsterBiengDisplayed.ReturnRune(6).ReturnMainRuneStat() != 0)
            {
                RuneSixImage.gameObject.SetActive(true);
            }
        }

    }

    // this function adds the viewed monster to the list 
    // if the list has more then three monsters (count equal too 2) then the panel opens to pick one to replace
    public void AddViewedMonsterToSelected()
    {
        

        for(int i = 0; i < SelectedMonsters.Count; i++)
        {
            if(MonsterBiengDisplayed != SelectedMonsters[i])
            {
                if(SelectedMonsters.Count  < 3)
                {
                    SelectedMonsters.Add(MonsterBiengDisplayed);
                    switch (SelectedMonsters.Count)
                    {
                        case (1):
                            {
                                SelectedMonsterOneImage.sprite = MonsterImages[MonsterBiengDisplayed.GetMonsterImageNumber() -1];
                                SelectionNotification(MonsterBiengDisplayed.ReturnMonsterName(), 1);
                                break;
                            }
                        case (2):
                            {
                                SelectedMonsterTwoImage.sprite = MonsterImages[MonsterBiengDisplayed.GetMonsterImageNumber() -1];
                                SelectionNotification(MonsterBiengDisplayed.ReturnMonsterName(), 2);
                                break;
                            }
                        case (3):
                            {
                                SelectedMonsterThreeImage.sprite = MonsterImages[MonsterBiengDisplayed.GetMonsterImageNumber() -1];
                                SelectionNotification(MonsterBiengDisplayed.ReturnMonsterName(), 3);
                                break;
                            }
                    }

                    break;
                }
                else
                {
                    ReplaceMonsterPanel.SetActive(true);
                }
            }
        }

        if (SelectedMonsters.Count == 0)
        {
            if (MonsterBiengDisplayed.ReturnMonsterName() != "Blank")
            {
                SelectedMonsters.Add(MonsterBiengDisplayed);
                SelectedMonsterOneImage.sprite = MonsterImages[MonsterBiengDisplayed.GetMonsterImageNumber() - 1];
                SelectionNotification(MonsterBiengDisplayed.ReturnMonsterName(), 1);
            }

        }
    }

    // this function is used on the replacement panel to swap the monster bieng viewed with the one selected
    public void ReplaceSelectedMonster(int SelectedMonsterNum)
    {
        bool MonsterAlreadySelected = false;

        for(int i = 0; i < SelectedMonsters.Count; i++)
        {
            if(MonsterBiengDisplayed == SelectedMonsters[i])
            {
                MonsterAlreadySelected = true;
            }
        }


        if (!MonsterAlreadySelected)
        {
            SelectedMonsters[SelectedMonsterNum] = MonsterBiengDisplayed;

            switch ((SelectedMonsterNum + 1))
            {
                case (1):
                    {
                        SelectedMonsterOneImage.sprite = MonsterImages[MonsterBiengDisplayed.GetMonsterImageNumber() - 1];
                        SelectionNotification(MonsterBiengDisplayed.ReturnMonsterName(), 1);
                        break;
                    }
                case (2):
                    {
                        SelectedMonsterTwoImage.sprite = MonsterImages[MonsterBiengDisplayed.GetMonsterImageNumber() - 1];
                        SelectionNotification(MonsterBiengDisplayed.ReturnMonsterName(), 2);
                        break;
                    }
                case (3):
                    {
                        SelectedMonsterThreeImage.sprite = MonsterImages[MonsterBiengDisplayed.GetMonsterImageNumber() - 1];
                        SelectionNotification(MonsterBiengDisplayed.ReturnMonsterName(), 3);
                        break;
                    }
            }


        }

    }


    // a function to display what monster has been selected and added to the team
    public void SelectionNotification(string MonsterName, int Slot)
    {
        MonsterSelectedPanel.SetActive(true);
        SelectedMonsterdisplayText.text = MonsterName + " Has been selected and added to the team. they are in Slot: " + Slot;

    }

    // a function that starts the training battle for the player
    public void StartBattle()
    {
        FindObjectOfType<BattleManager>().SetPlayerBattleMonsters(SelectedMonsters);
        
        // here i want a bettle effect to be a transition.

        gameObject.SetActive(false);
    }
}
