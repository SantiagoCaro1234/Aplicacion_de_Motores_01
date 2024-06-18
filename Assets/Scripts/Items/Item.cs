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

    public virtual void OnPickup(Player player, int stacks)
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

public class MoveSpeedItem : Item
{
    public override string GiveName()
    {
        return "MoveSpeedItem";
    }

    public override void OnPickup(Player player, int stacks)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        if (stacks <= 1)
        {
            movement.IncreaseMoveSpeed(10);
        }
    }
}

public class IncreaseJumpItem : Item
{
    public override string GiveName()
    {
        return "IncreaseJumpItem";
    }

    public override void OnPickup(Player player, int stacks)
    {
        CharacterController2D jump = player.GetComponent<CharacterController2D>();

        if (stacks <= 1)
        {
            jump.IncreaseJumpForce(100);
        }
    }
}
