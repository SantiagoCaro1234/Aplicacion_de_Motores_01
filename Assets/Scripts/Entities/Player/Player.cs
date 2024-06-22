using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public List<ItemList> itemsList = new List<ItemList>();

    private void Start()
    {
        StartCoroutine(CallItemUpdate());
    }

    private void Awake()
    {
        _currentHealth = 100f;
    }

    IEnumerator CallItemUpdate()
    {
        foreach (ItemList i in itemsList)
        {
            i.item.Update(this, i.stacks);
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(CallItemUpdate());
    }

    public void CallItemOnPickup()
    {
        foreach (ItemList i in itemsList)
        {
            i.item.OnPickup(this, i.stacks);
        }
    }

    protected override void Die()
    {
        print("Moriste");
    }
}
