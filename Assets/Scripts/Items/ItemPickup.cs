using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Items itemDrop;

    private void Start()
    {
        item = AssignItem(itemDrop);
    }

    public void AddItem(Player player)
    {
        foreach (ItemList i in player.itemsList)
        {
            if (i.name == item.GiveName())
            {
                i.stacks += 1;
                return;
            }
        }
        player.itemsList.Add(new ItemList(item, item.GiveName(), 1));
    }

    public Item AssignItem(Items itemToAssign)
    {
        switch (itemToAssign)
        {
            case Items.HealingItem:
                return new HealingItem();
            case Items.MoveSpeedItem:
                return new MoveSpeedItem();
            case Items.IncreaseJumpItem:
                return new IncreaseJumpItem();
            default:
                return new HealingItem(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            AddItem(player);
            player.CallItemOnPickup();
            Destroy(this.gameObject);
        }
    }
}

public enum Items
{
    HealingItem,
    MoveSpeedItem,
    IncreaseJumpItem
}
