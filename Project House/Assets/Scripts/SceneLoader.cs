using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject cutscene;
    public GameObject game;

    public Button startButton;
    public Button skipButton;

    public float cutsceneDuration = 10.0f; // Define the cutscene duration as a class-level variable.

    private void Start()
    {
        // Initially, the main menu is visible, and the cutscene and game are hidden.
        mainMenu.SetActive(true);
        cutscene.SetActive(false);
        game.SetActive(false);

        // Attach button click events.
        startButton.onClick.AddListener(StartGame);
        skipButton.onClick.AddListener(SkipCutscene);
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        cutscene.SetActive(true);
        game.SetActive(false);

        // Play cutscene here (e.g., animation, video, or other logic).
        // You can use Unity's Animation or other tools to control your cutscene.

        // After the cutscene, transition to the game.
        Invoke("StartGameplay", cutsceneDuration);
    }

    private void StartGameplay()
    {
        mainMenu.SetActive(false);
        cutscene.SetActive(false);
        game.SetActive(true);

        // Start your game logic here.
    }

    public void SkipCutscene()
    {
        // If the player wants to skip the cutscene, you can call this function.
        // Implement logic to stop or skip the cutscene and start
    }
}