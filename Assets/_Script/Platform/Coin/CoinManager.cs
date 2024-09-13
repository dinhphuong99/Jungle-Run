// File: Assets/Scripts/CoinManager.cs
public class CoinManager
{
    public int coinsCollectedInLevel = 0;

    public int CoinsCollectedInLevel
    {
        get { return coinsCollectedInLevel; }
    }

    // Thêm coin trong màn chơi
    public void AddCoin()
    {
        coinsCollectedInLevel++;
    }

    // Reset số lượng coin của màn chơi hiện tại
    public void ResetLevelCoins()
    {
        coinsCollectedInLevel = 0;
    }

    // Lấy tổng số coin đã thu thập từ GameManager
    public int GetTotalCoins()
    {
        return GameManager.Instance.GameService.GameData.CoinCount;
    }

    // Cộng số coin của màn chơi vào tổng số coin
    public void AddLevelCoinsToTotal()
    {
        GameManager.Instance.AddCoin(coinsCollectedInLevel);
    }
}
