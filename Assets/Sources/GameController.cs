using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Systems systems;

    void Start()
    {
        systems = new AllSystems(Contexts.sharedInstance);
        systems.Initialize();

        this.SetupLevel();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }

    void SetupLevel()
    {
        var contexts = Contexts.sharedInstance;
        var commandContext = contexts.command;

        commandContext.CreateEntity().AddCreateFlatCommand(2, 0);

        commandContext.CreateEntity().AddCreateFlatmateCommand("Mate", 0);
        commandContext.CreateEntity().AddCreateFlatmateCommand("Dude", 1);
        commandContext.CreateEntity().AddCreateFlatmateCommand("Dudley", 2);
        commandContext.CreateEntity().AddCreateFlatmateCommand("Madlene", 3);
    }
}
