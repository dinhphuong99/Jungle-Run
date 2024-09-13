// File: Assets/Scripts/GameService.cs
using UnityEngine;

public class GameService
{
    private readonly IDataManager dataManager;
    public GameData GameData { get; private set; }

    public GameService(IDataManager dataManager)
    {
        this.dataManager = dataManager;
        GameData = dataManager.LoadData();
    }

    public void AddCoin(int amount)
    {
        GameData.CoinCount += amount;
        dataManager.SaveData(GameData);
    }

    public void UnlockCharacter(string characterKey)
    {
        if (!GameData.UnlockedCharacters.Contains(characterKey))
        {
            GameData.UnlockedCharacters.Add(characterKey);
            dataManager.SaveData(GameData);
        }
    }
}