public class AIRoom
{
    public Room Room;
    public float DirtLevel;
    public int RoomId;

    public AIRoom(Room r, float dirtLevel, int roomID)
    {
        Room = r;
        DirtLevel = dirtLevel;
        RoomId = roomID;
    }
}