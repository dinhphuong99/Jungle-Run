using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    public TMP_Text unlockPriceText;
    public TMP_Text activityButtonText;
    public GameObject buttonObject;

    private Button activityButton;

    void Start()
    {
        activityButton = buttonObject.GetComponentInChildren<Button>();
    }

    public void UpdateUI(CharacterAttributes currentCharacter, bool isCharacterUnlocked, int indexSelectedPrevious)
    {
        buttonObject.SetActive(indexSelectedPrevious != CharacterManager.indexSelected);

        if (!isCharacterUnlocked)
        {
            unlockPriceText.enabled = true;
            unlockPriceText.text = currentCharacter.coinUnlock.ToString();
            SetButtonState(Color.red, "Unlock");
        }
        else
        {
            unlockPriceText.enabled = false;
            SetButtonState(Color.green, "Select");
        }
    }

    private void SetButtonState(Color normalColor, string buttonText)
    {
        activityButtonText.text = buttonText;
        activityButton.colors = new ColorBlock
        {
            normalColor = normalColor,
            highlightedColor = Color.yellow,
            pressedColor = Color.white,
            colorMultiplier = activityButton.colors.colorMultiplier,
            fadeDuration = activityButton.colors.fadeDuration
        };
    }
}
