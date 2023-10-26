using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private static string trName = "End";
    private static float time = 1f;
    public Animator transition;
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
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
}
