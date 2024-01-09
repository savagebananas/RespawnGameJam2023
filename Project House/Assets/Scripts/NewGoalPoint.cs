
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/**
*   Charles Caton
*   New Version of GoalPoint_Script.cs
*   Made 1/6/2024
*/

public class NewGoalPoint : MonoBehaviour
{
    //standard gameState to tell endings and such
    private GameState gameState;

    //current goal for builder to go to. rapidly changing. this must be what houses this NewGoalPoint script
    public Transform currGoal;

    //player game object. In unity set this to the players own self
    [SerializeField] GameObject player;

    //Total number of goals for the level. This must be set in unity 
    [SerializeField] public static int numOfGoals;

    //Array of all goals for this specific level
    [SerializeField] Transform[] goalArray = new Transform[numOfGoals];

    //Bool to check if builder is already fixing something
    public bool isFixing;


    /**
    *   Start sets all needed bools to false and the gameState to the right thing
    *   Then it gets a random goal and sets it for the builder
    **/
    void Start()
    {
        isFixing = false;
        numOfGoals = goalArray.Length;

        SetGoalPointRandom();
        player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
        
        gameState = GameObject.Find("General").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(currGoal.position.x - player.transform.position.x) < 0.5 && Mathf.Abs(currGoal.position.y - player.transform.position.y) < 0.5 && isFixing == false)
        {
            Fix();
        }
    }


    /** 
    *   When the builder is in range of the task, the animation and sounds play.
    *   The builder then repairs the task until it is done or is interupted/killed
    *   Once completed it checks for victory and assigns the next task
    **/
    public void Fix()
    {
        isFixing = true;
        FindObjectOfType<AudioManager>().Play("Wrench");
        player.GetComponent<Builder>().isFixing = true;

        StartCoroutine(Fixing());
    }

    //Just finishes fix with the waiting 5 seconds
    private IEnumerator Fixing()
    {
        yield return new WaitForSeconds(5);

        for(int i = 0; i < numOfGoals; i++)
        {
            if(goalArray[i].position == currGoal.position)
            {
                goalArray[i].gameObject.GetComponent<Task>().fixTask(); //Fixed task
                goalArray[i] = null;
            }
        }

        player.GetComponent<Builder>().isFixing = false;
        checkIfWon();
        SetGoalPointRandom();
    }

    /** 
    *   This is called at the begining of the game and every time a task needs to be set i.e. when another is completed
    *   It chooses a random number and sets the goal position to be that number in the array
    *   It also checks to make sure the goal selected is not already done, and if it is tries again
    **/
    void SetGoalPointRandom()
    {
        isFixing = false;

        int randomNum = Random.Range(0, numOfGoals -1);
        if(goalArray[randomNum] != null)
        {
            currGoal.position = goalArray[randomNum].position;
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
        }
        else SetGoalPointRandom(); 
    }

    /** 
    *   This is called exclusivly from the phone.
    *   It chooses the goal set to the specific phone and sets the builder on that new path
    *   It also checks to make sure the goal selected is not already done, and if it is builder ignores
    **/
    public void SetGoalPointSpecific(Transform goalGiven)
    {
        isFixing = false;
        for(int i = 0; i < numOfGoals; i++)
        {
            if(goalArray[i] != null)
            {
                if(goalGiven.position == goalArray[i].position)
                {
                    currGoal.position = goalArray[i].position;
                }
            }
        }
    }

    /** 
    *   This just checks if all tasks are complete by checking if the elements of the goalArray have all been set to null
    *   Then if the number of null tasks = to the number of total goals, the player has won this level.
    **/
    void checkIfWon()
    {
        int numDone = 0;
        for(int i = 0; i < numOfGoals; i++)
        {
            if(goalArray[i] == null)
            {
                numDone += 1;
            }
        }

        if(numDone == numOfGoals)
        {
            YouWin();
        }
        else numDone = 0;
    }

    /** 
    *   This is only called when all tasks are complete. If more states are added in the gameState feel free to change THIS HERE ONLY
    **/
    public void YouWin()
    {
        Debug.Log("last task done");
        Debug.Log("You win");
        gameState.WinGame();
    }
}
