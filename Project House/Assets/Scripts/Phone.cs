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

    [SerializeField] GameObject phone;
    [SerializeField] GameObject connectedTask;
    [SerializeField] GameObject builder;
    [SerializeField] GameObject currGoal;

    RaycastHit2D hit;

    public float timeRemaining = 5.0f;
    public bool isRinging;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Step 1");
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                Debug.Log("Step 2");
            }

            if(hit.collider == null)
            {
                Debug.Log(" null Step 2");
            }
            
            if(hit.transform.tag.Equals("phone") == true)
            {
                hit.transform.GetComponent<Animator>().SetBool("isRinging", false);
                hit.transform.GetComponent<Animator>().SetBool("isNormal", true);
                Debug.Log("Step 3");
                float timeRemaining = 5.0f;
                //phone ring sound effect
                FindObjectOfType<AudioManager>().Play("PhoneRing");
                //phone ring animation
                
                isRinging = true;
                hit.transform.GetComponent<Animator>().SetBool("isRinging", true);
                hit.transform.GetComponent<Animator>().SetBool("isNormal", false);

                currGoal.GetComponent<NewGoalPoint>().SetGoalPointSpecific(connectedTask.transform);
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
