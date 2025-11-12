using UnityEngine;

public class Armory : Item
{
    public float defence;
    private void Awake()
    {
        _maxItemsToPickUp = 1;
    }
}
