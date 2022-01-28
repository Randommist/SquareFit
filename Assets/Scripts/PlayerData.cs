using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static bool CheckFirstStart()
    {
        if (PlayerPrefs.GetInt("firstStart") > 0)
        {
            return false;
        }
        else
        {
            PlayerPrefs.SetInt("firstStart", 1);
            return true;
        }
    }
    public static void SetScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }

    public static void SetName(string name)
    {
        PlayerPrefs.SetString("playerName", name);
    }

    public static void SetEnergy(int num)
    {
        PlayerPrefs.SetInt("energy", num);
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("score");
    }
    public static string GetName()
    {
        return PlayerPrefs.GetString("playerName");
    }

    public static int GetEnergy()
    {
        return PlayerPrefs.GetInt("energy");
    }
}
