using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Task : MonoBehaviour
{
    public GameObject taskText;
    public Light2D globalLight;

    public void fixTask()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // add fixed deco
        gameObject.transform.GetChild(1).gameObject.SetActive(false); // remove broken deco
        gameObject.transform.GetChild(2).gameObject.GetComponent<Animator>().SetTrigger("out"); // exclamation mark

        //spawn particles
        //play sound

        //update ui text
        taskText.GetComponent<Animator>().SetTrigger("fadeOut");

        if (this.name.Equals("Power Box")) // change light levels if task fixed power box
        {
            globalLight.intensity = 0.35f;
        }
    }
}
