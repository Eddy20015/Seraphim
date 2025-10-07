using UnityEngine;

public abstract class RoomAbstract : MonoBehaviour
{

    protected RoomManager.ROOMTYPE roomType;
    [SerializeField] protected string startingBlock = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    virtual protected void Start()
    {
        RoomManager.SetCurrRoomType(roomType);
        RoomManager.BeginRoom(startingBlock);
        Begin();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        
    }

    protected abstract void Begin();

    protected abstract void End();
}
