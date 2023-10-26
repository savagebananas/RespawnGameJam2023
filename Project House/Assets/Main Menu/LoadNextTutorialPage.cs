using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextTutorialPage : MonoBehaviour
{
    public GameObject nextTutorialPage;
    public void LoadNext()
    {
        this.GetComponent<Animator>().SetTrigger("out");
        if (nextTutorialPage != null) nextTutorialPage.GetComponent<Animator>().SetTrigger("in");
        
        
    }
}
