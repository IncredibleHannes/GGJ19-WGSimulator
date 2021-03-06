using System.Collections.Generic;
using Entitas;

public sealed class CreateFlatmateSystem : ReactiveSystem<CommandEntity>
{
    private readonly CoreContext coreContext;
    System.Random rnd = new System.Random();

    public CreateFlatmateSystem(Contexts contexts) : base(contexts.command)
    {
        coreContext = contexts.core;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        return context.CreateCollector(CommandMatcher.CreateFlatmateCommand);
    }

    protected override bool Filter(CommandEntity entity)
    {
        return entity.hasCreateFlatmateCommand;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var command = e.createFlatmateCommand;

            var flatmate = coreContext.CreateEntity();
            flatmate.isFlatmate = true;
            flatmate.AddFlatmateId(flatmate.creationIndex);
            flatmate.AddName(command.name);
            flatmate.AddMotivation(100);
            flatmate.AddFun(0);
            flatmate.AddCurrentRoom(command.startingRoomId);
            flatmate.AddOpinion(new Dictionary<int, float>());
            flatmate.AddOpinionModifier(1, 1, 1, 1, 1, 1, 1);
            flatmate.AddAIBehaviour(new AIBehaviour(0.2f * (float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 2 * (float)rnd.NextDouble()));

            e.isDestroyed = true;
        }
    }
}
