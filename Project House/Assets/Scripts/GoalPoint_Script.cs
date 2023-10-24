using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;

public class GoalPoint_Script : MonoBehaviour
{
    public Transform currGoal;


    [SerializeField] GameObject player;
    [SerializeField] Transform goalPoint;
    [SerializeField] Transform goalA;

    [SerializeField] Transform goalB;
    
    [SerializeField] Transform goalC;
    
    [SerializeField] Transform goalD;
    
    [SerializeField] Transform goalE;

    [SerializeField] Transform goalF;

    Transform firstGoal;
    Transform secondGoal;
    Transform thirdGoal;
    Transform fourthGoal;
    Transform fifthGoal;
    Transform sixthGoal;

    public bool isFixing;
    

    // Start is called before the first frame update
    void Start()
    {
        isFixing = false;
        changeGoalRand();
        player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
        goalPoint = currGoal;
        goalPoint.position = currGoal.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        goalPoint.position = currGoal.position;
        
        if(Mathf.Abs(currGoal.position.x - player.transform.position.x) < 0.5 && Mathf.Abs(currGoal.position.y - player.transform.position.y) < 0.5 && isFixing == false)
        {
            Fix();
        }


        
        //if bell in range set that to current goal
        //if goal value = null set it to new one
    }

    public void changeGoalRand()
    {
        Debug.Log("got here");
        //Set first goal
        int index1 = Random.Range(1, 7);
        if(index1 == 1){
            firstGoal = goalA;
            Debug.Log("1");
        }
        if(index1 == 2){
            firstGoal = goalB;
            Debug.Log("2");
        }
        if(index1 == 3){
            firstGoal = goalC;
            Debug.Log("3");
        }
        if(index1 == 4){
            firstGoal = goalD;
            Debug.Log("4");
        }
        if(index1 == 5){
            firstGoal = goalE;
            Debug.Log("5");
        }
        if(index1 == 6){
            firstGoal = goalF;
            Debug.Log("6");
        }

        //set second goal
        int index2 = Random.Range(1, 7);
        if(index2 == index1){
            while(index2 == index1){
                index2 = Random.Range(1, 7);
            }
        }
        if(index2 == 1){
            secondGoal = goalA;
        }
        if(index2 == 2){
            secondGoal = goalB;
        }
        if(index2 == 3){
            secondGoal = goalC;
        }
        if(index2 == 4){
            secondGoal = goalD;
        }
        if(index2 == 5){
            secondGoal = goalE;
        }
        if(index2 == 6){
            secondGoal = goalF;
        }

        //set third goal
        int index3 = Random.Range(1, 7);
        if(index3 == index1 || index3 == index2){
            while(index3 == index1 || index3 == index2){
                index3 = Random.Range(1, 7);
            }
        }

        if(index3 == 1){
            thirdGoal = goalA;
        }
        if(index3 == 2){
            thirdGoal = goalB;
        }
        if(index3 == 3){
            thirdGoal = goalC;
        }
        if(index3 == 4){
            thirdGoal = goalD;
        }
        if(index3 == 5){
            thirdGoal = goalE;
        }
        if(index3 == 6){
            thirdGoal = goalF;
        }

        //set fourth goal
        int index4 = Random.Range(1, 7);
        if(index4 == index1 || index4 == index2 || index4 == index3){
            while(index4 == index1 || index4 == index2 || index4 == index3){
                index4 = Random.Range(1, 7);
            }
        }
        if(index4 == 1){
            fourthGoal = goalA;
        }
        if(index4 == 2){
            fourthGoal = goalB;
        }
        if(index4 == 3){
            fourthGoal = goalC;
        }
        if(index4 == 4){
            fourthGoal = goalD;
        }
        if(index4 == 5){
            fourthGoal = goalE;
        }
        if(index4 == 6){
            fourthGoal = goalF;
        }

        //set fifth goal
        int index5 = Random.Range(1, 7);
        if(index5 == index1 || index5 == index2 || index5 == index3 || index5 == index4){
            while(index5 == index1 || index5 == index2 || index5 == index3 || index5 == index4){
                index5 = Random.Range(1, 7);
            }
        }
        if(index5 == 1){
            fifthGoal = goalA;
        }
        if(index5 == 2){
            fifthGoal = goalB;
        }
        if(index5 == 3){
            fifthGoal = goalC;
        }
        if(index5 == 4){
            fifthGoal = goalD;
        }
        if(index5 == 5){
            fifthGoal = goalE;
        }
        if(index5 == 6){
            fifthGoal = goalF;
        }

        //set sixth goal
        int index6 = Random.Range(1, 7);
        if(index6 == index1 || index6 == index2 || index6 == index3 || index6 == index4 || index6 == index5){
            while(index6 == index1 || index6 == index2 || index6 == index3 || index6 == index4 || index6 == index5){
                index6 = Random.Range(1, 7);
            }
        }
        if(index6 == 1){
            sixthGoal = goalA;
        }
        if(index6 == 2){
            sixthGoal = goalB;
        }
        if(index6 == 3){
            sixthGoal = goalC;
        }
        if(index6 == 4){
            sixthGoal = goalD;
        }
        if(index6 == 5){
            sixthGoal = goalE;
        }
        if(index6 == 6){
            sixthGoal = goalF;
        }

        currGoal = firstGoal;
        currGoal.position = firstGoal.position;
    }

    public void Fix()
    {
        isFixing = true;
        //start animation of repairs
        StartCoroutine(Fixing());

        
    }

    IEnumerator Fixing()
    {
        yield return new WaitForSeconds(5.0f);

        if(currGoal == firstGoal){
            Debug.Log("First task done");
            currGoal.position = secondGoal.position;
            currGoal = secondGoal;
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == secondGoal){
            Debug.Log("Second task done");
            currGoal.position = thirdGoal.position;
            currGoal = thirdGoal;
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == thirdGoal){
            Debug.Log("Third task done");
            currGoal.position = fourthGoal.position;
            currGoal = fourthGoal;
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == fourthGoal){
            Debug.Log("Fourth task done");
            currGoal.position = fifthGoal.position;
            currGoal = fifthGoal;
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == fifthGoal){
            Debug.Log("Fifth task done");
            currGoal.position = sixthGoal.position;
            currGoal = sixthGoal;
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == sixthGoal){
            Debug.Log("last task done");
            Debug.Log("You win");
        }

        
    }
}
