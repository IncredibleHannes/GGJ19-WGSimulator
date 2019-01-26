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

        commandContext.CreateEntity().AddCreateRoomCommand(new Room("Living Room"));
        commandContext.CreateEntity().AddCreateRoomCommand(new Room("Dining Room"));
        commandContext.CreateEntity().AddCreateFlatmateCommand("Mate", 0);
        commandContext.CreateEntity().AddCreateFlatmateCommand("Dude", 0);
    }
}
