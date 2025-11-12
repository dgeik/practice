using System.IO;
using UnityEngine;

public class Ammo : Item
{
    private void Awake()
    {
        nameItem = "Ammo";
        _maxItemsToPickUp = Random.Range(4,8);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp((float)Random.Range(3,_maxItemsToPickUp));
        }
    }
}
