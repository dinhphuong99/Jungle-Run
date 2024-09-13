// File: Assets/Scripts/CoinDisplay.cs
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    public TMP_Text textCoinInLevel; // Hiển thị số coin trong màn chơi
    public TMP_Text textAllCoin; // Hiển thị tổng số coin

    // Cập nhật số lượng coin của màn chơi hiện tại
    public void UpdateLevelCoinDisplay(int coinsCollectedInLevel)
    {
        if (textCoinInLevel != null)
        {
            textCoinInLevel.text = coinsCollectedInLevel.ToString();
        }
    }

    // Cập nhật tổng số lượng coin
    public void UpdateTotalCoinDisplay(int totalCoins)
    {
        if (textAllCoin != null)
        {
            textAllCoin.text = totalCoins.ToString();
        }
    }
}
