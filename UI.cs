using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text coinText;
    void Update()
    {
        DisplayCoinText(); //อัพเดทให้แสดง
    }

    private void DisplayCoinText()
    {
        coinText.text = " : " + GameManager.Instance.coin.ToString(); //ตัวสั่งให้แสดง CoinText โดยเชื่อมต่อกับGameManager
    }
    
}