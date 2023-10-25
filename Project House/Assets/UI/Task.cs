using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public GameObject taskText;

    private void Start()
    {
        //test
        fixTask();
    }

    public void fixTask()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);

        //spawn particles
        //play sound

        //update ui
        taskText.GetComponent<Animator>().SetTrigger("fadeOut");

    }
}
