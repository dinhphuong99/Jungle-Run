using UnityEngine;

public class CharacterManagerController : MonoBehaviour
{
    public CharacterManager characterManager;
    public int indexSelectedPrevious = CharacterManager.indexSelected;

    private void Start()
    {
        ReplaceChildrenWithPrefab(gameObject, characterManager.characters[CharacterManager.indexSelected]);
    }

    public void LeftRightButtonHandle(bool direct)
    {
        CharacterManager.indexSelected = (CharacterManager.indexSelected + (direct ? 1 : -1)
            + characterManager.characters.Length) % characterManager.characters.Length;
        ReplaceChildrenWithPrefab(gameObject, characterManager.characters[CharacterManager.indexSelected]);
    }

    public void UnlockOrSelect(CharacterAttributes selectedCharacter)
    {
        bool isUnlocked = characterManager.UnlockCharacter(selectedCharacter);
        bool isSelected = characterManager.SelectCharacter(selectedCharacter.KeyCharacter);

        if (isUnlocked || isSelected)
        {
            indexSelectedPrevious = CharacterManager.indexSelected;
        }
    }

    private void ReplaceChildrenWithPrefab(GameObject parent, GameObject child)
    {
        foreach (Transform obj in parent.transform)
        {
            GameObject.DestroyImmediate(obj.gameObject);
        }
        Instantiate(child, parent.transform);
    }
}