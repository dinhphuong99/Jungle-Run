using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Public array of character prefabs

    private void Start()
    {
        // Thêm và thiết lập các gameObject con
        AddAndSetUpCharacters();
    }

    // Xóa tất cả các gameObject con hiện tại và thêm các gameObject mới từ characterPrefabs
    private void AddAndSetUpCharacters()
    {
        // Xóa tất cả các gameObject con hiện tại
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Thêm các gameObject mới từ characterPrefabs
        foreach (GameObject characterPrefab in characterPrefabs)
        {
            CharacterAttributes attributes = characterPrefab.GetComponent<CharacterAttributes>();

            if (attributes != null)
            {
                // Đặt giá trị KeyCharacter cho các gameObject con
                if (attributes.KeyCharacter.Equals(PlayerPrefs.GetString("selectKeyCharacter")))
                {
                    // Instantiate prefab
                    GameObject instantiatedPrefab = Instantiate(characterPrefab);

                    // Đặt prefab mới tạo làm con của parentObject
                    instantiatedPrefab.transform.SetParent(transform);
                    break;
                }
            }
        }
    }

    // Lấy CharacterAttributes từ các prefab
    private CharacterAttributes GetCharacterAttributes(string characterKey)
    {
        foreach (var characterPrefab in characterPrefabs)
        {
            CharacterAttributes attributes = characterPrefab.GetComponent<CharacterAttributes>();
            if (attributes != null && attributes.KeyCharacter.Equals(characterKey))
            {
                return attributes;
            }
        }
        return null;
    }
}
