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

    bool firstGoalDone = false;
    bool secondGoalDone = false;
    bool thirdGoalDone = false;
    bool fourthGoalDone = false;
    bool fifthGoalDone = false;
    bool sixthGoalDone = false;

    Transform firstGoal;
    Transform secondGoal;
    Transform thirdGoal;
    Transform fourthGoal;
    Transform fifthGoal;
    Transform sixthGoal;

    public bool isFixing;
    public float timeRemaining = 5.0f;
    public bool isRinging;

    RaycastHit2D hit;
    

    // Start is called before the first frame update
    void Start()
    {
        isFixing = false;
        changeGoalRand();
        player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
        //goalPoint = currGoal;
        goalPoint.position = currGoal.position;
        isRinging = false;

        //test
        //currGoal = goalF;
    }

    // Update is called once per frame
    void Update()
    {
        if(firstGoalDone && secondGoalDone && thirdGoalDone && fourthGoalDone && fifthGoalDone && sixthGoalDone){
            YouWin();
        }
        goalPoint.position = currGoal.position;
        
        if(Mathf.Abs(currGoal.position.x - player.transform.position.x) < 0.5 && Mathf.Abs(currGoal.position.y - player.transform.position.y) < 0.5 && isFixing == false)
        {
            
            Fix();
        }


        
        //if bell in range set that to current goal
        //if goal value = null set it to new one
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Step 1");
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null){
                Debug.Log("Step 2");
            }
            if(hit.collider == null){
                Debug.Log(" null Step 2");
            }
            
            if(hit.transform.tag.Equals("phone") == true){
                Debug.Log("Step 3");
                float timeRemaining = 5.0f;
                //phone ring sound effect
                //phone ring animation
                
                isRinging = true;
            }
        }

        if (isRinging && timeRemaining > 0){
            Debug.Log("Step 4");
                    if(Mathf.Abs(hit.transform.position.x - player.transform.position.x) < 15 
                    && Mathf.Abs(hit.transform.position.y - player.transform.position.y) < 15 ){
                       Debug.Log("step 5");
                        //figure out which phone it is
                        float distanceToTaskOne = Mathf.Abs((hit.transform.position.x - firstGoal.transform.position.x) + (hit.transform.position.y - firstGoal.transform.position.y));
                        float distanceToTaskTwo = Mathf.Abs((hit.transform.position.x - secondGoal.transform.position.x) + (hit.transform.position.y - secondGoal.transform.position.y));
                        float distanceToTaskThree = Mathf.Abs((hit.transform.position.x - thirdGoal.transform.position.x) + (hit.transform.position.y - thirdGoal.transform.position.y));
                        float distanceToTaskFour = Mathf.Abs((hit.transform.position.x - fourthGoal.transform.position.x) + (hit.transform.position.y - fourthGoal.transform.position.y));
                        float distanceToTaskFive = Mathf.Abs((hit.transform.position.x - fifthGoal.transform.position.x) + (hit.transform.position.y - fifthGoal.transform.position.y));
                        float distanceToTaskSix = Mathf.Abs((hit.transform.position.x - sixthGoal.transform.position.x) + (hit.transform.position.y - sixthGoal.transform.position.y));

                        float minDistance = distanceToTaskOne;
                        if(distanceToTaskTwo < minDistance){
                            minDistance = distanceToTaskTwo;
                        }
                        if(distanceToTaskThree < minDistance){
                            minDistance = distanceToTaskThree;
                        }
                        if(distanceToTaskFour < minDistance){
                            minDistance = distanceToTaskFour;
                        }
                        if(distanceToTaskFive < minDistance){
                            minDistance = distanceToTaskFive;
                        }
                        if(distanceToTaskSix < minDistance){
                            minDistance = distanceToTaskSix;
                        }

                        if(minDistance == distanceToTaskOne){
                            currGoal = firstGoal;
                            currGoal.position = firstGoal.position;
                        }
                        if(minDistance == distanceToTaskTwo){
                            currGoal = secondGoal;
                            currGoal.position = secondGoal.position;
                        }
                        if(minDistance == distanceToTaskThree){
                            currGoal = thirdGoal;
                            currGoal.position = thirdGoal.position;
                        }
                        if(minDistance == distanceToTaskFour){
                            currGoal = fourthGoal;
                            currGoal.position = fourthGoal.position;
                        }
                        if(minDistance == distanceToTaskFive){
                            currGoal = fifthGoal;
                            currGoal.position = fifthGoal.position;
                        }
                        if(minDistance == distanceToTaskSix){
                            currGoal = sixthGoal;
                            currGoal.position = sixthGoal.position;
                        }


                        //set currGoal to that task 
                        player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
                    
                        //set ai to walk there
                    }
                    //make time increase
                    timeRemaining-=Time.deltaTime;
                }
        else{
            isRinging = false;
            timeRemaining = 5.0f;
        }
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
        if(currGoal == firstGoal && firstGoalDone == true){
            if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }
        else if(currGoal == secondGoal && secondGoalDone == true){
            if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            if(firstGoalDone == false){
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }
        else if(currGoal == thirdGoal && thirdGoalDone == true){
            if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            if(firstGoalDone == false){
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }
        else if(currGoal == fourthGoal && fourthGoal == true){
            if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            if(firstGoalDone == false){
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }
        else if(currGoal == fifthGoal && fifthGoalDone == true){
            if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            if(firstGoalDone == false){
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }
        else if(currGoal == sixthGoal && sixthGoalDone == true){
            if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            if(firstGoalDone == false){
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        yield return new WaitForSeconds(5.0f);

        if(currGoal == firstGoal){
            Debug.Log("First task done");
            
            firstGoalDone = true;
            currGoal.gameObject.GetComponent<Task>().fixTask(); //Fixed task

            if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            else{
                YouWin();
            }

            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == secondGoal){
            Debug.Log("Second task done");
            
            secondGoalDone = true;
            currGoal.gameObject.GetComponent<Task>().fixTask(); //Fixed task
            if(firstGoalDone == false){
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            else if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            else{
                YouWin();
            }

            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == thirdGoal){
            Debug.Log("Third task done");
            
            thirdGoalDone = true;
            currGoal.gameObject.GetComponent<Task>().fixTask(); //Fixed task
            if(firstGoalDone == false){
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            else if(secondGoalDone == false){
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            }
            else if(thirdGoalDone == false){
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if(fourthGoalDone == false){
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if(fifthGoalDone == false){
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if(sixthGoalDone == false){
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            else{
                YouWin();
            }

            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == fourthGoal){
            Debug.Log("Fourth task done");
            
            fourthGoalDone = true;
            currGoal.gameObject.GetComponent<Task>().fixTask(); //Fixed task
            if (firstGoalDone == false)
            {
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            else if (secondGoalDone == false)
            {
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            }
            else if (thirdGoalDone == false)
            {
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if (fourthGoalDone == false)
            {
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if (fifthGoalDone == false)
            {
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if (sixthGoalDone == false)
            {
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            else
            {
                YouWin();
            }

            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == fifthGoal){
            Debug.Log("Fifth task done");
            
            fifthGoalDone = true;
            currGoal.gameObject.GetComponent<Task>().fixTask(); //Fixed task
            if (firstGoalDone == false)
            {
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            else if (secondGoalDone == false)
            {
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            }
            else if (thirdGoalDone == false)
            {
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if (fourthGoalDone == false)
            {
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if (fifthGoalDone == false)
            {
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if (sixthGoalDone == false)
            {
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            else
            {
                YouWin();
            }

            player.GetComponent<AIDestinationSetter>().target = currGoal.transform;
            isFixing = false;
            yield break;
        }

        else if(currGoal == sixthGoal){
            sixthGoalDone = true;
            currGoal.gameObject.GetComponent<Task>().fixTask(); //Fixed task

            if (firstGoalDone == false)
            {
                currGoal = firstGoal;
                currGoal.position = firstGoal.position;
            }
            else if (secondGoalDone == false)
            {
                currGoal = secondGoal;
                currGoal.position = secondGoal.position;
            }
            else if (thirdGoalDone == false)
            {
                currGoal = thirdGoal;
                currGoal.position = thirdGoal.position;
            }
            else if (fourthGoalDone == false)
            {
                currGoal = fourthGoal;
                currGoal.position = fourthGoal.position;
            }
            else if (fifthGoalDone == false)
            {
                currGoal = fifthGoal;
                currGoal.position = fifthGoal.position;
            }
            else if (sixthGoalDone == false)
            {
                currGoal = sixthGoal;
                currGoal.position = sixthGoal.position;
            }
            else
            {
                YouWin();
            }
        }

    }

    public void YouWin(){
        Debug.Log("last task done");
        Debug.Log("You win");
    }
}
