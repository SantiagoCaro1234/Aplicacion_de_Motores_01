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

    private void Update()
    {

    }

    IEnumerator CallItemUpdate()
    {
        foreach (ItemList i in itemsList)
        {
            i.item.Update(this, i.stacks);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }

    protected override void Die()
    {
        print("Moriste");
    }
}
