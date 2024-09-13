using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyRebindManager : MonoBehaviour
{
    // Các TextMeshPro UI để hiển thị phím điều khiển
    public TMP_Text pauseKeyText;
    public TMP_Text moveLeftKeyText;
    public TMP_Text moveRightKeyText;
    public TMP_Text jumpKeyText;
    public TMP_Text crouchKeyText;

    [HideInInspector] public bool isPause = false;
    [HideInInspector] public bool isMoveLeft = false;
    [HideInInspector] public bool isMoveRight = false;
    [HideInInspector] public bool isJump = false;
    [HideInInspector] public bool isCrouch = false;

    private static Dictionary<string, KeyCode> keyBindings = new Dictionary<string, KeyCode>();
    private string keyToRebind;

    void Start()
    {
        // Thiết lập các key ban đầu
        keyBindings["Pause"] = KeyCode.Escape;
        keyBindings["MoveLeft"] = KeyCode.A;
        keyBindings["MoveRight"] = KeyCode.D;
        keyBindings["Jump"] = KeyCode.W;
        keyBindings["Crouch"] = KeyCode.S;

        // Kiểm tra xem tất cả các biến TMP_Text có được gán hay không
        if (pauseKeyText != null &&
            moveLeftKeyText != null &&
            moveRightKeyText != null &&
            jumpKeyText != null &&
            crouchKeyText != null)
        {
            UpdateUI();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(keyBindings["Pause"]))
        {
            isPause = true;
        }
        else
        {
            isPause = false;
        }

        if (Input.GetKey(keyBindings["MoveLeft"]))
        {
            isMoveLeft = true;
        }
        else
        {
            isMoveLeft = false;
        }

        if (Input.GetKey(keyBindings["MoveRight"]))
        {
            isMoveRight = true;
        }
        else
        {
            isMoveRight = false;
        }

        if (Input.GetKeyDown(keyBindings["Jump"]))
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }

        if (Input.GetKey(keyBindings["Crouch"]))
        {
            isCrouch = true;
        }
        else
        {
            isCrouch = false;
        }

        // Chờ người dùng nhập phím mới
        if (!string.IsNullOrEmpty(keyToRebind))
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    RebindKey(keyToRebind, key);
                    keyToRebind = null;
                    break;
                }
            }
        }
    }

    public void RebindKey(string action, KeyCode newKey)
    {
        if (keyBindings.ContainsKey(action))
        {
            keyBindings[action] = newKey;
            UpdateUI();
        }
    }

    public void StartRebinding(string action)
    {
        keyToRebind = action;
        GetTextForKey(action).text = "Press any key...";
    }

    private TMP_Text GetTextForKey(string action)
    {
        switch (action)
        {
            case "Pause": return pauseKeyText;
            case "MoveLeft": return moveLeftKeyText;
            case "MoveRight": return moveRightKeyText;
            case "Jump": return jumpKeyText;
            case "Crouch": return crouchKeyText;
            default: return null;
        }
    }

    private void UpdateUI()
    {
        // Cập nhật UI để hiển thị key hiện tại
        pauseKeyText.text = keyBindings["Pause"].ToString();
        moveLeftKeyText.text = keyBindings["MoveLeft"].ToString();
        moveRightKeyText.text = keyBindings["MoveRight"].ToString();
        jumpKeyText.text = keyBindings["Jump"].ToString();
        crouchKeyText.text = keyBindings["Crouch"].ToString();
    }
}
