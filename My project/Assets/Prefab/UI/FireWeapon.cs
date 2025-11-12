using Unity.VisualScripting;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public void FireWeaponClick()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getNearestEnemy;
        if (PlayerData.inventory.GetItem("Ammo") != null && enemy != null)
        {
            PlayerData.inventory.Remove(PlayerData.inventory.GetItem("Ammo").item, 1f);
            enemy.GetComponent<Enemy>().TakeDamage(PlayerData.damage);
        }
    }
}
