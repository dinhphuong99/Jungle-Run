// File: Assets/Scripts/GameData.cs
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int CoinCount;
    public List<string> UnlockedCharacters;

    public GameData()
    {
        CoinCount = 0;
        UnlockedCharacters = new List<string>();
    }
}