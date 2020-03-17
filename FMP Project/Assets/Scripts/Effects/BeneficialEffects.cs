using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeneficialEffects 
{

    [Tooltip("this is the amount of time left on the beneficial effect")]
    [SerializeField]
    private int TurnsLeftOnBeneficialEffect;

    // this is the enum for the differnt types of buff that this script can be
    public enum Bufftype {DefenceBuff, AttackBuff, CritRateBuff, AccuracyBuff, ShieldBuff, ImmunityBuff };

    [Tooltip("This is the type of buff this Effect is")]
    [SerializeField]
    private Bufftype BeneficialEffect = Bufftype.DefenceBuff;


    // this is the function that will set the amount of turns that this harmful effect will have
    public void SetTurns(int turns)
    {
        TurnsLeftOnBeneficialEffect = turns;
    }


    //this function will set the type of effects that this beneficial effect will be 
    public void SetBeneficialEffects(string Effect)
    {
        switch(Effect)
        {
            case ("Defence"):
                {
                    BeneficialEffect = Bufftype.DefenceBuff;
                    break;
                }
            case ("Attack"):
                {
                    BeneficialEffect = Bufftype.AttackBuff;
                    break;
                }
            case ("CritRate"):
                {
                    BeneficialEffect = Bufftype.CritRateBuff;
                    break;
                }
            case ("Accuracy"):
                {
                    BeneficialEffect = Bufftype.AccuracyBuff;
                    break;
                }
            case ("Shield"):
                {
                    BeneficialEffect = Bufftype.ShieldBuff;
                    break;
                }
            case ("Immunity"):
                {
                    BeneficialEffect = Bufftype.ImmunityBuff;
                    break;
                }
            
        }
    }

    //this function will return the beneficial effect that this effect is
    public Bufftype ReturnBuffType()
    {
        return BeneficialEffect;
    }

    // this function will return how many turns are left on this effect
    public int ReturnTurnsLeft()
    {
        return TurnsLeftOnBeneficialEffect;
    }

}
