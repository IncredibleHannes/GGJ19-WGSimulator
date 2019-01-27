using UnityEngine;
using Entitas;
using Entitas.Unity;

public class View : MonoBehaviour, IView, ICoreDestroyedListener
{
    public virtual void Link(CoreEntity entity)
    {
        gameObject.Link(entity);

        entity.AddCoreDestroyedListener(this);
        if (entity.isDestroyed) this.OnDestroyed(entity);
    }

    public void OnDestroyed(CoreEntity entity)
    {
        DestroyView();
    }

    public virtual void DestroyView()
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}