using UnityEngine;

public class RoomSeraph : RoomAbstract
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override protected void Start()
    {
        roomType = RoomManager.ROOMTYPE.SERAPH;
        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {

    }

    override protected void Begin()
    {
        
    }

    protected override void End()
    {
        RoomManager.EndRoom("");
    }
}
