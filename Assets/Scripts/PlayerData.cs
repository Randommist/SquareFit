using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static void SetScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }

    public static void SetName(string name)
    {
        PlayerPrefs.SetString("playerName", name);
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("score");
    }
    public static string GetName()
    {
        return PlayerPrefs.GetString("playerName");
    }
}
