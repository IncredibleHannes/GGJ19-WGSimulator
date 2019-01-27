public class Room
{
    public string Name { get; private set; }
    public RoomType Type { get; private set; }

    public Room(string name, RoomType type)
    {
        Name = name;
        Type = type;
    }

    public static Room LIVING_ROOM { get => new Room("Living Room", RoomType.LIVING_ROOM); }
    public static Room KITCHEN { get => new Room("Kitchen", RoomType.KITCHEN); }
    public static Room BATHROOM { get => new Room("Bathroom", RoomType.BATHROOM); }
}