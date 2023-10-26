using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private static string trName = "End";
    private static float time = 1f;
    public Animator transition;

    public Animator ui1;
    public Animator ui2;
    public Animator ui3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startTransition() {
        StartCoroutine(levelTransition());
    }
    IEnumerator levelTransition() {
        transition.SetTrigger(trName);
        if (ui1 != null) ui1.SetTrigger("fadeOut");
        if (ui2 != null) ui2.SetTrigger("fadeOut");
        if (ui3 != null) ui3.SetTrigger("fadeOut");
        yield return new WaitForSeconds(time);
        if(SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        else
            SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
