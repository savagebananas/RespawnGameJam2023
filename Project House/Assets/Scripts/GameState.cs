using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Mangages the game start and end
 * Sets any prefabs and values
 */

public class GameState : MonoBehaviour
{
    public GameObject highlight;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public static bool gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        gameEnd = false;
        MouseHighlight.setLight(highlight);
    }

    public void WinGame()
    {
        if (gameEnd == false)
        {
            gameWinUI.SetActive(true);
            gameEnd = true;
            StartCoroutine(fadeToNextScene(1.5f));
        }
    }

    public void LoseGame()
    {
        if (gameEnd == false)
        {
            gameOverUI.SetActive(true);
            gameEnd = true;
            StartCoroutine(fadeToNextScene(1.5f));
        }
    }

    IEnumerator fadeToNextScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Find("LevelLoader").GetComponent<SceneTransition>().startTransition();
    }
}
