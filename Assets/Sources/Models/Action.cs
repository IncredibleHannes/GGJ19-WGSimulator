using System.Collections.Generic;
using System.Reflection;

public class Action
{
    public string Title { get; private set; }
    public RoomType[] AllowedRoomTypes { get; private set; }
    public float MotivationPerSecond { get; private set; }
    public float FunPerSecond { get; private set; }
    public float DirtPerSecond { get; private set; }
    public float BaseOpinionPerSecond { get; private set; }

    public float DefaultLength { get; private set; }

    public int TimesPerDay { get; private set; }

    private Action(string title, RoomType[] allowedRoomTypes, float motivationPerSecond, float funPerSecond, float dirtPerSecond, float baseOpinionPerSecond, float defaultLength, int timesPerDay)
    {
        Title = title;
        AllowedRoomTypes = allowedRoomTypes;
        MotivationPerSecond = motivationPerSecond;
        FunPerSecond = funPerSecond;
        DirtPerSecond = dirtPerSecond;
        BaseOpinionPerSecond = baseOpinionPerSecond;
        DefaultLength = defaultLength;
        TimesPerDay = timesPerDay;
    }

    public Action() : this("idle", new RoomType[] { RoomType.BATHROOM, RoomType.KITCHEN, RoomType.LIVING_ROOM }, 0, 0, 0, 0, 0, int.MaxValue) { }

    public static List<Action> Actions
    {
        get
        {
            var fields = typeof(Action).GetFields();
            List<Action> actions = new List<Action>();
            foreach (FieldInfo f in fields)
            {
                if (f.FieldType == typeof(Action))
                {
                    actions.Add(f.GetValue(null) as Action);
                }
            }
            return actions;
        }
    }

    public static Action TIDY_UP = new Action("tidy up", new RoomType[] { RoomType.LIVING_ROOM, RoomType.KITCHEN }, -1, 0, -1, 1, 5, 4);
    public static Action CLEAN = new Action("clean", new RoomType[] { RoomType.BATHROOM }, -1, 0, -1, 1, 5, 1);
    public static Action DO_THE_DISHES = new Action("do the dishes", new RoomType[] { RoomType.KITCHEN }, -0.5f, 0.01f, -0.25f, 0.75f, 4, 1);
    public static Action WATCH_TV = new Action("watch TV", new RoomType[] { RoomType.LIVING_ROOM }, 0, 2, 0.5f, -.25f, 7, 10);
    public static Action HAVE_A_PARTY = new Action("have a party", new RoomType[] { RoomType.LIVING_ROOM }, 0, 1, 1, -1, 10, 1);
    public static Action EAT = new Action("eat", new RoomType[] { RoomType.KITCHEN }, 0, 0.6f, 0.4f, -.1f, 4, 4);
    public static Action SHOWER = new Action("shower", new RoomType[] { RoomType.BATHROOM }, 0, 0.7f, 0.4f, -.1f, 3, 1);
    public static Action GO_TO_TOILET = new Action("go to toilet", new RoomType[] { RoomType.BATHROOM }, 0, 0.2f, 0.1f, -.05f, 3, 10);
    public static Action IDLE = new Action("idle", new RoomType[] { RoomType.BATHROOM, RoomType.KITCHEN, RoomType.LIVING_ROOM }, 0, 0, 0, 0, 5, int.MaxValue);
}
