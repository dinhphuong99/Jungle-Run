// File: Assets/Scripts/IDataManager.cs
public interface IDataManager
{
    void SaveData(GameData data);
    GameData LoadData();
}