using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Animator[] cutscenePanels;
    int i = 0;

    public void nextPage()
    {
        cutscenePanels[i].SetTrigger("out"); // move current panel out
        i++;

        if (i < cutscenePanels.Length)
        {
            cutscenePanels[i].SetTrigger("in"); // move next panel in frame
        }
        else
        {
            Debug.Log("No more panels!");
        }
    }
}
