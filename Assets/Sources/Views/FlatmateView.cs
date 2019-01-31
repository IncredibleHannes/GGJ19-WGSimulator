using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatmateView : View, ICurrentRoomListener, IActiveActionListener
{
    private static System.Random rng = new System.Random();

    public List<SpriteRenderer> playerSkins;

    public override void Link(CoreEntity entity)
    {
        base.Link(entity);

        foreach (var skin in playerSkins)
        {
            skin.enabled = false;
        }
        if (entity.hasFlatmateId)
        {
            playerSkins[entity.flatmateId.value % 4].enabled = true;
        }
        else
        {
            playerSkins[rng.Next(playerSkins.Count)].enabled = true;
        }

        entity.AddCurrentRoomListener(this);
        if (entity.hasCurrentRoom) this.OnCurrentRoom(entity, entity.currentRoom.roomId);
    }

    public void OnActiveAction(CoreEntity entity, Action value)
    {
        if (entity.hasActiveAction && entity.hasCurrentRoom)
        {
            this.OnCurrentRoom(entity, entity.currentRoom.roomId);
        }
    }

    public void OnCurrentRoom(CoreEntity entity, int roomId)
    {
        switch (roomId)
        {
            case 0: // Living room
                if (entity.hasActiveAction && entity.activeAction.value == Action.HAVE_A_PARTY)
                {
                    transform.position = new Vector2(5.02f, 2.67f);
                }
                else if (entity.hasActiveAction && entity.activeAction.value == Action.WATCH_TV)
                {
                    transform.position = new Vector2(6.82f, 0.31f);
                }
                else
                {
                    transform.position = new Vector2(6.82f, 2f);
                }
                break;
            case 1: // Kitchen
                if (entity.hasActiveAction && entity.activeAction.value == Action.DO_THE_DISHES)
                {
                    transform.position = new Vector2(1.92f, 3.87f);
                }
                else if (entity.hasActiveAction && entity.activeAction.value == Action.EAT)
                {
                    transform.position = new Vector2(3.8f, 0.5f);
                }
                else
                {
                    transform.position = new Vector2(3f, 3f);
                }
                break;

            case 2: // Bathroom
                if (entity.hasActiveAction && entity.activeAction.value == Action.GO_TO_TOILET)
                {
                    transform.position = new Vector2(0.2f, -4.2f);
                }
                else if (entity.hasActiveAction && entity.activeAction.value == Action.SHOWER)
                {
                    transform.position = new Vector2(0.2f, -3f);
                }
                else
                {
                    transform.position = new Vector2(-1.5f, -3f);
                }

                break;
            default:
                transform.position = new Vector2(0f, 0f);
                break;
        }
    }
}
