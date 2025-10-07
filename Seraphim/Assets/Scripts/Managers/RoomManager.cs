using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class RoomManager : MonoBehaviour
{
    private static RoomManager Instance;
    private static Fungus.Flowchart roomFlowchart;
    private static bool RoomCompleted = false;
    

    public enum ROOMTYPE
    {
        INTRO,
        SERAPH,
        MEMORY
    }

    private static ROOMTYPE currRoomType;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }

        try
        {
            roomFlowchart = GameObject.FindAnyObjectByType<Fungus.Flowchart>();
        }
        catch
        {
            Debug.LogError("DIDNT FIND FLOWCHART! PROBLEM");
        }
    }

    public static void SetCurrRoomType(ROOMTYPE newRoomType)
    {
        currRoomType = newRoomType;
    }

    public static void EndRoom(string requestedRoom)
    {
        if(RoomCompleted)
        {
            SceneManager.LoadScene(requestedRoom);
        }
    }

    public static void BeginRoom(string startingBlock = "")
    {
        RoomCompleted = false;
        if (currRoomType == ROOMTYPE.INTRO)
        {
            GameStateManager.Intro();
        }
        else if (currRoomType == ROOMTYPE.MEMORY)
        {
            GameStateManager.Play();
        }
        else if (currRoomType == ROOMTYPE.SERAPH)
        {
            ActivateFungus(startingBlock);
        }
    }

    public static void ActivateFungus(string startingBlock)
    {
        GameStateManager.Talk();
        roomFlowchart.ExecuteBlock(startingBlock); //call the block that handle Stay or Entry
    }

    public static void CompleteRoom()
    {
        RoomCompleted = true;
    }
}
