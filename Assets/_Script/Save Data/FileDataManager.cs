using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataManager : IDataManager
{
    private readonly string dataFilePath;

    public FileDataManager()
    {
        // Kiểm tra xem game có đang chạy trong Unity Editor hay đã build
#if UNITY_EDITOR
        // Nếu đang chạy trong Unity Editor, lưu file vào thư mục Assets/Save
        string saveFolderPath = Path.Combine(Application.dataPath, "Save");
#else
            // Nếu đã build, lưu file vào thư mục Save bên ngoài (thư mục chứa game)
            string saveFolderPath = Path.Combine(Application.persistentDataPath, "Save");
#endif

        // Tạo thư mục Save nếu chưa tồn tại
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }

        // Đường dẫn đầy đủ tới file gamedata.json
        dataFilePath = Path.Combine(saveFolderPath, "gamedata.json");
    }

    public void SaveData(GameData data)
    {
        if (data == null)
        {
            Debug.LogError("GameData is null, cannot save.");
            return;
        }
        string json = JsonUtility.ToJson(data, true);

        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError("Serialized GameData is empty, something went wrong.");
            return;
        }

        File.WriteAllText(dataFilePath, json);
    }

    public GameData LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            string json = File.ReadAllText(dataFilePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.LogWarning("Game data file not found, returning default data.");
            return new GameData
            {
                CoinCount = 0, // Khởi tạo số lượng coin mặc định
                UnlockedCharacters = new List<string>() // Khởi tạo danh sách rỗng
            };
        }
    }

}
