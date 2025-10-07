using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager Instance;
    [SerializeField] private bool StartingInMenu = true;

    //this is what kind of state the game is in itself
    public enum GAMESTATE
    {
        GAMEOVER,
        MENU,
        INTRO,
        PLAYING,
        TALKING
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

    public static void Intro()
    {
        GameState = GAMESTATE.INTRO;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //set GameState to MENU, Multiplay to NONE and Load Main Menu
    public static void MainMenu()
    {
        GameState = GAMESTATE.MENU;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //set GameState to PLAYING and load a/the level
    //will also be used to restart after a gameover
    //if there is only one level, we could make the string name a SerializeField instead of a parameter
    public static void Play()
    {
        GameState = GAMESTATE.PLAYING;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void Talk()
    {
        GameState = GAMESTATE.TALKING;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}