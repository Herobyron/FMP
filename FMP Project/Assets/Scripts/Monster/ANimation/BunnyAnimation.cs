using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAttacking(int number)
    {
        FindObjectOfType<RealBattleUIScript>().SetAnimating(number);
    }
}
