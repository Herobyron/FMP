﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HarmfulEffects 
{
    [Tooltip("this is the amount of time left on the beneficial effect")]
    [SerializeField]
    private int TurnsLeftOnHarmfulEffect;

    // this is the enum for the differnt types of buff that this script can be
    public enum Bufftype { DefenceDeBuff, AttackDeBuff, CritRateDeBuff, MissDeBuff, ShieldDeBuff, ImmunityDeBuff };

    [Tooltip("This is the type of buff this Effect is")]
    [SerializeField]
    private Bufftype HarmfulEffect;


    // this is the function that will set the amount of turns that this harmful effect will last
    public void SetTurns(int turns)
    {
        TurnsLeftOnHarmfulEffect = turns;
    }

    // this function will set the type of effects that this harmful effects will be 
    public void SetHarmfulEffect(string Effect)
    {
        switch(Effect)
        {
            case ("Defence"):
                {
                    HarmfulEffect = Bufftype.DefenceDeBuff;
                    break;
                }
            case ("Attack"):
                {
                    HarmfulEffect = Bufftype.AttackDeBuff;
                    break;
                }
            case ("CritRate"):
                {
                    HarmfulEffect = Bufftype.CritRateDeBuff;
                    break;
                }
            case ("Miss"):
                {
                    HarmfulEffect = Bufftype.MissDeBuff;
                    break;
                }
            case ("Shield"):
                {
                    HarmfulEffect = Bufftype.ShieldDeBuff;
                    break;
                }
            case ("Immunity"):
                {
                    HarmfulEffect = Bufftype.ImmunityDeBuff;
                    break;
                }
        }
    }


    //this function will return the harmful effect that this is
    public Bufftype ReturnDebuffType()
    {
        return HarmfulEffect;
    }

    // this function will return how many turns are left on this effect
    public int ReturnturnsLeft()
    {
        return TurnsLeftOnHarmfulEffect;
    }


    // this function returns the effect but in the form of a string instead of an enum
    public string ReturnDeBuffTypeString()
    {
        string ReturnString = "";

        switch (HarmfulEffect)
        {
            case (Bufftype.AttackDeBuff):
                {
                    ReturnString = "AttackDown";
                    break;
                }
            case (Bufftype.CritRateDeBuff):
                {
                    ReturnString = "CritRateDeBuff";
                    break;
                }
            case (Bufftype.DefenceDeBuff):
                {
                    ReturnString = "DefenceDown";
                    break;
                }
            case (Bufftype.ImmunityDeBuff):
                {
                    ReturnString = "ImmunityDown";
                    break;
                }
            case (Bufftype.MissDeBuff):
                {
                    ReturnString = "MissDeBuff";
                    break;
                }
            case (Bufftype.ShieldDeBuff):
                {
                    ReturnString = "ShieldDown";
                    break;
                }
        }


        return ReturnString;
    }

}
