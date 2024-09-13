// File: Assets/Scripts/CoinCollector.cs
using UnityEngine;

public class CoinCollector : MonoBehaviour, ICoinCollector
{
    private CoinManager coinManager;
    private CoinDisplay coinDisplay;
    private int coinPrevious = 0;

    private void Start()
    {
        coinManager = new CoinManager();
        coinDisplay = GetComponent<CoinDisplay>();
        coinPrevious = coinManager.GetTotalCoins();
    }

    private void Update()
    {
        if (!PauseButton.pause)
        {
            coinDisplay.UpdateLevelCoinDisplay(coinManager.CoinsCollectedInLevel);
        }

        coinDisplay.UpdateTotalCoinDisplay(coinManager.GetTotalCoins());
    }

    // Triển khai phương thức CollectCoin từ ICoinCollector
    public void CollectCoin()
    {
        coinManager.AddCoin();
        coinDisplay.UpdateLevelCoinDisplay(coinManager.CoinsCollectedInLevel);
    }

    // Triển khai phương thức EndLevel từ ICoinCollector
    public void EndLevel()
    {
        coinManager.AddLevelCoinsToTotal();
        coinManager.ResetLevelCoins();
        coinDisplay.UpdateTotalCoinDisplay(coinManager.GetTotalCoins());
    }
}
