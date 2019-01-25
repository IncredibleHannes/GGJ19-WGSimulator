using UnityEngine;
using Entitas;
using Entitas.Unity;

public class View : MonoBehaviour, IView
{
    public virtual void Link(CoreEntity entity)
    {
        gameObject.Link(entity);
    }
}