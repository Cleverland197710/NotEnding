using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;


public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update void Start()
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }
    
    public void IncreaseCoins(int v)
    {
        currentCoins = (currentCoins + v);
        coinText.text = "COINS: " + currentCoins.ToString();
    }
    
}