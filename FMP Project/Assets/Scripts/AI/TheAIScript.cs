using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


// a class specifically made to make decisions based on certain circumstances 
// these circumstances will be wether or not the monsters skill is on cooldown
// the decsisions need to be looked into and how its going to interact with the UI script and the players turns

public class TheDecisions
{
    public bool SkillTwoOnCoolDown(MonsterScript TheMonster)
    {
        if(TheMonster.ReturnSkillTwoCoolDown() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
     
    
    public bool SkillThreeOnCoolDown(MonsterScript TheMonster)
    {
        if (TheMonster.ReturnSkillThreeCoolDown() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public MonsterScript PickEnemyTarget(List<MonsterScript> AllTargets)
    {
        int temphealth = 1000000;
        MonsterScript ReturnMonster = null;

        foreach(MonsterScript M in AllTargets)
        {
            if(temphealth > M.ReturnCurrentHealth())
            {
                temphealth = (int)M.ReturnCurrentHealth();
                ReturnMonster = M;
            }
        }

        return ReturnMonster;
    }

}


// this class deals with using the monster skills under certain circumstances
// these functions will be called when the monsters skills are off cooldown
public class TheActions
{
    public void UseMonsterSkillOne(RealBattleUIScript TheBattleUI)
    {
        TheBattleUI.UseSkillOneAI();

    }

    public void UseMonsterSkillTwo(RealBattleUIScript TheBattleUI)
    {
        TheBattleUI.UseSkillTwoAI();
    }

    public void UseMonsterSkillThree(RealBattleUIScript TheBattleUI)
    {
        TheBattleUI.UseSkillThreeAI();
    }

}

// this is a basic node used as the parent class for the other nodes
public class TheNode
{
    // a bool to determine if the node is a leaf node or not
    public bool LeafNode;

    // a function to return if this node is actually a lead node
    public bool ReturnLeafNode()
    {
        return LeafNode;
    }


    // the node needs the ability to execute actions and made a decsision depending on the type of node
    public virtual void ExecuteAction(RealBattleUIScript TheUI)
    {

    }


    // this function may need to return a node
    public virtual TheNode MakeDecision()
    {
        return null;
    }



}

// this is a decision node that uses all of the information from the parent class
public class TheDecisionNode : TheNode
{
    // a refernce to the monster whos turn it is
    public MonsterScript TheMonster;

    public string DecisionType = "";

    // a decsisoin node means it results in a yes and no these are the yes and no nodes that are the result of this nodes decsision
    public TheNode YesNode;
    public TheNode NoNode;

    TheDecisions Decision;

    public TheDecisionNode(MonsterScript Monster)
    {
        LeafNode = false;

        YesNode = null;
        NoNode = null;

        TheMonster = Monster;
    }

    public void AddYesNode(TheNode TheYesNode)
    {
        YesNode = TheYesNode;
    }

    public void AddNoNode(TheNode TheNoNode)
    {
        NoNode = TheNoNode;
    }

    // this function is the one that should make the decision to determine which child to go to 
    // this function will need to return the node that it has decided is next in the list
    public override TheNode MakeDecision()
    {
        if(DecisionType == "SkillTwo")
        {
            if(Decision.SkillTwoOnCoolDown(TheMonster))
            {
                return YesNode;
            }
            else
            {
                return NoNode;
            }

        }
        else if(DecisionType == "SkillThree")
        {
            if (Decision.SkillThreeOnCoolDown(TheMonster))
            {
                return YesNode;
            }
            else
            {
                return NoNode;
            }
        }

        return NoNode;
    }
}

public class TheActionNode : TheNode
{
    MonsterScript TheMonster;

    TheActions TheAction;

    string TheActionName;



    public TheActionNode(MonsterScript Monster)
    {
        LeafNode = true;
        TheMonster = Monster;
    }

    // this is what will use the skill depending on the circumstances
    public override void ExecuteAction(RealBattleUIScript TheUI)
    {
        if(TheActionName == "SkillOne")
        {
            TheAction.UseMonsterSkillOne(TheUI);
        }
        else if(TheActionName == "SkillTwo")
        {
            TheAction.UseMonsterSkillTwo(TheUI);
        }
        else if(TheActionName == "SkillThree")
        {
            TheAction.UseMonsterSkillThree(TheUI);
        }
    }

}


public class TheAIScript : MonoBehaviour
{
    public TheNode TheRootNode = null;

    public TheNode CurrentNode = null;

    public TheAIScript(TheNode Root)
    {
        TheRootNode = Root;
        CurrentNode = null;

    }

    // this funcion starts the decision tree
    public void Execute(RealBattleUIScript TheUI)
    {
        TraverseTree(TheRootNode, TheUI);
    }


    // this function goes thorugh the tree testing differnt decsisions until it reaches a leaf node
    public void TraverseTree(TheNode TheCurrentNode, RealBattleUIScript TheUI)
    {
        if(TheCurrentNode.LeafNode)
        {
            CurrentNode.ExecuteAction(TheUI);
        }
        else
        {

            CurrentNode = CurrentNode.MakeDecision();
            // the function does not do anything yet
            //CurrentNode = TheCurrentNode.MakeDecision();
            TraverseTree(CurrentNode, TheUI);
        }
    }

}
