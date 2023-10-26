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
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);

        //spawn particles
        //play sound

        //update ui
        taskText.GetComponent<Animator>().SetTrigger("fadeOut");

        if (this.name.Equals("Power Box"))
        {
            globalLight.intensity = 0.35f;
        }
    }
}
