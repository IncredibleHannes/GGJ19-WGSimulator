using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatmateView : View, ICurrentRoomListener
{
    public override void Link(CoreEntity entity)
    {
        base.Link(entity);

        entity.AddCurrentRoomListener(this);
        if (entity.hasCurrentRoom) this.OnCurrentRoom(entity, entity.currentRoom.roomId);
    }

    public void OnCurrentRoom(CoreEntity entity, int roomId)
    {
        switch (roomId)
        {
            case 0:
                transform.position = new Vector2(1.92f, 3.87f);
                break;
            case 1:
                transform.position = new Vector2(-0.74f, -3f);
                break;
            case 2:
                transform.position = new Vector2(6.82f, 0.31f);
                break;
            case 3:
                transform.position = new Vector2(5.02f, 2.67f);
                break;
            default:
                transform.position = new Vector2(0f, 0f);
                break;
        }
    }
}
