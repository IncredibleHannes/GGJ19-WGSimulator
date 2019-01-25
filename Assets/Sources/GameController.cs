using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Systems systems;

    void Start()
    {
        systems = new AllSystems(Contexts.sharedInstance);
        systems.Initialize();
    }

    void Update()
    {
        systems.Execute();
        systems.Cleanup();
    }
}
