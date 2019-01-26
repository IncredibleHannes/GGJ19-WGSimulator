using Entitas;

public sealed class UpdateOtherRoomOpinionSystem : IExecuteSystem
{
    private readonly Contexts contexts;
    private readonly IGroup<CoreEntity> actingFlatmates;
    private readonly IGroup<CoreEntity> opiniatedFlatmates;

    public UpdateOtherRoomOpinionSystem(Contexts contexts)
    {
        this.contexts = contexts;

        actingFlatmates = contexts.core.GetGroup(CoreMatcher.AllOf(CoreMatcher.FlatmateId, CoreMatcher.ActiveAction, CoreMatcher.CurrentRoom));
        opiniatedFlatmates = contexts.core.GetGroup(CoreMatcher.AllOf(CoreMatcher.Flatmate, CoreMatcher.Opinion, CoreMatcher.CurrentRoom));
    }

    public void Execute()
    {
        foreach (var actingFlatmate in actingFlatmates)
        {
            int flatmateId = actingFlatmate.flatmateId.value;
            Action activeAction = actingFlatmate.activeAction.value;
            int roomId = actingFlatmate.currentRoom.roomId;

            foreach (var opiniatedFlatmate in opiniatedFlatmates)
            {
                if (opiniatedFlatmate.currentRoom.roomId == roomId) continue;

                float opinionMultiplier = opiniatedFlatmate.hasOpinionModifier
                    ? opiniatedFlatmate.opinionModifier.baseOpinionMultiplier * opiniatedFlatmate.opinionModifier.otherRoomOpinionMultiplier
                    : 1;

                float currentOpinion = opiniatedFlatmate.opinion.value.GetOrDefault(flatmateId, 0f);
                var opinions = opiniatedFlatmate.opinion.value;

                opinions[flatmateId] = currentOpinion + activeAction.BaseOpinionPerSecond * opinionMultiplier * contexts.core.timeSinceLastTick.value;

                opiniatedFlatmate.ReplaceOpinion(opinions);
            }
        }
    }
}
