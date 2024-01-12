using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/**
*   Charles Caton
*   New Version phone contents of GoalPoint_Script.cs
*   Made 1/8/2024
*/

public class Phone : MonoBehaviour
{

    public  GameObject connectedTask;
    [SerializeField] GameObject currGoal;

    RaycastHit2D hit;

    public float timeRemaining = 5.0f;
    public bool isRinging;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && currGoal.GetComponent<NewGoalPoint>().isSetting == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hit.transform.tag.Equals("phone") == true && isRinging == false)
            {
                hit.transform.GetComponent<Animator>().SetBool("isRinging", false);
                hit.transform.GetComponent<Animator>().SetBool("isNormal", true);
                float timeRemaining = 5.0f;
                //phone ring sound effect
                FindObjectOfType<AudioManager>().Play("PhoneRing");
                //phone ring animation
                
                isRinging = true;
                hit.transform.GetComponent<Animator>().SetBool("isRinging", true);
                hit.transform.GetComponent<Animator>().SetBool("isNormal", false);
                
                if(currGoal.GetComponent<NewGoalPoint>().isSetting == false)
                {
                    if(hit.transform.GetComponent<Phone>().connectedTask != null)
                    {
                        Debug.Log("starting here with " + hit.transform.GetComponent<Phone>().connectedTask);
                        currGoal.GetComponent<NewGoalPoint>().SetGoalPointSpecific(hit.transform.GetComponent<Phone>().connectedTask);
                    }
                }
            }
        }

        if(timeRemaining < 0)
        {
            hit.transform.GetComponent<Animator>().SetBool("isRinging", false);
            hit.transform.GetComponent<Animator>().SetBool("isNormal", true);
        }

        if (isRinging && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        else
        {
            isRinging = false;
            timeRemaining = 5.0f;
        }
    }
}
