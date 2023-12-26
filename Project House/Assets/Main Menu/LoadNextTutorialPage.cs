using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextTutorialPage : MonoBehaviour
{
    public GameObject nextTutorialPage;
    public static bool tutorialOpen;

    public void loadFirst()
    {
        if (!tutorialOpen)
        {
            this.GetComponent<Animator>().SetTrigger("out");
            if (nextTutorialPage != null) nextTutorialPage.GetComponent<Animator>().SetTrigger("in");
            tutorialOpen = true;
        }
        else Debug.Log("tutorial panel already open");
    }

    public void loadNext()
    {

        this.GetComponent<Animator>().SetTrigger("out");
        if (nextTutorialPage != null) nextTutorialPage.GetComponent<Animator>().SetTrigger("in");
        else tutorialOpen = false;
        
    }
}
