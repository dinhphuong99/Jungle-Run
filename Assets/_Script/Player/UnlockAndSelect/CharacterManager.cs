using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public string defaultCharacterKey = "Brian";
    public GameObject[] characters;
    public CharacterAttributes[] characterAttributes;

    private GameService gameService;
    public static int indexSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Tự động lấy các component CharacterAttributes từ các GameObject
        InitializeCharacterAttributes();

        PlayerPrefs.SetString("selectKeyCharacter", defaultCharacterKey);

        gameService = GameManager.Instance.GameService;

        // Đảm bảo nhân vật mặc định đã được mở khóa
        CharacterAttributes defaultCharacter = GetCharacterAttributes(defaultCharacterKey);
        if (defaultCharacter != null && !gameService.GameData.UnlockedCharacters.Contains(defaultCharacterKey))
        {
            UnlockCharacter(defaultCharacter); // Mở khóa không cần trừ tiền cho nhân vật mặc định
        }

        SelectCharacter(defaultCharacterKey); // Chọn nhân vật mặc định
    }

    // Hàm tự động lấy các component CharacterAttributes từ các GameObject trong mảng characters
    private void InitializeCharacterAttributes()
    {
        characterAttributes = new CharacterAttributes[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            characterAttributes[i] = characters[i].GetComponent<CharacterAttributes>();
            if (characterAttributes[i] == null)
            {
                Debug.LogError($"GameObject {characters[i].name} không có component CharacterAttributes.");
            }
        }
    }

    public bool UnlockCharacter(CharacterAttributes character)
    {
        if (character == null) return false;

        if (gameService.GameData.CoinCount >= character.coinUnlock)
        {
            gameService.GameData.CoinCount -= (int)character.coinUnlock;
            gameService.UnlockCharacter(character.KeyCharacter);
            character.unlock = true; // Đặt unlock = true
            SelectCharacter(character.KeyCharacter);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool SelectCharacter(string characterKey)
    {
        if (gameService.GameData.UnlockedCharacters.Contains(characterKey))
        {
            PlayerPrefs.SetString("selectKeyCharacter", characterKey); // Chọn đúng nhân vật theo key được cung cấp
            UpdateIndexSelected(characterKey);
            return true;
        }
        else
        {
            return false;
        }
    }

    private CharacterAttributes GetCharacterAttributes(string characterKey)
    {
        foreach (var character in characterAttributes)
        {
            if (character.KeyCharacter == characterKey)
            {
                return character;
            }
        }
        return null;
    }

    private void UpdateIndexSelected(string characterKey)
    {
        for (int i = 0; i < characterAttributes.Length; i++)
        {
            if (characterAttributes[i].KeyCharacter.Equals(characterKey))
            {
                indexSelected = i;
                break;
            }
        }
    }
}