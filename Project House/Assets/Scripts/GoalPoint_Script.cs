using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;

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

    [SerializeField] Transform goalF;

    [SerializeField] public float timeToFix = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        changeGoalRand();
        goalblock.position = currGoal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currGoal == null)
        {
            //changeGoalRand();
        }
        
        if(currGoal.position.x - player.transform.position.x < 0.5 && currGoal.position.y - player.transform.position.y < 0.5)
        {
            Fix();
        }

        
        //if bell in range set that to current goal
        //if goal value = null set it to new one
    }

    public void changeGoalRand()
    {
        int  num = Random.Range(0, 5);
        if(num == 0)
        {
            if(goalA == null){
                changeGoalRand();
            }
            else{
                
            currGoal = goalA;
            currGoal.position = goalA.position;                
            }
        }

        else if (num == 1)
        {
            if(goalB == null){
                changeGoalRand();
            }
            else{
            currGoal = goalB;
            currGoal.position = goalB.position;            
            }
        }

        else if (num == 2)
        {
            if(goalC == null){
                changeGoalRand();
            }
            else{
            currGoal = goalC;
            currGoal.position = goalC.position;         
            }
        }

        else if (num == 3)
        {
            if(goalD == null){
                changeGoalRand();
            }
            else{
            currGoal = goalD;
            currGoal.position = goalD.position;         
            }
        }

        else if (num == 4)
        {
            if(goalE == null){
                changeGoalRand();
            }
            else{
            currGoal = goalE;
            currGoal.position = goalE.position;         
            }
        }

        else if(num == 5)
        {
            if(goalF == null){
                changeGoalRand();
            }
            else{
            currGoal = goalF;
            currGoal.position = goalF.position;         
            }
        }

        player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
    }

    public void Fix()
    {
        //start animation of repairs
        StartCoroutine(Fixing());


        if(currGoal.position == goalA.position && goalA != null)
        {
            goalA = null;
        }
        else if(currGoal.position == goalB.position && goalB != null)
        {
            goalB = null;
            return;
        }
        else if(currGoal.position == goalC.position && goalC != null)
        {
            goalC = null;
            return;
        }
        else if(currGoal.position == goalD.position && goalD  != null)
        {
            goalD = null;
            return;
        }
        else if(currGoal.position == goalE.position && goalE  != null)
        {
            goalE = null;
            return;
        }
        else if(currGoal.position == goalF.position && goalF != null)
        {
            goalF = null;
            return;
        }
        
        changeGoalRand();

    //    if(goalA == null && goalB == null && goalC == null && goalD == null && goalE == null && goalF == null)
    //    {
    //        Debug.Log("YOU WIN");
    //    }
    }

    IEnumerator Fixing()
    {
        yield return new WaitForSeconds(timeToFix);
    }
}
