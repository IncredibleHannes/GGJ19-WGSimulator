using System.Collections.Generic;
using System.Reflection;

public class Action
{
    public string Title { get; private set; }
    public float MotivationPerSecond { get; private set; }
    public float FunPerSecond { get; private set; }
    public float DirtPerSecond { get; private set; }
    public float BaseOpinionPerSecond { get; private set; }

    public Action(string title, float motivationPerSecond, float funPerSecond, float dirtPerSecond, float baseOpinionPerSecond)
    {
        Title = title;
        MotivationPerSecond = motivationPerSecond;
        FunPerSecond = funPerSecond;
        DirtPerSecond = dirtPerSecond;
        BaseOpinionPerSecond = baseOpinionPerSecond;
    }

    public Action() : this("idle", 0, 0, 0, 0) { }

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

    public static Action TIDY_UP = new Action("tidy up", -1, 0, -1, 1);
    public static Action WATCH_TV = new Action("watch TV", 0, 2, 0.5f, -.25f);
}
