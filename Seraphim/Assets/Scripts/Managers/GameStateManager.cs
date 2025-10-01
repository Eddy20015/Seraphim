using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    //Will be using this GameStateManager as a SceneManager that loads and changes scenes with the correct GameState

    private static GameStateManager Instance;
    [SerializeField] private bool StartingInMenu = true;

    //this is what kind of state the game is in itself
    public enum GAMESTATE
    {
        GAMEOVER,
        MENU,
        PLAYING
    }

    private static GAMESTATE GameState;

    [SerializeField] private string MainMenuNameSetter;
    private static string MainMenuName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (StartingInMenu)
            {
                GameState = GAMESTATE.MENU;
            }
            else
            {
                GameState = GAMESTATE.PLAYING;
            }
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }

        MainMenuName = MainMenuNameSetter;
    }

    //sets GameState to GAMEOVER
    public static void Gameover()
    {
        GameState = GAMESTATE.GAMEOVER;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //this is so that the game freezes when it's gameover
        //Time.timeScale = 0f;
    }

    //returns the current GameState
    public static GAMESTATE GetGameState()
    {
        return GameState;
    }

    //set GameState to MENU, Multiplay to NONE and Load Main Menu
    public static void MainMenu()
    {
        GameState = GAMESTATE.MENU;
        SceneManager.LoadScene(MainMenuName);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    //set GameState to PLAYING and load a/the level
    //will also be used to restart after a gameover
    //if there is only one level, we could make the string name a SerializeField instead of a parameter
    public static void Start(string Level)
    {

        GameState = GAMESTATE.PLAYING;

        //not sure if this is necessary just cuz this is for local
        SceneManager.LoadScene(Level);

        //this can be removed if Gameover() will not set timescale to 0
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}