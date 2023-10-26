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

    private bool gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        MouseHighlight.setLight(highlight);
    }

    public void WinGame()
    {
        if (gameEnd == false)
        {
            gameWinUI.SetActive(true);
            gameEnd = true;
        }
    }

    public void LoseGame()
    {
        if (gameEnd == false)
        {
            gameOverUI.SetActive(true);
            GameObject.Find("LevelLoader").GetComponent<SceneTransition>().startTransition();
            gameEnd = true;
        }
    }
}
