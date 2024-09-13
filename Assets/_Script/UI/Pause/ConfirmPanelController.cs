using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmPanelController : HandleSceneManager
{
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private TMP_Text confirmText;
    [SerializeField] private string startSceneName;
    [HideInInspector] public string activity;

    // Hàm để kích hoạt confirmPanel và thay đổi text
    public void ShowConfirmPanel(string message)
    {
        // Cập nhật nội dung của confirmText
        confirmText.text = message;

        // Kích hoạt confirmPanel
        confirmPanel.SetActive(true);
    }

    // Hàm để ẩn confirmPanel (tuỳ chọn nếu bạn cần)
    public void HideConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }

    public void SetActivity(string activity)
    {
        this.activity = activity;
    }

    public void HandleButtonConfirm()
    {
        Time.timeScale = 1f;
        if (activity.Equals("Restart"))
        {
            RestartScene();
        }
        else if (activity.Equals("Go home"))
        {
            OpenNewScene(startSceneName);
        }
    }
}
