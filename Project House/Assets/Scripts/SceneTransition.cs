using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static bool isFirstPlay;

    private static string trName = "End";
    private static float time = 1f;
    public Animator transition;

    public Animator[] uiObjects;

    public void startTransition() {
        StartCoroutine(levelTransition());
    }
    IEnumerator levelTransition() {
        transition.SetTrigger(trName);


        for (int i = 0; i < uiObjects.Length; i++)
        {
            if (uiObjects[i] != null || uiObjects[i].GetComponent<Animator>() != null) uiObjects[i].SetTrigger("fadeOut");
            else Debug.Log("No animator component for uiObjects: index " + i);
        }
           

        yield return new WaitForSeconds(time);

        // load next scene (if last scene, load main menu)
        if(SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        else 
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
