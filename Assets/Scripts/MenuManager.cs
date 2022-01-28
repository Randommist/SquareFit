using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text PlayerName;
    public Text PlayerScore;
    public Text PlayerEnergy;
    void Start()
    {
        if (PlayerData.CheckFirstStart())
            PlayerData.SetEnergy(100);

        if (PlayerData.GetName() == "")
            PlayerData.SetName("Player" + Random.Range(1000, 9999).ToString());

        if (PlayerName != null)
            PlayerName.text = PlayerData.GetName();
        if (PlayerScore != null)
            PlayerScore.text = PlayerData.GetScore().ToString();
        if (PlayerEnergy != null)
            PlayerEnergy.text = PlayerData.GetEnergy().ToString();

    }

}
