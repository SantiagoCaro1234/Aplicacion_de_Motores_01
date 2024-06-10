using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public abstract class Item 
{
    public abstract string GiveName();

    public virtual void Update(Player player, int stacks)
    {

    }
}

public class HealingItem : Item
{
    public override string GiveName()
    {
        return "Healing Item";
    }

    public override void Update(Player player, int stacks)
    {
        player._currentHealth += 3 + (2 * stacks);
    }
}
