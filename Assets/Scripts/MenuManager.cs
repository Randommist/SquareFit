using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text PlayerName;
    public Text PlayerScore;
    void Start()
    {
        if (PlayerData.GetName() == "")
            PlayerData.SetName("Player" + Random.Range(1000, 9999).ToString());

        PlayerName.text = PlayerData.GetName();
        PlayerScore.text = PlayerData.GetScore().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
