using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalPoint_Script : MonoBehaviour
{
    public Transform currGoal = null;


    [SerializeField] GameObject player;
    [SerializeField] Transform goalblock;
    [SerializeField] Transform goalA;

    [SerializeField] Transform goalB;
    
    [SerializeField] Transform goalC;
    
    [SerializeField] Transform goalD;
    
    [SerializeField] Transform goalE;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goalblock.position = currGoal.position;
        
        if(currGoal.position.x - player.transform.position.x < 1 && currGoal.position.y - player.transform.position.y < 1)
        {
            changeGoalRand();
        }

        if(currGoal == null)
        {
            changeGoalRand();
        }
        //if bell in range set that to current goal
        //if goal value = null set it to new one
    }

    public void changeGoalRand()
    {
        int  num = Random.Range(0, 4);
        if(num == 0)
        {
            currGoal.position = goalA.position;
        }

        if (num == 1)
        {
            currGoal.position = goalB.position;
        }

        if (num == 2)
        {
            currGoal.position = goalC.position;
        }

        if (num == 3)
        {
            currGoal.position = goalD.position;
        }

        if (num == 4)
        {
            currGoal.position = goalD.position;
        }
    }
}
