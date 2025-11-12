using UnityEngine;

public class Weapon : Item
{
    public float damage;
    private void Awake()
    {
        _maxItemsToPickUp = 1;
    }
}
