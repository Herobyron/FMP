using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRuneUI : MonoBehaviour
{

    [Tooltip("The game manager that holds all of the player information")]
    [SerializeField]
    private GameManagment TheManager;

    [Tooltip("The layout for the runes that will be displayed to the player to use")]
    [SerializeField]
    private GridLayoutGroup GridGroup;

    [Tooltip("this is the button template that will be used to display a single rune")]
    [SerializeField]
    private GameObject ButtonTemplate;

    void Start()
    {

    }

    // generates the runes buttons to be used on the scrolling ui
    public void GenerateRuneButtons()
    {
       

        foreach (RuneScript R in TheManager.ReturnPlayerRunes())
        {
            GameObject NewButton = Instantiate(ButtonTemplate) as GameObject;
            NewButton.SetActive(true);
            NewButton.transform.SetParent(ButtonTemplate.transform.parent, false);
        }

    }

}
