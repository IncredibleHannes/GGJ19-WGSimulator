public class AIFlatmate
{
    public Action ActiveAction;
    public int CurrentRoomId;
    public AIFlatmate(Action activeAction, int currentRoomId)
    {
        ActiveAction = activeAction;
        CurrentRoomId = currentRoomId;
    }
}