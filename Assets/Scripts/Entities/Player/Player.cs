using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public List<ItemList> itemsList = new List<ItemList>();
    public delegate void OnPlayerDead();
    public static OnPlayerDead onPlayerDeath;


    private void Awake()
    {
        onPlayerDeath = null;
        _currentHealth = 100f;
    }

    private void Start()
    {
        StartCoroutine(CallItemUpdate());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            DelegateUtils.ListSubscribedMethods(onPlayerDeath);
        }
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

    public override void Die()
    {
        onPlayerDeath?.Invoke();
    }
}
