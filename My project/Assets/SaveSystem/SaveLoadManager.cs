using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveLoadManager
{
    public static void SaveGame()
    {
        PlayerData.Save();
    }

    public static void LoadGame()
    {
        PlayerData.Load();
    }
}
