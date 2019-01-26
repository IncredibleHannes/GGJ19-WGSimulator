using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomView : View, IDirtLevelListener
{
    public int roomId;
    public List<SpriteRenderer> dirtSprites;

    public override void Link(CoreEntity entity)
    {
        base.Link(entity);

        entity.AddDirtLevelListener(this);
        if (entity.hasDirtLevel) this.OnDirtLevel(entity, entity.dirtLevel.value);
    }

    public void OnDirtLevel(CoreEntity entity, float value)
    {
        foreach (var dirtSprite in dirtSprites)
        {
            var color = dirtSprite.color;
            dirtSprite.color = new Color(color.r, color.g, color.b, Mathf.Max(0, Mathf.Min(1, value / 10)));
        }
    }
}
