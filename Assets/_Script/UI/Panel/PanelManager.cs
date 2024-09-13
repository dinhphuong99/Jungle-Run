using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // Mảng chứa các panel cần quản lý
    public GameObject[] panels;

    // Hàm mở một panel theo tên
    public void OpenPanel(string panelName)
    {
        foreach (GameObject panel in panels)
        {
            if (panel.name.Equals(panelName))
            {
                panel.SetActive(true);  // Mở panel
            }
            else
            {
                panel.SetActive(false); // Đóng các panel khác
            }
        }
    }

    // Hàm đóng toàn bộ các panel
    public void CloseAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    // Hàm toggle đóng mở một panel
    public void TogglePanel(string panelName)
    {
        foreach (GameObject panel in panels)
        {
            if (panel.name.Equals(panelName))
            {
                panel.SetActive(!panel.activeSelf); // Đổi trạng thái mở/đóng của panel
            }
        }
    }
}
