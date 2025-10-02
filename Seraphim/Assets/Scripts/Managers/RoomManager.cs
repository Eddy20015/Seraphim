using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    private static RoomManager Instance;

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
    }
    
    //THIS COULD ALL BE STUPID AND WE DONT ACTUALLY CARE LOL
    public struct Condition
    {
        public enum CONDITIONTYPE
        {
            ENTRY,
            CONTINUE,
            END
        }

        public bool conditionState; 
        public string conditionName;
        public CONDITIONTYPE conditionType;
        public string switchRoom;
    }

    private string currConditionName;

    //public void SelectConditionName(Condition newCondition)
    //{
    //    currConditionName = newCondition.conditionName;
    //}

    public void ConditionMet(Condition newCondition)
    {

    }

    private void SwitchRoom(string requestedRoom, Condition switchCondition)
    {
        if(switchCondition.conditionName == currConditionName && switchCondition.conditionState)
        {
            SceneManager.LoadScene(requestedRoom);
        }
    }
}
