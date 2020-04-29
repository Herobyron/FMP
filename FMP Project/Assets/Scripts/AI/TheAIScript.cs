using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


// a class specifically made to make decisions based on certain circumstances 
// these circumstances will be wether or not the monsters skill is on cooldown
// the decsisions need to be looked into and how its going to interact with the UI script and the players turns

public class TheDecisions
{
    public int SkillTwoOnCoolDown(MonsterScript TheMonster)
    {
        return TheMonster.ReturnSkillTwoCoolDown();
    }
     
    
    public int SkillThreeOnCoolDown(MonsterScript TheMonster)
    {
        return TheMonster.ReturnSkillThreeCoolDown();
    }


}


// this class deals with using the monster skills under certain circumstances
// these functions will be called when the monsters skills are off cooldown
public class Actions
{
    public void UseMonsterSkillOne(MonsterScript TheMonster)
    {
       // i will have to have a look at puting the battle UI in so it can detemrine the skill 
       // or implement something similar from the battle ui in this function 
    }

    public void UseMonsterSkillTwo(MonsterScript TheMonster)
    {
        // i will have to have a look at puting the battle UI in so it can detemrine the skill 
        // or implement something similar from the battle ui in this function 
    }

    public void UseMonsterSkillThree(MonsterScript TheMonster)
    {
        // i will have to have a look at puting the battle UI in so it can detemrine the skill 
        // or implement something similar from the battle ui in this function 
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
    public virtual void ExecuteAction()
    {

    }


    // this function may need to return a node
    public virtual void MakeDecision()
    {

    }



}

// this is a decision node that uses all of the information from the parent class
public class TheDecisionNode : TheNode
{
    // a refernce to the monster whos turn it is
    public MonsterScript TheMonster;

    // a decsisoin node means it results in a yes and no these are the yes and no nodes that are the result of this nodes decsision
    public Node YesNode;
    public Node NoNode;

    public TheDecisionNode(MonsterScript Monster)
    {
        LeafNode = false;

        YesNode = null;
        NoNode = null;

        TheMonster = Monster;
    }

    public void AddYesNode(Node TheYesNode)
    {
        YesNode = TheYesNode;
    }

    public void AddNoNode(Node TheNoNode)
    {
        NoNode = TheNoNode;
    }

    // this function is the one that should make the decision to determine which child to go to 
    // this function will need to return the node that it has decided is next in the list
    public override void MakeDecision()
    {

    }
}

public class TheActionNode : TheNode
{
    MonsterScript TheMonster;


    public TheActionNode(MonsterScript Monster)
    {
        LeafNode = true;
        TheMonster = Monster;
    }

    // this is what will use the skill depending on the circumstances
    public override void ExecuteAction()
    {

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
    public void Execute()
    {
        TraverseTree(TheRootNode);
    }


    // this function goes thorugh the tree testing differnt decsisions until it reaches a leaf node
    public void TraverseTree(TheNode TheCurrentNode)
    {
        if(TheCurrentNode.LeafNode)
        {
            CurrentNode.ExecuteAction();
        }
        else
        {
            // the function does not do anything yet
            //CurrentNode = TheCurrentNode.MakeDecision();
            TraverseTree(CurrentNode);
        }
    }

}
