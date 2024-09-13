using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private GameService gameService;
    public GameService GameService // Thêm thuộc tính công khai để truy cập gameService
    {
        get { return gameService; }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        IDataManager dataManager = new FileDataManager();
        gameService = new GameService(dataManager);
    }

    public void AddCoin(int amount)
    {
        gameService.AddCoin(amount);
    }

    public void UnlockCharacter(string characterKey)
    {
        gameService.UnlockCharacter(characterKey);
    }
}