using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public CharacterUIManager uiManager;
    public CharacterManagerController managerController;
    public GameManager gameManager;

    void Start()
    {
        Invoke(nameof(UpdateSelectionUI), 0.5f);
    }

    public void UpdateSelectionUI()
    {
        var currentCharacter = managerController.characterManager.characterAttributes[CharacterManager.indexSelected];
        bool isCharacterUnlocked = gameManager.GameService.GameData.UnlockedCharacters.Contains(currentCharacter.KeyCharacter);

        uiManager.UpdateUI(currentCharacter, isCharacterUnlocked, managerController.indexSelectedPrevious);
    }

    public void HandleUnlockOrSelect()
    {
        var selectedCharacter = managerController.characterManager.characterAttributes[CharacterManager.indexSelected];
        managerController.UnlockOrSelect(selectedCharacter);
        UpdateSelectionUI();
    }

    public void HandleLeftRightButton(bool direct)
    {
        managerController.LeftRightButtonHandle(direct);
        UpdateSelectionUI();
    }
}
