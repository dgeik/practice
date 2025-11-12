using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected int _maxItemsToPickUp;
    public Sprite iconItem;
    public string nameItem;
    public void PickUp(float count)
    {
        if (PlayerData.inventory.Add(this, count))
        {
            Destroy(gameObject);
        }
        
    }
}
