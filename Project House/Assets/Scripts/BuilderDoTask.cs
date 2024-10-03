
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine.XR;

/**
*   Charles Caton and Bruno Wu
*   1/16/2024
*/

public class BuilderDoTask : MonoBehaviour
{
    // standard gameState to tell endings and such
    private GameState gameState;

    // current goal for builder to go to
    [SerializeField] private GameObject currGoal;

    // player game object. In unity set this to the players own self
    [SerializeField] GameObject player;

    // List of all goals for this specific level
    public List<GameObject> goals;

    public bool isFixing;
    public bool isSetting;

    //Checks if level is completed
    private bool isWon;

    private AudioManager audioManager;


    /**
    *   Start sets all needed bools to false and the gameState to the right thing
    *   Then it gets a random goal and sets it for the builder
    **/
    void Start()
    {
        gameState = GameObject.Find("General").GetComponent<GameState>();
        isFixing = false;
        isSetting = false;

        Random.seed = System.DateTime.Now.Millisecond; // to prevent the same random index on start function
        SetGoalPointRandom(); // set first goal

        player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
        audioManager = FindObjectOfType<AudioManager>();


    }

    void Update()
    {
        float x = Mathf.Abs(currGoal.transform.position.x - player.transform.position.x);
        float y = Mathf.Abs(currGoal.transform.position.y - player.transform.position.y);
        float distPlayerToGoal = Mathf.Sqrt(x * x + y * y);

        // Fix task when player arrives
        if (distPlayerToGoal < 0.5 && isFixing == false) StartCoroutine(Fixing());
    }

    
    /// <summary>
    /// When the builder is in range of the task, the animation and sounds play.
    /// The builder then repairs the task until it is done or is interupted/killed
    /// Once completed it checks for victory and assigns the next task
    /// </summary>
    /// <returns></returns>
    private IEnumerator Fixing()
    {
        isFixing = true;
        audioManager.Play("Wrench"); // sfx
        player.GetComponent<Builder>().isFixing = true; // builder animation

        yield return new WaitForSeconds(5);

        currGoal.GetComponent<Task>().fixTask();
        goals.Remove(currGoal);

        isFixing = false;
        player.GetComponent<Builder>().isFixing = false; // builder animation

        checkIfWon(); 
        if(!isWon) SetGoalPointRandom(); // set new point
    }

    /** 
    *   This is called at the begining of the game and every time a task needs to be set i.e. when another is completed
    *   It chooses a random number and sets the goal position to be that number in the array
    *   It also checks to make sure the goal selected is not already done, and if it is tries again
    **/
    void SetGoalPointRandom()
    {
        currGoal = goals[Random.Range(0, goals.Count)];
        player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
    }

    /** 
    *   THIS IS CALLED EXCLUSIVELY FROM THE PHONE.
    *   It chooses the goal set to the specific phone and sets the builder on that new path
    *   It also checks to make sure the goal selected is not already done, and if it is builder ignores
    **/
    public void SetGoalPointSpecific(GameObject goalGiven)
    {
        if (goalGiven != null && !isSetting)
        {
            isFixing = false;
            isSetting = true;
            currGoal = goalGiven;
            StartCoroutine(setPointWait());
        }


    }

    /** 
    *   This prevents a glitch in double clicking a phone too quickly
    **/
    private IEnumerator setPointWait()
    {
        yield return new WaitForSeconds(0.2f);
        isSetting = false;
    }

    /** 
    *   This just checks if all tasks are complete by checking if the elements of the goalArray have all been set to null
    *   Then if the number of null tasks = to the number of total goals, the player has won this level.
    **/
    void checkIfWon()
    {
        if (goals.Count <= 0 && !isWon)
        {
            gameState.WinGame();
            isWon = true;
        }
    }
}
