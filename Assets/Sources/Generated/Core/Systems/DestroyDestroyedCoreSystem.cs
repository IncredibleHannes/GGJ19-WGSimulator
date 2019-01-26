//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Roslyn.CodeGeneration.Plugins.CleanupSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using Entitas;

public sealed class DestroyDestroyedCoreSystem : ICleanupSystem {

    readonly IGroup<CoreEntity> _group;
    readonly List<CoreEntity> _buffer = new List<CoreEntity>();

    public DestroyDestroyedCoreSystem(Contexts contexts) {
        _group = contexts.core.GetGroup(CoreMatcher.Destroyed);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.Destroy();
        }
    }
}