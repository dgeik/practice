using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class PlayerData
{
    public static float hp = 5f;
    public static float maxHp = 5f;
    public static float damage = 1f;
    public static Inventory inventory = new Inventory();

    public static void Save()
    {
        var data = new PlayerSaveData
        {
            SaveHp = hp,
            SaveMaxHp = maxHp,
            SaveDamage = damage,
            SaveInventory = inventory
        };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetPath(), json);
    }

    public static void Load()
    {
        if (File.Exists(GetPath()))
        {
            string json = File.ReadAllText(GetPath());
            var data = JsonUtility.FromJson<PlayerSaveData>(json);
            hp = data.SaveHp;
            maxHp = data.SaveMaxHp;
            damage = data.SaveDamage;
            inventory = data.SaveInventory;
        }
    }
    private static string GetPath() => Application.persistentDataPath + "/player.json";
}


public class PlayerSaveData
{
    public float SaveHp;
    public float SaveMaxHp;
    public float SaveDamage;
    public Inventory SaveInventory;
}
