public class AIAction
{
    public Action action;
    public int room;

    public AIAction(Action a, int room)
    {
        this.action = a;
        this.room = room;
    }

    public AIAction(AIAction a)
    {
        this.action = a.action;
        this.room = a.room;
    }
}