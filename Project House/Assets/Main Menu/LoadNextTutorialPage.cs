using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gets called when tutorial button and next tutorial page button is pressed
 * Open and close tutorial + next page functionality
 */
public class LoadNextTutorialPage : MonoBehaviour
{
    private static GameObject currentTutorialPage;
    public GameObject nextTutorialPage;
    public static bool tutorialOpen;

    /**
     * Gets called when tutorial button is pressed.
     * Opens tutorial if unopened, else close existing tutorial page
     */
    public void loadFirst()
    {
        if (!tutorialOpen) // open tutorial
        {
            if (nextTutorialPage != null)
            {
                nextTutorialPage.GetComponent<Animator>().SetTrigger("in");
                currentTutorialPage = nextTutorialPage as GameObject;
            }
            
            tutorialOpen = true;
        }
        else // close tutorial
        {
            currentTutorialPage.GetComponent<Animator>().SetTrigger("out");
            tutorialOpen = false;
        }
    }

    /**
     * Loads next tutorial page
     * Exits tutorial if none 
     */
    public void loadNext()
    {
        currentTutorialPage.GetComponent<Animator>().SetTrigger("out"); // remove current page
        if (nextTutorialPage != null)
        {
            nextTutorialPage.GetComponent<Animator>().SetTrigger("in");
            currentTutorialPage = nextTutorialPage as GameObject;
        }
        else tutorialOpen = false;
        
    }
}
